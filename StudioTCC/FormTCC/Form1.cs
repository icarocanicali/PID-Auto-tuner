using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace TCC
{
    public partial class Form1 : Form
    { 
        private Dictionary<string, string> DicArduino;                                          // Dicionário para leitura de dados
        string aux1, ultimamsg;                                                                 // Auxiliares comunicação
        double inicio, GYmax = 4200, GYmin = 0,                                                 // Parâmetros do gráfico   
               tal1, tal2, talm, teta1, teta2, tetam, t01, t02, t0m, t0mm,                      // Parâmetros FOPDT
               amp = 200, his = 100, biashis = 250, biasamp = 250,                              // Parâmetros relé
               // setpoint do PID, sinal de operação de malha aberta, taxa de amostragem do PID, médias da saida e entrada do processo antes de iniciar a lógica relé
               setpoint, sinalop, sampletime, mVP, mOUT,                                        // 
               VPvar = 50, VPmax = 3500, VPmin = 500, OUTvar = 50, OUTmax = 3500, OUTmin = 500, // Limites estabilidade
               IniRele, FimRele;                                                                // Inicio e final da lógica relé
        double[,] IntERR = new double[5, 1], IntOUT = new double[5, 1],                         // Integrais do erro e da saída do relé
                  t0on = new double[5, 1], t0off = new double[5, 1],                            // Atrasos de transporte medidos
                  Ton = new double[5, 1], Toff = new double[5, 1],                              // Tempo dos semiciclos ON e OFF
                  Ad = new double[5, 1], Au = new double[5, 1],                                 // Vale e Pico da saída do processo 
                  K = new double[5, 1];                                                         // Ganho estático do processo  
        double KP = 1, KI = 0, KD = 0, lambda = 2,                                              // Ganhos do controlador e lambda
               //Ganhos do controlador PID para diferentes métodos e modelos 
               ZNKp1 = 0, ZNKi1 = 0, ZNKd1 = 0, ZNKp2 = 0, ZNKi2 = 0, ZNKd2 = 0, ZNKpm = 0, ZNKim = 0, ZNKdm = 0,
               CHRKp1 = 0, CHRKi1 = 0, CHRKd1 = 0, CHRKp2 = 0, CHRKi2 = 0, CHRKd2 = 0, CHRKpm = 0, CHRKim = 0, CHRKdm = 0, 
               IAEKp1 = 0, IAEKi1 = 0, IAEKd1 = 0, IAEKp2 = 0, IAEKi2 = 0, IAEKd2 = 0, IAEKpm = 0, IAEKim = 0, IAEKdm = 0,
               IMCKp1 = 0, IMCKi1 = 0, IMCKd1 = 0, IMCKp2 = 0, IMCKi2 = 0, IMCKd2 = 0, IMCKpm = 0, IMCKim = 0, IMCKdm = 0,
               ZNt0mKp1 = 0, ZNt0mKi1 = 0, ZNt0mKd1 = 0, ZNt0mKp2 = 0, ZNt0mKi2 = 0, ZNt0mKd2 = 0, ZNt0mKpm = 0, ZNt0mKim = 0, ZNt0mKdm = 0,
               CHRt0mKp1 = 0, CHRt0mKi1 = 0, CHRt0mKd1 = 0, CHRt0mKp2 = 0, CHRt0mKi2 = 0, CHRt0mKd2 = 0, CHRt0mKpm = 0, CHRt0mKim = 0, CHRt0mKdm = 0,
               IAEt0mKp1 = 0, IAEt0mKi1 = 0, IAEt0mKd1 = 0, IAEt0mKp2 = 0, IAEt0mKi2 = 0, IAEt0mKd2 = 0, IAEt0mKpm = 0, IAEt0mKim = 0, IAEt0mKdm = 0,
               IMCt0mKp1 = 0, IMCt0mKi1 = 0, IMCt0mKd1 = 0, IMCt0mKp2 = 0, IMCt0mKi2 = 0, IMCt0mKd2 = 0, IMCt0mKpm = 0, IMCt0mKim = 0, IMCt0mKdm = 0;
        bool bypass = false,  // bypass dos comandos, quando já tem outro aguardando na fila
             f2 = false,      // intertravamento do processamento dos dados recebidos
             RSC = false,     // flag de reenvio de dados para o Arduino
             MET = false,     // flag auxiliar no envio do comando de alteração do método
             RStxt = false,   // flag de reenvio da mensagem da caixa de texto 'Arduino'
             close = false,   // flag auxiliar da conexão com Arduino
             RL = false,      // status de operação do relé
             sentrele = true; // sentido de operação do relé (acima ou abaixo do ponto de operação)
        int acao = 1,         // ação do controlador 
            tamgra = 30000,   // tamanho (em milissegundos) do eixo horizontal do gráfico
            size = 0,         // tamanho do pacote de dados recebido 
            comando = 0,      // comando para o Arduino 
            ultimocom = 0,    // ultimo comando enviado ao Arduino
            proxcom = 0,      // proximo comando a ser enviado ao Arduino  
            auxcom = 0,       // auxiliar do reenvio de comandos ao Arduino
            metodo = 1,       // método de sintonia utilizado 
            malha = 0,        // malha em operação (Aberta, Relé, PID)
            modelo = 1;       // modelo FOPDT utilizado 

        public Form1()
        {
            InitializeComponent();                                      // Inicializa a aplicação
            portaseriallista.Items.AddRange(SerialPort.GetPortNames()); // Adiciona as portas seriais encontradas 
            timer1.Interval = 1000;                                     // Seta o temporizador em 1 segundo                    
        }

        private void BTAtualizar_Click(object sender, EventArgs e)
        {
            portaseriallista.Items.Clear();                             // Apaga a lista de portas seriais
            portaseriallista.Items.AddRange(SerialPort.GetPortNames()); // Adiciona portas seriais encontradas
        }

        private void BTConectar_Click(object sender, EventArgs e)
        {
            if (BTConectar.Text == "Conectar")                          // Verifica se o botão está para 'conectar'
            {
                if (portaseriallista.Text == "Porta Serial")            // Verifica se nenhuma porta serial foi selecionada
                    // Caso não haja porta serial selecionada envia mensagem na tela       
                    MessageBox.Show("Informe a Porta Serial", "", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                else
                {
                    serialPortTCC.PortName = portaseriallista.Text;     // Informa qual o nome da porta a ser utilizada
                    serialPortTCC.BaudRate = (int)TaxaTransferencia.Value;// Informa qual a taxa de transferência a ser utilizado
                    try
                    {
                        serialPortTCC.Open();                           // Abre a porta serial iniciando a conexão
                        serialPortTCC.ReadExisting();                   // Zera o buffer
                        // Adiciona a função que trata o evento de receber dados via porta serial
                        serialPortTCC.DataReceived += new SerialDataReceivedEventHandler(dadosArduino); 
                        TBRecebeArduino.Text = "";                      // Limpa a caixa de texto que escreve os dados do Arduino
                        BTConectar.Text = "Desconectar";                // Muda o nome do botão para 'desconectar'
                        comando = 51;                                   // Seleciona o comando para requisitar dados para Inicialização do FORM
                        aux1 = "";                                      // Limpa a variável aux1
                        Invoke(new EventHandler(enviarDados));          // Chama a função para enviar o comando selcionado
                        // Desbloqueia os comandos para o Arduino
                        NSetpoint.Enabled = true;
                        NSO.Enabled = true;
                        NKp.Enabled = true;
                        NKi.Enabled = true;
                        NKd.Enabled = true;
                        NTAmostragem.Enabled = true;
                        NAmplitudeRele.Enabled = true;
                        NBiasAmplitude.Enabled = true;
                        NHistereseRele.Enabled = true;
                        NBiasHisterese.Enabled = true;
                        NLambda.Enabled = true;
                        NVPvar.Enabled = true;
                        NVPmax.Enabled = true;
                        NVPmin.Enabled = true;
                        NOUTvar.Enabled = true;
                        NOUTmax.Enabled = true;
                        NOUTmin.Enabled = true;
                        RBON.Enabled = true;
                        RBOFF.Enabled = true;
                        RB1.Enabled = true;
                        RB2.Enabled = true;
                        RB3.Enabled = true;
                        RB4.Enabled = true;
                        RBCalculado.Enabled = true;
                        RBMedido.Enabled = true;
                        RBPIDBrett.Enabled = true;
                        RBPIDParalelo.Enabled = true;
                        RBAberta.Enabled = true;
                        //RBReleUP.Enabled = true;
                        //RBReleDown.Enabled = true;
                        BTEnviar.Enabled = true;
                        BTGrafico.Enabled = true;
                        BTAcao.Enabled = true;
                    }
                    catch
                    {
                        // Escreve mensagem na tela caso haja erro de conexão 
                        MessageBox.Show("Houve erro na conexão, tente novamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BTConectar.Text = "Conectar";                   // Habilita a conexão, alterando o nome do botão
                    }
                }
            }
            else
            {
                if (!close)                                             // Confere se a flag de desconexão não está ativada 
                {
                    close = true;                                       // Aciona a flag de desconexão 
                    timer1.Start();                                     // Inicia o temporizador para desconexão 
                    // Bloqueia os comandos para o Arduino
                    NSetpoint.Enabled = false;
                    NSO.Enabled = false;
                    NKp.Enabled = false;
                    NKi.Enabled = false;
                    NKd.Enabled = false;
                    NTAmostragem.Enabled = false;
                    NAmplitudeRele.Enabled = false;
                    NBiasAmplitude.Enabled = false;
                    NHistereseRele.Enabled = false;
                    NBiasHisterese.Enabled = false;
                    NLambda.Enabled = false;
                    NVPvar.Enabled = false;
                    NVPmax.Enabled = false;
                    NVPmin.Enabled = false;
                    NOUTvar.Enabled = false;
                    NOUTmax.Enabled = false;
                    NOUTmin.Enabled = false;
                    RBON.Enabled = false;
                    RBOFF.Enabled = false;
                    RB1.Enabled = false;
                    RB2.Enabled = false;
                    RB3.Enabled = false;
                    RB4.Enabled = false;
                    RBCalculado.Enabled = false;
                    RBMedido.Enabled = false;
                    RBPIDBrett.Enabled = false;
                    RBPIDParalelo.Enabled = false;
                    RBAberta.Enabled = false;
                    RBReleUP.Enabled = false;
                    RBReleDown.Enabled = false;
                    BTEnviar.Enabled = false;
                    BTGrafico.Enabled = false;
                    BTAcao.Enabled = false;
                }
            }
        }

        private void closeport(object sender, EventArgs e)
        {
            try
            {
                serialPortTCC.DiscardInBuffer();                        // Limpa o buffer de entrada
                serialPortTCC.DiscardOutBuffer();                       // Limpa o buffer de saída
                serialPortTCC.Close();                                  // Fecha a porta serial (desconecta)
                BTConectar.Text = "Conectar";                           // Permite tentar conectar novamente alterando o nome do botão
                GBstatus.BackColor = Color.Black;                       // Altera a cor da barra de comunicação informando a desconexão
                close = false;                                          // Desaciona a flag de desconexão 
            }
            catch
            {
                // Escreve mensagem na tela caso haja erro de conexão 
                MessageBox.Show("A desconexão falhou, tente novamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                BTConectar.Text = "Desconectar";                        // Permite tentar conectar novamente alterando o nome do botão
            }
        }

        private void enviarDados(object sender, EventArgs e)
        {
            if (!close)                                                 // Confere se a flag de desconexão não está ativada 
            {
                while (aux1 != "")                                      // Confere se o último dado recebido já foi processado 
                    continue;
                if (comando != 60)                                      // Confere se o comando a ser enviado não é o de Reenvio 
                    auxcom = comando;                                   // Grava qual o comando que será enviado (exceto reenvio)
                ultimocom = comando;                                    // Grava qual o comando que será enviado 
                timer1.Stop();                                          // Desativa o temporizador 
                timer1.Start();                                         // Reinicia o temporizador para 'vigiar' a comunicação 
                switch (comando)                                        // Switch Case do comando a ser enviado  
                {
                    case 2: // Comando para alterar o Setpoint 
                        serialPortTCC.WriteLine("}B" + NSetpoint.Value.ToString());
                        break;
                    case 3: // Comando para alterar o Sinal de Operação
                        serialPortTCC.WriteLine("}C" + NSO.Value.ToString());
                        break;
                    case 4: // Comando para alterar a variação de VP permitida no critério de estabilidade
                        serialPortTCC.WriteLine("}D" + NVPvar.Value.ToString());
                        VPvar = Convert.ToDouble(NVPvar.Value);
                        break;
                    case 5: // Comando para alterar o valor máximo de VP no critério de estabilidade
                        serialPortTCC.WriteLine("}E" + NVPmax.Value.ToString());
                        VPmax = Convert.ToDouble(NVPmax.Value);
                        break;
                    case 6: // Comando para alterar o valor mínimo de VP no critério de estabilidade
                        serialPortTCC.WriteLine("}F" + NVPmin.Value.ToString());
                        VPmin = Convert.ToDouble(NVPmin.Value);
                        break;
                    case 7: // Comando para alterar a variação de OUT permitida no critério de estabilidade
                        serialPortTCC.WriteLine("}G" + NOUTvar.Value.ToString());
                        OUTvar = Convert.ToDouble(NOUTvar.Value);
                        break;
                    case 8: // Comando para alterar o valor máximo de OUT no critério de estabilidade
                        serialPortTCC.WriteLine("}H" + NOUTmax.Value.ToString());
                        OUTmax = Convert.ToDouble(NOUTmax.Value);
                        break;
                    case 9: // Comando para alterar o valor mínimo de OUT no critério de estabilidade
                        serialPortTCC.WriteLine("}I" + NOUTmin.Value.ToString());
                        OUTmin = Convert.ToDouble(NOUTmin.Value);
                        break;
                    case 10: // Comando para alterar o valor de Lambda
                        lambda = Convert.ToDouble(NLambda.Value);
                        // Calculo dos paramentros do PID usando IMC
                        try
                        { // Cálculo usando modelo ON com t0 calculado
                            IMCKp1 = (2 * tal1 + t01) / (K[0, 0] * (2 * lambda + t01));
                            IMCKi1 = IMCKp1 / (tal1 + (t01 / 2));
                            IMCKd1 = IMCKp1 * ((tal1 * t01) / (2 * tal1 + t01));
                        }
                        catch
                        { // Seta valores padrão caso haja erro ao calcular os ganhos
                            IMCKp1 = 1;
                            IMCKi1 = 0;
                            IMCKd1 = 0;
                        }
                        try
                        { // Cálculo usando modelo OFF com t0 calculado
                            IMCKp2 = (2 * tal2 + t02) / (K[0, 0] * (2 * lambda + t02));
                            IMCKi2 = IMCKp2 / (tal2 + (t02 / 2));
                            IMCKd2 = IMCKp2 * ((tal2 * t02) / (2 * tal2 + t02));
                        }
                        catch
                        { // Seta valores padrão caso haja erro ao calcular os ganhos
                            IMCKp2 = 1;
                            IMCKi2 = 0;
                            IMCKd2 = 0;
                        }
                        try
                        { // Cálculo usando modelo Média com t0 calculado
                            IMCKpm = (2 * talm + t0m) / (K[0, 0] * (2 * lambda + t0m));
                            IMCKim = IMCKpm / (talm + (t0m / 2));
                            IMCKdm = IMCKpm * ((talm * t0m) / (2 * talm + t0m));
                        }
                        catch
                        { // Seta valores padrão caso haja erro ao calcular os ganhos
                            IMCKpm = 1;
                            IMCKim = 0;
                            IMCKdm = 0;
                        }
                        try
                        { // Cálculo usando modelo ON com t0 medido
                            IMCt0mKp1 = (2 * tal1 + t0on[0, 0]) / (K[0, 0] * (2 * lambda + t0on[0, 0]));
                            IMCt0mKi1 = IMCt0mKp1 / (tal1 + (t0on[0, 0] / 2));
                            IMCt0mKd1 = IMCt0mKp1 * ((tal1 * t0on[0, 0]) / (2 * tal1 + t0on[0, 0]));
                        }
                        catch
                        { // Seta valores padrão caso haja erro ao calcular os ganhos
                            IMCt0mKp1 = 1;
                            IMCt0mKi1 = 0;
                            IMCt0mKd1 = 0;
                        }
                        try
                        { // Cálculo usando modelo OFF com t0 medido
                            IMCt0mKp2 = (2 * tal2 + t0off[0, 0]) / (K[0, 0] * (2 * lambda + t0off[0, 0]));
                            IMCt0mKi2 = IMCt0mKp2 / (tal2 + (t0off[0, 0] / 2));
                            IMCt0mKd2 = IMCt0mKp2 * ((tal2 * t0off[0, 0]) / (2 * tal2 + t0off[0, 0]));
                        }
                        catch
                        { // Seta valores padrão caso haja erro ao calcular os ganhos
                            IMCt0mKp2 = 1;
                            IMCt0mKi2 = 0;
                            IMCt0mKd2 = 0;
                        }
                        try
                        { // Cálculo usando modelo Média com t0 medido
                            IMCt0mKpm = (2 * talm + t0mm) / (K[0, 0] * (2 * lambda + t0mm));
                            IMCt0mKim = IMCt0mKpm / (talm + (t0mm / 2));
                            IMCt0mKdm = IMCt0mKpm * ((talm * t0mm) / (2 * talm + t0mm));
                        }
                        catch
                        { // Seta valores padrão caso haja erro ao calcular os ganhos
                            IMCt0mKpm = 1;
                            IMCt0mKim = 0;
                            IMCt0mKdm = 0;
                        }
                        proxcom = 53; // Proximo comando setado para enviar o modelo seguido dos ganhos do PID
                        serialPortTCC.WriteLine("}J" + NLambda.Value.ToString());
                        break;
                    case 11: // Altera o modo de ação do controlador
                        if (BTAcao.Text == "Ação Direta")
                        {
                            acao = -1;
                            BTAcao.Text = "Ação Reversa";
                        }
                        else if (BTAcao.Text == "Ação Reversa")
                        {
                            acao = 1;
                            BTAcao.Text = "Ação Direta";
                        }
                        serialPortTCC.WriteLine("}K" + acao.ToString());
                        break;
                    // AUXILIARES 14 - 17
                    case 14: // Envia o valor de Kp
                        proxcom = 15;
                        serialPortTCC.WriteLine("}y" + NKp.Value.ToString());
                        break;
                    case 15: // Envia o valor de Ki
                        proxcom = 16;
                        serialPortTCC.WriteLine("}z" + NKi.Value.ToString());
                        break;
                    case 16: // Envia o valor de Kd
                        if (MET)          // Se o case foi chamado pela alteração do método
                        {
                            MET = false;  // desaciona a flag do método
                            proxcom = 0;  // libera a chamada de comandos
                        }
                        else
                            proxcom = 17; // 
                        serialPortTCC.WriteLine("}{" + NKd.Value.ToString());
                        break;
                    case 17: // Envia a malha PID selecionada 
                        if (malha == 3)
                        {
                            RBPIDBrett.Checked = true;
                            RBPIDParalelo.Checked = false;
                        }
                        else if (malha == 4)
                        {
                            RBPIDBrett.Checked = false;
                            RBPIDParalelo.Checked = true;
                        }
                        RBAberta.Checked = false;
                        RBReleUP.Checked = false;
                        proxcom = 0;
                        serialPortTCC.WriteLine("}v" + malha.ToString());
                        break;
                    case 47: // Comando para alterar a Histerese do relé
                        serialPortTCC.WriteLine("}o" + NHistereseRele.Value.ToString());
                        his = Convert.ToDouble(NHistereseRele.Value);
                        break;
                    case 48: // Comando para alterar o Bias da Histerese
                        serialPortTCC.WriteLine("}p" + NBiasHisterese.Value.ToString());
                        biashis = Convert.ToDouble(NBiasHisterese.Value);
                        break;
                    case 49: // Comando para alterar a Amplitude do relé
                        serialPortTCC.WriteLine("}q" + NAmplitudeRele.Value.ToString());
                        amp = Convert.ToDouble(NAmplitudeRele.Value);
                        break;
                    case 50: // Comando para alterar o Bias da Amplitude
                        serialPortTCC.WriteLine("}r" + NBiasAmplitude.Value.ToString());
                        biasamp = Convert.ToDouble(NBiasAmplitude.Value);
                        break;
                    case 51: // Comando para pedir dados para inicialização do FORM
                        serialPortTCC.WriteLine("}s");
                        break;
                    case 52: // Comando para pedir dados para o gráfico
                        serialPortTCC.WriteLine("}t");
                        break;
                    case 53: // Comando para o Arduino gravar o modelo utilizado 
                        proxcom = 55;
                        numerador.Text = K[0, 0].ToString("0.00");
                        if (modelo == 1.00)
                        {   // Modelo ON com t0 calculado
                            RBON.Checked = true;
                            RBOFF.Checked = false;
                            RBMedia.Checked = false;
                            RBCalculado.Checked = true;
                            RBMedido.Checked = false;
                            divisor.Text = "(" + tal1.ToString("0.00") + " s + 1)";
                            expoente.Text = "-" + (t01).ToString("0.00") + " s";
                            }
                        else if (modelo == 2.00)
                        {   // Modelo OFF com t0 calculado
                            RBON.Checked = false;
                            RBOFF.Checked = true;
                            RBMedia.Checked = false;
                            RBCalculado.Checked = true;
                            RBMedido.Checked = false;
                            divisor.Text = "(" + tal2.ToString("0.00") + " s + 1)";
                            expoente.Text = "-" + (t02).ToString("0.00") + " s";
                        }
                        else if (modelo == 3.00)
                        {   // Modelo Média com t0 calculado
                            RBON.Checked = false;
                            RBOFF.Checked = false;
                            RBMedia.Checked = true;
                            RBCalculado.Checked = true;
                            RBMedido.Checked = false;
                            divisor.Text = "(" + talm.ToString("0.00") + " s + 1)";
                            expoente.Text = "-" + (t0m).ToString("0.00") + " s";
                        }
                        else if (modelo == 4.00)
                        {   // Modelo ON com t0 medido
                            RBON.Checked = true;
                            RBOFF.Checked = false;
                            RBMedia.Checked = false;
                            RBCalculado.Checked = false;
                            RBMedido.Checked = true;
                            divisor.Text = "(" + tal1.ToString("0.00") + " s + 1)";
                            expoente.Text = "-" + (t0on[0, 0]).ToString("0.00") + " s";
                        }
                        else if (modelo == 5.00)
                        {   // Modelo OFF com t0 medido
                            RBON.Checked = false;
                            RBOFF.Checked = true;
                            RBMedia.Checked = false;
                            RBCalculado.Checked = false;
                            RBMedido.Checked = true;
                            divisor.Text = "(" + tal2.ToString("0.00") + " s + 1)";
                            expoente.Text = "-" + (t0off[0, 0]).ToString("0.00") + " s";
                        }
                        else if (modelo == 6.00)
                        {   // Modelo Média com t0 medido
                            RBON.Checked = false;
                            RBOFF.Checked = false;
                            RBMedia.Checked = true;
                            RBCalculado.Checked = false;
                            RBMedido.Checked = true;
                            divisor.Text = "(" + talm.ToString("0.00") + " s + 1)";
                            expoente.Text = "-" + (t0mm).ToString("0.00") + " s";
                        }
                        serialPortTCC.WriteLine("}u" + modelo.ToString());
                        break; 
                    case 54: // Comando para alterar a Malha de controle
                        if (malha == 0.00)
                        {   // Malha Aberta
                            RBAberta.Checked = true;
                            RBReleUP.Checked = false;
                            RBReleDown.Checked = false;
                            RBPIDBrett.Checked = false;
                            RBPIDParalelo.Checked = false;
                        }
                        else if (malha == 1.00)
                        {   // Malha Relé UP
                            RBAberta.Checked = false;
                            RBReleUP.Checked = true;
                            RBReleDown.Checked = false;
                            RBPIDBrett.Checked = false;
                            RBPIDParalelo.Checked = false;
                        }
                        else if (malha == 2.00)
                        {   // Malha Relé Down
                            RBAberta.Checked = false;
                            RBReleUP.Checked = false;
                            RBReleDown.Checked = true;
                            RBPIDBrett.Checked = false;
                            RBPIDParalelo.Checked = false;
                        }
                        else if (malha == 3.00)
                        {   // Malha PID Brett
                            RBAberta.Checked = false;
                            RBReleUP.Checked = false;
                            RBReleDown.Checked = false;
                            RBPIDBrett.Checked = true;
                            RBPIDParalelo.Checked = false;
                        }
                        else if (malha == 4.00)
                        {   // Malha PID Simples
                            RBAberta.Checked = false;
                            RBReleUP.Checked = false;
                            RBReleDown.Checked = false;
                            RBPIDBrett.Checked = false;
                            RBPIDParalelo.Checked = true;
                        }
                        if ((malha == 3) || (malha == 4))
                        {    // Caso a malha selecionada seja PID, envia os valores de Kp, Ki, e Kd antes
                            proxcom = 15;
                            serialPortTCC.WriteLine("}y" + NKp.Value.ToString());
                        }
                        else
                            serialPortTCC.WriteLine("}v" + malha.ToString());
                        break;
                    case 55: // Comando para alterar o Metodo de sintonia utilizado
                        MET = true;               // Aciona a flag de metodo
                        proxcom = 14;             // Envia os valores de Kp Ki e Kd na sequência 
                        if (metodo == 1)          // Método Ziegler and Nichols 
                        {
                            RB1.Checked = true;
                            RB2.Checked = false;
                            RB3.Checked = false;
                            RB4.Checked = false;
                            if (modelo == 1)      // Caso o modelo de parametrização selecionado seja ON com atraso calculado
                            {
                                KP = ZNKp1 > 1000 ? 1000.00 : Math.Round(ZNKp1, 2);
                                KI = ZNKi1 > 1000 ? 1000.00 : Math.Round(ZNKi1, 2);
                                KD = ZNKd1 > 1000 ? 1000.00 : Math.Round(ZNKd1, 2);
                            }
                            else if (modelo == 2) // Caso o modelo de parametrização selecionado seja OFF com atraso calculado
                            {
                                KP = ZNKp2 > 1000 ? 1000.00 : Math.Round(ZNKp2, 2);
                                KI = ZNKi2 > 1000 ? 1000.00 : Math.Round(ZNKi2, 2);
                                KD = ZNKd2 > 1000 ? 1000.00 : Math.Round(ZNKd2, 2);
                            }
                            else if (modelo == 3) // Caso o modelo de parametrização selecionado seja Média com atraso calculado
                            {
                                KP = ZNKpm > 1000 ? 1000.00 : Math.Round(ZNKpm, 2);
                                KI = ZNKim > 1000 ? 1000.00 : Math.Round(ZNKim, 2);
                                KD = ZNKdm > 1000 ? 1000.00 : Math.Round(ZNKdm, 2);
                            }
                            else if (modelo == 4) // Caso o modelo de parametrização selecionado seja ON com atraso medido
                            {
                                KP = ZNt0mKp1 > 1000 ? 1000.00 : Math.Round(ZNt0mKp1, 2);
                                KI = ZNt0mKi1 > 1000 ? 1000.00 : Math.Round(ZNt0mKi1, 2);
                                KD = ZNt0mKd1 > 1000 ? 1000.00 : Math.Round(ZNt0mKd1, 2);
                            }
                            else if (modelo == 5) // Caso o modelo de parametrização selecionado seja OFF com atraso medido
                            {
                                KP = ZNt0mKp2 > 1000 ? 1000.00 : Math.Round(ZNt0mKp2, 2);
                                KI = ZNt0mKi2 > 1000 ? 1000.00 : Math.Round(ZNt0mKi2, 2);
                                KD = ZNt0mKd2 > 1000 ? 1000.00 : Math.Round(ZNt0mKd2, 2);
                            }
                            else if (modelo == 6) // Caso o modelo de parametrização selecionado seja Média com atraso medido
                            {
                                KP = ZNt0mKpm > 1000 ? 1000.00 : Math.Round(ZNt0mKpm, 2);
                                KI = ZNt0mKim > 1000 ? 1000.00 : Math.Round(ZNt0mKim, 2);
                                KD = ZNt0mKdm > 1000 ? 1000.00 : Math.Round(ZNt0mKdm, 2);
                            }
                            serialPortTCC.WriteLine("}w1");
                        }
                        else if (metodo == 2)     // Método IAE Rovira
                        {
                            RB2.Checked = true;
                            RB1.Checked = false;
                            RB3.Checked = false;
                            RB4.Checked = false;
                            if (modelo == 1)      // Caso o modelo de parametrização selecionado seja ON com atraso calculado
                            {
                                KP = IAEKp1 > 1000 ? 1000.00 : Math.Round(IAEKp1, 2);
                                KI = IAEKi1 > 1000 ? 1000.00 : Math.Round(IAEKi1, 2);
                                KD = IAEKd1 > 1000 ? 1000.00 : Math.Round(IAEKd1, 2);
                            }
                            else if (modelo == 2) // Caso o modelo de parametrização selecionado seja OFF com atraso calculado
                            {
                                KP = IAEKp2 > 1000 ? 1000.00 : Math.Round(IAEKp2, 2);
                                KI = IAEKi2 > 1000 ? 1000.00 : Math.Round(IAEKi2, 2);
                                KD = IAEKd2 > 1000 ? 1000.00 : Math.Round(IAEKd2, 2);
                            }
                            else if (modelo == 3) // Caso o modelo de parametrização selecionado seja Média com atraso calculado
                            {
                                KP = IAEKpm > 1000 ? 1000.00 : Math.Round(IAEKpm, 2);
                                KI = IAEKim > 1000 ? 1000.00 : Math.Round(IAEKim, 2);
                                KD = IAEKdm > 1000 ? 1000.00 : Math.Round(IAEKdm, 2);
                            }
                            else if (modelo == 4) // Caso o modelo de parametrização selecionado seja ON com atraso medido
                            {
                                KP = IAEt0mKp1 > 1000 ? 1000.00 : Math.Round(IAEt0mKp1, 2);
                                KI = IAEt0mKi1 > 1000 ? 1000.00 : Math.Round(IAEt0mKi1, 2);
                                KD = IAEt0mKd1 > 1000 ? 1000.00 : Math.Round(IAEt0mKd1, 2);
                            }
                            else if (modelo == 5) // Caso o modelo de parametrização selecionado seja OFF com atraso medido
                            {
                                KP = IAEt0mKp2 > 1000 ? 1000.00 : Math.Round(IAEt0mKp2, 2);
                                KI = IAEt0mKi2 > 1000 ? 1000.00 : Math.Round(IAEt0mKi2, 2);
                                KD = IAEt0mKd2 > 1000 ? 1000.00 : Math.Round(IAEt0mKd2, 2);
                            }
                            else if (modelo == 6) // Caso o modelo de parametrização selecionado seja Média com atraso medido
                            {
                                KP = IAEt0mKpm > 1000 ? 1000.00 : Math.Round(IAEt0mKpm, 2);
                                KI = IAEt0mKim > 1000 ? 1000.00 : Math.Round(IAEt0mKim, 2);
                                KD = IAEt0mKdm > 1000 ? 1000.00 : Math.Round(IAEt0mKdm, 2);
                            }
                            serialPortTCC.WriteLine("}w2");
                        }
                        else if (metodo == 3)     // Método CHR 
                        {
                            RB3.Checked = true;
                            RB1.Checked = false;
                            RB2.Checked = false;
                            RB4.Checked = false;
                            if (modelo == 1)      // Caso o modelo de parametrização selecionado seja ON com atraso calculado
                            {
                                KP = CHRKp1 > 1000 ? 1000.00 : Math.Round(CHRKp1, 2);
                                KI = CHRKi1 > 1000 ? 1000.00 : Math.Round(CHRKi1, 2);
                                KD = CHRKd1 > 1000 ? 1000.00 : Math.Round(CHRKd1, 2);
                            }
                            else if (modelo == 2) // Caso o modelo de parametrização selecionado seja OFF com atraso calculado
                            {
                                KP = CHRKp2 > 1000 ? 1000.00 : Math.Round(CHRKp2, 2);
                                KI = CHRKi2 > 1000 ? 1000.00 : Math.Round(CHRKi2, 2);
                                KD = CHRKd2 > 1000 ? 1000.00 : Math.Round(CHRKd2, 2);
                            }
                            else if (modelo == 3) // Caso o modelo de parametrização selecionado seja Média com atraso calculado
                            {
                                KP = CHRKpm > 1000 ? 1000.00 : Math.Round(CHRKpm, 2);
                                KI = CHRKim > 1000 ? 1000.00 : Math.Round(CHRKim, 2);
                                KD = CHRKdm > 1000 ? 1000.00 : Math.Round(CHRKdm, 2);
                            }
                            else if (modelo == 4) // Caso o modelo de parametrização selecionado seja ON com atraso medido
                            {
                                KP = CHRt0mKp1 > 1000 ? 1000.00 : Math.Round(CHRt0mKp1, 2);
                                KI = CHRt0mKi1 > 1000 ? 1000.00 : Math.Round(CHRt0mKi1, 2);
                                KD = CHRt0mKd1 > 1000 ? 1000.00 : Math.Round(CHRt0mKd1, 2);
                            }
                            else if (modelo == 5) // Caso o modelo de parametrização selecionado seja OFF com atraso medido
                            {
                                KP = CHRt0mKp2 > 1000 ? 1000.00 : Math.Round(ZNt0mKp2, 2);
                                KI = CHRt0mKi2 > 1000 ? 1000.00 : Math.Round(ZNt0mKi2, 2);
                                KD = CHRt0mKd2 > 1000 ? 1000.00 : Math.Round(ZNt0mKd2, 2);
                            }
                            else if (modelo == 6) // Caso o modelo de parametrização selecionado seja Média com atraso medido
                            {
                                KP = CHRt0mKpm > 1000 ? 1000.00 : Math.Round(CHRt0mKpm, 2);
                                KI = CHRt0mKim > 1000 ? 1000.00 : Math.Round(CHRt0mKim, 2);
                                KD = CHRt0mKdm > 1000 ? 1000.00 : Math.Round(CHRt0mKdm, 2);
                            }
                            serialPortTCC.WriteLine("}w3");
                        }
                        else if (metodo == 4)     // Método IMC
                        {
                            RB4.Checked = true;
                            RB1.Checked = false;
                            RB2.Checked = false;
                            RB3.Checked = false;
                            if (modelo == 1)      // Caso o modelo de parametrização selecionado seja ON com atraso calculado
                            {
                                KP = IMCKp1 > 1000 ? 1000.00 : Math.Round(IMCKp1, 2);
                                KI = IMCKi1 > 1000 ? 1000.00 : Math.Round(IMCKi1, 2);
                                KD = IMCKd1 > 1000 ? 1000.00 : Math.Round(IMCKd1, 2);
                            }
                            else if (modelo == 2) // Caso o modelo de parametrização selecionado seja OFF com atraso calculado
                            {
                                KP = IMCKp2 > 1000 ? 1000.00 : Math.Round(IMCKp2, 2);
                                KI = IMCKi2 > 1000 ? 1000.00 : Math.Round(IMCKi2, 2);
                                KD = IMCKd2 > 1000 ? 1000.00 : Math.Round(IMCKd2, 2);
                            }
                            else if (modelo == 3) // Caso o modelo de parametrização selecionado seja Média com atraso calculado
                            {
                                KP = IMCKpm > 1000 ? 1000.00 : Math.Round(IMCKpm, 2);
                                KI = IMCKim > 1000 ? 1000.00 : Math.Round(IMCKim, 2);
                                KD = IMCKdm > 1000 ? 1000.00 : Math.Round(IMCKdm, 2);
                            }
                            else if (modelo == 4) // Caso o modelo de parametrização selecionado seja ON com atraso medido
                            {
                                KP = IMCt0mKp1 > 1000 ? 1000.00 : Math.Round(IMCt0mKp1, 2);
                                KI = IMCt0mKi1 > 1000 ? 1000.00 : Math.Round(IMCt0mKi1, 2);
                                KD = IMCt0mKd1 > 1000 ? 1000.00 : Math.Round(IMCt0mKd1, 2);
                            }
                            else if (modelo == 5) // Caso o modelo de parametrização selecionado seja OFF com atraso medido
                            {
                                KP = IMCt0mKp2 > 1000 ? 1000.00 : Math.Round(IMCt0mKp2, 2);
                                KI = IMCt0mKi2 > 1000 ? 1000.00 : Math.Round(IMCt0mKi2, 2);
                                KD = IMCt0mKd2 > 1000 ? 1000.00 : Math.Round(IMCt0mKd2, 2);
                            }
                            else if (modelo == 6) // Caso o modelo de parametrização selecionado seja Média com atraso medido
                            {
                                KP = IMCt0mKpm > 1000 ? 1000.00 : Math.Round(IMCt0mKpm, 2);
                                KI = IMCt0mKim > 1000 ? 1000.00 : Math.Round(IMCt0mKim, 2);
                                KD = IMCt0mKdm > 1000 ? 1000.00 : Math.Round(IMCt0mKdm, 2);
                            }
                            serialPortTCC.WriteLine("}w4");
                        }
                        try
                        {  // Lógica de bypass para evitar que sejam enviados comandos desnecessários
                            bypass = true;
                            while ((NKp.Value != Convert.ToDecimal(KP)) ||
                                   (NKi.Value != Convert.ToDecimal(KI)) ||
                                   (NKd.Value != Convert.ToDecimal(KD)))
                            {
                                NKp.Value = Convert.ToDecimal(KP);
                                NKi.Value = Convert.ToDecimal(KI);
                                NKd.Value = Convert.ToDecimal(KD);
                            }
                        }
                        catch { }
                        bypass = false;
                        break;
                    case 56: // Comando para alterar a Taxa de Amostragem do PID
                        serialPortTCC.WriteLine("}x" + NTAmostragem.Value.ToString());
                        break;
                    case 57: // Comando para alterar Kp
                        serialPortTCC.WriteLine("}y" + NKp.Value.ToString());
                        break;
                    case 58: // Comando para alterar Ki
                        serialPortTCC.WriteLine("}z" + NKi.Value.ToString());
                        break;
                    case 59: // Comando para alterar Kd
                        serialPortTCC.WriteLine("}{" + NKd.Value.ToString());
                        break;
                    case 60: // Comando para requisitar reenvio de dados
                        serialPortTCC.WriteLine("}|");
                        break;
                    case 62: // Comando para enviar o que estiver escrito na caixa de texto 'Arduino'
                        if (!RStxt) // Caso o comando tenha sido enviado pelo operador 
                        {    
                            ultimamsg = TBEnviaArduino.Text;
                            TBEnviaArduino.Text = "";
                        }
                        else // Caso o Arduino tenha requisitado reenvio e o último comando tenha sido escrito na caixa de texto 'Arduino'
                            RStxt = false; // Desaciona a flag de reenvio da mensagem da caixa de texto 'Arduino'
                        serialPortTCC.WriteLine(ultimamsg);
                        break;
                }
                serialPortTCC.DiscardOutBuffer();                       // Limpa o buffer de saída 
                comando = 0;                                            // Zera a variável comando
            }
        }

        private void dadosArduino(object sender, SerialDataReceivedEventArgs e)
        {
            if (!close)                                                 // Confere se a flag de desconexão não está ativada 
            {
                while (comando != 0)                                    // Confere se o último comando selecionado já foi enviado
                    continue;
                aux1 = serialPortTCC.ReadLine();                        // Armazena em aux1 o pacote de dados recebido
                serialPortTCC.DiscardInBuffer();                        // Limpa o buffer de entrada
                if (!close)                                             // Confere se a flag de desconexão não está ativada
                    timer1.Stop();                                      // Desativa o temporizador
                if (aux1 != null)                                       // Confere se o pacote de dados recebido não está vazio
                {
                    size = aux1.Length;                                 // Armazena o tamanho do pacote de dados recebido
                    try
                    {   
                        if (aux1[0].CompareTo('}') == 0)                // Confere se o pacote de dados recebido possui o Header no começo
                        {   
                            // Escrevendo os dados no dicionario separando por nome de entrada(key) e valor(value), armazena no formato string   
                            DicArduino = aux1.Split(',').ToDictionary(x => x.Split('=')[0], x => (x.Split('=').Length > 1 ? x.Split('=')[1] : ""));
                            // Confere se tem Header e Checksum, senão pede pro Arduino reenviar os dados
                            if (DicArduino.Keys.Contains("}") && DicArduino.Keys.Contains("~"))
                            {
                                // Confere o tamanho do pacote de dados enviado pelo Arduino, senão pede pro Arduino reenviar os dados
                                if (DicArduino["~"] == size.ToString())
                                {
                                    // Confere se o Arduino recebeu corretamente o ultimo comando enviado, senão reenvia o comando 
                                    if ((DicArduino["}"] == ultimocom.ToString()) ||    // Caso tenha recebido corretamente
                                        (DicArduino["}"] == "57" && ultimocom == 14) || // Caso tenha usado comando auxiliar
                                        (DicArduino["}"] == "58" && ultimocom == 15) || // Caso tenha usado comando auxiliar
                                        (DicArduino["}"] == "59" && ultimocom == 16) || // Caso tenha usado comando auxiliar
                                        (DicArduino["}"] == "54" && ultimocom == 17) || // Caso tenha usado comando auxiliar
                                        (DicArduino["}"] == "60") ||                    // Caso o último comando seja reenvio
                                        (DicArduino["}"] == "62"))                      // Caso o último comando tenha sido enviado pela caixa de envio de comandos
                                    {
                                        GBstatus.BackColor = Color.Green; // Indica que a comunicação ocorreu corretamente
                                        // Verifica se os dados vindos do Arduino contém 't' (estabilidade)
                                        if (DicArduino.Keys.Contains("t"))
                                        {
                                            f2 = true; // Aciona a flag de processamento de dados
                                            if ((DicArduino["v"] == "1") || (DicArduino["v"] == "2")) // Confere se a maha selecionada é a do relé
                                            {   // Armazena o momento que inicia a malha relé
                                                if (!RL) IniRele = Convert.ToUInt32(DicArduino["A"]) - 1000;
                                                // Chama função para bloquear comandos do FORM
                                                Invoke(new EventHandler(RestricaoRele));
                                                RL = true; // Aciona flag, informando que está sendo usada a malha relé 
                                            }
                                            else if ((DicArduino["v"] != "1") && (DicArduino["v"] != "2")) // Confere se a maha selecionada não é a do relé
                                            {   // Armazena o momento que encerra a malha relé
                                                if (RL) FimRele = Convert.ToUInt32(DicArduino["A"]) + 1000;
                                                // Chama função para desbloquear comandos do FORM
                                                Invoke(new EventHandler(PermissaoRele));
                                                // Bloqueia ou desbloqueia a opção relé dependendo da estabilidade
                                                if ((DicArduino["t"] == "1") && RBReleUP.Enabled == false) Invoke(new EventHandler(EstabilidadeRele)); //Libera a lógica relé caso o sistema esteja estável
                                                else if ((DicArduino["t"] == "0") && RBReleUP.Enabled == true) Invoke(new EventHandler(EstabilidadeRele)); //Trava a lógica relé caso o sistema esteja instável
                                                RL = false; // Desciona flag, informando que não está sendo usada a malha relé 
                                            }
                                            if (BTGrafico.Text == "Reset BD") // Confere o botão do gráfico
                                            {
                                                DataRow row = databaseTCCDataSet1.TabelaDados.NewRow(); // Gera uma nova linha no banco de dados
                                                row["ms"] = Convert.ToUInt32(DicArduino["A"]);          // Adiciona o tempo recebido do Arduino
                                                row["INP"] = Convert.ToDouble(DicArduino["D"]);         // Adiciona o VP recebido do Arduino
                                                //row["SP"] = Convert.ToDouble(DicArduino["B"]);          //Adiciona o SP recebido do Arduino
                                                row["OUT"] = Convert.ToDouble(DicArduino["E"]);         // Adiciona o OUT recebido do Arduino                        
                                                databaseTCCDataSet1.TabelaDados.Rows.Add(row);          // Insere a linha gerada na tabela
                                                Invoke(new EventHandler(AtualizacaoGrafico));           // Chama função para plotar os dados no gráfico
                                            }
                                            else if (BTGrafico.Text == "Plotar")         // Confere o botão do gráfico
                                                Invoke(new EventHandler(AtualizaVPOUT)); // Chama função para informar VP e OUT no FORM
                                        }
                                        // Verifica se os dados vindos do Arduino contém 'F' (mVP - indicando retorno do rele)
                                        else if (DicArduino.Keys.Contains("F"))
                                        {
                                            f2 = true; // Aciona a flag de processamento de dados
                                            Invoke(new EventHandler(Malha0));       // Chama função que seleciona a malha aberta
                                            Invoke(new EventHandler(update_dados)); // Chama função que calcula os parametros do controlador PID
                                        }
                                        // Verifica se os dados vindos do Arduino contém 'o' (histerese - enviado pela logica de inicializacao) 
                                        else if (DicArduino.Keys.Contains("o"))
                                        {
                                            f2 = true; // Aciona a flag de processamento de dados
                                            Invoke(new EventHandler(Inicializacao)); // Chama função que processa os dados para inicialização do FORM
                                        }
                                        // Verifica se os dados vindos do Arduino contém 'B' (setpoint) e contém 'C' (sinal de operação) 
                                        else if (DicArduino.Keys.Contains("B") && DicArduino.Keys.Contains("C")) 
                                        {
                                            f2 = true; // Aciona a flag de processamento de dados
                                            Invoke(new EventHandler(TrackSP)); // Chama função que informa o novo setpoint (tracking)
                                        }
                                        // Verifica se os dados vindos do Arduino contém '|' (reenvio) 
                                        else if (DicArduino.Keys.Contains("|"))
                                            RSC = true; // Aciona a flag para reenvio do último comando enviado para o Arduino
                                        while (f2) // Aguarda o processamento dos dados recebidos antes de enviar outro comando ao Arduino
                                            continue;
                                    }
                                    // Caso o ultimocom seja diferente do recebido porém contenha a informação correta com pedido de reenvio
                                    else if ((DicArduino["}"] == "0") && (DicArduino.Keys.Contains("|"))) 
                                        RSC = true; // Aciona a flag para reenvio do último comando enviado para o Arduino
                                    else
                                    {
                                        GBstatus.BackColor = Color.Red; // Altera a cor da barra de comunicação informando que houve erro
                                        comando = 63; // Solicita reenvio de dados
                                    }
                                }
                                else // Caso o checksum receba um valor incorreto
                                {
                                    GBstatus.BackColor = Color.Red; // Altera a cor da barra de comunicação informando que houve erro
                                    comando = 64; // Solicita reenvio de dados
                                }
                            }
                            else // Caso não tenha recebido header e ou checksum
                            {
                                GBstatus.BackColor = Color.Red; // Altera a cor da barra de comunicação informando que houve erro
                                comando = 65; // Solicita reenvio de dados
                            }
                        }
                        else // Caso não tenha header no começo do dado recebido
                        {
                            GBstatus.BackColor = Color.Red; // Altera a cor da barra de comunicação informando que houve erro
                            comando = 66; // Solicita reenvio de dados
                        }
                    }
                    catch // Caso não consiga processar o dado (dicionario e outros)
                    {
                        GBstatus.BackColor = Color.Red; // Altera a cor da barra de comunicação informando que houve erro
                        comando = 67; // Solicita reenvio de dados
                    }
                }
                else // Caso o dado venha vazio (null)
                {
                    GBstatus.BackColor = Color.Red; // Altera a cor da barra de comunicação informando que houve erro
                    comando = 68; // Solicita reenvio de dados
                }
                // LÓGICA PARA ESCOLHER O COMANDO A SER ENVIADO PARA O ARDUINO
                if (comando >= 63) // Caso haja erro na comunicação
                {
                    switch (comando) // Switch Case para informar o erro no FORM
                    {
                        case 63:
                            aux1 += "\rDado recebido com indicação de comando enviado incorreto\r";
                            break;
                        case 64:
                            aux1 += "\rDado recebido com checksum incorreto\r";
                            break;
                        case 65:
                            aux1 += "\rDado recebido sem header e ou checksum\r";
                            break;
                        case 66:
                            aux1 += "\rDado recebido sem header no começo\r";
                            break;
                        case 67:
                            aux1 += "\rErro ao tentar processar o dado recebido\r";   
                            break;
                        case 68:
                            aux1 += "\rDado recebido vazio (NULL)\r";
                            break;
                    }
                    comando = 60;                        // Seleciona o comando para solicitar reenvio de dados
                }
                else if (RSC)                            // Confere se a flag de reenvio de comando está acionada 
                {
                    RSC = false;                         // Desaciona a flag de reenvio de comando
                    comando = auxcom;                    // Seleciona o último comando enviado
                    if (auxcom == 62)                    // Verifica se o último comando foi enviado pela caixa de envio de texto 'Arduino'
                        RStxt = true;                    // Aciona a flag para reenvio do ultimo comando da caixa de envio de texto 'Arduino'
                }
                else if (comando == 0 && proxcom != 0)   // Confere se não há nenhum comando prioritário e se possui algum na fila
                {
                    comando = proxcom;                   // Seleciona o comando pré-selecionado 
                    proxcom = 0;                         // Zera a pré-seleção de comando
                }
                else if (comando == 0)                   // Confere se não há nenhum comando prioritário e se não possui um pré-selecionado
                    comando = 52;                        // Seleciona o comando para requisitar dados para o gráfico 
                Invoke(new EventHandler(RecebeArduino)); // Chama função para escrever o aux1 no FORM
                aux1 = "";                               // Limpa a variável aux1
                Invoke(new EventHandler(enviarDados));   // Chama função para enviar comando para o Arduino
            }
        }
        //Função que atualiza as informações na tela do programa
        private void update_dados(object sender, EventArgs e) 
        { 
            mVP = Convert.ToDouble(DicArduino["F"]);                                        // Recebe o valor de mVP
            mOUT = Convert.ToDouble(DicArduino["G"]);                                       // Recebe o valor de mOUT
            if (DicArduino["H"] == "1")                                                     // Verifica se o sentido de operação relé é acima do ponto de operação
                sentrele = true;                                                            //
            else if (DicArduino["H"] == "0")                                                // Verifica se o sentido de operação relé é abaixo do ponto de operação
                sentrele = false;                                                           // 
            t0on[1, 0] = Convert.ToDouble(DicArduino["N"]) / 1000;                          // Recebe o valor do atraso de transporte do semiciclo ON do ciclo 1  
            t0off[1, 0] = Convert.ToDouble(DicArduino["O"]) / 1000;                         // Recebe o valor do atraso de transporte do semiciclo OFF do ciclo 1
            t0on[2, 0] = Convert.ToDouble(DicArduino["P"]) / 1000;                          // Recebe o valor do atraso de transporte do semiciclo ON do ciclo 2
            t0off[2, 0] = Convert.ToDouble(DicArduino["Q"]) / 1000;                         // Recebe o valor do atraso de transporte do semiciclo OFF do ciclo 2
            t0on[3, 0] = Convert.ToDouble(DicArduino["R"]) / 1000;                          // Recebe o valor do atraso de transporte do semiciclo ON do ciclo 3
            t0off[3, 0] = Convert.ToDouble(DicArduino["S"]) / 1000;                         // Recebe o valor do atraso de transporte do semiciclo OFF do ciclo 3
            t0on[4, 0] = Convert.ToDouble(DicArduino["T"]) / 1000;                          // Recebe o valor do atraso de transporte do semiciclo ON do ciclo 4
            t0off[4, 0] = Convert.ToDouble(DicArduino["U"]) / 1000;                         // Recebe o valor do atraso de transporte do semiciclo OFF do ciclo 4
            Ton[1, 0] = Convert.ToDouble(DicArduino["V"]) / 1000;                           // Recebe o valor do tempo do semiciclo ON do ciclo 1 
            Ton[2, 0] = Convert.ToDouble(DicArduino["W"]) / 1000;                           // Recebe o valor do tempo do semiciclo ON do ciclo 2
            Ton[3, 0] = Convert.ToDouble(DicArduino["X"]) / 1000;                           // Recebe o valor do tempo do semiciclo ON do ciclo 3
            Ton[4, 0] = Convert.ToDouble(DicArduino["Y"]) / 1000;                           // Recebe o valor do tempo do semiciclo ON do ciclo 4
            Toff[1, 0] = Convert.ToDouble(DicArduino["Z"]) / 1000;                          // Recebe o valor do tempo do semiciclo OFF do ciclo 1
            Toff[2, 0] = Convert.ToDouble(DicArduino["["]) / 1000;                          // Recebe o valor do tempo do semiciclo OFF do ciclo 2
            Toff[3, 0] = Convert.ToDouble(DicArduino["]"]) / 1000;                          // Recebe o valor do tempo do semiciclo OFF do ciclo 3
            Toff[4, 0] = Convert.ToDouble(DicArduino["^"]) / 1000;                          // Recebe o valor do tempo do semiciclo OFF do ciclo 4
            Au[1, 0] = Convert.ToDouble(DicArduino["_"]);                                   // Recebe o valor do pico do semiciclo OFF do ciclo 1
            Au[2, 0] = Convert.ToDouble(DicArduino["'"]);                                   // Recebe o valor do pico do semiciclo OFF do ciclo 2
            Au[3, 0] = Convert.ToDouble(DicArduino["a"]);                                   // Recebe o valor do pico do semiciclo OFF do ciclo 3
            Au[4, 0] = Convert.ToDouble(DicArduino["b"]);                                   // Recebe o valor do pico do semiciclo OFF do ciclo 4
            Ad[1, 0] = Convert.ToDouble(DicArduino["c"]);                                   // Recebe o valor do vale do semiciclo ON do ciclo 1
            Ad[2, 0] = Convert.ToDouble(DicArduino["d"]);                                   // Recebe o valor do vale do semiciclo ON do ciclo 2
            Ad[3, 0] = Convert.ToDouble(DicArduino["e"]);                                   // Recebe o valor do vale do semiciclo ON do ciclo 3
            Ad[4, 0] = Convert.ToDouble(DicArduino["f"]);                                   // Recebe o valor do vale do semiciclo ON do ciclo 4
            IntERR[1, 0] = Convert.ToDouble(DicArduino["g"]);                               // Recebe o valor da integral do erro do ciclo 1
            IntERR[2, 0] = Convert.ToDouble(DicArduino["h"]);                               // Recebe o valor da integral do erro do ciclo 2
            IntERR[3, 0] = Convert.ToDouble(DicArduino["i"]);                               // Recebe o valor da integral do erro do ciclo 3
            IntERR[4, 0] = Convert.ToDouble(DicArduino["j"]);                               // Recebe o valor da integral do erro do ciclo 4
            IntOUT[1, 0] = Convert.ToDouble(DicArduino["k"]);                               // Recebe o valor da integral da saída do relé do ciclo 1
            IntOUT[2, 0] = Convert.ToDouble(DicArduino["l"]);                               // Recebe o valor da integral da saída do relé do ciclo 2
            IntOUT[3, 0] = Convert.ToDouble(DicArduino["m"]);                               // Recebe o valor da integral da saída do relé do ciclo 3
            IntOUT[4, 0] = Convert.ToDouble(DicArduino["n"]);                               // Recebe o valor da integral da saída do relé do ciclo 4
            // CÁLCULOS
            t0on[0, 0] = (t0on[1, 0] + t0on[2, 0] + t0on[3, 0] + t0on[4, 0]) / 4;           // Média dos atrasos de transporte dos semiciclos ON dos 4 ciclos
            t0off[0, 0] = (t0off[1, 0] + t0off[2, 0] + t0off[3, 0] + t0off[4, 0]) / 4;      // Média dos atrasos de transporte dos semiciclos OFF dos 4 ciclos
            Ton[0, 0] = (Ton[1, 0] + Ton[2, 0] + Ton[3, 0] + Ton[4, 0]) / 4;                // Média dos tempos dos semiciclos ON dos 4 ciclos
            Toff[0, 0] = (Toff[1, 0] + Toff[2, 0] + Toff[3, 0] + Toff[4, 0]) / 4;           // Média dos tempos dos semiciclos OFF dos 4 ciclos
            Au[0, 0] = (Au[1, 0] + Au[2, 0] + Au[3, 0] + Au[4, 0]) / 4;                     // Média dos picos dos semiciclos OFF dos 4 ciclos
            Ad[0, 0] = (Ad[1, 0] + Ad[2, 0] + Ad[3, 0] + Ad[4, 0]) / 4;                     // Média dos vales dos semiciclos ON dos 4 ciclos
            IntERR[0, 0] = (IntERR[1, 0] + IntERR[2, 0] + IntERR[3, 0] + IntERR[4, 0]) / 4; // Média das integrais do erro dos 4 ciclos
            IntOUT[0, 0] = (IntOUT[1, 0] + IntOUT[2, 0] + IntOUT[3, 0] + IntOUT[4, 0]) / 4; // Média das integrais da saída do relé dos 4 ciclos
            K[1, 0] = -(IntERR[1, 0] / IntOUT[1, 0]);                                       // Cálculo do ganho estático do ciclo 1
            K[2, 0] = -(IntERR[2, 0] / IntOUT[2, 0]);                                       // Cálculo do ganho estático do ciclo 2
            K[3, 0] = -(IntERR[3, 0] / IntOUT[3, 0]);                                       // Cálculo do ganho estático do ciclo 3
            K[4, 0] = -(IntERR[4, 0] / IntOUT[4, 0]);                                       // Cálculo do ganho estático do ciclo 4
            K[0, 0] = (K[1, 0] + K[2, 0] + K[3, 0] + K[4, 0]) / 4;                          // Média dos ganhos estáticos dos 4 ciclos

            if (sentrele == false) // Relé excitado abaixo do ponto de operação
            {
                try // Cálculo dos parâmetros FOPDT do Modelo ON com t0 calculado
                {
                    teta1 = Math.Log((K[0, 0] * (amp + biasamp) - (biashis + his)) / ((K[0, 0] * (amp + biasamp)) + (Ad[0, 0])));
                    tal1 = Ton[0, 0] / Math.Log((2 * K[0, 0] * Math.Pow(Math.E, teta1) * amp - K[0, 0] * (amp + biasamp) + (his + biashis)) / (K[0, 0] * (amp - biasamp) + (biashis - his)));
                    t01 = teta1 * tal1;
                    RBON.Enabled = true; // Desbloqueia a opção de usar o Modelo ON com t0 calculado
                }
                catch // Bloqueia a opção de usar o Modelo ON com t0 calculado
                {
                    RBON.Checked = false;
                    RBON.Enabled = false;
                }
                try // Cálculo dos parâmetros FOPDT do Modelo OFF com t0 calculado
                {
                    teta2 = Math.Log((K[0, 0] * (amp - biasamp) - (his - biashis)) / (K[0, 0] * (amp - biasamp) - (Au[0, 0])));
                    tal2 = Toff[0, 0] / Math.Log((2 * K[0, 0] * Math.Pow(Math.E, teta2) * amp - K[0, 0] * (-biasamp + amp) + (-biashis + his)) / (K[0, 0] * (amp + biasamp) + (-biashis - his)));
                    t02 = teta2 * tal2;
                    RBOFF.Enabled = true; // Desbloqueia a opção de usar o Modelo OFF com t0 calculado
                }
                catch // Bloqueia a opção de usar o Modelo OFF com t0 calculado
                {
                    RBOFF.Checked = false;
                    RBOFF.Enabled = false;
                }
            }
            else if (sentrele == true)  // Relé excitado acima do ponto de operação
            {
                try // Cálculo dos parâmetros FOPDT do Modelo ON com t0 calculado
                {
                    teta1 = Math.Log((K[0, 0] * (amp - biasamp) + (biashis - his)) / ((K[0, 0] * (amp - biasamp)) + (Ad[0, 0])));
                    tal1 = Ton[0, 0] / Math.Log((2 * K[0, 0] * Math.Pow(Math.E, teta1) * amp + K[0, 0] * (biasamp - amp) - (biashis - his)) / (K[0, 0] * (amp + biasamp) - (biashis + his)));
                    t01 = teta1 * tal1;
                    RBON.Enabled = true;  // Desbloqueia a opção de usar o Modelo ON com t0 calculado
                }
                catch // Bloqueia a opção de usar o Modelo ON com t0 calculado
                { 
                    RBON.Checked = false;
                    RBON.Enabled = false;
                }
                try // Cálculo dos parâmetros FOPDT do Modelo OFF com t0 calculado
                {
                    teta2 = Math.Log((K[0, 0] * (amp + biasamp) - (biashis + his)) / (K[0, 0] * (amp + biasamp) - (Au[0, 0])));
                    tal2 = Toff[0, 0] / Math.Log((2 * K[0, 0] * Math.Pow(Math.E, teta2) * amp - K[0, 0] * (biasamp + amp) + (biashis + his)) / (-K[0, 0] * (biasamp - amp) + (biashis - his)));
                    t02 = teta2 * tal2;
                    RBOFF.Enabled = true; // Desbloqueia a opção de usar o Modelo OFF com t0 calculado
                }
                catch // Bloqueia a opção de usar o Modelo OFF com t0 calculado
                { 
                    RBOFF.Checked = false;
                    RBOFF.Enabled = false;
                }
            }
            try // Cálculo dos parâmetros FOPDT do Modelo Média com t0 calculado
            {
                tetam = (teta1 + teta2) / 2;
                talm = (tal1 + tal2) / 2;
                t0m = (t01 + t02) / 2;
                RBMedia.Enabled = true;  // Desbloqueia a opção de usar o Modelo Media com t0 calculado
            }
            catch // Bloqueia a opção de usar o Modelo Media com t0 calculado
            {
                RBMedia.Checked = false;
                RBMedia.Enabled = false;
            }
            t0mm = (t0on[0, 0] + t0off[0, 0]) / 2;
            // Cálculo dos paramentros do PID usando IAE Rovira
            try
            { // Cálculo usando modelo ON com t0 calculado
                IAEKp1 = (1.086 / K[0, 0]) * (Math.Pow((t01 / tal1), -0.869));
                IAEKi1 = IAEKp1 / (tal1 / (0.740 - 0.130 * (t01 / tal1)));
                IAEKd1 = IAEKp1 * ((0.348 * tal1) * (Math.Pow((t01 / tal1), 0.914)));
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                IAEKp1 = 1;
                IAEKi1 = 0;
                IAEKd1 = 0;
            }
            try
            { // Cálculo usando modelo OFF com t0 calculado
                IAEKp2 = (1.086 / K[0, 0]) * (Math.Pow((t02 / tal2), -0.869));
                IAEKi2 = IAEKp2 / (tal2 / (0.740 - 0.130 * (t02 / tal2)));
                IAEKd2 = IAEKp2 * ((0.348 * tal2) * (Math.Pow((t02 / tal2), 0.914)));
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                IAEKp2 = 1;
                IAEKi2 = 0;
                IAEKd2 = 0;
            }
            try
            { // Cálculo usando modelo Média com t0 calculado
                IAEKpm = (1.086 / K[0, 0]) * (Math.Pow((t0m / talm), -0.869));
                IAEKim = IAEKpm / (talm / (0.740 - 0.130 * (t0m / talm)));
                IAEKdm = IAEKpm * ((0.348 * talm) * (Math.Pow((t0m / talm), 0.914)));
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                IAEKpm = 1;
                IAEKim = 0;
                IAEKdm = 0;
            }
            try
            { // Cálculo usando modelo ON com t0 medido
                IAEt0mKp1 = (1.086 / K[0, 0]) * (Math.Pow((t0on[0, 0] / tal1), -0.869));
                IAEt0mKi1 = IAEt0mKp1 / (tal1 / (0.740 - 0.130 * (t0on[0, 0] / tal1)));
                IAEt0mKd1 = IAEt0mKp1 * ((0.348 * tal1) * (Math.Pow((t0on[0, 0] / tal1), 0.914)));
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                IAEt0mKp1 = 1;
                IAEt0mKi1 = 0;
                IAEt0mKd1 = 0;
            }
            try
            { // Cálculo usando modelo OFF com t0 medido
                IAEt0mKp2 = (1.086 / K[0, 0]) * (Math.Pow((t0off[0, 0] / tal2), -0.869));
                IAEt0mKi2 = IAEt0mKp2 / (tal2 / (0.740 - 0.130 * (t0off[0, 0] / tal2)));
                IAEt0mKd2 = IAEt0mKp2 * ((0.348 * tal2) * (Math.Pow((t0off[0, 0] / tal2), 0.914)));
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                IAEt0mKp2 = 1;
                IAEt0mKi2 = 0;
                IAEt0mKd2 = 0;
            }
            try
            { // Cálculo usando modelo Média com t0 medido
                IAEt0mKpm = (1.086 / K[0, 0]) * (Math.Pow((t0mm / talm), -0.869));
                IAEt0mKim = IAEt0mKpm / (talm / (0.740 - 0.130 * (t0mm / talm)));
                IAEt0mKdm = IAEt0mKpm * ((0.348 * talm) * (Math.Pow((t0mm / talm), 0.914)));
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                IAEt0mKpm = 1;
                IAEt0mKim = 0;
                IAEt0mKdm = 0;
            }
            // Calculo dos paramentros do PID usando Ziegler & Nichols
            try
            { // Cálculo usando modelo ON com t0 calculado
                ZNKp1 = (1.2 * tal1) / ((K[0, 0]) * t01);
                ZNKi1 = ZNKp1 / (2 * t01);
                ZNKd1 = ZNKp1 * (t01 / 2);
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                ZNKp1 = 1;
                ZNKi1 = 0;
                ZNKd1 = 0;
            }
            try
            { // Cálculo usando modelo OFF com t0 calculado
                ZNKp2 = (1.2 * tal2) / ((K[0, 0]) * t02);
                ZNKi2 = ZNKp2 / (2 * t02);
                ZNKd2 = ZNKp2 * (t02 / 2);
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                ZNKp2 = 1;
                ZNKi2 = 0;
                ZNKd2 = 0;
            }
            try
            { // Cálculo usando modelo Média com t0 calculado
                ZNKpm = (1.2 * talm) / ((K[0, 0]) * t0m);
                ZNKim = ZNKpm / (2 * t0m);
                ZNKdm = ZNKpm * (t0m / 2);
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                ZNKpm = 1;
                ZNKim = 0;
                ZNKdm = 0;
            }
            try
            { // Cálculo usando modelo ON com t0 medido
                ZNt0mKp1 = (1.2 * tal1) / ((K[0, 0]) * t0on[0, 0]);
                ZNt0mKi1 = ZNt0mKp1 / (2 * t0on[0, 0]);
                ZNt0mKd1 = ZNt0mKp1 * (t0on[0, 0] / 2);
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                ZNt0mKp1 = 1;
                ZNt0mKi1 = 0;
                ZNt0mKd1 = 0;
            }
            try
            { // Cálculo usando modelo OFF com t0 medido
                ZNt0mKp2 = (1.2 * tal2) / ((K[0, 0]) * t0off[0, 0]);
                ZNt0mKi2 = ZNt0mKp2 / (2 * t0off[0, 0]);
                ZNt0mKd2 = ZNt0mKp2 * (t0off[0, 0] / 2);
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                ZNt0mKp2 = 1;
                ZNt0mKi2 = 0;
                ZNt0mKd2 = 0;
            }
            try
            { // Cálculo usando modelo Média com t0 medido
                ZNt0mKpm = (1.2 * talm) / ((K[0, 0]) * t0mm);
                ZNt0mKim = ZNt0mKpm / (2 * t0mm);
                ZNt0mKdm = ZNt0mKpm * (t0mm / 2);
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                ZNt0mKpm = 1;
                ZNt0mKim = 0;
                ZNt0mKdm = 0;
            }
            // Calculo dos paramentros do PID usando CHR
            try
            { // Cálculo usando modelo ON com t0 calculado
                CHRKp1 = 0.95 * (tal1 / (K[0, 0] * t01));
                CHRKi1 = CHRKp1 / (2.375 * t01);
                CHRKd1 = CHRKp1 * (0.421 * t01);
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                CHRKp1 = 1;
                CHRKi1 = 0;
                CHRKd1 = 0;
            }
            try
            { // Cálculo usando modelo OFF com t0 calculado
                CHRKp2 = 0.95 * (tal2 / (K[0, 0] * t02));
                CHRKi2 = CHRKp2 / (2.375 * t02);
                CHRKd2 = CHRKp2 * (0.421 * t02);
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                CHRKp2 = 1;
                CHRKi2 = 0;
                CHRKd2 = 0;
            }
            try
            { // Cálculo usando modelo Média com t0 calculado
                CHRKpm = 0.95 * (talm / (K[0, 0] * t0m));
                CHRKim = CHRKpm / (2.375 * t0m);
                CHRKdm = CHRKpm * (0.421 * t0m);
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                CHRKpm = 1;
                CHRKim = 0;
                CHRKdm = 0;
            }
            try
            { // Cálculo usando modelo ON com t0 medido
                CHRt0mKp1 = 0.95 * (tal1 / (K[0, 0] * t0on[0, 0]));
                CHRt0mKi1 = CHRt0mKp1 / (2.375 * t0on[0, 0]);
                CHRt0mKd1 = CHRt0mKp1 * (0.421 * t0on[0, 0]);
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                CHRt0mKp1 = 1;
                CHRt0mKi1 = 0;
                CHRt0mKd1 = 0;
            }
            try
            { // Cálculo usando modelo OFF com t0 medido
                CHRt0mKp2 = 0.95 * (tal2 / (K[0, 0] * t0off[0, 0]));
                CHRt0mKi2 = CHRt0mKp2 / (2.375 * t0off[0, 0]);
                CHRt0mKd2 = CHRt0mKp2 * (0.421 * t0off[0, 0]);
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                CHRt0mKp2 = 1;
                CHRt0mKi2 = 0;
                CHRt0mKd2 = 0;
            }
            try
            { // Cálculo usando modelo Média com t0 medido
                CHRt0mKpm = 0.95 * (talm / (K[0, 0] * t0mm));
                CHRt0mKim = CHRt0mKpm / (2.375 * t0mm);
                CHRt0mKdm = CHRt0mKpm * (0.421 * t0mm);
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                CHRt0mKpm = 1;
                CHRt0mKim = 0;
                CHRt0mKdm = 0;
            }
            // Calculo dos paramentros do PID usando IMC
            try
            { // Cálculo usando modelo ON com t0 calculado
                IMCKp1 = (2 * tal1 + t01) / (K[0, 0] * (2 * lambda + t01));
                IMCKi1 = IMCKp1 / (tal1 + (t01 / 2));
                IMCKd1 = IMCKp1 * ((tal1 * t01) / (2 * tal1 + t01));
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                IMCKp1 = 1;
                IMCKi1 = 0;
                IMCKd1 = 0;
            }
            try
            { // Cálculo usando modelo OFF com t0 calculado
                IMCKp2 = (2 * tal2 + t02) / (K[0, 0] * (2 * lambda + t02));
                IMCKi2 = IMCKp2 / (tal2 + (t02 / 2));
                IMCKd2 = IMCKp2 * ((tal2 * t02) / (2 * tal2 + t02));
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                IMCKp2 = 1;
                IMCKi2 = 0;
                IMCKd2 = 0;
            }
            try
            { // Cálculo usando modelo Média com t0 calculado
                IMCKpm = (2 * talm + t0m) / (K[0, 0] * (2 * lambda + t0m));
                IMCKim = IMCKpm / (talm + (t0m / 2));
                IMCKdm = IMCKpm * ((talm * t0m) / (2 * talm + t0m));
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                IMCKpm = 1;
                IMCKim = 0;
                IMCKdm = 0;
            }
            try
            { // Cálculo usando modelo ON com t0 medido
                IMCt0mKp1 = (2 * tal1 + t0on[0, 0]) / (K[0, 0] * (2 * lambda + t0on[0, 0]));
                IMCt0mKi1 = IMCt0mKp1 / (tal1 + (t0on[0, 0] / 2));
                IMCt0mKd1 = IMCt0mKp1 * ((tal1 * t0on[0, 0]) / (2 * tal1 + t0on[0, 0]));
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                IMCt0mKp1 = 1;
                IMCt0mKi1 = 0;
                IMCt0mKd1 = 0;
            }
            try
            { // Cálculo usando modelo OFF com t0 medido
                IMCt0mKp2 = (2 * tal2 + t0off[0, 0]) / (K[0, 0] * (2 * lambda + t0off[0, 0]));
                IMCt0mKi2 = IMCt0mKp2 / (tal2 + (t0off[0, 0] / 2));
                IMCt0mKd2 = IMCt0mKp2 * ((tal2 * t0off[0, 0]) / (2 * tal2 + t0off[0, 0]));
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                IMCt0mKp2 = 1;
                IMCt0mKi2 = 0;
                IMCt0mKd2 = 0;
            }
            try
            { // Cálculo usando modelo Média com t0 medido
                IMCt0mKpm = (2 * talm + t0mm) / (K[0, 0] * (2 * lambda + t0mm));
                IMCt0mKim = IMCt0mKpm / (talm + (t0mm / 2));
                IMCt0mKdm = IMCt0mKpm * ((talm * t0mm) / (2 * talm + t0mm));
            }
            catch
            { // Seta valores padrão caso haja erro ao calcular os ganhos
                IMCt0mKpm = 1;
                IMCt0mKim = 0;
                IMCt0mKdm = 0;
            }
            
            try
            { // Seleciona os ganhos de acordo com a modelo e metdodo selecionados
                if (RB1.Checked)
                {
                    if (RBCalculado.Checked)
                    {
                        if (RBON.Checked)
                        {
                            KP = ZNKp1 > 1000 ? 1000.00 : Math.Round(ZNKp1, 2);
                            KI = ZNKi1 > 1000 ? 1000.00 : Math.Round(ZNKi1, 2);
                            KD = ZNKd1 > 1000 ? 1000.00 : Math.Round(ZNKd1, 2);
                        }
                        else if (RBOFF.Checked)
                        {
                            KP = ZNKp2 > 1000 ? 1000.00 : Math.Round(ZNKp2, 2);
                            KI = ZNKi2 > 1000 ? 1000.00 : Math.Round(ZNKi2, 2);
                            KD = ZNKd2 > 1000 ? 1000.00 : Math.Round(ZNKd2, 2);
                        }
                        else if (RBMedia.Checked)
                        {
                            KP = ZNKpm > 1000 ? 1000.00 : Math.Round(ZNKpm, 2);
                            KI = ZNKim > 1000 ? 1000.00 : Math.Round(ZNKim, 2);
                            KD = ZNKdm > 1000 ? 1000.00 : Math.Round(ZNKdm, 2);
                        }
                    }
                    else if (RBMedido.Checked)
                    {
                        if (RBON.Checked)
                        {
                            KP = ZNt0mKp1 > 1000 ? 1000.00 : Math.Round(ZNt0mKp1, 2);
                            KI = ZNt0mKi1 > 1000 ? 1000.00 : Math.Round(ZNt0mKi1, 2);
                            KD = ZNt0mKd1 > 1000 ? 1000.00 : Math.Round(ZNt0mKd1, 2);
                        }
                        else if (RBOFF.Checked)
                        {
                            KP = ZNt0mKp2 > 1000 ? 1000.00 : Math.Round(ZNt0mKp2, 2);
                            KI = ZNt0mKi2 > 1000 ? 1000.00 : Math.Round(ZNt0mKi2, 2);
                            KD = ZNt0mKd2 > 1000 ? 1000.00 : Math.Round(ZNt0mKd2, 2);
                        }
                        else if (RBMedia.Checked)
                        {
                            KP = ZNt0mKpm > 1000 ? 1000.00 : Math.Round(ZNt0mKpm, 2);
                            KI = ZNt0mKim > 1000 ? 1000.00 : Math.Round(ZNt0mKim, 2);
                            KD = ZNt0mKdm > 1000 ? 1000.00 : Math.Round(ZNt0mKdm, 2);
                        }
                    }
                }
                else if (RB2.Checked)
                {
                    if (RBCalculado.Checked)
                    {
                        if (RBON.Checked)
                        {
                            KP = IAEKp1 > 1000 ? 1000.00 : Math.Round(IAEKp1, 2);
                            KI = IAEKi1 > 1000 ? 1000.00 : Math.Round(IAEKi1, 2);
                            KD = IAEKd1 > 1000 ? 1000.00 : Math.Round(IAEKd1, 2);
                        }
                        else if (RBOFF.Checked)
                        {
                            KP = IAEKp2 > 1000 ? 1000.00 : Math.Round(IAEKp2, 2);
                            KI = IAEKi2 > 1000 ? 1000.00 : Math.Round(IAEKi2, 2);
                            KD = IAEKd2 > 1000 ? 1000.00 : Math.Round(IAEKd2, 2);
                        }
                        else if (RBMedia.Checked)
                        {
                            KP = IAEKpm > 1000 ? 1000.00 : Math.Round(IAEKpm, 2);
                            KI = IAEKim > 1000 ? 1000.00 : Math.Round(IAEKim, 2);
                            KD = IAEKdm > 1000 ? 1000.00 : Math.Round(IAEKdm, 2);
                        }
                    }
                    else if (RBMedido.Checked)
                    {
                        if (RBON.Checked)
                        {
                            KP = IAEt0mKp1 > 1000 ? 1000.00 : Math.Round(IAEt0mKp1, 2);
                            KI = IAEt0mKi1 > 1000 ? 1000.00 : Math.Round(IAEt0mKi1, 2);
                            KD = IAEt0mKd1 > 1000 ? 1000.00 : Math.Round(IAEt0mKd1, 2);
                        }
                        else if (RBOFF.Checked)
                        {
                            KP = IAEt0mKp2 > 1000 ? 1000.00 : Math.Round(IAEt0mKp2, 2);
                            KI = IAEt0mKi2 > 1000 ? 1000.00 : Math.Round(IAEt0mKi2, 2);
                            KD = IAEt0mKd2 > 1000 ? 1000.00 : Math.Round(IAEt0mKd2, 2);
                        }
                        else if (RBMedia.Checked)
                        {
                            KP = IAEt0mKpm > 1000 ? 1000.00 : Math.Round(IAEt0mKpm, 2);
                            KI = IAEt0mKim > 1000 ? 1000.00 : Math.Round(IAEt0mKim, 2);
                            KD = IAEt0mKdm > 1000 ? 1000.00 : Math.Round(IAEt0mKdm, 2);
                        }
                    }
                }
                else if (RB3.Checked)
                {
                    if (RBCalculado.Checked)
                    {
                        if (RBON.Checked)
                        {
                            KP = CHRKp1 > 1000 ? 1000.00 : Math.Round(CHRKp1, 2);
                            KI = CHRKi1 > 1000 ? 1000.00 : Math.Round(CHRKi1, 2);
                            KD = CHRKd1 > 1000 ? 1000.00 : Math.Round(CHRKd1, 2);
                        }
                        else if (RBOFF.Checked)
                        {
                            KP = CHRKp2 > 1000 ? 1000.00 : Math.Round(CHRKp2, 2);
                            KI = CHRKi2 > 1000 ? 1000.00 : Math.Round(CHRKi2, 2);
                            KD = CHRKd2 > 1000 ? 1000.00 : Math.Round(CHRKd2, 2);
                        }
                        else if (RBMedia.Checked)
                        {
                            KP = CHRKpm > 1000 ? 1000.00 : Math.Round(CHRKpm, 2);
                            KI = CHRKim > 1000 ? 1000.00 : Math.Round(CHRKim, 2);
                            KD = CHRKdm > 1000 ? 1000.00 : Math.Round(CHRKdm, 2);
                        }
                    }
                    else if (RBMedido.Checked)
                    {
                        if (RBON.Checked)
                        {
                            KP = CHRt0mKp1 > 1000 ? 1000.00 : Math.Round(CHRt0mKp1, 2);
                            KI = CHRt0mKi1 > 1000 ? 1000.00 : Math.Round(CHRt0mKi1, 2);
                            KD = CHRt0mKd1 > 1000 ? 1000.00 : Math.Round(CHRt0mKd1, 2);
                        }
                        else if (RBOFF.Checked)
                        {
                            KP = CHRt0mKp2 > 1000 ? 1000.00 : Math.Round(CHRt0mKp2, 2);
                            KI = CHRt0mKi2 > 1000 ? 1000.00 : Math.Round(CHRt0mKi2, 2);
                            KD = CHRt0mKd2 > 1000 ? 1000.00 : Math.Round(CHRt0mKd2, 2);
                        }
                        else if (RBMedia.Checked)
                        {
                            KP = CHRt0mKpm > 1000 ? 1000.00 : Math.Round(CHRt0mKpm, 2);
                            KI = CHRt0mKim > 1000 ? 1000.00 : Math.Round(CHRt0mKim, 2);
                            KD = CHRt0mKdm > 1000 ? 1000.00 : Math.Round(CHRt0mKdm, 2);
                        }
                    }
                }
                else if (RB4.Checked)
                {
                    if (RBCalculado.Checked)
                    {
                        if (RBON.Checked)
                        {
                            KP = IMCKp1 > 1000 ? 1000.00 : Math.Round(IMCKp1, 2);
                            KI = IMCKi1 > 1000 ? 1000.00 : Math.Round(IMCKi1, 2);
                            KD = IMCKd1 > 1000 ? 1000.00 : Math.Round(IMCKd1, 2);
                        }
                        else if (RBOFF.Checked)
                        {
                            KP = IMCKp2 > 1000 ? 1000.00 : Math.Round(IMCKp2, 2);
                            KI = IMCKi2 > 1000 ? 1000.00 : Math.Round(IMCKi2, 2);
                            KD = IMCKd2 > 1000 ? 1000.00 : Math.Round(IMCKd2, 2);
                        }
                        else if (RBMedia.Checked)
                        {
                            KP = IMCKpm > 1000 ? 1000.00 : Math.Round(IMCKpm, 2);
                            KI = IMCKim > 1000 ? 1000.00 : Math.Round(IMCKim, 2);
                            KD = IMCKdm > 1000 ? 1000.00 : Math.Round(IMCKdm, 2);
                        }
                    }
                    else if (RBMedido.Checked)
                    {
                        if (RBON.Checked)
                        {
                            KP = IMCt0mKp1 > 1000 ? 1000.00 : Math.Round(IMCt0mKp1, 2);
                            KI = IMCt0mKi1 > 1000 ? 1000.00 : Math.Round(IMCt0mKi1, 2);
                            KD = IMCt0mKd1 > 1000 ? 1000.00 : Math.Round(IMCt0mKd1, 2);
                        }
                        else if (RBOFF.Checked)
                        {
                            KP = IMCt0mKp2 > 1000 ? 1000.00 : Math.Round(IMCt0mKp2, 2);
                            KI = IMCt0mKi2 > 1000 ? 1000.00 : Math.Round(IMCt0mKi2, 2);
                            KD = IMCt0mKd2 > 1000 ? 1000.00 : Math.Round(IMCt0mKd2, 2);
                        }
                        else if (RBMedia.Checked)
                        {
                            KP = IMCt0mKpm > 1000 ? 1000.00 : Math.Round(IMCt0mKpm, 2);
                            KI = IMCt0mKim > 1000 ? 1000.00 : Math.Round(IMCt0mKim, 2);
                            KD = IMCt0mKdm > 1000 ? 1000.00 : Math.Round(IMCt0mKdm, 2);
                        }
                    }
                } // Lógica de bypass para evitar que sejam enviados comandos desnecessários
                bypass = true;
                while ((NKp.Value != Convert.ToDecimal(KP)) ||
                        (NKi.Value != Convert.ToDecimal(KI)) ||
                        (NKd.Value != Convert.ToDecimal(KD)))
                {
                    NKp.Value = Convert.ToDecimal(KP);
                    NKi.Value = Convert.ToDecimal(KI);
                    NKd.Value = Convert.ToDecimal(KD);
                }
            }
            catch { }
            bypass = false;
            // Escreve os valores encontrados no FORM
            TBt0onM.Text = t0on[0, 0].ToString("0.00");
            TBt0on1.Text = t0on[1, 0].ToString("0.00");
            TBt0on2.Text = t0on[2, 0].ToString("0.00");
            TBt0on3.Text = t0on[3, 0].ToString("0.00");
            TBt0on4.Text = t0on[4, 0].ToString("0.00");
            TBt0offM.Text = t0off[0, 0].ToString("0.00");
            TBt0off1.Text = t0off[1, 0].ToString("0.00");
            TBt0off2.Text = t0off[2, 0].ToString("0.00");
            TBt0off3.Text = t0off[3, 0].ToString("0.00");
            TBt0off4.Text = t0off[4, 0].ToString("0.00");
            TBTonM.Text = Ton[0, 0].ToString("0.00");
            TBTon1.Text = Ton[1, 0].ToString("0.00");
            TBTon2.Text = Ton[2, 0].ToString("0.00");
            TBTon3.Text = Ton[3, 0].ToString("0.00");
            TBTon4.Text = Ton[4, 0].ToString("0.00");
            TBToffM.Text = Toff[0, 0].ToString("0.00");
            TBToff1.Text = Toff[1, 0].ToString("0.00");
            TBToff2.Text = Toff[2, 0].ToString("0.00");
            TBToff3.Text = Toff[3, 0].ToString("0.00");
            TBToff4.Text = Toff[4, 0].ToString("0.00");
            TBpicoM.Text = Au[0, 0].ToString("0.00");
            TBpico1.Text = Au[1, 0].ToString("0.00");
            TBpico2.Text = Au[2, 0].ToString("0.00");
            TBpico3.Text = Au[3, 0].ToString("0.00");
            TBpico4.Text = Au[4, 0].ToString("0.00");
            TBvaleM.Text = Ad[0, 0].ToString("0.00");
            TBvale1.Text = Ad[1, 0].ToString("0.00");
            TBvale2.Text = Ad[2, 0].ToString("0.00");
            TBvale3.Text = Ad[3, 0].ToString("0.00");
            TBvale4.Text = Ad[4, 0].ToString("0.00");
            TBIerroM.Text = IntERR[0, 0].ToString("0.00");
            TBIerro1.Text = IntERR[1, 0].ToString("0.00");
            TBIerro2.Text = IntERR[2, 0].ToString("0.00");
            TBIerro3.Text = IntERR[3, 0].ToString("0.00");
            TBIerro4.Text = IntERR[4, 0].ToString("0.00");
            TBIoutM.Text = IntOUT[0, 0].ToString("0.00");
            TBIout1.Text = IntOUT[1, 0].ToString("0.00");
            TBIout2.Text = IntOUT[2, 0].ToString("0.00");
            TBIout3.Text = IntOUT[3, 0].ToString("0.00");
            TBIout4.Text = IntOUT[4, 0].ToString("0.00");
            TBKM.Text = K[0, 0].ToString("0.00");
            TBK1.Text = K[0, 0].ToString("0.00");
            TBK2.Text = K[0, 0].ToString("0.00");
            TBK3.Text = K[0, 0].ToString("0.00");
            TBK4.Text = K[0, 0].ToString("0.00");
            TBmVP.Text = mVP.ToString("0.00");
            TBmOUT.Text = mOUT.ToString("0.00");
            numerador.Text = K[0, 0].ToString("0.00");
            if (RBON.Checked)
            {
                divisor.Text = "(" + tal1.ToString("0.00") + " s + 1)";
                if (RBMedido.Checked)
                    expoente.Text = "-" + (t0on[0, 0]).ToString("0.00") + " s";
                else
                    expoente.Text = "-" + (t01).ToString("0.00") + " s";
            }
            else if (RBOFF.Checked)
            {
                divisor.Text = "(" + tal2.ToString("0.00") + " s + 1)";
                if (RBMedido.Checked)
                    expoente.Text = "-" + (t0off[0, 0]).ToString("0.00") + " s";
                else
                    expoente.Text = "-" + (t02).ToString("0.00") + " s";
            }
            else if (RBMedia.Checked)
            {
                divisor.Text = "(" + talm.ToString("0.00") + " s + 1)";
                if (RBMedido.Checked)
                    expoente.Text = "-" + (t0mm).ToString("0.00") + " s";
                else
                    expoente.Text = "-" + (t0m).ToString("0.00") + " s";
            }
            f2 = false; // Desaciona a flag de processamento de dados
        }
        // Função para plotar o gráfico e escrever VP e OUT na tela do programa
        private void AtualizacaoGrafico(object sender, EventArgs e)
        {
            if (RBAtualizando.Checked)
            { // Opção de gráfico atualizando com os últimos valores em uma faixa de tempo determinada pela variável 'tamgra' 
                Grafico.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(DicArduino["A"]);
                Grafico.ChartAreas[0].AxisX.Minimum = Convert.ToDouble(DicArduino["A"]) - tamgra;
            }
            else if (RBEstatico.Checked)
            { // Opção de gráfico estático começando por 'inicio' extendendo por uma faixa de tempo determinada pela variável 'tamgra'
                Grafico.ChartAreas[0].AxisX.Maximum = inicio + tamgra;
                Grafico.ChartAreas[0].AxisX.Minimum = inicio;
            }
            else if (RBParametrizacao.Checked)
            { // Opção de gráfico estático começando por 'IniRele' extendendo até 'FimRele'
                Grafico.ChartAreas[0].AxisX.Maximum = FimRele;
                Grafico.ChartAreas[0].AxisX.Minimum = IniRele;
            }
            Grafico.ChartAreas[0].AxisY.Maximum = GYmax;          // Define o valor máximo do eixo Y
            Grafico.ChartAreas[0].AxisY.Minimum = GYmin;          // Define o valor mínimo do eixo Y 
            Grafico.Series["OUT"].XValueMember = "ms";            // Define os valores do eixo X para plotar OUT   
            Grafico.Series["OUT"].YValueMembers = "OUT";          // Define os valores de OUT para plotar (saída do controlador)
            Grafico.Series["INP"].XValueMember = "ms";            // Define os valores do eixo X para plotar INP  
            Grafico.Series["INP"].YValueMembers = "INP";          // Define os valores de INP para plotar (saída do processo)
            //Grafico.Series["SP"].XValueMember = "ms";             // Define os valores do eixo X para plotar SP
            //Grafico.Series["SP"].YValueMembers = "SP";            // Define os valores de SP para plotar (setpoint)
            Grafico.DataSource = databaseTCCDataSet1.TabelaDados; // Busca os pontos armazenados no banco de dados
            Grafico.DataBind();                                   // Plota o gráfico
            TBOUT.Text = DicArduino["E"];                         // Exibe no FORM o valor da saída do controlador
            TBVP.Text = DicArduino["D"];                          // Exibe no FORM o valor da saída do processo
            f2 = false; // Desaciona a flag de processamento de dados
        }
        // Função para receber os dados para inicialização do FORM vindos do Arduino
        private void Inicializacao(object sender, EventArgs e)
        {
            setpoint = Convert.ToDouble(DicArduino["B"]);         // Recebe o valor do setpoint
            sinalop = Convert.ToDouble(DicArduino["C"]);          // Recebe o valor do sinal de operação
            acao = Convert.ToInt32(DicArduino["K"]);              // Recebe o valor do sinal de operação
            his = Convert.ToDouble(DicArduino["o"]);              // Recebe o valor da histerese do relé
            biashis = Convert.ToDouble(DicArduino["p"]);          // Recebe o valor do bias da histerese do relé
            amp = Convert.ToDouble(DicArduino["q"]);              // Recebe o valor da amplitude do relé
            biasamp = Convert.ToDouble(DicArduino["r"]);          // Recebe o valor do bias da amplitude do relé
            modelo = Convert.ToInt32(DicArduino["u"]);            // Recebe o modelo gravado no arduino
            malha = Convert.ToInt32(DicArduino["v"]);             // Recebe a malha em operação 
            metodo = Convert.ToInt32(DicArduino["w"]);            // Recebe o método de sintonia gravado no arduino
            sampletime = Convert.ToDouble(DicArduino["x"]);       // Recebe o valor da taxa de amostragem do controlador
            KP = Convert.ToDouble(DicArduino["y"]);               // Recebe o valor ganho proporcional do controlador
            KI = Convert.ToDouble(DicArduino["z"]);               // Recebe o valor ganho integral do controlador
            KD = Convert.ToDouble(DicArduino["{"]);               // Recebe o valor ganho derivativo do controlador
            try
            { // Lógica de bypass para evitar que sejam enviados comandos desnecessários
                bypass = true;
                while ((NSetpoint.Value != Convert.ToDecimal(setpoint)) ||
                       (NSO.Value != Convert.ToDecimal(sinalop)) ||
                       (NAmplitudeRele.Value != Convert.ToDecimal(amp)) ||
                       (NBiasAmplitude.Value != Convert.ToDecimal(biasamp)) ||
                       (NHistereseRele.Value != Convert.ToDecimal(his)) ||
                       (NBiasHisterese.Value != Convert.ToDecimal(biashis)) ||
                       (NVPvar.Value != Convert.ToDecimal(VPvar)) ||
                       (NVPmax.Value != Convert.ToDecimal(VPmax)) ||
                       (NVPmin.Value != Convert.ToDecimal(VPmin)) ||
                       (NOUTvar.Value != Convert.ToDecimal(OUTvar)) ||
                       (NOUTmax.Value != Convert.ToDecimal(OUTmax)) ||
                       (NOUTmin.Value != Convert.ToDecimal(OUTmin)) ||
                       (NKp.Value != Convert.ToDecimal(KP)) ||
                       (NKi.Value != Convert.ToDecimal(KI)) ||
                       (NKd.Value != Convert.ToDecimal(KD)) ||
                       (NTAmostragem.Value != Convert.ToDecimal(sampletime)))
                {
                    NSetpoint.Value = Convert.ToDecimal(setpoint);
                    NSO.Value = Convert.ToDecimal(sinalop);
                    NAmplitudeRele.Value = Convert.ToDecimal(amp);
                    NHistereseRele.Value = Convert.ToDecimal(his);
                    NBiasAmplitude.Value = Convert.ToDecimal(biasamp);
                    NBiasHisterese.Value = Convert.ToDecimal(biashis);
                    NVPvar.Value = Convert.ToDecimal(VPvar);
                    NVPmax.Value = Convert.ToDecimal(VPmax);
                    NVPmin.Value = Convert.ToDecimal(VPmin);
                    NOUTvar.Value = Convert.ToDecimal(OUTvar);
                    NOUTmax.Value = Convert.ToDecimal(OUTmax);
                    NOUTmin.Value = Convert.ToDecimal(OUTmin);
                    NKp.Value = Convert.ToDecimal(KP);
                    NKi.Value = Convert.ToDecimal(KI);
                    NKd.Value = Convert.ToDecimal(KD);
                    NTAmostragem.Value = Convert.ToDecimal(sampletime);
                }
            }
            catch { }
            bypass = false;
            // Atualiza no FORM o método gravado no Arduino
            if (DicArduino["w"] == "1.00")
            {
                RB1.Checked = true;
                RB2.Checked = false;
                RB3.Checked = false;
                RB4.Checked = false;
            }
            else if (DicArduino["w"] == "2.00")
            {
                RB1.Checked = false;
                RB2.Checked = true;
                RB3.Checked = false;
                RB4.Checked = false;
            }
            else if (DicArduino["w"] == "3.00")
            {
                RB1.Checked = false;
                RB2.Checked = false;
                RB3.Checked = true;
                RB4.Checked = false;
            }
            else if (DicArduino["w"] == "4.00")
            {
                RB1.Checked = false;
                RB2.Checked = false;
                RB3.Checked = false;
                RB4.Checked = true;
            }
            // Atualiza no FORM o modelo gravado no Arduino
            if (DicArduino["u"] == "1.00")
            {
                RBON.Checked = true;
                RBOFF.Checked = false;
                RBMedia.Checked = false;
                RBCalculado.Checked = true;
                RBMedido.Checked = false;
            }
            else if (DicArduino["u"] == "2.00")
            {
                RBON.Checked = false;
                RBOFF.Checked = true;
                RBMedia.Checked = false;
                RBCalculado.Checked = true;
                RBMedido.Checked = false;
            }
            else if (DicArduino["u"] == "3.00")
            {
                RBON.Checked = false;
                RBOFF.Checked = false;
                RBMedia.Checked = true;
                RBCalculado.Checked = true;
                RBMedido.Checked = false;
            }
            else if (DicArduino["u"] == "4.00")
            {
                RBON.Checked = true;
                RBOFF.Checked = false;
                RBMedia.Checked = false;
                RBCalculado.Checked = false;
                RBMedido.Checked = true;
            }
            else if (DicArduino["u"] == "5.00")
            {
                RBON.Checked = false;
                RBOFF.Checked = true;
                RBMedia.Checked = false;
                RBCalculado.Checked = false;
                RBMedido.Checked = true;
            }
            else if (DicArduino["u"] == "6.00")
            {
                RBON.Checked = false;
                RBOFF.Checked = false;
                RBMedia.Checked = true;
                RBCalculado.Checked = false;
                RBMedido.Checked = true;
            }
            if (DicArduino["v"] == "0.00")
            {
                RBAberta.Checked = true;
                RBReleUP.Checked = false;
                RBReleDown.Checked = false;
                RBPIDBrett.Checked = false;
                RBPIDParalelo.Checked = false;
            }
            else if (DicArduino["v"] == "1.00")
            {
                RBAberta.Checked = false;
                RBReleUP.Checked = true;
                RBReleDown.Checked = false;
                RBPIDBrett.Checked = false;
                RBPIDParalelo.Checked = false;
            }
            else if (DicArduino["v"] == "2.00")
            {
                RBAberta.Checked = false;
                RBReleUP.Checked = false;
                RBReleDown.Checked = true;
                RBPIDBrett.Checked = false;
                RBPIDParalelo.Checked = false;
            }
            else if (DicArduino["v"] == "3.00")
            {
                RBAberta.Checked = false;
                RBReleUP.Checked = false;
                RBReleDown.Checked = false;
                RBPIDBrett.Checked = true;
                RBPIDParalelo.Checked = false;
            }
            else if (DicArduino["v"] == "4.00")
            {
                RBAberta.Checked = false;
                RBReleUP.Checked = false;
                RBReleDown.Checked = false;
                RBPIDBrett.Checked = false;
                RBPIDParalelo.Checked = true;
            }
            if ((acao == 1) && (BTAcao.Text == "Ação Reversa"))
                BTAcao.Text = "Ação Direta";
            else if ((acao == -1) && (BTAcao.Text == "Ação Direta"))
                BTAcao.Text = "Ação Reversa";
            f2 = false; // Desaciona a flag de processamento de dados
        }
        // Função para receber o valor de setpoint alterado pela lógica de tracking do Arduino
        private void TrackSP(object sender, EventArgs e)
        {
            try
            { // Lógica de bypass para evitar que sejam enviados comandos desnecessários
                bypass = true;
                while ((NSetpoint.Value != Convert.ToDecimal(DicArduino["B"])) || (NSO.Value != Convert.ToDecimal(DicArduino["C"])))
                {
                    NSetpoint.Value = Convert.ToDecimal(DicArduino["B"]); // Atualiza no FORM o valor do setpoint
                    NSO.Value = Convert.ToDecimal(DicArduino["C"]);       // Atualiza no FORM o valor do sinal de operação 
                }
            }
            catch { }
            bypass = false;
            f2 = false; // Desaciona a flag de processamento de dados
        }
        // Função para escrever o pacote de dados recebidos (aux1) na tela do FORM
        private void RecebeArduino(object sender, EventArgs e)
        { 
            TBRecebeArduino.Text += aux1;                                 // Adiciona no texto o ultimo pacote de dados recebido
            TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
            TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
        }
        // Função para atualizar o display de VP e OUT no FORM
        private void AtualizaVPOUT(object sender, EventArgs e)
        {
            TBOUT.Text = DicArduino["E"]; // Exibe no FORM o valor da saída do controlador
            TBVP.Text = DicArduino["D"];  // Exibe no FORM o valor da saída do processo
            f2 = false;                   // Desaciona a flag de processamento de dados
        }
        // Função para selecionar malha aberta após conclusão da excitação do relé
        private void Malha0(object sender, EventArgs e)
        {
            RBReleUP.Checked = false;
            RBReleDown.Checked = false;
            RBPIDBrett.Checked = false;
            RBPIDParalelo.Checked = false;
            RBAberta.Checked = true;
        }
        // Função para liberar comandos do FORM quando o relé não está sendo utilizado
        private void PermissaoRele(object sender, EventArgs e)
        {
            GBMalha.Enabled = true;
            GBPID.Enabled = true;
            GBRELE.Enabled = true;
            GBestabilidade.Enabled = true;
            RBON.Enabled = true;
            RBOFF.Enabled = true;
            RBMedia.Enabled = true;
            RBCalculado.Enabled = true;
            RBMedido.Enabled = true;
            BTEnviar.Enabled = true;
        }
        // Função para bloquear comandos do FORM quando o relé estiver sendo utilizado
        private void RestricaoRele(object sender, EventArgs e)
        {
            GBMalha.Enabled = false;
            GBPID.Enabled = false;
            GBRELE.Enabled = false;
            GBestabilidade.Enabled = false;
            RBON.Enabled = false;
            RBOFF.Enabled = false;
            RBMedia.Enabled = false;
            RBCalculado.Enabled = false;
            RBMedido.Enabled = false;
            BTEnviar.Enabled = false;
        }
        // Função para liberar ou bloquear a opção relé de acordo com a estabilidade do sistema
        private void EstabilidadeRele(object sender, EventArgs e)
        {
            RBReleUP.Enabled = !RBReleUP.Enabled;
            RBReleDown.Enabled = !RBReleDown.Enabled;
        }
        //// EVENTOS DE COMANDOS DO FORM \\\\
        private void BTGrafico_Click(object sender, EventArgs e)
        {
            if (BTGrafico.Text == "Plotar")
            {
                BTGrafico.Text = "Reset BD";             // Altera o título do botão
            }
            else if (BTGrafico.Text == "Reset BD")
            {
                databaseTCCDataSet1.TabelaDados.Clear(); // Limpa o banco de dados 
                Grafico.DataBind();                      // Limpa o gráfico
                BTGrafico.Text = "Plotar";               // Altera o título do botão
            }
        }

        private void NSetpoint_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o setpoint
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 2;  // Pré-seleciona o comando para alterar o Setpoint
                else              // Escreve no FORM que a porta Serial está ocupada 
                { 
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NSO_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o sinal de operação
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 3;  // Pré-seleciona o comando para alterar o Sinal de Operação
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NVPvar_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar a variação de VP permitida pela lógica de estabilidade do Arduino
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 4;  // Pré-seleciona o comando para alterar VPvar 
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }


        private void NVPmax_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o valor máximo de VP permitido pela lógica de estabilidade do Arduino
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 5;  // Pré-seleciona o comando para alterar VPmax 
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NVPmin_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o valor mínimo de VP permitido pela lógica de estabilidade do Arduino
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 6;  // Pré-seleciona o comando para alterar VPmin 
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NOUTvar_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar a variação de OUT permitida pela lógica de estabilidade do Arduino
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 7;  // Pré-seleciona o comando para alterar OUTvar 
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NOUTmax_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o valor máximo de OUT permitido pela lógica de estabilidade do Arduino
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 8;  // Pré-seleciona o comando para alterar OUTmax 
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NOUTmin_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o valor mínimo de OUT permitido pela lógica de estabilidade do Arduino
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 9;  // Pré-seleciona o comando para alterar OUTmin 
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NLambda_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o valor de lambda usado no método IMC
            if (!bypass) // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 10; // Pré-seleciona o comando para alterar o lambda 
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }

        }

        private void BTAcao_Click(object sender, EventArgs e)
        {                         // Evento que altera a ação do controlador
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 11; // Pré-seleciona o comando para alterar a ação do controlador 
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NHisterese_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o valor da histerese do relé 
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 47; // Pré-seleciona o comando para alterar a Histerese do Relé 
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }
        
        private void NBiasHisterese_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o valor do bias da histerese
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 48; // Pré-seleciona o comando para alterar o Bias da Histerese
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NAmplitudeRele_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o valor da amplitude do relé 
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 49; // Pré-seleciona o comando para alterar a Amplitude do Relé
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NBiasAmplitude_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o valor do bias da amplitude
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 50; // Pré-seleciona o comando para alterar o Bias da Amplitude
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RBON_Click(object sender, EventArgs e)
        {                           // Evento usado para alterar o modelo 
            if (!bypass)            // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0)   // Confere se não há comando pré-selecionado
                {
                    if (RBCalculado.Checked)
                        modelo = 1; // Seleciona modelo OFF com t0 calculado
                    else if (RBMedido.Checked)
                        modelo = 4; // Seleciona modelo OFF com t0 medido
                    proxcom = 53;   // Pré-seleciona o comando para alterar o modelo
                }
                else                // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RBOFF_Click(object sender, EventArgs e)
        {                           // Evento usado para alterar o modelo 
            if (!bypass)            // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0)   // Confere se não há comando pré-selecionado
                {
                    if (RBCalculado.Checked)
                        modelo = 2; // Seleciona modelo OFF com t0 calculado
                    else if (RBMedido.Checked)
                        modelo = 5; // Seleciona modelo OFF com t0 medido
                    proxcom = 53;   // Pré-seleciona o comando para alterar o modelo
                }
                else                // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RBMedia_Click(object sender, EventArgs e)
        {                           // Evento usado para alterar o modelo 
            if (!bypass)            // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0)   // Confere se não há comando pré-selecionado
                {
                    if (RBCalculado.Checked)
                        modelo = 3; // Seleciona modelo Media com t0 calculado
                    else if (RBMedido.Checked)
                        modelo = 6; // Seleciona modelo Media com t0 medido
                    proxcom = 53;   // Pré-seleciona o comando para alterar o modelo
                }
                else                // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RBCalculado_Click(object sender, EventArgs e)
        {                           // Evento usado para alterar o modelo 
            if (!bypass)            // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0)   // Confere se não há comando pré-selecionado
                {
                    if (RBON.Checked)
                        modelo = 1; // Seleciona modelo ON com t0 calculado
                    else if (RBOFF.Checked)
                        modelo = 2; // Seleciona modelo OFF com t0 calculado
                    else if (RBMedia.Checked)
                        modelo = 3; // Seleciona modelo Media com t0 calculado
                    proxcom = 53;   // Pré-seleciona o comando para alterar o modelo
                }
                else                // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RBMedido_Click(object sender, EventArgs e)
        {                           // Evento usado para alterar o modelo 
            if (!bypass)            // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0)   // Confere se não há comando pré-selecionado
                {
                    if (RBON.Checked)
                        modelo = 4; // Seleciona modelo ON com t0 medido
                    else if (RBOFF.Checked)
                        modelo = 5; // Seleciona modelo OFF com t0 medido
                    else if (RBMedia.Checked)
                        modelo = 6; // Seleciona modelo Media com t0 medido
                    proxcom = 53;   // Pré-seleciona o comando para alterar o modelo
                }
                else                // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RBAberta_Click(object sender, EventArgs e)
        {                         // Evento usado para alterar a malha de operação 
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                {
                    malha = 0;    // Seleciona malha Aberta
                    proxcom = 54; // Pré-seleciona o comando para alterar a malha
                }
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RBReleUP_Click(object sender, EventArgs e)
        {                         // Evento usado para alterar a malha de operação
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                {
                    malha = 1;    // Seleciona malha Relé UP
                    proxcom = 54; // Pré-seleciona o comando para alterar a malha
                }
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RBReleDown_Click(object sender, EventArgs e)
        {                         // Evento usado para alterar a malha de operação
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                {
                    malha = 2;    // Seleciona malha Relé Down
                    proxcom = 54; // Pré-seleciona o comando para alterar a malha
                }
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RBPIDBrett_Click(object sender, EventArgs e)
        {                         // Evento usado para alterar a malha de operação
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                {
                    malha = 3;    // Seleciona malha PID Brett
                    proxcom = 54; // Pré-seleciona o comando para alterar a malha
                }
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RBPIDParalelo_Click(object sender, EventArgs e)
        {                         // Evento usado para alterar a malha de operação
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                {
                    malha = 4;    // Seleciona malha PID Paralelo
                    proxcom = 54; // Pré-seleciona o comando para alterar a malha
                }
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RB1_Click(object sender, EventArgs e)
        {                         // Evento usado para alterar o método de sintonia
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                {
                    metodo = 1;   // Seleciona o metodo Ziegler e Nichols
                    proxcom = 55; // Pré-seleciona o comando para alterar a metodo
                }
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RB2_Click(object sender, EventArgs e)
        {                         // Evento usado para alterar o método de sintonia
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                {
                    metodo = 2;   // Seleciona o metodo IAE
                    proxcom = 55; // Pré-seleciona o comando para alterar a metodo
                }
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RB3_Click(object sender, EventArgs e)
        {                         // Evento usado para alterar o método de sintonia
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                {
                    metodo = 3;   // Seleciona o metodo CHR
                    proxcom = 55; // Pré-seleciona o comando para alterar a metodo
                }
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void RB4_Click(object sender, EventArgs e)
        {                         // Evento usado para alterar o método de sintonia
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                {
                    metodo = 4;   // Seleciona o metodo IMC
                    proxcom = 55; // Pré-seleciona o comando para alterar a metodo
                }
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NTA_ValueChanged(object sender, EventArgs e)
        {
            if (!bypass) // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 56; // Pré-seleciona o comando para alterar a taxa de amostragem do PID
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }

        }

        private void NKp_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o valor do ganho proporcional
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 57; // Pré-seleciona o comando para alterar o ganho proporcional 
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NKi_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o valor do ganho integral
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 58; // Pré-seleciona o comando para alterar o ganho integral
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void NKd_ValueChanged(object sender, EventArgs e)
        {                         // Evento usado para alterar o valor do ganho derivativo
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 59; // Pré-seleciona o comando para alterar o ganho derivativo
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {                         // Evento usado para enviar a mensagem da caixa de texto 'Arduino' 
            if (!bypass)          // Lógica de bypass para evitar que sejam enviados comandos desnecessários
            {
                if (proxcom == 0) // Confere se não há comando pré-selecionado
                    proxcom = 62; // Pré-seleciona o comando para enviar o que estiver na caixa de texto 'Arduino' 
                else              // Escreve no FORM que a porta Serial está ocupada 
                {
                    TBRecebeArduino.Text += "\rComando não enviado Porta Serial ocupada, aguarde e tente reenviar o comando novamente\r";
                    TBRecebeArduino.SelectionStart = TBRecebeArduino.Text.Length; // Seleciona o inicio do texto
                    TBRecebeArduino.ScrollToCaret();                              // Arrasta o cursor do texto para o final
                }
            }
        }
        
        // Evento que seleciona opção de gráfico atualizando
        private void RBAtualizando_Click(object sender, EventArgs e)
        {
            RBAtualizando.Checked = true;
            RBEstatico.Checked = false;
            RBParametrizacao.Checked = false;
        }
        // Evento que seleciona opção de gráfico estático
        private void RBEstatico_Click(object sender, EventArgs e)
        {
            RBEstatico.Checked = true;
            RBAtualizando.Checked = false;
            RBParametrizacao.Checked = false;
        }
        // Evento que seleciona opção de gráfico no momento da parametrização
        private void RBParametrizacao_Click(object sender, EventArgs e)
        {
            RBParametrizacao.Checked = true;
            RBEstatico.Checked = false;
            RBAtualizando.Checked = false;

        }
        // Evento que altera a tamanho do eixo horizontal do gráfico (tempo (ms)) 
        private void NTempo_ValueChanged(object sender, EventArgs e)
        {
            tamgra = Convert.ToInt32(NDuracao.Value);
        }
        // Evento que altera o momento de ínicio do gráfico 
        private void NInicio_ValueChanged(object sender, EventArgs e)
        {
            inicio = Convert.ToDouble(NInicio.Value);
        }
        // Evento que altera o limite máximo do eixo Y do gráfico 
        private void NYmax_ValueChanged(object sender, EventArgs e)
        {
            if (NYmax.Value < NYmin.Value)
            { // Intertravamento para caso o operador digite um valor máximo menor que o mínimo
                GYmax = Convert.ToDouble(NYmin.Value) + 1;
                NYmax.Value = Convert.ToDecimal(GYmax);
            }
            else    
                GYmax = Convert.ToDouble(NYmax.Value);
        }
        // Evento que altera o limite mínimo do eixo Y do gráfico 
        private void NYmin_ValueChanged(object sender, EventArgs e)
        {
            if (NYmin.Value > NYmax.Value)
            { // Intertravamento para caso o operador digite um valor mínimo maior que o máximo
                GYmin = Convert.ToDouble(NYmax.Value) - 1;
                NYmin.Value = Convert.ToDecimal(GYmin);
            }
            else
                GYmin = Convert.ToDouble(NYmin.Value);
        }
        // Evento que dispara o temporizador 
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();                             // Desativa o temporizador
            if (close)                                 // Confere se a flag de desconexão está ativada 
                Invoke(new EventHandler(closeport));   // Chama função para desconectar a comunicação serial
            else
            {
                comando = 51;                          // Seleciona o comando para requisitar dados para Inicialização do FORM
                Invoke(new EventHandler(enviarDados)); // Chama função para enviar comando para o Arduino
                //MessageBox.Show("Timeout - falha na comunicação com Arduino", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
