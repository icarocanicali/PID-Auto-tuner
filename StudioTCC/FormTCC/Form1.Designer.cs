using System;

namespace TCC
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.GBPainelLateral = new System.Windows.Forms.GroupBox();
            this.GBestabilidade = new System.Windows.Forms.GroupBox();
            this.NVPvar = new System.Windows.Forms.NumericUpDown();
            this.NVPmin = new System.Windows.Forms.NumericUpDown();
            this.NOUTvar = new System.Windows.Forms.NumericUpDown();
            this.NOUTmin = new System.Windows.Forms.NumericUpDown();
            this.NVPmax = new System.Windows.Forms.NumericUpDown();
            this.Variacao = new System.Windows.Forms.Label();
            this.NOUTmax = new System.Windows.Forms.NumericUpDown();
            this.Maximo = new System.Windows.Forms.Label();
            this.Minimo = new System.Windows.Forms.Label();
            this.VPestabilidade = new System.Windows.Forms.Label();
            this.OUTestabilidade = new System.Windows.Forms.Label();
            this.GBMalha = new System.Windows.Forms.GroupBox();
            this.RBPIDParalelo = new System.Windows.Forms.RadioButton();
            this.RBReleDown = new System.Windows.Forms.RadioButton();
            this.RBReleUP = new System.Windows.Forms.RadioButton();
            this.RBAberta = new System.Windows.Forms.RadioButton();
            this.RBPIDBrett = new System.Windows.Forms.RadioButton();
            this.SinalOperacao = new System.Windows.Forms.Label();
            this.NSO = new System.Windows.Forms.NumericUpDown();
            this.Setpoint = new System.Windows.Forms.Label();
            this.NSetpoint = new System.Windows.Forms.NumericUpDown();
            this.GBArduino = new System.Windows.Forms.GroupBox();
            this.TBRecebeArduino = new System.Windows.Forms.TextBox();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.TBEnviaArduino = new System.Windows.Forms.TextBox();
            this.GBRELE = new System.Windows.Forms.GroupBox();
            this.NBiasHisterese = new System.Windows.Forms.NumericUpDown();
            this.NHistereseRele = new System.Windows.Forms.NumericUpDown();
            this.NBiasAmplitude = new System.Windows.Forms.NumericUpDown();
            this.BiasHisterese = new System.Windows.Forms.Label();
            this.NAmplitudeRele = new System.Windows.Forms.NumericUpDown();
            this.BiasAmplitude = new System.Windows.Forms.Label();
            this.HistereseRele = new System.Windows.Forms.Label();
            this.AmplitudeRele = new System.Windows.Forms.Label();
            this.GBPID = new System.Windows.Forms.GroupBox();
            this.NLambda = new System.Windows.Forms.NumericUpDown();
            this.RB4 = new System.Windows.Forms.RadioButton();
            this.NTAmostragem = new System.Windows.Forms.NumericUpDown();
            this.NKd = new System.Windows.Forms.NumericUpDown();
            this.NKi = new System.Windows.Forms.NumericUpDown();
            this.TaxaAmostragem = new System.Windows.Forms.Label();
            this.RB3 = new System.Windows.Forms.RadioButton();
            this.NKp = new System.Windows.Forms.NumericUpDown();
            this.Lambda = new System.Windows.Forms.Label();
            this.Kderivativo = new System.Windows.Forms.Label();
            this.RB2 = new System.Windows.Forms.RadioButton();
            this.Kintegral = new System.Windows.Forms.Label();
            this.RB1 = new System.Windows.Forms.RadioButton();
            this.Kproporcional = new System.Windows.Forms.Label();
            this.GBComunicacao = new System.Windows.Forms.GroupBox();
            this.GBstatus = new System.Windows.Forms.GroupBox();
            this.TaxaTransferencia = new System.Windows.Forms.NumericUpDown();
            this.BTConectar = new System.Windows.Forms.Button();
            this.BTAtualizar = new System.Windows.Forms.Button();
            this.portaseriallista = new System.Windows.Forms.ComboBox();
            this.LAu1 = new System.Windows.Forms.Label();
            this.LAd1 = new System.Windows.Forms.Label();
            this.LToff1 = new System.Windows.Forms.Label();
            this.LTon1 = new System.Windows.Forms.Label();
            this.TBpico1 = new System.Windows.Forms.TextBox();
            this.TBvale1 = new System.Windows.Forms.TextBox();
            this.TBToff1 = new System.Windows.Forms.TextBox();
            this.TBTon1 = new System.Windows.Forms.TextBox();
            this.Grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GBPainelInferior = new System.Windows.Forms.GroupBox();
            this.GBmedia = new System.Windows.Forms.GroupBox();
            this.TBToffM = new System.Windows.Forms.TextBox();
            this.TBIerroM = new System.Windows.Forms.TextBox();
            this.LToffM = new System.Windows.Forms.Label();
            this.TBvaleM = new System.Windows.Forms.TextBox();
            this.TBpicoM = new System.Windows.Forms.TextBox();
            this.TBKM = new System.Windows.Forms.TextBox();
            this.TBIoutM = new System.Windows.Forms.TextBox();
            this.LTonM = new System.Windows.Forms.Label();
            this.TBt0onM = new System.Windows.Forms.TextBox();
            this.Lt0onM = new System.Windows.Forms.Label();
            this.TBt0offM = new System.Windows.Forms.TextBox();
            this.Lt0offM = new System.Windows.Forms.Label();
            this.LAuM = new System.Windows.Forms.Label();
            this.TBTonM = new System.Windows.Forms.TextBox();
            this.LIoutM = new System.Windows.Forms.Label();
            this.LAdM = new System.Windows.Forms.Label();
            this.LKM = new System.Windows.Forms.Label();
            this.LIerroM = new System.Windows.Forms.Label();
            this.GBciclo4 = new System.Windows.Forms.GroupBox();
            this.TBToff4 = new System.Windows.Forms.TextBox();
            this.TBIerro4 = new System.Windows.Forms.TextBox();
            this.LToff4 = new System.Windows.Forms.Label();
            this.TBvale4 = new System.Windows.Forms.TextBox();
            this.TBpico4 = new System.Windows.Forms.TextBox();
            this.TBK4 = new System.Windows.Forms.TextBox();
            this.TBIout4 = new System.Windows.Forms.TextBox();
            this.LTon4 = new System.Windows.Forms.Label();
            this.TBt0on4 = new System.Windows.Forms.TextBox();
            this.Lt0on4 = new System.Windows.Forms.Label();
            this.TBt0off4 = new System.Windows.Forms.TextBox();
            this.Lt0off4 = new System.Windows.Forms.Label();
            this.LAu4 = new System.Windows.Forms.Label();
            this.TBTon4 = new System.Windows.Forms.TextBox();
            this.LIout4 = new System.Windows.Forms.Label();
            this.LAd4 = new System.Windows.Forms.Label();
            this.LK4 = new System.Windows.Forms.Label();
            this.LIerro4 = new System.Windows.Forms.Label();
            this.GBciclo2 = new System.Windows.Forms.GroupBox();
            this.TBToff2 = new System.Windows.Forms.TextBox();
            this.TBIerro2 = new System.Windows.Forms.TextBox();
            this.LToff2 = new System.Windows.Forms.Label();
            this.TBvale2 = new System.Windows.Forms.TextBox();
            this.TBpico2 = new System.Windows.Forms.TextBox();
            this.TBK2 = new System.Windows.Forms.TextBox();
            this.TBIout2 = new System.Windows.Forms.TextBox();
            this.LTon2 = new System.Windows.Forms.Label();
            this.TBt0on2 = new System.Windows.Forms.TextBox();
            this.Lt0on2 = new System.Windows.Forms.Label();
            this.TBt0off2 = new System.Windows.Forms.TextBox();
            this.Lt0off2 = new System.Windows.Forms.Label();
            this.LAu2 = new System.Windows.Forms.Label();
            this.TBTon2 = new System.Windows.Forms.TextBox();
            this.LIout2 = new System.Windows.Forms.Label();
            this.LAd2 = new System.Windows.Forms.Label();
            this.LK2 = new System.Windows.Forms.Label();
            this.LIerro2 = new System.Windows.Forms.Label();
            this.GBciclo3 = new System.Windows.Forms.GroupBox();
            this.TBToff3 = new System.Windows.Forms.TextBox();
            this.TBIerro3 = new System.Windows.Forms.TextBox();
            this.LToff3 = new System.Windows.Forms.Label();
            this.TBvale3 = new System.Windows.Forms.TextBox();
            this.TBpico3 = new System.Windows.Forms.TextBox();
            this.TBK3 = new System.Windows.Forms.TextBox();
            this.TBIout3 = new System.Windows.Forms.TextBox();
            this.LTon3 = new System.Windows.Forms.Label();
            this.TBt0on3 = new System.Windows.Forms.TextBox();
            this.Lt0on3 = new System.Windows.Forms.Label();
            this.TBt0off3 = new System.Windows.Forms.TextBox();
            this.Lt0off3 = new System.Windows.Forms.Label();
            this.LAu3 = new System.Windows.Forms.Label();
            this.TBTon3 = new System.Windows.Forms.TextBox();
            this.LIout3 = new System.Windows.Forms.Label();
            this.LAd3 = new System.Windows.Forms.Label();
            this.LK3 = new System.Windows.Forms.Label();
            this.LIerro3 = new System.Windows.Forms.Label();
            this.GBciclo1 = new System.Windows.Forms.GroupBox();
            this.TBIerro1 = new System.Windows.Forms.TextBox();
            this.TBK1 = new System.Windows.Forms.TextBox();
            this.TBIout1 = new System.Windows.Forms.TextBox();
            this.TBt0on1 = new System.Windows.Forms.TextBox();
            this.Lt0on1 = new System.Windows.Forms.Label();
            this.TBt0off1 = new System.Windows.Forms.TextBox();
            this.Lt0off1 = new System.Windows.Forms.Label();
            this.LIout1 = new System.Windows.Forms.Label();
            this.LK1 = new System.Windows.Forms.Label();
            this.LIerro1 = new System.Windows.Forms.Label();
            this.GBGrafico = new System.Windows.Forms.GroupBox();
            this.NYmin = new System.Windows.Forms.NumericUpDown();
            this.NYmax = new System.Windows.Forms.NumericUpDown();
            this.NDuracao = new System.Windows.Forms.NumericUpDown();
            this.NInicio = new System.Windows.Forms.NumericUpDown();
            this.BTGrafico = new System.Windows.Forms.Button();
            this.RBParametrizacao = new System.Windows.Forms.RadioButton();
            this.RBEstatico = new System.Windows.Forms.RadioButton();
            this.RBAtualizando = new System.Windows.Forms.RadioButton();
            this.Ymax = new System.Windows.Forms.Label();
            this.Inicio = new System.Windows.Forms.Label();
            this.Ymin = new System.Windows.Forms.Label();
            this.Duracao = new System.Windows.Forms.Label();
            this.GBProcesso = new System.Windows.Forms.GroupBox();
            this.GBModelo = new System.Windows.Forms.GroupBox();
            this.RBON = new System.Windows.Forms.RadioButton();
            this.RBOFF = new System.Windows.Forms.RadioButton();
            this.RBMedia = new System.Windows.Forms.RadioButton();
            this.GBAtraso = new System.Windows.Forms.GroupBox();
            this.RBMedido = new System.Windows.Forms.RadioButton();
            this.RBCalculado = new System.Windows.Forms.RadioButton();
            this.GBFuncao = new System.Windows.Forms.GroupBox();
            this.numerador = new System.Windows.Forms.Label();
            this.expoente = new System.Windows.Forms.Label();
            this.divisor = new System.Windows.Forms.Label();
            this.funcao = new System.Windows.Forms.Label();
            this.TBmVP = new System.Windows.Forms.TextBox();
            this.TBVP = new System.Windows.Forms.TextBox();
            this.TBmOUT = new System.Windows.Forms.TextBox();
            this.TBOUT = new System.Windows.Forms.TextBox();
            this.LmOUT = new System.Windows.Forms.Label();
            this.LVariavelControlada = new System.Windows.Forms.Label();
            this.LmVP = new System.Windows.Forms.Label();
            this.LVariavelProcesso = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serialPortTCC = new System.IO.Ports.SerialPort(this.components);
            this.databaseTCCDataSet1 = new TCC.DatabaseTCCDataSet();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BTAcao = new System.Windows.Forms.Button();
            this.GBPainelLateral.SuspendLayout();
            this.GBestabilidade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NVPvar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NVPmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NOUTvar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NOUTmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NVPmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NOUTmax)).BeginInit();
            this.GBMalha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NSO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NSetpoint)).BeginInit();
            this.GBArduino.SuspendLayout();
            this.GBRELE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NBiasHisterese)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NHistereseRele)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBiasAmplitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NAmplitudeRele)).BeginInit();
            this.GBPID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NLambda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NTAmostragem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NKd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NKi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NKp)).BeginInit();
            this.GBComunicacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaxaTransferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grafico)).BeginInit();
            this.GBPainelInferior.SuspendLayout();
            this.GBmedia.SuspendLayout();
            this.GBciclo4.SuspendLayout();
            this.GBciclo2.SuspendLayout();
            this.GBciclo3.SuspendLayout();
            this.GBciclo1.SuspendLayout();
            this.GBGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NYmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NYmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NDuracao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NInicio)).BeginInit();
            this.GBProcesso.SuspendLayout();
            this.GBModelo.SuspendLayout();
            this.GBAtraso.SuspendLayout();
            this.GBFuncao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseTCCDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // GBPainelLateral
            // 
            this.GBPainelLateral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GBPainelLateral.Controls.Add(this.GBestabilidade);
            this.GBPainelLateral.Controls.Add(this.GBMalha);
            this.GBPainelLateral.Controls.Add(this.GBArduino);
            this.GBPainelLateral.Controls.Add(this.GBRELE);
            this.GBPainelLateral.Controls.Add(this.GBPID);
            this.GBPainelLateral.Controls.Add(this.GBComunicacao);
            this.GBPainelLateral.Location = new System.Drawing.Point(3, 3);
            this.GBPainelLateral.Name = "GBPainelLateral";
            this.GBPainelLateral.Size = new System.Drawing.Size(214, 693);
            this.GBPainelLateral.TabIndex = 0;
            this.GBPainelLateral.TabStop = false;
            // 
            // GBestabilidade
            // 
            this.GBestabilidade.Controls.Add(this.NVPvar);
            this.GBestabilidade.Controls.Add(this.NVPmin);
            this.GBestabilidade.Controls.Add(this.NOUTvar);
            this.GBestabilidade.Controls.Add(this.NOUTmin);
            this.GBestabilidade.Controls.Add(this.NVPmax);
            this.GBestabilidade.Controls.Add(this.Variacao);
            this.GBestabilidade.Controls.Add(this.NOUTmax);
            this.GBestabilidade.Controls.Add(this.Maximo);
            this.GBestabilidade.Controls.Add(this.Minimo);
            this.GBestabilidade.Controls.Add(this.VPestabilidade);
            this.GBestabilidade.Controls.Add(this.OUTestabilidade);
            this.GBestabilidade.Location = new System.Drawing.Point(3, 496);
            this.GBestabilidade.Name = "GBestabilidade";
            this.GBestabilidade.Size = new System.Drawing.Size(208, 113);
            this.GBestabilidade.TabIndex = 5;
            this.GBestabilidade.TabStop = false;
            this.GBestabilidade.Text = "Estabilidade";
            // 
            // NVPvar
            // 
            this.NVPvar.Enabled = false;
            this.NVPvar.Location = new System.Drawing.Point(59, 31);
            this.NVPvar.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.NVPvar.Name = "NVPvar";
            this.NVPvar.Size = new System.Drawing.Size(60, 20);
            this.NVPvar.TabIndex = 9;
            this.NVPvar.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NVPvar.ValueChanged += new System.EventHandler(this.NVPvar_ValueChanged);
            // 
            // NVPmin
            // 
            this.NVPmin.Enabled = false;
            this.NVPmin.Location = new System.Drawing.Point(59, 83);
            this.NVPmin.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.NVPmin.Name = "NVPmin";
            this.NVPmin.Size = new System.Drawing.Size(61, 20);
            this.NVPmin.TabIndex = 11;
            this.NVPmin.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NVPmin.ValueChanged += new System.EventHandler(this.NVPmin_ValueChanged);
            // 
            // NOUTvar
            // 
            this.NOUTvar.Enabled = false;
            this.NOUTvar.Location = new System.Drawing.Point(136, 31);
            this.NOUTvar.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.NOUTvar.Name = "NOUTvar";
            this.NOUTvar.Size = new System.Drawing.Size(60, 20);
            this.NOUTvar.TabIndex = 9;
            this.NOUTvar.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NOUTvar.ValueChanged += new System.EventHandler(this.NOUTvar_ValueChanged);
            // 
            // NOUTmin
            // 
            this.NOUTmin.Enabled = false;
            this.NOUTmin.Location = new System.Drawing.Point(136, 83);
            this.NOUTmin.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.NOUTmin.Name = "NOUTmin";
            this.NOUTmin.Size = new System.Drawing.Size(61, 20);
            this.NOUTmin.TabIndex = 11;
            this.NOUTmin.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NOUTmin.ValueChanged += new System.EventHandler(this.NOUTmin_ValueChanged);
            // 
            // NVPmax
            // 
            this.NVPmax.Enabled = false;
            this.NVPmax.Location = new System.Drawing.Point(59, 57);
            this.NVPmax.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.NVPmax.Name = "NVPmax";
            this.NVPmax.Size = new System.Drawing.Size(61, 20);
            this.NVPmax.TabIndex = 10;
            this.NVPmax.Value = new decimal(new int[] {
            3500,
            0,
            0,
            0});
            this.NVPmax.ValueChanged += new System.EventHandler(this.NVPmax_ValueChanged);
            // 
            // Variacao
            // 
            this.Variacao.AutoSize = true;
            this.Variacao.Location = new System.Drawing.Point(4, 34);
            this.Variacao.Name = "Variacao";
            this.Variacao.Size = new System.Drawing.Size(49, 13);
            this.Variacao.TabIndex = 8;
            this.Variacao.Text = "Variação";
            // 
            // NOUTmax
            // 
            this.NOUTmax.Enabled = false;
            this.NOUTmax.Location = new System.Drawing.Point(136, 57);
            this.NOUTmax.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.NOUTmax.Name = "NOUTmax";
            this.NOUTmax.Size = new System.Drawing.Size(61, 20);
            this.NOUTmax.TabIndex = 10;
            this.NOUTmax.Value = new decimal(new int[] {
            3500,
            0,
            0,
            0});
            this.NOUTmax.ValueChanged += new System.EventHandler(this.NOUTmax_ValueChanged);
            // 
            // Maximo
            // 
            this.Maximo.AutoSize = true;
            this.Maximo.Location = new System.Drawing.Point(4, 60);
            this.Maximo.Name = "Maximo";
            this.Maximo.Size = new System.Drawing.Size(43, 13);
            this.Maximo.TabIndex = 8;
            this.Maximo.Text = "Máximo";
            // 
            // Minimo
            // 
            this.Minimo.AutoSize = true;
            this.Minimo.Location = new System.Drawing.Point(4, 86);
            this.Minimo.Name = "Minimo";
            this.Minimo.Size = new System.Drawing.Size(42, 13);
            this.Minimo.TabIndex = 8;
            this.Minimo.Text = "Mínimo";
            // 
            // VPestabilidade
            // 
            this.VPestabilidade.AutoSize = true;
            this.VPestabilidade.Location = new System.Drawing.Point(72, 15);
            this.VPestabilidade.Name = "VPestabilidade";
            this.VPestabilidade.Size = new System.Drawing.Size(21, 13);
            this.VPestabilidade.TabIndex = 8;
            this.VPestabilidade.Text = "VP";
            // 
            // OUTestabilidade
            // 
            this.OUTestabilidade.AutoSize = true;
            this.OUTestabilidade.Location = new System.Drawing.Point(149, 15);
            this.OUTestabilidade.Name = "OUTestabilidade";
            this.OUTestabilidade.Size = new System.Drawing.Size(30, 13);
            this.OUTestabilidade.TabIndex = 8;
            this.OUTestabilidade.Text = "OUT";
            // 
            // GBMalha
            // 
            this.GBMalha.Controls.Add(this.BTAcao);
            this.GBMalha.Controls.Add(this.RBPIDParalelo);
            this.GBMalha.Controls.Add(this.RBReleDown);
            this.GBMalha.Controls.Add(this.RBReleUP);
            this.GBMalha.Controls.Add(this.RBAberta);
            this.GBMalha.Controls.Add(this.RBPIDBrett);
            this.GBMalha.Controls.Add(this.SinalOperacao);
            this.GBMalha.Controls.Add(this.NSO);
            this.GBMalha.Controls.Add(this.Setpoint);
            this.GBMalha.Controls.Add(this.NSetpoint);
            this.GBMalha.Location = new System.Drawing.Point(3, 100);
            this.GBMalha.Name = "GBMalha";
            this.GBMalha.Size = new System.Drawing.Size(208, 121);
            this.GBMalha.TabIndex = 4;
            this.GBMalha.TabStop = false;
            this.GBMalha.Text = "Malha";
            // 
            // RBPIDParalelo
            // 
            this.RBPIDParalelo.AutoSize = true;
            this.RBPIDParalelo.Enabled = false;
            this.RBPIDParalelo.Location = new System.Drawing.Point(106, 96);
            this.RBPIDParalelo.Name = "RBPIDParalelo";
            this.RBPIDParalelo.Size = new System.Drawing.Size(85, 17);
            this.RBPIDParalelo.TabIndex = 13;
            this.RBPIDParalelo.TabStop = true;
            this.RBPIDParalelo.Text = "PID Clássico";
            this.RBPIDParalelo.UseVisualStyleBackColor = true;
            this.RBPIDParalelo.Click += new System.EventHandler(this.RBPIDParalelo_Click);
            // 
            // RBReleDown
            // 
            this.RBReleDown.AutoSize = true;
            this.RBReleDown.Enabled = false;
            this.RBReleDown.Location = new System.Drawing.Point(9, 95);
            this.RBReleDown.Name = "RBReleDown";
            this.RBReleDown.Size = new System.Drawing.Size(78, 17);
            this.RBReleDown.TabIndex = 12;
            this.RBReleDown.TabStop = true;
            this.RBReleDown.Text = "Relé Down";
            this.RBReleDown.UseVisualStyleBackColor = true;
            this.RBReleDown.Click += new System.EventHandler(this.RBReleDown_Click);
            // 
            // RBReleUP
            // 
            this.RBReleUP.AutoSize = true;
            this.RBReleUP.Enabled = false;
            this.RBReleUP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RBReleUP.Location = new System.Drawing.Point(9, 73);
            this.RBReleUP.Name = "RBReleUP";
            this.RBReleUP.Size = new System.Drawing.Size(65, 17);
            this.RBReleUP.TabIndex = 11;
            this.RBReleUP.TabStop = true;
            this.RBReleUP.Text = "Relé UP";
            this.RBReleUP.UseVisualStyleBackColor = true;
            this.RBReleUP.Click += new System.EventHandler(this.RBReleUP_Click);
            // 
            // RBAberta
            // 
            this.RBAberta.AutoSize = true;
            this.RBAberta.Checked = true;
            this.RBAberta.Enabled = false;
            this.RBAberta.Location = new System.Drawing.Point(9, 50);
            this.RBAberta.Name = "RBAberta";
            this.RBAberta.Size = new System.Drawing.Size(56, 17);
            this.RBAberta.TabIndex = 10;
            this.RBAberta.TabStop = true;
            this.RBAberta.Text = "Aberta";
            this.RBAberta.UseVisualStyleBackColor = true;
            this.RBAberta.Click += new System.EventHandler(this.RBAberta_Click);
            // 
            // RBPIDBrett
            // 
            this.RBPIDBrett.AutoSize = true;
            this.RBPIDBrett.Enabled = false;
            this.RBPIDBrett.Location = new System.Drawing.Point(106, 73);
            this.RBPIDBrett.Name = "RBPIDBrett";
            this.RBPIDBrett.Size = new System.Drawing.Size(96, 17);
            this.RBPIDBrett.TabIndex = 10;
            this.RBPIDBrett.Text = "PID Alternativo";
            this.RBPIDBrett.UseVisualStyleBackColor = true;
            this.RBPIDBrett.Click += new System.EventHandler(this.RBPIDBrett_Click);
            // 
            // SinalOperacao
            // 
            this.SinalOperacao.AutoSize = true;
            this.SinalOperacao.Location = new System.Drawing.Point(3, 23);
            this.SinalOperacao.Name = "SinalOperacao";
            this.SinalOperacao.Size = new System.Drawing.Size(22, 13);
            this.SinalOperacao.TabIndex = 8;
            this.SinalOperacao.Text = "SO";
            // 
            // NSO
            // 
            this.NSO.Enabled = false;
            this.NSO.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NSO.Location = new System.Drawing.Point(25, 21);
            this.NSO.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.NSO.Name = "NSO";
            this.NSO.Size = new System.Drawing.Size(68, 20);
            this.NSO.TabIndex = 9;
            this.NSO.ValueChanged += new System.EventHandler(this.NSO_ValueChanged);
            // 
            // Setpoint
            // 
            this.Setpoint.AutoSize = true;
            this.Setpoint.Location = new System.Drawing.Point(108, 23);
            this.Setpoint.Name = "Setpoint";
            this.Setpoint.Size = new System.Drawing.Size(21, 13);
            this.Setpoint.TabIndex = 8;
            this.Setpoint.Text = "SP";
            // 
            // NSetpoint
            // 
            this.NSetpoint.Enabled = false;
            this.NSetpoint.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NSetpoint.Location = new System.Drawing.Point(129, 21);
            this.NSetpoint.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.NSetpoint.Name = "NSetpoint";
            this.NSetpoint.Size = new System.Drawing.Size(68, 20);
            this.NSetpoint.TabIndex = 9;
            this.NSetpoint.ValueChanged += new System.EventHandler(this.NSetpoint_ValueChanged);
            // 
            // GBArduino
            // 
            this.GBArduino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GBArduino.Controls.Add(this.TBRecebeArduino);
            this.GBArduino.Controls.Add(this.BTEnviar);
            this.GBArduino.Controls.Add(this.TBEnviaArduino);
            this.GBArduino.Location = new System.Drawing.Point(3, 615);
            this.GBArduino.Name = "GBArduino";
            this.GBArduino.Size = new System.Drawing.Size(208, 73);
            this.GBArduino.TabIndex = 3;
            this.GBArduino.TabStop = false;
            this.GBArduino.Text = "Arduino";
            // 
            // TBRecebeArduino
            // 
            this.TBRecebeArduino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TBRecebeArduino.Location = new System.Drawing.Point(6, 45);
            this.TBRecebeArduino.Multiline = true;
            this.TBRecebeArduino.Name = "TBRecebeArduino";
            this.TBRecebeArduino.ReadOnly = true;
            this.TBRecebeArduino.Size = new System.Drawing.Size(194, 22);
            this.TBRecebeArduino.TabIndex = 2;
            // 
            // BTEnviar
            // 
            this.BTEnviar.Enabled = false;
            this.BTEnviar.Location = new System.Drawing.Point(113, 19);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(87, 20);
            this.BTEnviar.TabIndex = 1;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = true;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // TBEnviaArduino
            // 
            this.TBEnviaArduino.Location = new System.Drawing.Point(6, 19);
            this.TBEnviaArduino.Name = "TBEnviaArduino";
            this.TBEnviaArduino.Size = new System.Drawing.Size(100, 20);
            this.TBEnviaArduino.TabIndex = 0;
            // 
            // GBRELE
            // 
            this.GBRELE.Controls.Add(this.NBiasHisterese);
            this.GBRELE.Controls.Add(this.NHistereseRele);
            this.GBRELE.Controls.Add(this.NBiasAmplitude);
            this.GBRELE.Controls.Add(this.BiasHisterese);
            this.GBRELE.Controls.Add(this.NAmplitudeRele);
            this.GBRELE.Controls.Add(this.BiasAmplitude);
            this.GBRELE.Controls.Add(this.HistereseRele);
            this.GBRELE.Controls.Add(this.AmplitudeRele);
            this.GBRELE.Location = new System.Drawing.Point(3, 227);
            this.GBRELE.Name = "GBRELE";
            this.GBRELE.Size = new System.Drawing.Size(208, 106);
            this.GBRELE.TabIndex = 2;
            this.GBRELE.TabStop = false;
            this.GBRELE.Text = "Relé";
            // 
            // NBiasHisterese
            // 
            this.NBiasHisterese.Enabled = false;
            this.NBiasHisterese.Location = new System.Drawing.Point(110, 76);
            this.NBiasHisterese.Maximum = new decimal(new int[] {
            1400,
            0,
            0,
            0});
            this.NBiasHisterese.Name = "NBiasHisterese";
            this.NBiasHisterese.Size = new System.Drawing.Size(87, 20);
            this.NBiasHisterese.TabIndex = 6;
            this.NBiasHisterese.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.NBiasHisterese.ValueChanged += new System.EventHandler(this.NBiasHisterese_ValueChanged);
            // 
            // NHistereseRele
            // 
            this.NHistereseRele.Enabled = false;
            this.NHistereseRele.Location = new System.Drawing.Point(6, 76);
            this.NHistereseRele.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NHistereseRele.Name = "NHistereseRele";
            this.NHistereseRele.Size = new System.Drawing.Size(87, 20);
            this.NHistereseRele.TabIndex = 6;
            this.NHistereseRele.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NHistereseRele.ValueChanged += new System.EventHandler(this.NHisterese_ValueChanged);
            // 
            // NBiasAmplitude
            // 
            this.NBiasAmplitude.Enabled = false;
            this.NBiasAmplitude.Location = new System.Drawing.Point(110, 34);
            this.NBiasAmplitude.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NBiasAmplitude.Name = "NBiasAmplitude";
            this.NBiasAmplitude.Size = new System.Drawing.Size(87, 20);
            this.NBiasAmplitude.TabIndex = 5;
            this.NBiasAmplitude.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.NBiasAmplitude.ValueChanged += new System.EventHandler(this.NBiasAmplitude_ValueChanged);
            // 
            // BiasHisterese
            // 
            this.BiasHisterese.AutoSize = true;
            this.BiasHisterese.Location = new System.Drawing.Point(110, 61);
            this.BiasHisterese.Name = "BiasHisterese";
            this.BiasHisterese.Size = new System.Drawing.Size(74, 13);
            this.BiasHisterese.TabIndex = 1;
            this.BiasHisterese.Text = "Bias Histerese";
            // 
            // NAmplitudeRele
            // 
            this.NAmplitudeRele.Enabled = false;
            this.NAmplitudeRele.Location = new System.Drawing.Point(6, 34);
            this.NAmplitudeRele.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NAmplitudeRele.Name = "NAmplitudeRele";
            this.NAmplitudeRele.Size = new System.Drawing.Size(87, 20);
            this.NAmplitudeRele.TabIndex = 5;
            this.NAmplitudeRele.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.NAmplitudeRele.ValueChanged += new System.EventHandler(this.NAmplitudeRele_ValueChanged);
            // 
            // BiasAmplitude
            // 
            this.BiasAmplitude.AutoSize = true;
            this.BiasAmplitude.Location = new System.Drawing.Point(107, 18);
            this.BiasAmplitude.Name = "BiasAmplitude";
            this.BiasAmplitude.Size = new System.Drawing.Size(76, 13);
            this.BiasAmplitude.TabIndex = 1;
            this.BiasAmplitude.Text = "Bias Amplitude";
            // 
            // HistereseRele
            // 
            this.HistereseRele.AutoSize = true;
            this.HistereseRele.Location = new System.Drawing.Point(6, 61);
            this.HistereseRele.Name = "HistereseRele";
            this.HistereseRele.Size = new System.Drawing.Size(76, 13);
            this.HistereseRele.TabIndex = 1;
            this.HistereseRele.Text = "Histerese Relé";
            // 
            // AmplitudeRele
            // 
            this.AmplitudeRele.AutoSize = true;
            this.AmplitudeRele.Location = new System.Drawing.Point(3, 18);
            this.AmplitudeRele.Name = "AmplitudeRele";
            this.AmplitudeRele.Size = new System.Drawing.Size(78, 13);
            this.AmplitudeRele.TabIndex = 1;
            this.AmplitudeRele.Text = "Amplitude Relé";
            // 
            // GBPID
            // 
            this.GBPID.Controls.Add(this.NLambda);
            this.GBPID.Controls.Add(this.RB4);
            this.GBPID.Controls.Add(this.NTAmostragem);
            this.GBPID.Controls.Add(this.NKd);
            this.GBPID.Controls.Add(this.NKi);
            this.GBPID.Controls.Add(this.TaxaAmostragem);
            this.GBPID.Controls.Add(this.RB3);
            this.GBPID.Controls.Add(this.NKp);
            this.GBPID.Controls.Add(this.Lambda);
            this.GBPID.Controls.Add(this.Kderivativo);
            this.GBPID.Controls.Add(this.RB2);
            this.GBPID.Controls.Add(this.Kintegral);
            this.GBPID.Controls.Add(this.RB1);
            this.GBPID.Controls.Add(this.Kproporcional);
            this.GBPID.Location = new System.Drawing.Point(3, 340);
            this.GBPID.Name = "GBPID";
            this.GBPID.Size = new System.Drawing.Size(208, 150);
            this.GBPID.TabIndex = 1;
            this.GBPID.TabStop = false;
            this.GBPID.Text = "PID";
            // 
            // NLambda
            // 
            this.NLambda.DecimalPlaces = 2;
            this.NLambda.Enabled = false;
            this.NLambda.Location = new System.Drawing.Point(123, 123);
            this.NLambda.Name = "NLambda";
            this.NLambda.Size = new System.Drawing.Size(76, 20);
            this.NLambda.TabIndex = 13;
            this.NLambda.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NLambda.ValueChanged += new System.EventHandler(this.NLambda_ValueChanged);
            // 
            // RB4
            // 
            this.RB4.AutoSize = true;
            this.RB4.Enabled = false;
            this.RB4.Location = new System.Drawing.Point(4, 123);
            this.RB4.Name = "RB4";
            this.RB4.Size = new System.Drawing.Size(44, 17);
            this.RB4.TabIndex = 12;
            this.RB4.TabStop = true;
            this.RB4.Text = "IMC";
            this.RB4.UseVisualStyleBackColor = true;
            this.RB4.Click += new System.EventHandler(this.RB4_Click);
            // 
            // NTAmostragem
            // 
            this.NTAmostragem.DecimalPlaces = 2;
            this.NTAmostragem.Enabled = false;
            this.NTAmostragem.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NTAmostragem.Location = new System.Drawing.Point(110, 19);
            this.NTAmostragem.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NTAmostragem.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NTAmostragem.Name = "NTAmostragem";
            this.NTAmostragem.Size = new System.Drawing.Size(88, 20);
            this.NTAmostragem.TabIndex = 11;
            this.NTAmostragem.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.NTAmostragem.ValueChanged += new System.EventHandler(this.NTA_ValueChanged);
            // 
            // NKd
            // 
            this.NKd.DecimalPlaces = 2;
            this.NKd.Enabled = false;
            this.NKd.Location = new System.Drawing.Point(123, 97);
            this.NKd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NKd.Name = "NKd";
            this.NKd.Size = new System.Drawing.Size(76, 20);
            this.NKd.TabIndex = 11;
            this.NKd.ValueChanged += new System.EventHandler(this.NKd_ValueChanged);
            // 
            // NKi
            // 
            this.NKi.DecimalPlaces = 2;
            this.NKi.Enabled = false;
            this.NKi.Location = new System.Drawing.Point(123, 71);
            this.NKi.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NKi.Name = "NKi";
            this.NKi.Size = new System.Drawing.Size(76, 20);
            this.NKi.TabIndex = 10;
            this.NKi.ValueChanged += new System.EventHandler(this.NKi_ValueChanged);
            // 
            // TaxaAmostragem
            // 
            this.TaxaAmostragem.AutoSize = true;
            this.TaxaAmostragem.Location = new System.Drawing.Point(3, 22);
            this.TaxaAmostragem.Name = "TaxaAmostragem";
            this.TaxaAmostragem.Size = new System.Drawing.Size(107, 13);
            this.TaxaAmostragem.TabIndex = 8;
            this.TaxaAmostragem.Text = "Taxa de Amostragem";
            // 
            // RB3
            // 
            this.RB3.AutoSize = true;
            this.RB3.Enabled = false;
            this.RB3.Location = new System.Drawing.Point(4, 97);
            this.RB3.Name = "RB3";
            this.RB3.Size = new System.Drawing.Size(87, 17);
            this.RB3.TabIndex = 7;
            this.RB3.Text = "CHR sem SS";
            this.RB3.UseVisualStyleBackColor = true;
            this.RB3.Click += new System.EventHandler(this.RB3_Click);
            // 
            // NKp
            // 
            this.NKp.DecimalPlaces = 2;
            this.NKp.Enabled = false;
            this.NKp.Location = new System.Drawing.Point(123, 45);
            this.NKp.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NKp.Name = "NKp";
            this.NKp.Size = new System.Drawing.Size(75, 20);
            this.NKp.TabIndex = 9;
            this.NKp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NKp.ValueChanged += new System.EventHandler(this.NKp_ValueChanged);
            // 
            // Lambda
            // 
            this.Lambda.AutoSize = true;
            this.Lambda.Location = new System.Drawing.Point(107, 126);
            this.Lambda.Name = "Lambda";
            this.Lambda.Size = new System.Drawing.Size(14, 13);
            this.Lambda.TabIndex = 8;
            this.Lambda.Text = "Y";
            // 
            // Kderivativo
            // 
            this.Kderivativo.AutoSize = true;
            this.Kderivativo.Location = new System.Drawing.Point(103, 101);
            this.Kderivativo.Name = "Kderivativo";
            this.Kderivativo.Size = new System.Drawing.Size(20, 13);
            this.Kderivativo.TabIndex = 8;
            this.Kderivativo.Text = "Kd";
            // 
            // RB2
            // 
            this.RB2.AutoSize = true;
            this.RB2.Enabled = false;
            this.RB2.Location = new System.Drawing.Point(4, 71);
            this.RB2.Name = "RB2";
            this.RB2.Size = new System.Drawing.Size(76, 17);
            this.RB2.TabIndex = 6;
            this.RB2.Text = "IAE Rovira";
            this.RB2.UseVisualStyleBackColor = true;
            this.RB2.Click += new System.EventHandler(this.RB2_Click);
            // 
            // Kintegral
            // 
            this.Kintegral.AutoSize = true;
            this.Kintegral.Location = new System.Drawing.Point(103, 75);
            this.Kintegral.Name = "Kintegral";
            this.Kintegral.Size = new System.Drawing.Size(16, 13);
            this.Kintegral.TabIndex = 8;
            this.Kintegral.Text = "Ki";
            // 
            // RB1
            // 
            this.RB1.AutoSize = true;
            this.RB1.Checked = true;
            this.RB1.Enabled = false;
            this.RB1.Location = new System.Drawing.Point(4, 46);
            this.RB1.Name = "RB1";
            this.RB1.Size = new System.Drawing.Size(92, 17);
            this.RB1.TabIndex = 5;
            this.RB1.TabStop = true;
            this.RB1.Text = "ZieglerNichols";
            this.RB1.UseVisualStyleBackColor = true;
            this.RB1.Click += new System.EventHandler(this.RB1_Click);
            // 
            // Kproporcional
            // 
            this.Kproporcional.AutoSize = true;
            this.Kproporcional.Location = new System.Drawing.Point(103, 48);
            this.Kproporcional.Name = "Kproporcional";
            this.Kproporcional.Size = new System.Drawing.Size(20, 13);
            this.Kproporcional.TabIndex = 8;
            this.Kproporcional.Text = "Kp";
            // 
            // GBComunicacao
            // 
            this.GBComunicacao.Controls.Add(this.GBstatus);
            this.GBComunicacao.Controls.Add(this.TaxaTransferencia);
            this.GBComunicacao.Controls.Add(this.BTConectar);
            this.GBComunicacao.Controls.Add(this.BTAtualizar);
            this.GBComunicacao.Controls.Add(this.portaseriallista);
            this.GBComunicacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.GBComunicacao.Location = new System.Drawing.Point(3, 16);
            this.GBComunicacao.Name = "GBComunicacao";
            this.GBComunicacao.Size = new System.Drawing.Size(208, 78);
            this.GBComunicacao.TabIndex = 0;
            this.GBComunicacao.TabStop = false;
            this.GBComunicacao.Text = "Comunicação";
            // 
            // GBstatus
            // 
            this.GBstatus.BackColor = System.Drawing.SystemColors.InfoText;
            this.GBstatus.Location = new System.Drawing.Point(75, 5);
            this.GBstatus.Name = "GBstatus";
            this.GBstatus.Size = new System.Drawing.Size(127, 8);
            this.GBstatus.TabIndex = 4;
            this.GBstatus.TabStop = false;
            // 
            // TaxaTransferencia
            // 
            this.TaxaTransferencia.Location = new System.Drawing.Point(6, 46);
            this.TaxaTransferencia.Maximum = new decimal(new int[] {
            250000,
            0,
            0,
            0});
            this.TaxaTransferencia.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.TaxaTransferencia.Name = "TaxaTransferencia";
            this.TaxaTransferencia.Size = new System.Drawing.Size(124, 20);
            this.TaxaTransferencia.TabIndex = 3;
            this.TaxaTransferencia.Value = new decimal(new int[] {
            115200,
            0,
            0,
            0});
            // 
            // BTConectar
            // 
            this.BTConectar.Location = new System.Drawing.Point(136, 46);
            this.BTConectar.Name = "BTConectar";
            this.BTConectar.Size = new System.Drawing.Size(66, 23);
            this.BTConectar.TabIndex = 2;
            this.BTConectar.Text = "Conectar";
            this.BTConectar.UseVisualStyleBackColor = true;
            this.BTConectar.Click += new System.EventHandler(this.BTConectar_Click);
            // 
            // BTAtualizar
            // 
            this.BTAtualizar.Location = new System.Drawing.Point(136, 17);
            this.BTAtualizar.Name = "BTAtualizar";
            this.BTAtualizar.Size = new System.Drawing.Size(66, 23);
            this.BTAtualizar.TabIndex = 1;
            this.BTAtualizar.Text = "Atualizar";
            this.BTAtualizar.UseVisualStyleBackColor = true;
            this.BTAtualizar.Click += new System.EventHandler(this.BTAtualizar_Click);
            // 
            // portaseriallista
            // 
            this.portaseriallista.FormattingEnabled = true;
            this.portaseriallista.Location = new System.Drawing.Point(6, 19);
            this.portaseriallista.Name = "portaseriallista";
            this.portaseriallista.Size = new System.Drawing.Size(124, 21);
            this.portaseriallista.TabIndex = 0;
            this.portaseriallista.Text = "Porta Serial";
            // 
            // LAu1
            // 
            this.LAu1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LAu1.AutoSize = true;
            this.LAu1.Location = new System.Drawing.Point(20, 146);
            this.LAu1.Name = "LAu1";
            this.LAu1.Size = new System.Drawing.Size(20, 13);
            this.LAu1.TabIndex = 4;
            this.LAu1.Text = "Au";
            // 
            // LAd1
            // 
            this.LAd1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LAd1.AutoSize = true;
            this.LAd1.Location = new System.Drawing.Point(20, 120);
            this.LAd1.Name = "LAd1";
            this.LAd1.Size = new System.Drawing.Size(20, 13);
            this.LAd1.TabIndex = 4;
            this.LAd1.Text = "Ad";
            // 
            // LToff1
            // 
            this.LToff1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LToff1.AutoSize = true;
            this.LToff1.Location = new System.Drawing.Point(14, 94);
            this.LToff1.Name = "LToff1";
            this.LToff1.Size = new System.Drawing.Size(26, 13);
            this.LToff1.TabIndex = 3;
            this.LToff1.Text = "Toff";
            // 
            // LTon1
            // 
            this.LTon1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LTon1.AutoSize = true;
            this.LTon1.Location = new System.Drawing.Point(14, 68);
            this.LTon1.Name = "LTon1";
            this.LTon1.Size = new System.Drawing.Size(26, 13);
            this.LTon1.TabIndex = 3;
            this.LTon1.Text = "Ton";
            // 
            // TBpico1
            // 
            this.TBpico1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBpico1.Location = new System.Drawing.Point(42, 143);
            this.TBpico1.Name = "TBpico1";
            this.TBpico1.ReadOnly = true;
            this.TBpico1.Size = new System.Drawing.Size(57, 20);
            this.TBpico1.TabIndex = 0;
            // 
            // TBvale1
            // 
            this.TBvale1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBvale1.Location = new System.Drawing.Point(42, 117);
            this.TBvale1.Name = "TBvale1";
            this.TBvale1.ReadOnly = true;
            this.TBvale1.Size = new System.Drawing.Size(57, 20);
            this.TBvale1.TabIndex = 0;
            // 
            // TBToff1
            // 
            this.TBToff1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBToff1.Location = new System.Drawing.Point(42, 91);
            this.TBToff1.Name = "TBToff1";
            this.TBToff1.ReadOnly = true;
            this.TBToff1.Size = new System.Drawing.Size(57, 20);
            this.TBToff1.TabIndex = 0;
            // 
            // TBTon1
            // 
            this.TBTon1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBTon1.Location = new System.Drawing.Point(42, 65);
            this.TBTon1.Name = "TBTon1";
            this.TBTon1.ReadOnly = true;
            this.TBTon1.Size = new System.Drawing.Size(57, 20);
            this.TBTon1.TabIndex = 0;
            // 
            // Grafico
            // 
            this.Grafico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.Grafico.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.Grafico.Legends.Add(legend3);
            this.Grafico.Location = new System.Drawing.Point(221, 9);
            this.Grafico.Name = "Grafico";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series7.Legend = "Legend1";
            series7.Name = "SP";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series8.Legend = "Legend1";
            series8.Name = "OUT";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series9.Legend = "Legend1";
            series9.Name = "INP";
            this.Grafico.Series.Add(series7);
            this.Grafico.Series.Add(series8);
            this.Grafico.Series.Add(series9);
            this.Grafico.Size = new System.Drawing.Size(922, 418);
            this.Grafico.TabIndex = 1;
            this.Grafico.Text = "Gráfico";
            // 
            // GBPainelInferior
            // 
            this.GBPainelInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GBPainelInferior.Controls.Add(this.GBmedia);
            this.GBPainelInferior.Controls.Add(this.GBciclo4);
            this.GBPainelInferior.Controls.Add(this.GBciclo2);
            this.GBPainelInferior.Controls.Add(this.GBciclo3);
            this.GBPainelInferior.Controls.Add(this.GBciclo1);
            this.GBPainelInferior.Controls.Add(this.GBGrafico);
            this.GBPainelInferior.Controls.Add(this.GBProcesso);
            this.GBPainelInferior.Controls.Add(this.label4);
            this.GBPainelInferior.Location = new System.Drawing.Point(221, 433);
            this.GBPainelInferior.Name = "GBPainelInferior";
            this.GBPainelInferior.Size = new System.Drawing.Size(922, 263);
            this.GBPainelInferior.TabIndex = 2;
            this.GBPainelInferior.TabStop = false;
            // 
            // GBmedia
            // 
            this.GBmedia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GBmedia.Controls.Add(this.TBToffM);
            this.GBmedia.Controls.Add(this.TBIerroM);
            this.GBmedia.Controls.Add(this.LToffM);
            this.GBmedia.Controls.Add(this.TBvaleM);
            this.GBmedia.Controls.Add(this.TBpicoM);
            this.GBmedia.Controls.Add(this.TBKM);
            this.GBmedia.Controls.Add(this.TBIoutM);
            this.GBmedia.Controls.Add(this.LTonM);
            this.GBmedia.Controls.Add(this.TBt0onM);
            this.GBmedia.Controls.Add(this.Lt0onM);
            this.GBmedia.Controls.Add(this.TBt0offM);
            this.GBmedia.Controls.Add(this.Lt0offM);
            this.GBmedia.Controls.Add(this.LAuM);
            this.GBmedia.Controls.Add(this.TBTonM);
            this.GBmedia.Controls.Add(this.LIoutM);
            this.GBmedia.Controls.Add(this.LAdM);
            this.GBmedia.Controls.Add(this.LKM);
            this.GBmedia.Controls.Add(this.LIerroM);
            this.GBmedia.Location = new System.Drawing.Point(348, 11);
            this.GBmedia.Name = "GBmedia";
            this.GBmedia.Size = new System.Drawing.Size(108, 247);
            this.GBmedia.TabIndex = 15;
            this.GBmedia.TabStop = false;
            this.GBmedia.Text = "Média";
            // 
            // TBToffM
            // 
            this.TBToffM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBToffM.Location = new System.Drawing.Point(42, 91);
            this.TBToffM.Name = "TBToffM";
            this.TBToffM.ReadOnly = true;
            this.TBToffM.Size = new System.Drawing.Size(57, 20);
            this.TBToffM.TabIndex = 0;
            // 
            // TBIerroM
            // 
            this.TBIerroM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBIerroM.Location = new System.Drawing.Point(42, 169);
            this.TBIerroM.Name = "TBIerroM";
            this.TBIerroM.ReadOnly = true;
            this.TBIerroM.Size = new System.Drawing.Size(57, 20);
            this.TBIerroM.TabIndex = 0;
            // 
            // LToffM
            // 
            this.LToffM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LToffM.AutoSize = true;
            this.LToffM.Location = new System.Drawing.Point(14, 94);
            this.LToffM.Name = "LToffM";
            this.LToffM.Size = new System.Drawing.Size(26, 13);
            this.LToffM.TabIndex = 3;
            this.LToffM.Text = "Toff";
            // 
            // TBvaleM
            // 
            this.TBvaleM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBvaleM.Location = new System.Drawing.Point(42, 117);
            this.TBvaleM.Name = "TBvaleM";
            this.TBvaleM.ReadOnly = true;
            this.TBvaleM.Size = new System.Drawing.Size(57, 20);
            this.TBvaleM.TabIndex = 0;
            // 
            // TBpicoM
            // 
            this.TBpicoM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBpicoM.Location = new System.Drawing.Point(42, 143);
            this.TBpicoM.Name = "TBpicoM";
            this.TBpicoM.ReadOnly = true;
            this.TBpicoM.Size = new System.Drawing.Size(57, 20);
            this.TBpicoM.TabIndex = 0;
            // 
            // TBKM
            // 
            this.TBKM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBKM.Location = new System.Drawing.Point(42, 221);
            this.TBKM.Name = "TBKM";
            this.TBKM.ReadOnly = true;
            this.TBKM.Size = new System.Drawing.Size(57, 20);
            this.TBKM.TabIndex = 0;
            // 
            // TBIoutM
            // 
            this.TBIoutM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBIoutM.Location = new System.Drawing.Point(42, 195);
            this.TBIoutM.Name = "TBIoutM";
            this.TBIoutM.ReadOnly = true;
            this.TBIoutM.Size = new System.Drawing.Size(57, 20);
            this.TBIoutM.TabIndex = 0;
            // 
            // LTonM
            // 
            this.LTonM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LTonM.AutoSize = true;
            this.LTonM.Location = new System.Drawing.Point(14, 68);
            this.LTonM.Name = "LTonM";
            this.LTonM.Size = new System.Drawing.Size(26, 13);
            this.LTonM.TabIndex = 3;
            this.LTonM.Text = "Ton";
            // 
            // TBt0onM
            // 
            this.TBt0onM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBt0onM.Location = new System.Drawing.Point(42, 14);
            this.TBt0onM.Name = "TBt0onM";
            this.TBt0onM.ReadOnly = true;
            this.TBt0onM.Size = new System.Drawing.Size(57, 20);
            this.TBt0onM.TabIndex = 0;
            // 
            // Lt0onM
            // 
            this.Lt0onM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lt0onM.AutoSize = true;
            this.Lt0onM.Location = new System.Drawing.Point(12, 17);
            this.Lt0onM.Name = "Lt0onM";
            this.Lt0onM.Size = new System.Drawing.Size(28, 13);
            this.Lt0onM.TabIndex = 3;
            this.Lt0onM.Text = "t0on";
            // 
            // TBt0offM
            // 
            this.TBt0offM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBt0offM.Location = new System.Drawing.Point(42, 39);
            this.TBt0offM.Name = "TBt0offM";
            this.TBt0offM.ReadOnly = true;
            this.TBt0offM.Size = new System.Drawing.Size(57, 20);
            this.TBt0offM.TabIndex = 0;
            // 
            // Lt0offM
            // 
            this.Lt0offM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lt0offM.AutoSize = true;
            this.Lt0offM.Location = new System.Drawing.Point(12, 42);
            this.Lt0offM.Name = "Lt0offM";
            this.Lt0offM.Size = new System.Drawing.Size(28, 13);
            this.Lt0offM.TabIndex = 3;
            this.Lt0offM.Text = "t0off";
            // 
            // LAuM
            // 
            this.LAuM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LAuM.AutoSize = true;
            this.LAuM.Location = new System.Drawing.Point(20, 146);
            this.LAuM.Name = "LAuM";
            this.LAuM.Size = new System.Drawing.Size(20, 13);
            this.LAuM.TabIndex = 4;
            this.LAuM.Text = "Au";
            // 
            // TBTonM
            // 
            this.TBTonM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBTonM.Location = new System.Drawing.Point(42, 65);
            this.TBTonM.Name = "TBTonM";
            this.TBTonM.ReadOnly = true;
            this.TBTonM.Size = new System.Drawing.Size(57, 20);
            this.TBTonM.TabIndex = 0;
            // 
            // LIoutM
            // 
            this.LIoutM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LIoutM.AutoSize = true;
            this.LIoutM.Location = new System.Drawing.Point(4, 198);
            this.LIoutM.Name = "LIoutM";
            this.LIoutM.Size = new System.Drawing.Size(36, 13);
            this.LIoutM.TabIndex = 4;
            this.LIoutM.Text = "∫ OUT";
            // 
            // LAdM
            // 
            this.LAdM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LAdM.AutoSize = true;
            this.LAdM.Location = new System.Drawing.Point(20, 120);
            this.LAdM.Name = "LAdM";
            this.LAdM.Size = new System.Drawing.Size(20, 13);
            this.LAdM.TabIndex = 4;
            this.LAdM.Text = "Ad";
            // 
            // LKM
            // 
            this.LKM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LKM.AutoSize = true;
            this.LKM.Location = new System.Drawing.Point(26, 224);
            this.LKM.Name = "LKM";
            this.LKM.Size = new System.Drawing.Size(14, 13);
            this.LKM.TabIndex = 2;
            this.LKM.Text = "K";
            // 
            // LIerroM
            // 
            this.LIerroM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LIerroM.AutoSize = true;
            this.LIerroM.Location = new System.Drawing.Point(9, 172);
            this.LIerroM.Name = "LIerroM";
            this.LIerroM.Size = new System.Drawing.Size(31, 13);
            this.LIerroM.TabIndex = 4;
            this.LIerroM.Text = "∫ erro";
            // 
            // GBciclo4
            // 
            this.GBciclo4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GBciclo4.Controls.Add(this.TBToff4);
            this.GBciclo4.Controls.Add(this.TBIerro4);
            this.GBciclo4.Controls.Add(this.LToff4);
            this.GBciclo4.Controls.Add(this.TBvale4);
            this.GBciclo4.Controls.Add(this.TBpico4);
            this.GBciclo4.Controls.Add(this.TBK4);
            this.GBciclo4.Controls.Add(this.TBIout4);
            this.GBciclo4.Controls.Add(this.LTon4);
            this.GBciclo4.Controls.Add(this.TBt0on4);
            this.GBciclo4.Controls.Add(this.Lt0on4);
            this.GBciclo4.Controls.Add(this.TBt0off4);
            this.GBciclo4.Controls.Add(this.Lt0off4);
            this.GBciclo4.Controls.Add(this.LAu4);
            this.GBciclo4.Controls.Add(this.TBTon4);
            this.GBciclo4.Controls.Add(this.LIout4);
            this.GBciclo4.Controls.Add(this.LAd4);
            this.GBciclo4.Controls.Add(this.LK4);
            this.GBciclo4.Controls.Add(this.LIerro4);
            this.GBciclo4.Location = new System.Drawing.Point(804, 11);
            this.GBciclo4.Name = "GBciclo4";
            this.GBciclo4.Size = new System.Drawing.Size(108, 247);
            this.GBciclo4.TabIndex = 15;
            this.GBciclo4.TabStop = false;
            this.GBciclo4.Text = "4º Ciclo";
            // 
            // TBToff4
            // 
            this.TBToff4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBToff4.Location = new System.Drawing.Point(42, 91);
            this.TBToff4.Name = "TBToff4";
            this.TBToff4.ReadOnly = true;
            this.TBToff4.Size = new System.Drawing.Size(57, 20);
            this.TBToff4.TabIndex = 0;
            // 
            // TBIerro4
            // 
            this.TBIerro4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBIerro4.Location = new System.Drawing.Point(42, 169);
            this.TBIerro4.Name = "TBIerro4";
            this.TBIerro4.ReadOnly = true;
            this.TBIerro4.Size = new System.Drawing.Size(57, 20);
            this.TBIerro4.TabIndex = 0;
            // 
            // LToff4
            // 
            this.LToff4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LToff4.AutoSize = true;
            this.LToff4.Location = new System.Drawing.Point(14, 94);
            this.LToff4.Name = "LToff4";
            this.LToff4.Size = new System.Drawing.Size(26, 13);
            this.LToff4.TabIndex = 3;
            this.LToff4.Text = "Toff";
            // 
            // TBvale4
            // 
            this.TBvale4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBvale4.Location = new System.Drawing.Point(42, 117);
            this.TBvale4.Name = "TBvale4";
            this.TBvale4.ReadOnly = true;
            this.TBvale4.Size = new System.Drawing.Size(57, 20);
            this.TBvale4.TabIndex = 0;
            // 
            // TBpico4
            // 
            this.TBpico4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBpico4.Location = new System.Drawing.Point(42, 143);
            this.TBpico4.Name = "TBpico4";
            this.TBpico4.ReadOnly = true;
            this.TBpico4.Size = new System.Drawing.Size(57, 20);
            this.TBpico4.TabIndex = 0;
            // 
            // TBK4
            // 
            this.TBK4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBK4.Location = new System.Drawing.Point(42, 221);
            this.TBK4.Name = "TBK4";
            this.TBK4.ReadOnly = true;
            this.TBK4.Size = new System.Drawing.Size(57, 20);
            this.TBK4.TabIndex = 0;
            // 
            // TBIout4
            // 
            this.TBIout4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBIout4.Location = new System.Drawing.Point(42, 195);
            this.TBIout4.Name = "TBIout4";
            this.TBIout4.ReadOnly = true;
            this.TBIout4.Size = new System.Drawing.Size(57, 20);
            this.TBIout4.TabIndex = 0;
            // 
            // LTon4
            // 
            this.LTon4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LTon4.AutoSize = true;
            this.LTon4.Location = new System.Drawing.Point(14, 68);
            this.LTon4.Name = "LTon4";
            this.LTon4.Size = new System.Drawing.Size(26, 13);
            this.LTon4.TabIndex = 3;
            this.LTon4.Text = "Ton";
            // 
            // TBt0on4
            // 
            this.TBt0on4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBt0on4.Location = new System.Drawing.Point(42, 14);
            this.TBt0on4.Name = "TBt0on4";
            this.TBt0on4.ReadOnly = true;
            this.TBt0on4.Size = new System.Drawing.Size(57, 20);
            this.TBt0on4.TabIndex = 0;
            // 
            // Lt0on4
            // 
            this.Lt0on4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lt0on4.AutoSize = true;
            this.Lt0on4.Location = new System.Drawing.Point(12, 17);
            this.Lt0on4.Name = "Lt0on4";
            this.Lt0on4.Size = new System.Drawing.Size(28, 13);
            this.Lt0on4.TabIndex = 3;
            this.Lt0on4.Text = "t0on";
            // 
            // TBt0off4
            // 
            this.TBt0off4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBt0off4.Location = new System.Drawing.Point(42, 39);
            this.TBt0off4.Name = "TBt0off4";
            this.TBt0off4.ReadOnly = true;
            this.TBt0off4.Size = new System.Drawing.Size(57, 20);
            this.TBt0off4.TabIndex = 0;
            // 
            // Lt0off4
            // 
            this.Lt0off4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lt0off4.AutoSize = true;
            this.Lt0off4.Location = new System.Drawing.Point(12, 42);
            this.Lt0off4.Name = "Lt0off4";
            this.Lt0off4.Size = new System.Drawing.Size(28, 13);
            this.Lt0off4.TabIndex = 3;
            this.Lt0off4.Text = "t0off";
            // 
            // LAu4
            // 
            this.LAu4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LAu4.AutoSize = true;
            this.LAu4.Location = new System.Drawing.Point(20, 146);
            this.LAu4.Name = "LAu4";
            this.LAu4.Size = new System.Drawing.Size(20, 13);
            this.LAu4.TabIndex = 4;
            this.LAu4.Text = "Au";
            // 
            // TBTon4
            // 
            this.TBTon4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBTon4.Location = new System.Drawing.Point(42, 65);
            this.TBTon4.Name = "TBTon4";
            this.TBTon4.ReadOnly = true;
            this.TBTon4.Size = new System.Drawing.Size(57, 20);
            this.TBTon4.TabIndex = 0;
            // 
            // LIout4
            // 
            this.LIout4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LIout4.AutoSize = true;
            this.LIout4.Location = new System.Drawing.Point(4, 198);
            this.LIout4.Name = "LIout4";
            this.LIout4.Size = new System.Drawing.Size(36, 13);
            this.LIout4.TabIndex = 4;
            this.LIout4.Text = "∫ OUT";
            // 
            // LAd4
            // 
            this.LAd4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LAd4.AutoSize = true;
            this.LAd4.Location = new System.Drawing.Point(20, 120);
            this.LAd4.Name = "LAd4";
            this.LAd4.Size = new System.Drawing.Size(20, 13);
            this.LAd4.TabIndex = 4;
            this.LAd4.Text = "Ad";
            // 
            // LK4
            // 
            this.LK4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LK4.AutoSize = true;
            this.LK4.Location = new System.Drawing.Point(26, 224);
            this.LK4.Name = "LK4";
            this.LK4.Size = new System.Drawing.Size(14, 13);
            this.LK4.TabIndex = 2;
            this.LK4.Text = "K";
            // 
            // LIerro4
            // 
            this.LIerro4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LIerro4.AutoSize = true;
            this.LIerro4.Location = new System.Drawing.Point(9, 172);
            this.LIerro4.Name = "LIerro4";
            this.LIerro4.Size = new System.Drawing.Size(31, 13);
            this.LIerro4.TabIndex = 4;
            this.LIerro4.Text = "∫ erro";
            // 
            // GBciclo2
            // 
            this.GBciclo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GBciclo2.Controls.Add(this.TBToff2);
            this.GBciclo2.Controls.Add(this.TBIerro2);
            this.GBciclo2.Controls.Add(this.LToff2);
            this.GBciclo2.Controls.Add(this.TBvale2);
            this.GBciclo2.Controls.Add(this.TBpico2);
            this.GBciclo2.Controls.Add(this.TBK2);
            this.GBciclo2.Controls.Add(this.TBIout2);
            this.GBciclo2.Controls.Add(this.LTon2);
            this.GBciclo2.Controls.Add(this.TBt0on2);
            this.GBciclo2.Controls.Add(this.Lt0on2);
            this.GBciclo2.Controls.Add(this.TBt0off2);
            this.GBciclo2.Controls.Add(this.Lt0off2);
            this.GBciclo2.Controls.Add(this.LAu2);
            this.GBciclo2.Controls.Add(this.TBTon2);
            this.GBciclo2.Controls.Add(this.LIout2);
            this.GBciclo2.Controls.Add(this.LAd2);
            this.GBciclo2.Controls.Add(this.LK2);
            this.GBciclo2.Controls.Add(this.LIerro2);
            this.GBciclo2.Location = new System.Drawing.Point(576, 11);
            this.GBciclo2.Name = "GBciclo2";
            this.GBciclo2.Size = new System.Drawing.Size(108, 247);
            this.GBciclo2.TabIndex = 15;
            this.GBciclo2.TabStop = false;
            this.GBciclo2.Text = "2º Ciclo";
            // 
            // TBToff2
            // 
            this.TBToff2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBToff2.Location = new System.Drawing.Point(42, 91);
            this.TBToff2.Name = "TBToff2";
            this.TBToff2.ReadOnly = true;
            this.TBToff2.Size = new System.Drawing.Size(57, 20);
            this.TBToff2.TabIndex = 0;
            // 
            // TBIerro2
            // 
            this.TBIerro2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBIerro2.Location = new System.Drawing.Point(42, 169);
            this.TBIerro2.Name = "TBIerro2";
            this.TBIerro2.ReadOnly = true;
            this.TBIerro2.Size = new System.Drawing.Size(57, 20);
            this.TBIerro2.TabIndex = 0;
            // 
            // LToff2
            // 
            this.LToff2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LToff2.AutoSize = true;
            this.LToff2.Location = new System.Drawing.Point(14, 94);
            this.LToff2.Name = "LToff2";
            this.LToff2.Size = new System.Drawing.Size(26, 13);
            this.LToff2.TabIndex = 3;
            this.LToff2.Text = "Toff";
            // 
            // TBvale2
            // 
            this.TBvale2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBvale2.Location = new System.Drawing.Point(42, 117);
            this.TBvale2.Name = "TBvale2";
            this.TBvale2.ReadOnly = true;
            this.TBvale2.Size = new System.Drawing.Size(57, 20);
            this.TBvale2.TabIndex = 0;
            // 
            // TBpico2
            // 
            this.TBpico2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBpico2.Location = new System.Drawing.Point(42, 143);
            this.TBpico2.Name = "TBpico2";
            this.TBpico2.ReadOnly = true;
            this.TBpico2.Size = new System.Drawing.Size(57, 20);
            this.TBpico2.TabIndex = 0;
            // 
            // TBK2
            // 
            this.TBK2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBK2.Location = new System.Drawing.Point(42, 221);
            this.TBK2.Name = "TBK2";
            this.TBK2.ReadOnly = true;
            this.TBK2.Size = new System.Drawing.Size(57, 20);
            this.TBK2.TabIndex = 0;
            // 
            // TBIout2
            // 
            this.TBIout2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBIout2.Location = new System.Drawing.Point(42, 195);
            this.TBIout2.Name = "TBIout2";
            this.TBIout2.ReadOnly = true;
            this.TBIout2.Size = new System.Drawing.Size(57, 20);
            this.TBIout2.TabIndex = 0;
            // 
            // LTon2
            // 
            this.LTon2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LTon2.AutoSize = true;
            this.LTon2.Location = new System.Drawing.Point(14, 68);
            this.LTon2.Name = "LTon2";
            this.LTon2.Size = new System.Drawing.Size(26, 13);
            this.LTon2.TabIndex = 3;
            this.LTon2.Text = "Ton";
            // 
            // TBt0on2
            // 
            this.TBt0on2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBt0on2.Location = new System.Drawing.Point(42, 14);
            this.TBt0on2.Name = "TBt0on2";
            this.TBt0on2.ReadOnly = true;
            this.TBt0on2.Size = new System.Drawing.Size(57, 20);
            this.TBt0on2.TabIndex = 0;
            // 
            // Lt0on2
            // 
            this.Lt0on2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lt0on2.AutoSize = true;
            this.Lt0on2.Location = new System.Drawing.Point(12, 17);
            this.Lt0on2.Name = "Lt0on2";
            this.Lt0on2.Size = new System.Drawing.Size(28, 13);
            this.Lt0on2.TabIndex = 3;
            this.Lt0on2.Text = "t0on";
            // 
            // TBt0off2
            // 
            this.TBt0off2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBt0off2.Location = new System.Drawing.Point(42, 39);
            this.TBt0off2.Name = "TBt0off2";
            this.TBt0off2.ReadOnly = true;
            this.TBt0off2.Size = new System.Drawing.Size(57, 20);
            this.TBt0off2.TabIndex = 0;
            // 
            // Lt0off2
            // 
            this.Lt0off2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lt0off2.AutoSize = true;
            this.Lt0off2.Location = new System.Drawing.Point(12, 42);
            this.Lt0off2.Name = "Lt0off2";
            this.Lt0off2.Size = new System.Drawing.Size(28, 13);
            this.Lt0off2.TabIndex = 3;
            this.Lt0off2.Text = "t0off";
            // 
            // LAu2
            // 
            this.LAu2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LAu2.AutoSize = true;
            this.LAu2.Location = new System.Drawing.Point(20, 146);
            this.LAu2.Name = "LAu2";
            this.LAu2.Size = new System.Drawing.Size(20, 13);
            this.LAu2.TabIndex = 4;
            this.LAu2.Text = "Au";
            // 
            // TBTon2
            // 
            this.TBTon2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBTon2.Location = new System.Drawing.Point(42, 65);
            this.TBTon2.Name = "TBTon2";
            this.TBTon2.ReadOnly = true;
            this.TBTon2.Size = new System.Drawing.Size(57, 20);
            this.TBTon2.TabIndex = 0;
            // 
            // LIout2
            // 
            this.LIout2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LIout2.AutoSize = true;
            this.LIout2.Location = new System.Drawing.Point(4, 198);
            this.LIout2.Name = "LIout2";
            this.LIout2.Size = new System.Drawing.Size(36, 13);
            this.LIout2.TabIndex = 4;
            this.LIout2.Text = "∫ OUT";
            // 
            // LAd2
            // 
            this.LAd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LAd2.AutoSize = true;
            this.LAd2.Location = new System.Drawing.Point(20, 120);
            this.LAd2.Name = "LAd2";
            this.LAd2.Size = new System.Drawing.Size(20, 13);
            this.LAd2.TabIndex = 4;
            this.LAd2.Text = "Ad";
            // 
            // LK2
            // 
            this.LK2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LK2.AutoSize = true;
            this.LK2.Location = new System.Drawing.Point(26, 224);
            this.LK2.Name = "LK2";
            this.LK2.Size = new System.Drawing.Size(14, 13);
            this.LK2.TabIndex = 2;
            this.LK2.Text = "K";
            // 
            // LIerro2
            // 
            this.LIerro2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LIerro2.AutoSize = true;
            this.LIerro2.Location = new System.Drawing.Point(9, 172);
            this.LIerro2.Name = "LIerro2";
            this.LIerro2.Size = new System.Drawing.Size(31, 13);
            this.LIerro2.TabIndex = 4;
            this.LIerro2.Text = "∫ erro";
            // 
            // GBciclo3
            // 
            this.GBciclo3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GBciclo3.Controls.Add(this.TBToff3);
            this.GBciclo3.Controls.Add(this.TBIerro3);
            this.GBciclo3.Controls.Add(this.LToff3);
            this.GBciclo3.Controls.Add(this.TBvale3);
            this.GBciclo3.Controls.Add(this.TBpico3);
            this.GBciclo3.Controls.Add(this.TBK3);
            this.GBciclo3.Controls.Add(this.TBIout3);
            this.GBciclo3.Controls.Add(this.LTon3);
            this.GBciclo3.Controls.Add(this.TBt0on3);
            this.GBciclo3.Controls.Add(this.Lt0on3);
            this.GBciclo3.Controls.Add(this.TBt0off3);
            this.GBciclo3.Controls.Add(this.Lt0off3);
            this.GBciclo3.Controls.Add(this.LAu3);
            this.GBciclo3.Controls.Add(this.TBTon3);
            this.GBciclo3.Controls.Add(this.LIout3);
            this.GBciclo3.Controls.Add(this.LAd3);
            this.GBciclo3.Controls.Add(this.LK3);
            this.GBciclo3.Controls.Add(this.LIerro3);
            this.GBciclo3.Location = new System.Drawing.Point(690, 11);
            this.GBciclo3.Name = "GBciclo3";
            this.GBciclo3.Size = new System.Drawing.Size(108, 247);
            this.GBciclo3.TabIndex = 15;
            this.GBciclo3.TabStop = false;
            this.GBciclo3.Text = "3º Ciclo";
            // 
            // TBToff3
            // 
            this.TBToff3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBToff3.Location = new System.Drawing.Point(42, 91);
            this.TBToff3.Name = "TBToff3";
            this.TBToff3.ReadOnly = true;
            this.TBToff3.Size = new System.Drawing.Size(57, 20);
            this.TBToff3.TabIndex = 0;
            // 
            // TBIerro3
            // 
            this.TBIerro3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBIerro3.Location = new System.Drawing.Point(42, 169);
            this.TBIerro3.Name = "TBIerro3";
            this.TBIerro3.ReadOnly = true;
            this.TBIerro3.Size = new System.Drawing.Size(57, 20);
            this.TBIerro3.TabIndex = 0;
            // 
            // LToff3
            // 
            this.LToff3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LToff3.AutoSize = true;
            this.LToff3.Location = new System.Drawing.Point(14, 94);
            this.LToff3.Name = "LToff3";
            this.LToff3.Size = new System.Drawing.Size(26, 13);
            this.LToff3.TabIndex = 3;
            this.LToff3.Text = "Toff";
            // 
            // TBvale3
            // 
            this.TBvale3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBvale3.Location = new System.Drawing.Point(42, 117);
            this.TBvale3.Name = "TBvale3";
            this.TBvale3.ReadOnly = true;
            this.TBvale3.Size = new System.Drawing.Size(57, 20);
            this.TBvale3.TabIndex = 0;
            // 
            // TBpico3
            // 
            this.TBpico3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBpico3.Location = new System.Drawing.Point(42, 143);
            this.TBpico3.Name = "TBpico3";
            this.TBpico3.ReadOnly = true;
            this.TBpico3.Size = new System.Drawing.Size(57, 20);
            this.TBpico3.TabIndex = 0;
            // 
            // TBK3
            // 
            this.TBK3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBK3.Location = new System.Drawing.Point(42, 221);
            this.TBK3.Name = "TBK3";
            this.TBK3.ReadOnly = true;
            this.TBK3.Size = new System.Drawing.Size(57, 20);
            this.TBK3.TabIndex = 0;
            // 
            // TBIout3
            // 
            this.TBIout3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBIout3.Location = new System.Drawing.Point(42, 195);
            this.TBIout3.Name = "TBIout3";
            this.TBIout3.ReadOnly = true;
            this.TBIout3.Size = new System.Drawing.Size(57, 20);
            this.TBIout3.TabIndex = 0;
            // 
            // LTon3
            // 
            this.LTon3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LTon3.AutoSize = true;
            this.LTon3.Location = new System.Drawing.Point(14, 68);
            this.LTon3.Name = "LTon3";
            this.LTon3.Size = new System.Drawing.Size(26, 13);
            this.LTon3.TabIndex = 3;
            this.LTon3.Text = "Ton";
            // 
            // TBt0on3
            // 
            this.TBt0on3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBt0on3.Location = new System.Drawing.Point(42, 14);
            this.TBt0on3.Name = "TBt0on3";
            this.TBt0on3.ReadOnly = true;
            this.TBt0on3.Size = new System.Drawing.Size(57, 20);
            this.TBt0on3.TabIndex = 0;
            // 
            // Lt0on3
            // 
            this.Lt0on3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lt0on3.AutoSize = true;
            this.Lt0on3.Location = new System.Drawing.Point(12, 17);
            this.Lt0on3.Name = "Lt0on3";
            this.Lt0on3.Size = new System.Drawing.Size(28, 13);
            this.Lt0on3.TabIndex = 3;
            this.Lt0on3.Text = "t0on";
            // 
            // TBt0off3
            // 
            this.TBt0off3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBt0off3.Location = new System.Drawing.Point(42, 39);
            this.TBt0off3.Name = "TBt0off3";
            this.TBt0off3.ReadOnly = true;
            this.TBt0off3.Size = new System.Drawing.Size(57, 20);
            this.TBt0off3.TabIndex = 0;
            // 
            // Lt0off3
            // 
            this.Lt0off3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lt0off3.AutoSize = true;
            this.Lt0off3.Location = new System.Drawing.Point(12, 42);
            this.Lt0off3.Name = "Lt0off3";
            this.Lt0off3.Size = new System.Drawing.Size(28, 13);
            this.Lt0off3.TabIndex = 3;
            this.Lt0off3.Text = "t0off";
            // 
            // LAu3
            // 
            this.LAu3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LAu3.AutoSize = true;
            this.LAu3.Location = new System.Drawing.Point(20, 146);
            this.LAu3.Name = "LAu3";
            this.LAu3.Size = new System.Drawing.Size(20, 13);
            this.LAu3.TabIndex = 4;
            this.LAu3.Text = "Au";
            // 
            // TBTon3
            // 
            this.TBTon3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBTon3.Location = new System.Drawing.Point(42, 65);
            this.TBTon3.Name = "TBTon3";
            this.TBTon3.ReadOnly = true;
            this.TBTon3.Size = new System.Drawing.Size(57, 20);
            this.TBTon3.TabIndex = 0;
            // 
            // LIout3
            // 
            this.LIout3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LIout3.AutoSize = true;
            this.LIout3.Location = new System.Drawing.Point(4, 198);
            this.LIout3.Name = "LIout3";
            this.LIout3.Size = new System.Drawing.Size(36, 13);
            this.LIout3.TabIndex = 4;
            this.LIout3.Text = "∫ OUT";
            // 
            // LAd3
            // 
            this.LAd3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LAd3.AutoSize = true;
            this.LAd3.Location = new System.Drawing.Point(20, 120);
            this.LAd3.Name = "LAd3";
            this.LAd3.Size = new System.Drawing.Size(20, 13);
            this.LAd3.TabIndex = 4;
            this.LAd3.Text = "Ad";
            // 
            // LK3
            // 
            this.LK3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LK3.AutoSize = true;
            this.LK3.Location = new System.Drawing.Point(26, 224);
            this.LK3.Name = "LK3";
            this.LK3.Size = new System.Drawing.Size(14, 13);
            this.LK3.TabIndex = 2;
            this.LK3.Text = "K";
            // 
            // LIerro3
            // 
            this.LIerro3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LIerro3.AutoSize = true;
            this.LIerro3.Location = new System.Drawing.Point(9, 172);
            this.LIerro3.Name = "LIerro3";
            this.LIerro3.Size = new System.Drawing.Size(31, 13);
            this.LIerro3.TabIndex = 4;
            this.LIerro3.Text = "∫ erro";
            // 
            // GBciclo1
            // 
            this.GBciclo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GBciclo1.Controls.Add(this.TBToff1);
            this.GBciclo1.Controls.Add(this.TBIerro1);
            this.GBciclo1.Controls.Add(this.LToff1);
            this.GBciclo1.Controls.Add(this.TBvale1);
            this.GBciclo1.Controls.Add(this.TBpico1);
            this.GBciclo1.Controls.Add(this.TBK1);
            this.GBciclo1.Controls.Add(this.TBIout1);
            this.GBciclo1.Controls.Add(this.LTon1);
            this.GBciclo1.Controls.Add(this.TBt0on1);
            this.GBciclo1.Controls.Add(this.Lt0on1);
            this.GBciclo1.Controls.Add(this.TBt0off1);
            this.GBciclo1.Controls.Add(this.Lt0off1);
            this.GBciclo1.Controls.Add(this.LAu1);
            this.GBciclo1.Controls.Add(this.TBTon1);
            this.GBciclo1.Controls.Add(this.LIout1);
            this.GBciclo1.Controls.Add(this.LAd1);
            this.GBciclo1.Controls.Add(this.LK1);
            this.GBciclo1.Controls.Add(this.LIerro1);
            this.GBciclo1.Location = new System.Drawing.Point(462, 11);
            this.GBciclo1.Name = "GBciclo1";
            this.GBciclo1.Size = new System.Drawing.Size(108, 247);
            this.GBciclo1.TabIndex = 15;
            this.GBciclo1.TabStop = false;
            this.GBciclo1.Text = "1º Ciclo";
            // 
            // TBIerro1
            // 
            this.TBIerro1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBIerro1.Location = new System.Drawing.Point(42, 169);
            this.TBIerro1.Name = "TBIerro1";
            this.TBIerro1.ReadOnly = true;
            this.TBIerro1.Size = new System.Drawing.Size(57, 20);
            this.TBIerro1.TabIndex = 0;
            // 
            // TBK1
            // 
            this.TBK1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBK1.Location = new System.Drawing.Point(42, 221);
            this.TBK1.Name = "TBK1";
            this.TBK1.ReadOnly = true;
            this.TBK1.Size = new System.Drawing.Size(57, 20);
            this.TBK1.TabIndex = 0;
            // 
            // TBIout1
            // 
            this.TBIout1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBIout1.Location = new System.Drawing.Point(42, 195);
            this.TBIout1.Name = "TBIout1";
            this.TBIout1.ReadOnly = true;
            this.TBIout1.Size = new System.Drawing.Size(57, 20);
            this.TBIout1.TabIndex = 0;
            // 
            // TBt0on1
            // 
            this.TBt0on1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBt0on1.Location = new System.Drawing.Point(42, 14);
            this.TBt0on1.Name = "TBt0on1";
            this.TBt0on1.ReadOnly = true;
            this.TBt0on1.Size = new System.Drawing.Size(57, 20);
            this.TBt0on1.TabIndex = 0;
            // 
            // Lt0on1
            // 
            this.Lt0on1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lt0on1.AutoSize = true;
            this.Lt0on1.Location = new System.Drawing.Point(12, 17);
            this.Lt0on1.Name = "Lt0on1";
            this.Lt0on1.Size = new System.Drawing.Size(28, 13);
            this.Lt0on1.TabIndex = 3;
            this.Lt0on1.Text = "t0on";
            // 
            // TBt0off1
            // 
            this.TBt0off1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBt0off1.Location = new System.Drawing.Point(42, 39);
            this.TBt0off1.Name = "TBt0off1";
            this.TBt0off1.ReadOnly = true;
            this.TBt0off1.Size = new System.Drawing.Size(57, 20);
            this.TBt0off1.TabIndex = 0;
            // 
            // Lt0off1
            // 
            this.Lt0off1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lt0off1.AutoSize = true;
            this.Lt0off1.Location = new System.Drawing.Point(12, 42);
            this.Lt0off1.Name = "Lt0off1";
            this.Lt0off1.Size = new System.Drawing.Size(28, 13);
            this.Lt0off1.TabIndex = 3;
            this.Lt0off1.Text = "t0off";
            // 
            // LIout1
            // 
            this.LIout1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LIout1.AutoSize = true;
            this.LIout1.Location = new System.Drawing.Point(4, 198);
            this.LIout1.Name = "LIout1";
            this.LIout1.Size = new System.Drawing.Size(36, 13);
            this.LIout1.TabIndex = 4;
            this.LIout1.Text = "∫ OUT";
            // 
            // LK1
            // 
            this.LK1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LK1.AutoSize = true;
            this.LK1.Location = new System.Drawing.Point(26, 224);
            this.LK1.Name = "LK1";
            this.LK1.Size = new System.Drawing.Size(14, 13);
            this.LK1.TabIndex = 2;
            this.LK1.Text = "K";
            // 
            // LIerro1
            // 
            this.LIerro1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LIerro1.AutoSize = true;
            this.LIerro1.Location = new System.Drawing.Point(9, 172);
            this.LIerro1.Name = "LIerro1";
            this.LIerro1.Size = new System.Drawing.Size(31, 13);
            this.LIerro1.TabIndex = 4;
            this.LIerro1.Text = "∫ erro";
            // 
            // GBGrafico
            // 
            this.GBGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GBGrafico.Controls.Add(this.NYmin);
            this.GBGrafico.Controls.Add(this.NYmax);
            this.GBGrafico.Controls.Add(this.NDuracao);
            this.GBGrafico.Controls.Add(this.NInicio);
            this.GBGrafico.Controls.Add(this.BTGrafico);
            this.GBGrafico.Controls.Add(this.RBParametrizacao);
            this.GBGrafico.Controls.Add(this.RBEstatico);
            this.GBGrafico.Controls.Add(this.RBAtualizando);
            this.GBGrafico.Controls.Add(this.Ymax);
            this.GBGrafico.Controls.Add(this.Inicio);
            this.GBGrafico.Controls.Add(this.Ymin);
            this.GBGrafico.Controls.Add(this.Duracao);
            this.GBGrafico.Location = new System.Drawing.Point(8, 11);
            this.GBGrafico.Name = "GBGrafico";
            this.GBGrafico.Size = new System.Drawing.Size(131, 247);
            this.GBGrafico.TabIndex = 14;
            this.GBGrafico.TabStop = false;
            this.GBGrafico.Text = "Gráfico";
            // 
            // NYmin
            // 
            this.NYmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NYmin.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NYmin.Location = new System.Drawing.Point(68, 130);
            this.NYmin.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.NYmin.Name = "NYmin";
            this.NYmin.Size = new System.Drawing.Size(51, 20);
            this.NYmin.TabIndex = 14;
            this.NYmin.ValueChanged += new System.EventHandler(this.NYmin_ValueChanged);
            // 
            // NYmax
            // 
            this.NYmax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NYmax.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NYmax.Location = new System.Drawing.Point(10, 129);
            this.NYmax.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.NYmax.Name = "NYmax";
            this.NYmax.Size = new System.Drawing.Size(52, 20);
            this.NYmax.TabIndex = 14;
            this.NYmax.Value = new decimal(new int[] {
            4200,
            0,
            0,
            0});
            this.NYmax.ValueChanged += new System.EventHandler(this.NYmax_ValueChanged);
            // 
            // NDuracao
            // 
            this.NDuracao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NDuracao.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NDuracao.Location = new System.Drawing.Point(10, 216);
            this.NDuracao.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.NDuracao.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NDuracao.Name = "NDuracao";
            this.NDuracao.Size = new System.Drawing.Size(109, 20);
            this.NDuracao.TabIndex = 14;
            this.NDuracao.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.NDuracao.ValueChanged += new System.EventHandler(this.NTempo_ValueChanged);
            // 
            // NInicio
            // 
            this.NInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NInicio.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NInicio.Location = new System.Drawing.Point(10, 173);
            this.NInicio.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.NInicio.Name = "NInicio";
            this.NInicio.Size = new System.Drawing.Size(109, 20);
            this.NInicio.TabIndex = 14;
            this.NInicio.ValueChanged += new System.EventHandler(this.NInicio_ValueChanged);
            // 
            // BTGrafico
            // 
            this.BTGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTGrafico.Enabled = false;
            this.BTGrafico.Location = new System.Drawing.Point(6, 17);
            this.BTGrafico.Name = "BTGrafico";
            this.BTGrafico.Size = new System.Drawing.Size(113, 22);
            this.BTGrafico.TabIndex = 13;
            this.BTGrafico.Text = "Plotar";
            this.BTGrafico.UseVisualStyleBackColor = true;
            this.BTGrafico.Click += new System.EventHandler(this.BTGrafico_Click);
            // 
            // RBParametrizacao
            // 
            this.RBParametrizacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RBParametrizacao.AutoSize = true;
            this.RBParametrizacao.Location = new System.Drawing.Point(10, 90);
            this.RBParametrizacao.Name = "RBParametrizacao";
            this.RBParametrizacao.Size = new System.Drawing.Size(98, 17);
            this.RBParametrizacao.TabIndex = 10;
            this.RBParametrizacao.Text = "Parametrização";
            this.RBParametrizacao.UseVisualStyleBackColor = true;
            this.RBParametrizacao.Click += new System.EventHandler(this.RBParametrizacao_Click);
            // 
            // RBEstatico
            // 
            this.RBEstatico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RBEstatico.AutoSize = true;
            this.RBEstatico.Location = new System.Drawing.Point(10, 67);
            this.RBEstatico.Name = "RBEstatico";
            this.RBEstatico.Size = new System.Drawing.Size(63, 17);
            this.RBEstatico.TabIndex = 10;
            this.RBEstatico.Text = "Estático";
            this.RBEstatico.UseVisualStyleBackColor = true;
            this.RBEstatico.Click += new System.EventHandler(this.RBEstatico_Click);
            // 
            // RBAtualizando
            // 
            this.RBAtualizando.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RBAtualizando.AutoSize = true;
            this.RBAtualizando.Checked = true;
            this.RBAtualizando.Location = new System.Drawing.Point(10, 44);
            this.RBAtualizando.Name = "RBAtualizando";
            this.RBAtualizando.Size = new System.Drawing.Size(80, 17);
            this.RBAtualizando.TabIndex = 11;
            this.RBAtualizando.TabStop = true;
            this.RBAtualizando.Text = "Atualizando";
            this.RBAtualizando.UseVisualStyleBackColor = true;
            this.RBAtualizando.Click += new System.EventHandler(this.RBAtualizando_Click);
            // 
            // Ymax
            // 
            this.Ymax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Ymax.AutoSize = true;
            this.Ymax.Location = new System.Drawing.Point(7, 113);
            this.Ymax.Name = "Ymax";
            this.Ymax.Size = new System.Drawing.Size(33, 13);
            this.Ymax.TabIndex = 12;
            this.Ymax.Text = "Ymax";
            // 
            // Inicio
            // 
            this.Inicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Inicio.AutoSize = true;
            this.Inicio.Location = new System.Drawing.Point(10, 157);
            this.Inicio.Name = "Inicio";
            this.Inicio.Size = new System.Drawing.Size(74, 13);
            this.Inicio.TabIndex = 12;
            this.Inicio.Text = "Início (miliseg)";
            // 
            // Ymin
            // 
            this.Ymin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Ymin.AutoSize = true;
            this.Ymin.Location = new System.Drawing.Point(65, 113);
            this.Ymin.Name = "Ymin";
            this.Ymin.Size = new System.Drawing.Size(30, 13);
            this.Ymin.TabIndex = 12;
            this.Ymin.Text = "Ymin";
            // 
            // Duracao
            // 
            this.Duracao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Duracao.AutoSize = true;
            this.Duracao.Location = new System.Drawing.Point(10, 200);
            this.Duracao.Name = "Duracao";
            this.Duracao.Size = new System.Drawing.Size(88, 13);
            this.Duracao.TabIndex = 12;
            this.Duracao.Text = "Duração (miliseg)";
            // 
            // GBProcesso
            // 
            this.GBProcesso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GBProcesso.Controls.Add(this.GBModelo);
            this.GBProcesso.Controls.Add(this.GBAtraso);
            this.GBProcesso.Controls.Add(this.GBFuncao);
            this.GBProcesso.Controls.Add(this.TBmVP);
            this.GBProcesso.Controls.Add(this.TBVP);
            this.GBProcesso.Controls.Add(this.TBmOUT);
            this.GBProcesso.Controls.Add(this.TBOUT);
            this.GBProcesso.Controls.Add(this.LmOUT);
            this.GBProcesso.Controls.Add(this.LVariavelControlada);
            this.GBProcesso.Controls.Add(this.LmVP);
            this.GBProcesso.Controls.Add(this.LVariavelProcesso);
            this.GBProcesso.Location = new System.Drawing.Point(145, 11);
            this.GBProcesso.Name = "GBProcesso";
            this.GBProcesso.Size = new System.Drawing.Size(197, 247);
            this.GBProcesso.TabIndex = 13;
            this.GBProcesso.TabStop = false;
            this.GBProcesso.Text = "Processo";
            // 
            // GBModelo
            // 
            this.GBModelo.Controls.Add(this.RBON);
            this.GBModelo.Controls.Add(this.RBOFF);
            this.GBModelo.Controls.Add(this.RBMedia);
            this.GBModelo.Location = new System.Drawing.Point(6, 68);
            this.GBModelo.Name = "GBModelo";
            this.GBModelo.Size = new System.Drawing.Size(185, 48);
            this.GBModelo.TabIndex = 14;
            this.GBModelo.TabStop = false;
            this.GBModelo.Text = "Modelo";
            // 
            // RBON
            // 
            this.RBON.AutoSize = true;
            this.RBON.Enabled = false;
            this.RBON.Location = new System.Drawing.Point(8, 21);
            this.RBON.Name = "RBON";
            this.RBON.Size = new System.Drawing.Size(41, 17);
            this.RBON.TabIndex = 10;
            this.RBON.Text = "ON";
            this.RBON.UseVisualStyleBackColor = true;
            this.RBON.Click += new System.EventHandler(this.RBON_Click);
            // 
            // RBOFF
            // 
            this.RBOFF.AutoSize = true;
            this.RBOFF.Enabled = false;
            this.RBOFF.Location = new System.Drawing.Point(65, 21);
            this.RBOFF.Name = "RBOFF";
            this.RBOFF.Size = new System.Drawing.Size(45, 17);
            this.RBOFF.TabIndex = 11;
            this.RBOFF.Text = "OFF";
            this.RBOFF.UseVisualStyleBackColor = true;
            this.RBOFF.Click += new System.EventHandler(this.RBOFF_Click);
            // 
            // RBMedia
            // 
            this.RBMedia.AutoSize = true;
            this.RBMedia.Checked = true;
            this.RBMedia.Enabled = false;
            this.RBMedia.Location = new System.Drawing.Point(121, 21);
            this.RBMedia.Name = "RBMedia";
            this.RBMedia.Size = new System.Drawing.Size(54, 17);
            this.RBMedia.TabIndex = 12;
            this.RBMedia.TabStop = true;
            this.RBMedia.Text = "Média";
            this.RBMedia.UseVisualStyleBackColor = true;
            this.RBMedia.Click += new System.EventHandler(this.RBMedia_Click);
            // 
            // GBAtraso
            // 
            this.GBAtraso.Controls.Add(this.RBMedido);
            this.GBAtraso.Controls.Add(this.RBCalculado);
            this.GBAtraso.Location = new System.Drawing.Point(6, 122);
            this.GBAtraso.Name = "GBAtraso";
            this.GBAtraso.Size = new System.Drawing.Size(185, 48);
            this.GBAtraso.TabIndex = 13;
            this.GBAtraso.TabStop = false;
            this.GBAtraso.Text = "Atraso";
            // 
            // RBMedido
            // 
            this.RBMedido.AutoSize = true;
            this.RBMedido.Enabled = false;
            this.RBMedido.Location = new System.Drawing.Point(104, 19);
            this.RBMedido.Name = "RBMedido";
            this.RBMedido.Size = new System.Drawing.Size(72, 17);
            this.RBMedido.TabIndex = 1;
            this.RBMedido.Text = "t0 Medido";
            this.RBMedido.UseVisualStyleBackColor = true;
            this.RBMedido.Click += new System.EventHandler(this.RBMedido_Click);
            // 
            // RBCalculado
            // 
            this.RBCalculado.AutoSize = true;
            this.RBCalculado.Checked = true;
            this.RBCalculado.Enabled = false;
            this.RBCalculado.Location = new System.Drawing.Point(8, 19);
            this.RBCalculado.Name = "RBCalculado";
            this.RBCalculado.Size = new System.Drawing.Size(84, 17);
            this.RBCalculado.TabIndex = 0;
            this.RBCalculado.TabStop = true;
            this.RBCalculado.Text = "t0 Calculado";
            this.RBCalculado.UseVisualStyleBackColor = true;
            this.RBCalculado.Click += new System.EventHandler(this.RBCalculado_Click);
            // 
            // GBFuncao
            // 
            this.GBFuncao.Controls.Add(this.numerador);
            this.GBFuncao.Controls.Add(this.expoente);
            this.GBFuncao.Controls.Add(this.divisor);
            this.GBFuncao.Controls.Add(this.funcao);
            this.GBFuncao.Location = new System.Drawing.Point(6, 176);
            this.GBFuncao.Name = "GBFuncao";
            this.GBFuncao.Size = new System.Drawing.Size(185, 66);
            this.GBFuncao.TabIndex = 9;
            this.GBFuncao.TabStop = false;
            this.GBFuncao.Text = "Função";
            // 
            // numerador
            // 
            this.numerador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numerador.AutoSize = true;
            this.numerador.Location = new System.Drawing.Point(51, 28);
            this.numerador.Name = "numerador";
            this.numerador.Size = new System.Drawing.Size(46, 13);
            this.numerador.TabIndex = 1;
            this.numerador.Text = "1000.00";
            // 
            // expoente
            // 
            this.expoente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.expoente.AutoSize = true;
            this.expoente.Location = new System.Drawing.Point(118, 23);
            this.expoente.Name = "expoente";
            this.expoente.Size = new System.Drawing.Size(48, 13);
            this.expoente.TabIndex = 1;
            this.expoente.Text = "- 10.00 s";
            // 
            // divisor
            // 
            this.divisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.divisor.AutoSize = true;
            this.divisor.Location = new System.Drawing.Point(45, 42);
            this.divisor.Name = "divisor";
            this.divisor.Size = new System.Drawing.Size(69, 13);
            this.divisor.TabIndex = 2;
            this.divisor.Text = "( 100.0 s + 1)";
            // 
            // funcao
            // 
            this.funcao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.funcao.AutoSize = true;
            this.funcao.Location = new System.Drawing.Point(5, 29);
            this.funcao.Name = "funcao";
            this.funcao.Size = new System.Drawing.Size(116, 13);
            this.funcao.TabIndex = 0;
            this.funcao.Text = "Gp(s) = ___________e";
            // 
            // TBmVP
            // 
            this.TBmVP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBmVP.Location = new System.Drawing.Point(134, 14);
            this.TBmVP.Name = "TBmVP";
            this.TBmVP.ReadOnly = true;
            this.TBmVP.Size = new System.Drawing.Size(57, 20);
            this.TBmVP.TabIndex = 1;
            // 
            // TBVP
            // 
            this.TBVP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBVP.Location = new System.Drawing.Point(36, 16);
            this.TBVP.Name = "TBVP";
            this.TBVP.ReadOnly = true;
            this.TBVP.Size = new System.Drawing.Size(57, 20);
            this.TBVP.TabIndex = 1;
            // 
            // TBmOUT
            // 
            this.TBmOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBmOUT.Location = new System.Drawing.Point(134, 40);
            this.TBmOUT.Name = "TBmOUT";
            this.TBmOUT.ReadOnly = true;
            this.TBmOUT.Size = new System.Drawing.Size(57, 20);
            this.TBmOUT.TabIndex = 1;
            // 
            // TBOUT
            // 
            this.TBOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBOUT.Location = new System.Drawing.Point(36, 42);
            this.TBOUT.Name = "TBOUT";
            this.TBOUT.ReadOnly = true;
            this.TBOUT.Size = new System.Drawing.Size(57, 20);
            this.TBOUT.TabIndex = 1;
            // 
            // LmOUT
            // 
            this.LmOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LmOUT.AutoSize = true;
            this.LmOUT.Location = new System.Drawing.Point(94, 46);
            this.LmOUT.Name = "LmOUT";
            this.LmOUT.Size = new System.Drawing.Size(38, 13);
            this.LmOUT.TabIndex = 8;
            this.LmOUT.Text = "mOUT";
            // 
            // LVariavelControlada
            // 
            this.LVariavelControlada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LVariavelControlada.AutoSize = true;
            this.LVariavelControlada.Location = new System.Drawing.Point(4, 45);
            this.LVariavelControlada.Name = "LVariavelControlada";
            this.LVariavelControlada.Size = new System.Drawing.Size(30, 13);
            this.LVariavelControlada.TabIndex = 8;
            this.LVariavelControlada.Text = "OUT";
            // 
            // LmVP
            // 
            this.LmVP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LmVP.AutoSize = true;
            this.LmVP.Location = new System.Drawing.Point(103, 20);
            this.LmVP.Name = "LmVP";
            this.LmVP.Size = new System.Drawing.Size(29, 13);
            this.LmVP.TabIndex = 8;
            this.LmVP.Text = "mVP";
            // 
            // LVariavelProcesso
            // 
            this.LVariavelProcesso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LVariavelProcesso.AutoSize = true;
            this.LVariavelProcesso.Location = new System.Drawing.Point(13, 19);
            this.LVariavelProcesso.Name = "LVariavelProcesso";
            this.LVariavelProcesso.Size = new System.Drawing.Size(21, 13);
            this.LVariavelProcesso.TabIndex = 8;
            this.LVariavelProcesso.Text = "VP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(692, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 1;
            // 
            // databaseTCCDataSet1
            // 
            this.databaseTCCDataSet1.DataSetName = "DatabaseTCCDataSet";
            this.databaseTCCDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BTAcao
            // 
            this.BTAcao.Enabled = false;
            this.BTAcao.Location = new System.Drawing.Point(106, 46);
            this.BTAcao.Name = "BTAcao";
            this.BTAcao.Size = new System.Drawing.Size(92, 23);
            this.BTAcao.TabIndex = 14;
            this.BTAcao.Text = "Ação Direta";
            this.BTAcao.UseVisualStyleBackColor = true;
            this.BTAcao.Click += new System.EventHandler(this.BTAcao_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 699);
            this.Controls.Add(this.GBPainelInferior);
            this.Controls.Add(this.Grafico);
            this.Controls.Add(this.GBPainelLateral);
            this.Name = "Form1";
            this.Text = "Form1";
            this.GBPainelLateral.ResumeLayout(false);
            this.GBestabilidade.ResumeLayout(false);
            this.GBestabilidade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NVPvar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NVPmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NOUTvar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NOUTmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NVPmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NOUTmax)).EndInit();
            this.GBMalha.ResumeLayout(false);
            this.GBMalha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NSO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NSetpoint)).EndInit();
            this.GBArduino.ResumeLayout(false);
            this.GBArduino.PerformLayout();
            this.GBRELE.ResumeLayout(false);
            this.GBRELE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NBiasHisterese)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NHistereseRele)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBiasAmplitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NAmplitudeRele)).EndInit();
            this.GBPID.ResumeLayout(false);
            this.GBPID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NLambda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NTAmostragem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NKd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NKi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NKp)).EndInit();
            this.GBComunicacao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaxaTransferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grafico)).EndInit();
            this.GBPainelInferior.ResumeLayout(false);
            this.GBPainelInferior.PerformLayout();
            this.GBmedia.ResumeLayout(false);
            this.GBmedia.PerformLayout();
            this.GBciclo4.ResumeLayout(false);
            this.GBciclo4.PerformLayout();
            this.GBciclo2.ResumeLayout(false);
            this.GBciclo2.PerformLayout();
            this.GBciclo3.ResumeLayout(false);
            this.GBciclo3.PerformLayout();
            this.GBciclo1.ResumeLayout(false);
            this.GBciclo1.PerformLayout();
            this.GBGrafico.ResumeLayout(false);
            this.GBGrafico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NYmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NYmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NDuracao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NInicio)).EndInit();
            this.GBProcesso.ResumeLayout(false);
            this.GBProcesso.PerformLayout();
            this.GBModelo.ResumeLayout(false);
            this.GBModelo.PerformLayout();
            this.GBAtraso.ResumeLayout(false);
            this.GBAtraso.PerformLayout();
            this.GBFuncao.ResumeLayout(false);
            this.GBFuncao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseTCCDataSet1)).EndInit();
            this.ResumeLayout(false);

        }
        

        #endregion

        private System.Windows.Forms.GroupBox GBPainelLateral;
        private System.Windows.Forms.DataVisualization.Charting.Chart Grafico;
        private System.Windows.Forms.GroupBox GBPainelInferior;
        private System.Windows.Forms.GroupBox GBComunicacao;
        private System.Windows.Forms.ComboBox portaseriallista;
        private System.Windows.Forms.NumericUpDown TaxaTransferencia;
        private System.Windows.Forms.Button BTConectar;
        private System.Windows.Forms.Button BTAtualizar;
        private System.Windows.Forms.GroupBox GBArduino;
        private System.Windows.Forms.TextBox TBRecebeArduino;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.TextBox TBEnviaArduino;
        private System.Windows.Forms.GroupBox GBRELE;
        private System.Windows.Forms.Label LAu1;
        private System.Windows.Forms.Label LAd1;
        private System.Windows.Forms.Label LToff1;
        private System.Windows.Forms.Label LTon1;
        private System.Windows.Forms.Label HistereseRele;
        private System.Windows.Forms.Label AmplitudeRele;
        private System.Windows.Forms.TextBox TBpico1;
        private System.Windows.Forms.TextBox TBvale1;
        private System.Windows.Forms.TextBox TBToff1;
        private System.Windows.Forms.TextBox TBTon1;
        private System.Windows.Forms.GroupBox GBPID;
        private System.Windows.Forms.Label Kderivativo;
        private System.Windows.Forms.Label Kintegral;
        private System.Windows.Forms.Label Kproporcional;
        private System.Windows.Forms.Label Setpoint;
        private System.Windows.Forms.RadioButton RB3;
        private System.Windows.Forms.RadioButton RB2;
        private System.Windows.Forms.RadioButton RB1;
        private System.Windows.Forms.Label divisor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label expoente;
        private System.Windows.Forms.Label numerador;
        private System.Windows.Forms.Label funcao;
        private System.Windows.Forms.Label LVariavelProcesso;
        private System.Windows.Forms.TextBox TBVP;
        private System.Windows.Forms.Label LVariavelControlada;
        private System.Windows.Forms.TextBox TBOUT;
        private System.IO.Ports.SerialPort serialPortTCC;
        private DatabaseTCCDataSet databaseTCCDataSet1;
        private System.Windows.Forms.NumericUpDown NHistereseRele;
        private System.Windows.Forms.NumericUpDown NAmplitudeRele;
        private System.Windows.Forms.NumericUpDown NKd;
        private System.Windows.Forms.NumericUpDown NKi;
        private System.Windows.Forms.NumericUpDown NKp;
        private System.Windows.Forms.NumericUpDown NSetpoint;
        private System.Windows.Forms.GroupBox GBMalha;
        private System.Windows.Forms.RadioButton RBAberta;
        private System.Windows.Forms.RadioButton RBPIDBrett;
        private System.Windows.Forms.Label Inicio;
        private System.Windows.Forms.Label Duracao;
        private System.Windows.Forms.RadioButton RBAtualizando;
        private System.Windows.Forms.RadioButton RBEstatico;
        private System.Windows.Forms.GroupBox GBGrafico;
        private System.Windows.Forms.GroupBox GBProcesso;
        private System.Windows.Forms.RadioButton RBReleUP;
        private System.Windows.Forms.Label SinalOperacao;
        private System.Windows.Forms.NumericUpDown NSO;
        private System.Windows.Forms.Button BTGrafico;
        private System.Windows.Forms.Label Ymax;
        private System.Windows.Forms.Label Ymin;
        private System.Windows.Forms.NumericUpDown NYmin;
        private System.Windows.Forms.NumericUpDown NYmax;
        private System.Windows.Forms.NumericUpDown NDuracao;
        private System.Windows.Forms.NumericUpDown NInicio;
        private System.Windows.Forms.GroupBox GBstatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown NTAmostragem;
        private System.Windows.Forms.Label TaxaAmostragem;
        private System.Windows.Forms.GroupBox GBmedia;
        private System.Windows.Forms.TextBox TBToffM;
        private System.Windows.Forms.TextBox TBIerroM;
        private System.Windows.Forms.Label LToffM;
        private System.Windows.Forms.TextBox TBvaleM;
        private System.Windows.Forms.TextBox TBpicoM;
        private System.Windows.Forms.TextBox TBKM;
        private System.Windows.Forms.TextBox TBIoutM;
        private System.Windows.Forms.Label LTonM;
        private System.Windows.Forms.TextBox TBt0onM;
        private System.Windows.Forms.Label Lt0onM;
        private System.Windows.Forms.TextBox TBt0offM;
        private System.Windows.Forms.Label Lt0offM;
        private System.Windows.Forms.Label LAuM;
        private System.Windows.Forms.TextBox TBTonM;
        private System.Windows.Forms.Label LIoutM;
        private System.Windows.Forms.Label LAdM;
        private System.Windows.Forms.Label LKM;
        private System.Windows.Forms.Label LIerroM;
        private System.Windows.Forms.GroupBox GBciclo4;
        private System.Windows.Forms.TextBox TBToff4;
        private System.Windows.Forms.TextBox TBIerro4;
        private System.Windows.Forms.Label LToff4;
        private System.Windows.Forms.TextBox TBvale4;
        private System.Windows.Forms.TextBox TBpico4;
        private System.Windows.Forms.TextBox TBK4;
        private System.Windows.Forms.TextBox TBIout4;
        private System.Windows.Forms.Label LTon4;
        private System.Windows.Forms.TextBox TBt0on4;
        private System.Windows.Forms.Label Lt0on4;
        private System.Windows.Forms.TextBox TBt0off4;
        private System.Windows.Forms.Label Lt0off4;
        private System.Windows.Forms.Label LAu4;
        private System.Windows.Forms.TextBox TBTon4;
        private System.Windows.Forms.Label LIout4;
        private System.Windows.Forms.Label LAd4;
        private System.Windows.Forms.Label LK4;
        private System.Windows.Forms.Label LIerro4;
        private System.Windows.Forms.GroupBox GBciclo2;
        private System.Windows.Forms.TextBox TBToff2;
        private System.Windows.Forms.TextBox TBIerro2;
        private System.Windows.Forms.Label LToff2;
        private System.Windows.Forms.TextBox TBvale2;
        private System.Windows.Forms.TextBox TBpico2;
        private System.Windows.Forms.TextBox TBK2;
        private System.Windows.Forms.TextBox TBIout2;
        private System.Windows.Forms.Label LTon2;
        private System.Windows.Forms.TextBox TBt0on2;
        private System.Windows.Forms.Label Lt0on2;
        private System.Windows.Forms.TextBox TBt0off2;
        private System.Windows.Forms.Label Lt0off2;
        private System.Windows.Forms.Label LAu2;
        private System.Windows.Forms.TextBox TBTon2;
        private System.Windows.Forms.Label LIout2;
        private System.Windows.Forms.Label LAd2;
        private System.Windows.Forms.Label LK2;
        private System.Windows.Forms.Label LIerro2;
        private System.Windows.Forms.GroupBox GBciclo3;
        private System.Windows.Forms.TextBox TBToff3;
        private System.Windows.Forms.TextBox TBIerro3;
        private System.Windows.Forms.Label LToff3;
        private System.Windows.Forms.TextBox TBvale3;
        private System.Windows.Forms.TextBox TBpico3;
        private System.Windows.Forms.TextBox TBK3;
        private System.Windows.Forms.TextBox TBIout3;
        private System.Windows.Forms.Label LTon3;
        private System.Windows.Forms.TextBox TBt0on3;
        private System.Windows.Forms.Label Lt0on3;
        private System.Windows.Forms.TextBox TBt0off3;
        private System.Windows.Forms.Label Lt0off3;
        private System.Windows.Forms.Label LAu3;
        private System.Windows.Forms.TextBox TBTon3;
        private System.Windows.Forms.Label LIout3;
        private System.Windows.Forms.Label LAd3;
        private System.Windows.Forms.Label LK3;
        private System.Windows.Forms.Label LIerro3;
        private System.Windows.Forms.GroupBox GBciclo1;
        private System.Windows.Forms.TextBox TBIerro1;
        private System.Windows.Forms.TextBox TBK1;
        private System.Windows.Forms.TextBox TBIout1;
        private System.Windows.Forms.TextBox TBt0on1;
        private System.Windows.Forms.Label Lt0on1;
        private System.Windows.Forms.TextBox TBt0off1;
        private System.Windows.Forms.Label Lt0off1;
        private System.Windows.Forms.Label LIout1;
        private System.Windows.Forms.Label LK1;
        private System.Windows.Forms.Label LIerro1;
        private System.Windows.Forms.TextBox TBmVP;
        private System.Windows.Forms.TextBox TBmOUT;
        private System.Windows.Forms.Label LmOUT;
        private System.Windows.Forms.Label LmVP;
        private System.Windows.Forms.RadioButton RBOFF;
        private System.Windows.Forms.RadioButton RBON;
        private System.Windows.Forms.GroupBox GBFuncao;
        private System.Windows.Forms.NumericUpDown NBiasHisterese;
        private System.Windows.Forms.NumericUpDown NBiasAmplitude;
        private System.Windows.Forms.Label BiasHisterese;
        private System.Windows.Forms.Label BiasAmplitude;
        private System.Windows.Forms.GroupBox GBestabilidade;
        private System.Windows.Forms.NumericUpDown NVPvar;
        private System.Windows.Forms.NumericUpDown NVPmin;
        private System.Windows.Forms.NumericUpDown NOUTvar;
        private System.Windows.Forms.NumericUpDown NOUTmin;
        private System.Windows.Forms.NumericUpDown NVPmax;
        private System.Windows.Forms.Label Variacao;
        private System.Windows.Forms.NumericUpDown NOUTmax;
        private System.Windows.Forms.Label Maximo;
        private System.Windows.Forms.Label Minimo;
        private System.Windows.Forms.Label VPestabilidade;
        private System.Windows.Forms.Label OUTestabilidade;
        private System.Windows.Forms.RadioButton RBParametrizacao;
        private System.Windows.Forms.NumericUpDown NLambda;
        private System.Windows.Forms.RadioButton RB4;
        private System.Windows.Forms.Label Lambda;
        private System.Windows.Forms.RadioButton RBPIDParalelo;
        private System.Windows.Forms.RadioButton RBReleDown;
        private System.Windows.Forms.GroupBox GBAtraso;
        private System.Windows.Forms.RadioButton RBMedido;
        private System.Windows.Forms.RadioButton RBCalculado;
        private System.Windows.Forms.RadioButton RBMedia;
        private System.Windows.Forms.GroupBox GBModelo;
        private System.Windows.Forms.Button BTAcao;
    }
}

