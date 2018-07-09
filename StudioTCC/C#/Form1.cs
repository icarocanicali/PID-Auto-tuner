using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace TCC
{
    public partial class Form1 : Form
    {
        private string aux1; //Variável para escrever os dados enviados a cada 250ms do Arduino 
        private Dictionary<string, string> DicArduino; //Dicionário para receber os dados do Arduino
        private int tamgra = 30000; //Variável tamanho do gráfico
        private double inicio, GYmax = 4200, GYmin = 0; //Variável início do gráfico, Ymax, Ymin
        double CCKp = 0, CCKi = 0, CCKd = 0, ZNKp = 0, ZNKi = 0, ZNKd = 0, AHKp = 0, AHKi = 0, AHKd = 0;
        bool f1 = false, f2 = false, f3 = false, f4 = false;


        public Form1()
        {
            InitializeComponent(); //Inicializa a aplicação
            portaseriallista.Items.AddRange(SerialPort.GetPortNames()); //Adiciona portas seriais 
        }

        private void BTAtualizar_Click(object sender, EventArgs e)
        {
            portaseriallista.Items.Clear(); //Apaga a lista de portas seriais
            portaseriallista.Items.AddRange(SerialPort.GetPortNames()); //Adiciona portas seriais
        }

        private void BTConectar_Click(object sender, EventArgs e)
        {
            if (BTConectar.Text == "Conectar") //Verifica o botão de conectar
            {
                if (portaseriallista.Text == "Porta Serial") //Verifica se tem alguma porta serial selecionada
                    MessageBox.Show("Informe a Porta Serial", "", MessageBoxButtons.OK, MessageBoxIcon.Information); //Caso não haja porta serial selecionada envia mensagem na tela       
                else
                {
                    serialPortTCC.PortName = portaseriallista.Text; //Informa qual o portname a ser utilizado
                    serialPortTCC.BaudRate = (int)TaxaTransferencia.Value;//Informa qual o baldrate a ser utilizado
                    try
                    {
                        serialPortTCC.Open(); //Abre a porta serial iniciando a conexão
                        serialPortTCC.DataReceived += new SerialDataReceivedEventHandler(dadosArduino); //Adiciona a função que trata eventos(receber dados via porta serial)
                        TBRecebeArduino.Text = ""; //Limpa a caixa de texto que escreve os dados do Arduino
                        BTConectar.Text = "Desconectar"; //Muda o nome do botão para desconectar
                        serialPortTCC.WriteLine("IN=0");
                        serialPortTCC.WriteLine("FL=0");
                        NSetpoint.Enabled = true;
                        NSO.Enabled = true;
                        NKp.Enabled = true;
                        NKi.Enabled = true;
                        NKd.Enabled = true;
                        NAmplitudeRele.Enabled = true;
                        NHisterese.Enabled = true;
                        RB1.Enabled = true;
                        RB2.Enabled = true;
                        RB3.Enabled = true;
                        RBPID.Enabled = true;
                        RBAberta.Enabled = true;
                        //RBRele.Enabled = true;
                        BTEnviar.Enabled = true;
                        BTGrafico.Enabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("Houve erro na conexão, tente novamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); //Escreve mensagem na tela caso haja erro de conexão 
                        BTConectar.Text = "Conectar"; //Permite tentar conectar novamente alterando o nome do botão
                    }
                }
            }
            else
            {
                serialPortTCC.Close(); //Fecha a porta serial (desconecta)
                BTConectar.Text = "Conectar"; //Permite tentar conectar novamente alterando o nome do botão
                //Proibindo alterar o valor de algumas variáveis (evita travar o programa)
                NSetpoint.Enabled = false;
                NSO.Enabled = false;
                NKp.Enabled = false;
                NKi.Enabled = false;
                NKd.Enabled = false;
                NAmplitudeRele.Enabled = false;
                NHisterese.Enabled = false;
                RB1.Enabled = false;
                RB2.Enabled = false;
                RB3.Enabled = false;
                RBPID.Enabled = false;
                RBAberta.Enabled = false;
                RBRele.Enabled = false;
                BTEnviar.Enabled = false;
                BTGrafico.Enabled = false;
            }
        }

        private void dadosArduino(object sender, SerialDataReceivedEventArgs e)
        {
            aux1 = serialPortTCC.ReadLine();
            if (aux1 != null)
            {
                try
                {
                    DicArduino = aux1.Split(',').ToDictionary(x => x.Split('=')[0], x => (x.Split('=').Length > 1 ? x.Split('=')[1] : "")); //Escrevendo os dados no dicionario separando por nome de entrada(key) e valor(value), armazena no formato string                       
                    if (DicArduino.Keys.Contains("RL") && DicArduino.Keys.Contains("estab"))
                    {
                        f1 = true;
                        if (DicArduino["RL"] == "1")
                        {
                            Invoke(new EventHandler(RestricaoRele));
                        }
                        else if (DicArduino["RL"] == "0")
                        {
                            Invoke(new EventHandler(PermissaoRele));
                            if ((DicArduino["estab"] == "estavel") && RBRele.Enabled == false) Invoke(new EventHandler(EstabilidadeRele)); //Libera a lógica relé caso o sistema esteja estável
                            else if ((DicArduino["estab"] == "instavel") && RBRele.Enabled == true) Invoke(new EventHandler(EstabilidadeRele)); //Trava a lógica relé caso o sistema esteja instável
                        }
                    }
                    if (DicArduino.Keys.Contains("ret_rele") && DicArduino.Keys.Contains("TON") && DicArduino.Keys.Contains("TOFF") && DicArduino.Keys.Contains("d") && DicArduino.Keys.Contains("his") && DicArduino.Keys.Contains("MediaAu") && DicArduino.Keys.Contains("MediaAd") && DicArduino.Keys.Contains("k")) //Verifica se os dados vindos do Arduino contém ret_rele
                    { //Calcula os parametros do controlador PID
                        f2 = true;
                        Invoke(new EventHandler(malha));
                        Invoke(new EventHandler(update_dados)); //Função que atualiza as informações na tela do programa e inicia a lógica PID
                    }
                    if (DicArduino.Keys.Contains("SO") && DicArduino.Keys.Contains("SP") && DicArduino.Keys.Contains("d") && DicArduino.Keys.Contains("his") && DicArduino.Keys.Contains("MT") && DicArduino.Keys.Contains("PID") && DicArduino.Keys.Contains("Kp") && DicArduino.Keys.Contains("Ki") && DicArduino.Keys.Contains("Kd") && DicArduino.Keys.Contains("RG"))
                    {
                        f2 = true;
                        Invoke(new EventHandler(Inicializacao));
                    }
                    if (BTGrafico.Text == "Reset BD" && DicArduino.Keys.Contains("ms") && DicArduino.Keys.Contains("VP") && DicArduino.Keys.Contains("OUT"))  //Verifica o botão e se os dados vindos do Arduino contém ms VP OUT
                    {
                        f3 = true;
                        DataRow row = databaseTCCDataSet1.TabelaDados.NewRow(); //Gera uma nova linha no banco de dados
                        row["ms"] = Convert.ToUInt32(DicArduino["ms"]); //Adiciona o tempo recebido do Arduino
                        row["INP"] = Convert.ToDouble(DicArduino["VP"]); //Adiciona o VP recebido do Arduino
                                                                         //row["SP"] = Convert.ToDouble(DicArduino["SP"]); //Adiciona o SP recebido do Arduino
                        row["OUT"] = Convert.ToDouble(DicArduino["OUT"]); //Adicionado o valor da saida recebido do Arduino                        
                        databaseTCCDataSet1.TabelaDados.Rows.Add(row); //Inseri a linha gerada na tabela
                        Invoke(new EventHandler(AtualizacaoGrafico)); //Chama função para alterar os dados do chart
                    }
                    else if (BTGrafico.Text == "Plotar" && DicArduino.Keys.Contains("VP") && DicArduino.Keys.Contains("OUT"))  //Verificao botão e se os dados vindos do Arduino contém VP OUT
                    {
                        f3 = true;
                        Invoke(new EventHandler(AtualizaVPOUT)); //Chama função para alterar os dados do chart
                    }
                    else
                    {
                        aux1 += "\rponto nao plotado\r"; //Informando que não conseguiu plotar o ponto
                        f3 = false;
                    }
                }
                catch
                {
                    aux1 += "\rerro de leitura\r"; //Informando que houve erro na leitura de dados do Arduino   
                }
                f4 = true;
                Invoke(new EventHandler(RecebeArduino)); //Função para escrever o aux1 na tela do programa
                while (f1 || f2 || f3 || f4)
                {
                    continue;
                }
                serialPortTCC.WriteLine("FL=0");
                aux1 = "";
            }
        }

        private void malha(object sender, EventArgs e)
        {
            RBRele.Checked = false;
            RBPID.Checked = false;
            RBAberta.Checked = true;
        }

        private void update_dados(object sender, EventArgs e)
        { //Função que atualiza as informações na tela do programa
            double tal, teta, Ku, mf = 30;
            if (Convert.ToDouble(DicArduino["MediaAu"]) > Convert.ToDouble(DicArduino["his"])) //Lógica para calcular Ku
            {
                Ku = 4 * Convert.ToDouble(DicArduino["d"]) / (Math.PI * Math.Sqrt((Convert.ToDouble(DicArduino["MediaAu"]) * Convert.ToDouble(DicArduino["MediaAu"])) - (Convert.ToDouble(DicArduino["his"]) * Convert.ToDouble(DicArduino["his"]))));
                if ((Ku * Convert.ToDouble(DicArduino["k"]) > 1)) //Lógica para calcular tal
                {
                    if ((Convert.ToDouble(DicArduino["TON"]) + Convert.ToDouble(DicArduino["TOFF"])) > 0) //Lógica para calcular tal e teta
                    {
                        tal = (((Convert.ToDouble(DicArduino["TON"]) + Convert.ToDouble(DicArduino["TOFF"])) / 2 * Math.PI) * Math.Sqrt((Ku * Ku * Convert.ToDouble(DicArduino["k"]) * Convert.ToDouble(DicArduino["k"])) - 1));
                        teta = (((Convert.ToDouble(DicArduino["TON"]) + Convert.ToDouble(DicArduino["TOFF"])) / 2 * Math.PI) * (Math.PI - Math.Atan(tal * 2 * Math.PI / (Convert.ToDouble(DicArduino["TON"]) + Convert.ToDouble(DicArduino["TOFF"])))));
                        //Calculo dos paramentros do PID usando Margem de Fase Astrom Hagglund 
                        AHKp = Ku * Math.Cos(mf);
                        AHKi = AHKp / (((Convert.ToDouble(DicArduino["TON"]) + Convert.ToDouble(DicArduino["TOFF"])) / (4 * Math.PI)) * (Math.Tan(mf) + Math.Sqrt(1 + (Math.Tan(mf) * Math.Tan(mf)))));
                        AHKd = (AHKp * AHKp) / (4 * AHKi);
                        //Calculo dos paramentros do PID usando Ziegler & Nichols
                        ZNKp = 0.6 * Ku;
                        ZNKi = ZNKp / (0.5 * (Convert.ToDouble(DicArduino["TON"]) + Convert.ToDouble(DicArduino["TOFF"])));
                        ZNKd = ZNKp * (0.125 * (Convert.ToDouble(DicArduino["TON"]) + Convert.ToDouble(DicArduino["TOFF"])));
                        //Calculo dos paramentros do PID usando Cohen Coon
                        CCKp = (tal / (teta * Convert.ToDouble(DicArduino["k"]))) * ((4 / 3) + (teta / (4 * tal)));
                        CCKi = CCKp / (teta * ((32 * tal) + (6 * teta))) / ((13 * tal) + (8 * teta));
                        CCKd = CCKp * (4 * tal * teta) / ((11 * tal) + (2 * teta));
                        if (!DicArduino.Keys.Contains("Ku"))
                            DicArduino.Add("Ku", Ku.ToString("0.00"));
                        if (!DicArduino.Keys.Contains("tal"))
                            DicArduino.Add("tal", tal.ToString("0.00"));
                        if (!DicArduino.Keys.Contains("teta"))
                            DicArduino.Add("teta", teta.ToString("0.00"));
                        if (RB1.Checked)
                        {
                            NKp.Value = ZNKp > 1000 ? 1000 : Convert.ToDecimal(ZNKp);
                            NKi.Value = ZNKi > 1000 ? 1000 : Convert.ToDecimal(ZNKi);
                            NKd.Value = ZNKd > 1000 ? 1000 : Convert.ToDecimal(ZNKd);
                        }
                        else if (RB2.Checked)
                        {
                            NKp.Value = AHKp > 1000 ? 1000 : Convert.ToDecimal(AHKp);
                            NKi.Value = AHKi > 1000 ? 1000 : Convert.ToDecimal(AHKi);
                            NKd.Value = AHKd > 1000 ? 1000 : Convert.ToDecimal(AHKd);
                        }
                        else if (RB3.Checked)
                        {
                            NKp.Value = CCKp > 1000 ? 1000 : Convert.ToDecimal(CCKp);
                            NKi.Value = CCKi > 1000 ? 1000 : Convert.ToDecimal(CCKi);
                            NKd.Value = CCKd > 1000 ? 1000 : Convert.ToDecimal(CCKd);
                        }
                        TBGanhoCritico.Text = DicArduino["Ku"];
                        TBTempoCritico.Text = (Convert.ToDouble(DicArduino["TON"]) + Convert.ToDouble(DicArduino["TOFF"])).ToString();
                        TBTempoON.Text = DicArduino["TON"];
                        TBTempoOFF.Text = DicArduino["TOFF"];
                        TBAlturaVale.Text = DicArduino["MediaAd"];
                        TBAlturaPico.Text = DicArduino["MediaAu"];
                        label2.Text = DicArduino["k"];
                        label3.Text = "(" + DicArduino["tal"] + " s + 1)";
                        label5.Text = "-" + DicArduino["teta"] + " s";
                    }
                    else
                        MessageBox.Show("Erro ao tentar calcular tal e teta, Ton + Toff =< 0, favor reiniciar a logica Rele", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Erro ao tentar calcular tal, Ku*K =< 1, favor reiniciar a logica Rele", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Erro ao tentar calcular Ku, Pico >= Histerese, favor reiniciar a logica Rele", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            f2 = false;
        }

        private void RecebeArduino(object sender, EventArgs e)
        { //Função para escrever o aux1 na tela do programa
            TBRecebeArduino.Text += aux1;
            TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length;
            TBRecebeArduino.ScrollToCaret();
            f4 = false;
        }

        private void AtualizacaoGrafico(object sender, EventArgs e)
        { //Função para plotar o gráfico e escrever VP e VC na tela do programa
            if (RBAtualizando.Checked)
            {
                Grafico.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(DicArduino["ms"]);
                Grafico.ChartAreas[0].AxisX.Minimum = Convert.ToDouble(DicArduino["ms"]) - tamgra;
            }
            else if (RBEstatico.Checked)
            {
                Grafico.ChartAreas[0].AxisX.Maximum = inicio + tamgra;
                Grafico.ChartAreas[0].AxisX.Minimum = inicio;
            }
            Grafico.ChartAreas[0].AxisY.Maximum = GYmax;
            Grafico.ChartAreas[0].AxisY.Minimum = GYmin;
            Grafico.Series["OUT"].XValueMember = "ms";
            Grafico.Series["OUT"].YValueMembers = "OUT";
            Grafico.Series["INP"].XValueMember = "ms";
            Grafico.Series["INP"].YValueMembers = "INP";
            //Grafico.Series["SP"].XValueMember = "ms";
            //Grafico.Series["SP"].YValueMembers = "SP";
            Grafico.DataSource = databaseTCCDataSet1.TabelaDados;
            Grafico.DataBind();
            TBVariavelControlada.Text = DicArduino["OUT"];
            TBVariavelProcesso.Text = DicArduino["VP"];
            f3 = false;
        }

        private void AtualizaVPOUT(object sender, EventArgs e)
        {
            TBVariavelControlada.Text = DicArduino["OUT"];
            TBVariavelProcesso.Text = DicArduino["VP"];
            f3 = false;
        }

        private void BTGrafico_Click(object sender, EventArgs e)
        {
            if (BTGrafico.Text == "Plotar")
            {
                BTGrafico.Text = "Reset BD";
            }
            else if (BTGrafico.Text == "Reset BD")
            {
                databaseTCCDataSet1.TabelaDados.Clear();
                Grafico.DataBind();
                BTGrafico.Text = "Plotar";
            }
        }

        private void Inicializacao(object sender, EventArgs e)
        {
            NSO.Value = Convert.ToDecimal(DicArduino["SO"]);
            NSetpoint.Value = Convert.ToDecimal(DicArduino["SP"]);
            NAmplitudeRele.Value = Convert.ToDecimal(DicArduino["d"]);
            NHisterese.Value = Convert.ToDecimal(DicArduino["his"]);
            if (DicArduino["MT"] == "1.00")
            {
                RB1.Checked = true;
                RB2.Checked = false;
                RB3.Checked = false;
            }
            else if (DicArduino["MT"] == "2.00")
            {
                RB1.Checked = false;
                RB2.Checked = true;
                RB3.Checked = false;
            }
            else if (DicArduino["MT"] == "3.00")
            {
                RB1.Checked = false;
                RB2.Checked = true;
                RB3.Checked = false;
            }
            if (DicArduino["PID"] == "1")
            {
                RBRele.Checked = false;
                RBPID.Checked = true;
                RBAberta.Checked = true;
                if (RB1.Checked)
                {
                    NKp.Value = ZNKp > 1000 ? 1000 : Convert.ToDecimal(ZNKp);
                    NKi.Value = ZNKi > 1000 ? 1000 : Convert.ToDecimal(ZNKi);
                    NKd.Value = ZNKd > 1000 ? 1000 : Convert.ToDecimal(ZNKd);
                }
                else if (RB2.Checked)
                {
                    NKp.Value = AHKp > 1000 ? 1000 : Convert.ToDecimal(AHKp);
                    NKi.Value = AHKi > 1000 ? 1000 : Convert.ToDecimal(AHKi);
                    NKd.Value = AHKd > 1000 ? 1000 : Convert.ToDecimal(AHKd);
                }
                else if (RB3.Checked)
                {
                    NKp.Value = CCKp > 1000 ? 1000 : Convert.ToDecimal(CCKp);
                    NKi.Value = CCKi > 1000 ? 1000 : Convert.ToDecimal(CCKi);
                    NKd.Value = CCKd > 1000 ? 1000 : Convert.ToDecimal(CCKd);
                }
            }
            else
            {
                RBRele.Checked = false;
                RBPID.Checked = false;
                RBAberta.Checked = true;
            }
            if ((DicArduino["RG"] == "1") && DicArduino.Keys.Contains("TON") && DicArduino.Keys.Contains("TOFF") && DicArduino.Keys.Contains("d") && DicArduino.Keys.Contains("his") && DicArduino.Keys.Contains("MediaAu") && DicArduino.Keys.Contains("MediaAd") && DicArduino.Keys.Contains("k"))
                Invoke(new EventHandler(update_dados));
            else
                f2 = false;
        }

        private void PermissaoRele(object sender, EventArgs e)
        {
            GBMalha.Enabled = true;
            GBPID.Enabled = true;
            GBRELE.Enabled = true;
            f1 = false;
        }

        private void RestricaoRele(object sender, EventArgs e)
        {
            GBMalha.Enabled = false;
            GBPID.Enabled = false;
            GBRELE.Enabled = false;
            f1 = false;
        }

        private void EstabilidadeRele(object sender, EventArgs e)
        {
            RBRele.Enabled = !RBRele.Enabled;
        }

        private void RB1_Click(object sender, EventArgs e)
        {
            RB1.Checked = true;
            RB2.Checked = false;
            RB3.Checked = false;
            serialPortTCC.WriteLine("MT=1");
            NKp.Value = ZNKp > 1000 ? 1000 : Convert.ToDecimal(ZNKp);
            NKi.Value = ZNKi > 1000 ? 1000 : Convert.ToDecimal(ZNKi);
            NKd.Value = ZNKd > 1000 ? 1000 : Convert.ToDecimal(ZNKd);
        }

        private void RB2_Click(object sender, EventArgs e)
        {
            RB2.Checked = true;
            RB1.Checked = false;
            RB3.Checked = false;
            serialPortTCC.WriteLine("MT=2");
            NKp.Value = AHKp > 1000 ? 1000 : Convert.ToDecimal(AHKp);
            NKi.Value = AHKi > 1000 ? 1000 : Convert.ToDecimal(AHKi);
            NKd.Value = AHKd > 1000 ? 1000 : Convert.ToDecimal(AHKd);
        }

        private void RB3_Click(object sender, EventArgs e)
        {
            RB3.Checked = true;
            RB1.Checked = false;
            RB2.Checked = false;
            serialPortTCC.WriteLine("MT=3");
            NKp.Value = CCKp > 1000 ? 1000 : Convert.ToDecimal(CCKp);
            NKi.Value = CCKi > 1000 ? 1000 : Convert.ToDecimal(CCKi);
            NKd.Value = CCKd > 1000 ? 1000 : Convert.ToDecimal(CCKd);
        }

        private void RBPID_Click(object sender, EventArgs e)
        {
            RBPID.Checked = true;
            RBAberta.Checked = false;
            RBRele.Checked = false;
            serialPortTCC.WriteLine("PID=0");
            if (RB1.Checked)
            {
                NKp.Value = ZNKp > 1000 ? 1000 : Convert.ToDecimal(ZNKp);
                NKi.Value = ZNKi > 1000 ? 1000 : Convert.ToDecimal(ZNKi);
                NKd.Value = ZNKd > 1000 ? 1000 : Convert.ToDecimal(ZNKd);
            }
            else if (RB2.Checked)
            {
                NKp.Value = AHKp > 1000 ? 1000 : Convert.ToDecimal(AHKp);
                NKi.Value = AHKi > 1000 ? 1000 : Convert.ToDecimal(AHKi);
                NKd.Value = AHKd > 1000 ? 1000 : Convert.ToDecimal(AHKd);
            }
            else if (RB3.Checked)
            {
                NKp.Value = CCKp > 1000 ? 1000 : Convert.ToDecimal(CCKp);
                NKi.Value = CCKi > 1000 ? 1000 : Convert.ToDecimal(CCKi);
                NKd.Value = CCKd > 1000 ? 1000 : Convert.ToDecimal(CCKd);
            }
        }

        private void RBAberta_Click(object sender, EventArgs e)
        {
            RBPID.Checked = false;
            RBAberta.Checked = true;
            RBRele.Checked = false;
            serialPortTCC.WriteLine("MA=0");
        }

        private void RBRele_Click(object sender, EventArgs e)
        {
            RBPID.Checked = false;
            RBAberta.Checked = false;
            RBRele.Checked = true;
            serialPortTCC.WriteLine("RL=0");
        }

        private void RBAtualizando_Click(object sender, EventArgs e)
        {
            RBAtualizando.Checked = true;
            RBEstatico.Checked = false;
        }

        private void RBEstatico_Click(object sender, EventArgs e)
        {
            RBEstatico.Checked = true;
            RBAtualizando.Checked = false;
        }

        private void NSetpoint_ValueChanged(object sender, EventArgs e)
        {
            serialPortTCC.WriteLine("SP=" + NSetpoint.Value.ToString());
        }

        private void NSO_ValueChanged(object sender, EventArgs e)
        {
            serialPortTCC.WriteLine("SO=" + NSO.Value.ToString());
        }

        private void NKp_ValueChanged(object sender, EventArgs e)
        {
            serialPortTCC.WriteLine("Kp=" + NKp.Value.ToString());
        }

        private void NKi_ValueChanged(object sender, EventArgs e)
        {
            serialPortTCC.WriteLine("Ki=" + NKi.Value.ToString());
        }

        private void NKd_ValueChanged(object sender, EventArgs e)
        {
            serialPortTCC.WriteLine("Kd=" + NKd.Value.ToString());
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            serialPortTCC.WriteLine(TBEnviaArduino.Text);
            TBEnviaArduino.Text = "";
        }

        private void NAmplitudeRele_ValueChanged(object sender, EventArgs e)
        {
            serialPortTCC.WriteLine("AR=" + NAmplitudeRele.Value.ToString());
        }

        private void NHisterese_ValueChanged(object sender, EventArgs e)
        {
            serialPortTCC.WriteLine("HI=" + NHisterese.Value.ToString());
        }

        private void NTempo_ValueChanged(object sender, EventArgs e)
        {
            tamgra = Convert.ToInt32(NTempo.Value);
        }

        private void NInicio_ValueChanged(object sender, EventArgs e)
        {
            inicio = Convert.ToDouble(NInicio.Value);
        }

        private void NYmax_ValueChanged(object sender, EventArgs e)
        {
            GYmax = Convert.ToDouble(NYmax.Value);
        }

        private void NYmin_ValueChanged(object sender, EventArgs e)
        {
            GYmin = Convert.ToDouble(NYmin.Value);
        }
    }
}
