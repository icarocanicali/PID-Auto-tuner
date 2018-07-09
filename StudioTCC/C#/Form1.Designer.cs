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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.GBPainelLateral = new System.Windows.Forms.GroupBox();
            this.GBMalha = new System.Windows.Forms.GroupBox();
            this.RBRele = new System.Windows.Forms.RadioButton();
            this.RBAberta = new System.Windows.Forms.RadioButton();
            this.RBPID = new System.Windows.Forms.RadioButton();
            this.SinalOperacao = new System.Windows.Forms.Label();
            this.NSO = new System.Windows.Forms.NumericUpDown();
            this.Setpoint = new System.Windows.Forms.Label();
            this.NSetpoint = new System.Windows.Forms.NumericUpDown();
            this.GBArduino = new System.Windows.Forms.GroupBox();
            this.TBRecebeArduino = new System.Windows.Forms.TextBox();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.TBEnviaArduino = new System.Windows.Forms.TextBox();
            this.GBRELE = new System.Windows.Forms.GroupBox();
            this.NHisterese = new System.Windows.Forms.NumericUpDown();
            this.NAmplitudeRele = new System.Windows.Forms.NumericUpDown();
            this.HistereseLabel = new System.Windows.Forms.Label();
            this.AmplitudeRele = new System.Windows.Forms.Label();
            this.GBPID = new System.Windows.Forms.GroupBox();
            this.NKd = new System.Windows.Forms.NumericUpDown();
            this.NKi = new System.Windows.Forms.NumericUpDown();
            this.NKp = new System.Windows.Forms.NumericUpDown();
            this.Kderivativo = new System.Windows.Forms.Label();
            this.Kintegral = new System.Windows.Forms.Label();
            this.Kproporcional = new System.Windows.Forms.Label();
            this.RB3 = new System.Windows.Forms.RadioButton();
            this.RB2 = new System.Windows.Forms.RadioButton();
            this.RB1 = new System.Windows.Forms.RadioButton();
            this.GBComunicacao = new System.Windows.Forms.GroupBox();
            this.TaxaTransferencia = new System.Windows.Forms.NumericUpDown();
            this.BTConectar = new System.Windows.Forms.Button();
            this.BTAtualizar = new System.Windows.Forms.Button();
            this.portaseriallista = new System.Windows.Forms.ComboBox();
            this.AlturaPico = new System.Windows.Forms.Label();
            this.AlturaVale = new System.Windows.Forms.Label();
            this.TempoOFF = new System.Windows.Forms.Label();
            this.TempoON = new System.Windows.Forms.Label();
            this.TempoCritico = new System.Windows.Forms.Label();
            this.GanhoCritico = new System.Windows.Forms.Label();
            this.TBAlturaPico = new System.Windows.Forms.TextBox();
            this.TBAlturaVale = new System.Windows.Forms.TextBox();
            this.TBTempoOFF = new System.Windows.Forms.TextBox();
            this.TBTempoON = new System.Windows.Forms.TextBox();
            this.TBTempoCritico = new System.Windows.Forms.TextBox();
            this.TBGanhoCritico = new System.Windows.Forms.TextBox();
            this.Grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GBPainelInferior = new System.Windows.Forms.GroupBox();
            this.GBGrafico = new System.Windows.Forms.GroupBox();
            this.NYmin = new System.Windows.Forms.NumericUpDown();
            this.NYmax = new System.Windows.Forms.NumericUpDown();
            this.NTempo = new System.Windows.Forms.NumericUpDown();
            this.NInicio = new System.Windows.Forms.NumericUpDown();
            this.BTGrafico = new System.Windows.Forms.Button();
            this.RBEstatico = new System.Windows.Forms.RadioButton();
            this.RBAtualizando = new System.Windows.Forms.RadioButton();
            this.Ymax = new System.Windows.Forms.Label();
            this.Inicio = new System.Windows.Forms.Label();
            this.Ymin = new System.Windows.Forms.Label();
            this.Tamanho = new System.Windows.Forms.Label();
            this.GBProcesso = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBVariavelProcesso = new System.Windows.Forms.TextBox();
            this.TBVariavelControlada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.VariavelControlada = new System.Windows.Forms.Label();
            this.VariavelProcesso = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serialPortTCC = new System.IO.Ports.SerialPort(this.components);
            this.databaseTCCDataSet1 = new TCC.DatabaseTCCDataSet();
            this.GBPainelLateral.SuspendLayout();
            this.GBMalha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NSO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NSetpoint)).BeginInit();
            this.GBArduino.SuspendLayout();
            this.GBRELE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NHisterese)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NAmplitudeRele)).BeginInit();
            this.GBPID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NKd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NKi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NKp)).BeginInit();
            this.GBComunicacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaxaTransferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grafico)).BeginInit();
            this.GBPainelInferior.SuspendLayout();
            this.GBGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NYmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NYmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NTempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NInicio)).BeginInit();
            this.GBProcesso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseTCCDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // GBPainelLateral
            // 
            this.GBPainelLateral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GBPainelLateral.Controls.Add(this.GBMalha);
            this.GBPainelLateral.Controls.Add(this.GBArduino);
            this.GBPainelLateral.Controls.Add(this.GBRELE);
            this.GBPainelLateral.Controls.Add(this.GBPID);
            this.GBPainelLateral.Controls.Add(this.GBComunicacao);
            this.GBPainelLateral.Location = new System.Drawing.Point(3, 3);
            this.GBPainelLateral.Name = "GBPainelLateral";
            this.GBPainelLateral.Size = new System.Drawing.Size(214, 487);
            this.GBPainelLateral.TabIndex = 0;
            this.GBPainelLateral.TabStop = false;
            // 
            // GBMalha
            // 
            this.GBMalha.Controls.Add(this.RBRele);
            this.GBMalha.Controls.Add(this.RBAberta);
            this.GBMalha.Controls.Add(this.RBPID);
            this.GBMalha.Controls.Add(this.SinalOperacao);
            this.GBMalha.Controls.Add(this.NSO);
            this.GBMalha.Controls.Add(this.Setpoint);
            this.GBMalha.Controls.Add(this.NSetpoint);
            this.GBMalha.Location = new System.Drawing.Point(3, 100);
            this.GBMalha.Name = "GBMalha";
            this.GBMalha.Size = new System.Drawing.Size(208, 69);
            this.GBMalha.TabIndex = 4;
            this.GBMalha.TabStop = false;
            this.GBMalha.Text = "Malha";
            // 
            // RBRele
            // 
            this.RBRele.AutoSize = true;
            this.RBRele.Enabled = false;
            this.RBRele.Location = new System.Drawing.Point(83, 46);
            this.RBRele.Name = "RBRele";
            this.RBRele.Size = new System.Drawing.Size(47, 17);
            this.RBRele.TabIndex = 11;
            this.RBRele.TabStop = true;
            this.RBRele.Text = "Relé";
            this.RBRele.UseVisualStyleBackColor = true;
            this.RBRele.Click += new System.EventHandler(this.RBRele_Click);
            // 
            // RBAberta
            // 
            this.RBAberta.AutoSize = true;
            this.RBAberta.Checked = true;
            this.RBAberta.Enabled = false;
            this.RBAberta.Location = new System.Drawing.Point(6, 46);
            this.RBAberta.Name = "RBAberta";
            this.RBAberta.Size = new System.Drawing.Size(56, 17);
            this.RBAberta.TabIndex = 10;
            this.RBAberta.TabStop = true;
            this.RBAberta.Text = "Aberta";
            this.RBAberta.UseVisualStyleBackColor = true;
            this.RBAberta.Click += new System.EventHandler(this.RBAberta_Click);
            // 
            // RBPID
            // 
            this.RBPID.AutoSize = true;
            this.RBPID.Enabled = false;
            this.RBPID.Location = new System.Drawing.Point(154, 46);
            this.RBPID.Name = "RBPID";
            this.RBPID.Size = new System.Drawing.Size(43, 17);
            this.RBPID.TabIndex = 10;
            this.RBPID.Text = "PID";
            this.RBPID.UseVisualStyleBackColor = true;
            this.RBPID.Click += new System.EventHandler(this.RBPID_Click);
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
            this.GBArduino.Location = new System.Drawing.Point(3, 344);
            this.GBArduino.Name = "GBArduino";
            this.GBArduino.Size = new System.Drawing.Size(208, 137);
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
            this.TBRecebeArduino.Size = new System.Drawing.Size(194, 86);
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
            this.GBRELE.Controls.Add(this.NHisterese);
            this.GBRELE.Controls.Add(this.NAmplitudeRele);
            this.GBRELE.Controls.Add(this.HistereseLabel);
            this.GBRELE.Controls.Add(this.AmplitudeRele);
            this.GBRELE.Location = new System.Drawing.Point(3, 175);
            this.GBRELE.Name = "GBRELE";
            this.GBRELE.Size = new System.Drawing.Size(208, 60);
            this.GBRELE.TabIndex = 2;
            this.GBRELE.TabStop = false;
            this.GBRELE.Text = "Relé";
            // 
            // NHisterese
            // 
            this.NHisterese.Enabled = false;
            this.NHisterese.Location = new System.Drawing.Point(110, 32);
            this.NHisterese.Maximum = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.NHisterese.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.NHisterese.Name = "NHisterese";
            this.NHisterese.Size = new System.Drawing.Size(87, 20);
            this.NHisterese.TabIndex = 6;
            this.NHisterese.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.NHisterese.ValueChanged += new System.EventHandler(this.NHisterese_ValueChanged);
            // 
            // NAmplitudeRele
            // 
            this.NAmplitudeRele.Enabled = false;
            this.NAmplitudeRele.Location = new System.Drawing.Point(6, 32);
            this.NAmplitudeRele.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.NAmplitudeRele.Minimum = new decimal(new int[] {
            175,
            0,
            0,
            0});
            this.NAmplitudeRele.Name = "NAmplitudeRele";
            this.NAmplitudeRele.Size = new System.Drawing.Size(87, 20);
            this.NAmplitudeRele.TabIndex = 5;
            this.NAmplitudeRele.Value = new decimal(new int[] {
            205,
            0,
            0,
            0});
            this.NAmplitudeRele.ValueChanged += new System.EventHandler(this.NAmplitudeRele_ValueChanged);
            // 
            // HistereseLabel
            // 
            this.HistereseLabel.AutoSize = true;
            this.HistereseLabel.Location = new System.Drawing.Point(110, 17);
            this.HistereseLabel.Name = "HistereseLabel";
            this.HistereseLabel.Size = new System.Drawing.Size(51, 13);
            this.HistereseLabel.TabIndex = 1;
            this.HistereseLabel.Text = "Histerese";
            // 
            // AmplitudeRele
            // 
            this.AmplitudeRele.AutoSize = true;
            this.AmplitudeRele.Location = new System.Drawing.Point(3, 16);
            this.AmplitudeRele.Name = "AmplitudeRele";
            this.AmplitudeRele.Size = new System.Drawing.Size(78, 13);
            this.AmplitudeRele.TabIndex = 1;
            this.AmplitudeRele.Text = "Amplitude Rele";
            // 
            // GBPID
            // 
            this.GBPID.Controls.Add(this.NKd);
            this.GBPID.Controls.Add(this.NKi);
            this.GBPID.Controls.Add(this.NKp);
            this.GBPID.Controls.Add(this.Kderivativo);
            this.GBPID.Controls.Add(this.Kintegral);
            this.GBPID.Controls.Add(this.Kproporcional);
            this.GBPID.Controls.Add(this.RB3);
            this.GBPID.Controls.Add(this.RB2);
            this.GBPID.Controls.Add(this.RB1);
            this.GBPID.Location = new System.Drawing.Point(3, 240);
            this.GBPID.Name = "GBPID";
            this.GBPID.Size = new System.Drawing.Size(208, 97);
            this.GBPID.TabIndex = 1;
            this.GBPID.TabStop = false;
            this.GBPID.Text = "PID";
            // 
            // NKd
            // 
            this.NKd.Enabled = false;
            this.NKd.Location = new System.Drawing.Point(23, 68);
            this.NKd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NKd.Name = "NKd";
            this.NKd.Size = new System.Drawing.Size(82, 20);
            this.NKd.TabIndex = 11;
            this.NKd.ValueChanged += new System.EventHandler(this.NKd_ValueChanged);
            // 
            // NKi
            // 
            this.NKi.Enabled = false;
            this.NKi.Location = new System.Drawing.Point(22, 42);
            this.NKi.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NKi.Name = "NKi";
            this.NKi.Size = new System.Drawing.Size(83, 20);
            this.NKi.TabIndex = 10;
            this.NKi.ValueChanged += new System.EventHandler(this.NKi_ValueChanged);
            // 
            // NKp
            // 
            this.NKp.Enabled = false;
            this.NKp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NKp.Location = new System.Drawing.Point(22, 16);
            this.NKp.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NKp.Name = "NKp";
            this.NKp.Size = new System.Drawing.Size(82, 20);
            this.NKp.TabIndex = 9;
            this.NKp.ValueChanged += new System.EventHandler(this.NKp_ValueChanged);
            // 
            // Kderivativo
            // 
            this.Kderivativo.AutoSize = true;
            this.Kderivativo.Location = new System.Drawing.Point(3, 72);
            this.Kderivativo.Name = "Kderivativo";
            this.Kderivativo.Size = new System.Drawing.Size(20, 13);
            this.Kderivativo.TabIndex = 8;
            this.Kderivativo.Text = "Kd";
            // 
            // Kintegral
            // 
            this.Kintegral.AutoSize = true;
            this.Kintegral.Location = new System.Drawing.Point(3, 46);
            this.Kintegral.Name = "Kintegral";
            this.Kintegral.Size = new System.Drawing.Size(16, 13);
            this.Kintegral.TabIndex = 8;
            this.Kintegral.Text = "Ki";
            // 
            // Kproporcional
            // 
            this.Kproporcional.AutoSize = true;
            this.Kproporcional.Location = new System.Drawing.Point(3, 19);
            this.Kproporcional.Name = "Kproporcional";
            this.Kproporcional.Size = new System.Drawing.Size(20, 13);
            this.Kproporcional.TabIndex = 8;
            this.Kproporcional.Text = "Kp";
            // 
            // RB3
            // 
            this.RB3.AutoSize = true;
            this.RB3.Enabled = false;
            this.RB3.Location = new System.Drawing.Point(113, 72);
            this.RB3.Name = "RB3";
            this.RB3.Size = new System.Drawing.Size(84, 17);
            this.RB3.TabIndex = 7;
            this.RB3.Text = "Cohen Coon";
            this.RB3.UseVisualStyleBackColor = true;
            this.RB3.Click += new System.EventHandler(this.RB3_Click);
            // 
            // RB2
            // 
            this.RB2.AutoSize = true;
            this.RB2.Enabled = false;
            this.RB2.Location = new System.Drawing.Point(113, 45);
            this.RB2.Name = "RB2";
            this.RB2.Size = new System.Drawing.Size(87, 17);
            this.RB2.TabIndex = 6;
            this.RB2.Text = "MF30 Astrom";
            this.RB2.UseVisualStyleBackColor = true;
            this.RB2.Click += new System.EventHandler(this.RB2_Click);
            // 
            // RB1
            // 
            this.RB1.AutoSize = true;
            this.RB1.Checked = true;
            this.RB1.Enabled = false;
            this.RB1.Location = new System.Drawing.Point(113, 19);
            this.RB1.Name = "RB1";
            this.RB1.Size = new System.Drawing.Size(92, 17);
            this.RB1.TabIndex = 5;
            this.RB1.TabStop = true;
            this.RB1.Text = "ZieglerNichols";
            this.RB1.UseVisualStyleBackColor = true;
            this.RB1.Click += new System.EventHandler(this.RB1_Click);
            // 
            // GBComunicacao
            // 
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
            // TaxaTransferencia
            // 
            this.TaxaTransferencia.Location = new System.Drawing.Point(10, 46);
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
            this.TaxaTransferencia.Size = new System.Drawing.Size(120, 20);
            this.TaxaTransferencia.TabIndex = 3;
            this.TaxaTransferencia.Value = new decimal(new int[] {
            250000,
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
            this.portaseriallista.Location = new System.Drawing.Point(9, 19);
            this.portaseriallista.Name = "portaseriallista";
            this.portaseriallista.Size = new System.Drawing.Size(121, 21);
            this.portaseriallista.TabIndex = 0;
            this.portaseriallista.Text = "Porta Serial";
            // 
            // AlturaPico
            // 
            this.AlturaPico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AlturaPico.AutoSize = true;
            this.AlturaPico.Location = new System.Drawing.Point(295, 53);
            this.AlturaPico.Name = "AlturaPico";
            this.AlturaPico.Size = new System.Drawing.Size(20, 13);
            this.AlturaPico.TabIndex = 4;
            this.AlturaPico.Text = "Au";
            // 
            // AlturaVale
            // 
            this.AlturaVale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AlturaVale.AutoSize = true;
            this.AlturaVale.Location = new System.Drawing.Point(295, 24);
            this.AlturaVale.Name = "AlturaVale";
            this.AlturaVale.Size = new System.Drawing.Size(20, 13);
            this.AlturaVale.TabIndex = 4;
            this.AlturaVale.Text = "Ad";
            // 
            // TempoOFF
            // 
            this.TempoOFF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TempoOFF.AutoSize = true;
            this.TempoOFF.Location = new System.Drawing.Point(191, 53);
            this.TempoOFF.Name = "TempoOFF";
            this.TempoOFF.Size = new System.Drawing.Size(26, 13);
            this.TempoOFF.TabIndex = 3;
            this.TempoOFF.Text = "Toff";
            // 
            // TempoON
            // 
            this.TempoON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TempoON.AutoSize = true;
            this.TempoON.Location = new System.Drawing.Point(191, 24);
            this.TempoON.Name = "TempoON";
            this.TempoON.Size = new System.Drawing.Size(26, 13);
            this.TempoON.TabIndex = 3;
            this.TempoON.Text = "Ton";
            // 
            // TempoCritico
            // 
            this.TempoCritico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TempoCritico.AutoSize = true;
            this.TempoCritico.Location = new System.Drawing.Point(101, 53);
            this.TempoCritico.Name = "TempoCritico";
            this.TempoCritico.Size = new System.Drawing.Size(20, 13);
            this.TempoCritico.TabIndex = 2;
            this.TempoCritico.Text = "Tu";
            // 
            // GanhoCritico
            // 
            this.GanhoCritico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GanhoCritico.AutoSize = true;
            this.GanhoCritico.Location = new System.Drawing.Point(101, 24);
            this.GanhoCritico.Name = "GanhoCritico";
            this.GanhoCritico.Size = new System.Drawing.Size(20, 13);
            this.GanhoCritico.TabIndex = 2;
            this.GanhoCritico.Text = "Ku";
            // 
            // TBAlturaPico
            // 
            this.TBAlturaPico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBAlturaPico.Location = new System.Drawing.Point(319, 50);
            this.TBAlturaPico.Name = "TBAlturaPico";
            this.TBAlturaPico.ReadOnly = true;
            this.TBAlturaPico.Size = new System.Drawing.Size(57, 20);
            this.TBAlturaPico.TabIndex = 0;
            // 
            // TBAlturaVale
            // 
            this.TBAlturaVale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBAlturaVale.Location = new System.Drawing.Point(319, 21);
            this.TBAlturaVale.Name = "TBAlturaVale";
            this.TBAlturaVale.ReadOnly = true;
            this.TBAlturaVale.Size = new System.Drawing.Size(57, 20);
            this.TBAlturaVale.TabIndex = 0;
            // 
            // TBTempoOFF
            // 
            this.TBTempoOFF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBTempoOFF.Location = new System.Drawing.Point(223, 50);
            this.TBTempoOFF.Name = "TBTempoOFF";
            this.TBTempoOFF.ReadOnly = true;
            this.TBTempoOFF.Size = new System.Drawing.Size(57, 20);
            this.TBTempoOFF.TabIndex = 0;
            // 
            // TBTempoON
            // 
            this.TBTempoON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBTempoON.Location = new System.Drawing.Point(223, 21);
            this.TBTempoON.Name = "TBTempoON";
            this.TBTempoON.ReadOnly = true;
            this.TBTempoON.Size = new System.Drawing.Size(57, 20);
            this.TBTempoON.TabIndex = 0;
            // 
            // TBTempoCritico
            // 
            this.TBTempoCritico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBTempoCritico.Location = new System.Drawing.Point(127, 50);
            this.TBTempoCritico.Name = "TBTempoCritico";
            this.TBTempoCritico.ReadOnly = true;
            this.TBTempoCritico.Size = new System.Drawing.Size(57, 20);
            this.TBTempoCritico.TabIndex = 0;
            // 
            // TBGanhoCritico
            // 
            this.TBGanhoCritico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBGanhoCritico.Location = new System.Drawing.Point(127, 21);
            this.TBGanhoCritico.Name = "TBGanhoCritico";
            this.TBGanhoCritico.ReadOnly = true;
            this.TBGanhoCritico.Size = new System.Drawing.Size(57, 20);
            this.TBGanhoCritico.TabIndex = 0;
            // 
            // Grafico
            // 
            this.Grafico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.Grafico.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Grafico.Legends.Add(legend2);
            this.Grafico.Location = new System.Drawing.Point(221, 9);
            this.Grafico.Name = "Grafico";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Legend = "Legend1";
            series4.Name = "SP";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.Legend = "Legend1";
            series5.Name = "OUT";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series6.Legend = "Legend1";
            series6.Name = "INP";
            this.Grafico.Series.Add(series4);
            this.Grafico.Series.Add(series5);
            this.Grafico.Series.Add(series6);
            this.Grafico.Size = new System.Drawing.Size(948, 396);
            this.Grafico.TabIndex = 1;
            this.Grafico.Text = "Gráfico";
            // 
            // GBPainelInferior
            // 
            this.GBPainelInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GBPainelInferior.Controls.Add(this.GBGrafico);
            this.GBPainelInferior.Controls.Add(this.GBProcesso);
            this.GBPainelInferior.Controls.Add(this.label4);
            this.GBPainelInferior.Location = new System.Drawing.Point(221, 404);
            this.GBPainelInferior.Name = "GBPainelInferior";
            this.GBPainelInferior.Size = new System.Drawing.Size(948, 86);
            this.GBPainelInferior.TabIndex = 2;
            this.GBPainelInferior.TabStop = false;
            // 
            // GBGrafico
            // 
            this.GBGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GBGrafico.Controls.Add(this.NYmin);
            this.GBGrafico.Controls.Add(this.NYmax);
            this.GBGrafico.Controls.Add(this.NTempo);
            this.GBGrafico.Controls.Add(this.NInicio);
            this.GBGrafico.Controls.Add(this.BTGrafico);
            this.GBGrafico.Controls.Add(this.RBEstatico);
            this.GBGrafico.Controls.Add(this.RBAtualizando);
            this.GBGrafico.Controls.Add(this.Ymax);
            this.GBGrafico.Controls.Add(this.Inicio);
            this.GBGrafico.Controls.Add(this.Ymin);
            this.GBGrafico.Controls.Add(this.Tamanho);
            this.GBGrafico.Location = new System.Drawing.Point(8, 7);
            this.GBGrafico.Name = "GBGrafico";
            this.GBGrafico.Size = new System.Drawing.Size(351, 76);
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
            this.NYmin.Location = new System.Drawing.Point(212, 48);
            this.NYmin.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.NYmin.Name = "NYmin";
            this.NYmin.Size = new System.Drawing.Size(66, 20);
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
            this.NYmax.Location = new System.Drawing.Point(211, 21);
            this.NYmax.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.NYmax.Name = "NYmax";
            this.NYmax.Size = new System.Drawing.Size(66, 20);
            this.NYmax.TabIndex = 14;
            this.NYmax.Value = new decimal(new int[] {
            4200,
            0,
            0,
            0});
            this.NYmax.ValueChanged += new System.EventHandler(this.NYmax_ValueChanged);
            // 
            // NTempo
            // 
            this.NTempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NTempo.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NTempo.Location = new System.Drawing.Point(89, 48);
            this.NTempo.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.NTempo.Name = "NTempo";
            this.NTempo.Size = new System.Drawing.Size(81, 20);
            this.NTempo.TabIndex = 14;
            this.NTempo.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.NTempo.ValueChanged += new System.EventHandler(this.NTempo_ValueChanged);
            // 
            // NInicio
            // 
            this.NInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NInicio.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NInicio.Location = new System.Drawing.Point(89, 22);
            this.NInicio.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.NInicio.Name = "NInicio";
            this.NInicio.Size = new System.Drawing.Size(81, 20);
            this.NInicio.TabIndex = 14;
            this.NInicio.ValueChanged += new System.EventHandler(this.NInicio_ValueChanged);
            // 
            // BTGrafico
            // 
            this.BTGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTGrafico.Enabled = false;
            this.BTGrafico.Location = new System.Drawing.Point(7, 21);
            this.BTGrafico.Name = "BTGrafico";
            this.BTGrafico.Size = new System.Drawing.Size(43, 49);
            this.BTGrafico.TabIndex = 13;
            this.BTGrafico.Text = "Plotar";
            this.BTGrafico.UseVisualStyleBackColor = true;
            this.BTGrafico.Click += new System.EventHandler(this.BTGrafico_Click);
            // 
            // RBEstatico
            // 
            this.RBEstatico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RBEstatico.AutoSize = true;
            this.RBEstatico.Location = new System.Drawing.Point(283, 51);
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
            this.RBAtualizando.Location = new System.Drawing.Point(283, 22);
            this.RBAtualizando.Name = "RBAtualizando";
            this.RBAtualizando.Size = new System.Drawing.Size(65, 17);
            this.RBAtualizando.TabIndex = 11;
            this.RBAtualizando.TabStop = true;
            this.RBAtualizando.Text = "Atualizar";
            this.RBAtualizando.UseVisualStyleBackColor = true;
            this.RBAtualizando.Click += new System.EventHandler(this.RBAtualizando_Click);
            // 
            // Ymax
            // 
            this.Ymax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Ymax.AutoSize = true;
            this.Ymax.Location = new System.Drawing.Point(179, 25);
            this.Ymax.Name = "Ymax";
            this.Ymax.Size = new System.Drawing.Size(33, 13);
            this.Ymax.TabIndex = 12;
            this.Ymax.Text = "Ymax";
            // 
            // Inicio
            // 
            this.Inicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Inicio.AutoSize = true;
            this.Inicio.Location = new System.Drawing.Point(56, 25);
            this.Inicio.Name = "Inicio";
            this.Inicio.Size = new System.Drawing.Size(34, 13);
            this.Inicio.TabIndex = 12;
            this.Inicio.Text = "Início";
            // 
            // Ymin
            // 
            this.Ymin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Ymin.AutoSize = true;
            this.Ymin.Location = new System.Drawing.Point(182, 53);
            this.Ymin.Name = "Ymin";
            this.Ymin.Size = new System.Drawing.Size(30, 13);
            this.Ymin.TabIndex = 12;
            this.Ymin.Text = "Ymin";
            // 
            // Tamanho
            // 
            this.Tamanho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Tamanho.AutoSize = true;
            this.Tamanho.Location = new System.Drawing.Point(50, 54);
            this.Tamanho.Name = "Tamanho";
            this.Tamanho.Size = new System.Drawing.Size(40, 13);
            this.Tamanho.TabIndex = 12;
            this.Tamanho.Text = "Tempo";
            // 
            // GBProcesso
            // 
            this.GBProcesso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GBProcesso.Controls.Add(this.label2);
            this.GBProcesso.Controls.Add(this.TBAlturaVale);
            this.GBProcesso.Controls.Add(this.TBTempoCritico);
            this.GBProcesso.Controls.Add(this.TBVariavelProcesso);
            this.GBProcesso.Controls.Add(this.TBTempoON);
            this.GBProcesso.Controls.Add(this.TBVariavelControlada);
            this.GBProcesso.Controls.Add(this.GanhoCritico);
            this.GBProcesso.Controls.Add(this.label1);
            this.GBProcesso.Controls.Add(this.label3);
            this.GBProcesso.Controls.Add(this.TBTempoOFF);
            this.GBProcesso.Controls.Add(this.AlturaVale);
            this.GBProcesso.Controls.Add(this.TempoCritico);
            this.GBProcesso.Controls.Add(this.AlturaPico);
            this.GBProcesso.Controls.Add(this.label5);
            this.GBProcesso.Controls.Add(this.VariavelControlada);
            this.GBProcesso.Controls.Add(this.TempoON);
            this.GBProcesso.Controls.Add(this.TBGanhoCritico);
            this.GBProcesso.Controls.Add(this.TBAlturaPico);
            this.GBProcesso.Controls.Add(this.VariavelProcesso);
            this.GBProcesso.Controls.Add(this.TempoOFF);
            this.GBProcesso.Location = new System.Drawing.Point(365, 7);
            this.GBProcesso.Name = "GBProcesso";
            this.GBProcesso.Size = new System.Drawing.Size(577, 76);
            this.GBProcesso.TabIndex = 13;
            this.GBProcesso.TabStop = false;
            this.GBProcesso.Text = "Processo";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "1000.00";
            // 
            // TBVariavelProcesso
            // 
            this.TBVariavelProcesso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBVariavelProcesso.Location = new System.Drawing.Point(32, 21);
            this.TBVariavelProcesso.Name = "TBVariavelProcesso";
            this.TBVariavelProcesso.ReadOnly = true;
            this.TBVariavelProcesso.Size = new System.Drawing.Size(57, 20);
            this.TBVariavelProcesso.TabIndex = 1;
            // 
            // TBVariavelControlada
            // 
            this.TBVariavelControlada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TBVariavelControlada.Location = new System.Drawing.Point(32, 50);
            this.TBVariavelControlada.Name = "TBVariavelControlada";
            this.TBVariavelControlada.ReadOnly = true;
            this.TBVariavelControlada.Size = new System.Drawing.Size(57, 20);
            this.TBVariavelControlada.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gp(s) = ___________e";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "( 100.0 s + 1)";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(505, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "- 45.00 s";
            // 
            // VariavelControlada
            // 
            this.VariavelControlada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VariavelControlada.AutoSize = true;
            this.VariavelControlada.Location = new System.Drawing.Point(10, 53);
            this.VariavelControlada.Name = "VariavelControlada";
            this.VariavelControlada.Size = new System.Drawing.Size(21, 13);
            this.VariavelControlada.TabIndex = 8;
            this.VariavelControlada.Text = "SC";
            // 
            // VariavelProcesso
            // 
            this.VariavelProcesso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VariavelProcesso.AutoSize = true;
            this.VariavelProcesso.Location = new System.Drawing.Point(10, 24);
            this.VariavelProcesso.Name = "VariavelProcesso";
            this.VariavelProcesso.Size = new System.Drawing.Size(21, 13);
            this.VariavelProcesso.TabIndex = 8;
            this.VariavelProcesso.Text = "VP";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 493);
            this.Controls.Add(this.GBPainelInferior);
            this.Controls.Add(this.Grafico);
            this.Controls.Add(this.GBPainelLateral);
            this.Name = "Form1";
            this.Text = "Form1";
            this.GBPainelLateral.ResumeLayout(false);
            this.GBMalha.ResumeLayout(false);
            this.GBMalha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NSO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NSetpoint)).EndInit();
            this.GBArduino.ResumeLayout(false);
            this.GBArduino.PerformLayout();
            this.GBRELE.ResumeLayout(false);
            this.GBRELE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NHisterese)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NAmplitudeRele)).EndInit();
            this.GBPID.ResumeLayout(false);
            this.GBPID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NKd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NKi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NKp)).EndInit();
            this.GBComunicacao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaxaTransferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grafico)).EndInit();
            this.GBPainelInferior.ResumeLayout(false);
            this.GBPainelInferior.PerformLayout();
            this.GBGrafico.ResumeLayout(false);
            this.GBGrafico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NYmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NYmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NTempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NInicio)).EndInit();
            this.GBProcesso.ResumeLayout(false);
            this.GBProcesso.PerformLayout();
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
        private System.Windows.Forms.Label AlturaPico;
        private System.Windows.Forms.Label AlturaVale;
        private System.Windows.Forms.Label TempoOFF;
        private System.Windows.Forms.Label TempoON;
        private System.Windows.Forms.Label TempoCritico;
        private System.Windows.Forms.Label GanhoCritico;
        private System.Windows.Forms.Label HistereseLabel;
        private System.Windows.Forms.Label AmplitudeRele;
        private System.Windows.Forms.TextBox TBAlturaPico;
        private System.Windows.Forms.TextBox TBAlturaVale;
        private System.Windows.Forms.TextBox TBTempoOFF;
        private System.Windows.Forms.TextBox TBTempoON;
        private System.Windows.Forms.TextBox TBTempoCritico;
        private System.Windows.Forms.TextBox TBGanhoCritico;
        private System.Windows.Forms.GroupBox GBPID;
        private System.Windows.Forms.Label Kderivativo;
        private System.Windows.Forms.Label Kintegral;
        private System.Windows.Forms.Label Kproporcional;
        private System.Windows.Forms.Label Setpoint;
        private System.Windows.Forms.RadioButton RB3;
        private System.Windows.Forms.RadioButton RB2;
        private System.Windows.Forms.RadioButton RB1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label VariavelProcesso;
        private System.Windows.Forms.TextBox TBVariavelProcesso;
        private System.Windows.Forms.Label VariavelControlada;
        private System.Windows.Forms.TextBox TBVariavelControlada;
        private System.IO.Ports.SerialPort serialPortTCC;
        private DatabaseTCCDataSet databaseTCCDataSet1;
        private System.Windows.Forms.NumericUpDown NHisterese;
        private System.Windows.Forms.NumericUpDown NAmplitudeRele;
        private System.Windows.Forms.NumericUpDown NKd;
        private System.Windows.Forms.NumericUpDown NKi;
        private System.Windows.Forms.NumericUpDown NKp;
        private System.Windows.Forms.NumericUpDown NSetpoint;
        private System.Windows.Forms.GroupBox GBMalha;
        private System.Windows.Forms.RadioButton RBAberta;
        private System.Windows.Forms.RadioButton RBPID;
        private System.Windows.Forms.Label Inicio;
        private System.Windows.Forms.Label Tamanho;
        private System.Windows.Forms.RadioButton RBAtualizando;
        private System.Windows.Forms.RadioButton RBEstatico;
        private System.Windows.Forms.GroupBox GBGrafico;
        private System.Windows.Forms.GroupBox GBProcesso;
        private System.Windows.Forms.RadioButton RBRele;
        private System.Windows.Forms.Label SinalOperacao;
        private System.Windows.Forms.NumericUpDown NSO;
        private System.Windows.Forms.Button BTGrafico;
        private System.Windows.Forms.Label Ymax;
        private System.Windows.Forms.Label Ymin;
        private System.Windows.Forms.NumericUpDown NYmin;
        private System.Windows.Forms.NumericUpDown NYmax;
        private System.Windows.Forms.NumericUpDown NTempo;
        private System.Windows.Forms.NumericUpDown NInicio;
    }
}

