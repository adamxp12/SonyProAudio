namespace SonyMDSDemo
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
            this.playBtn = new System.Windows.Forms.Button();
            this.openBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.comBox = new System.Windows.Forms.TextBox();
            this.playpauseBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.rmOnBtn = new System.Windows.Forms.Button();
            this.rmOffBtn = new System.Windows.Forms.Button();
            this.trackPlayBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.mechState = new System.Windows.Forms.Label();
            this.trackPauseBtn = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.autoOnBtn = new System.Windows.Forms.Button();
            this.autoOffBtn = new System.Windows.Forms.Button();
            this.ejectBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.alertLbl = new System.Windows.Forms.Label();
            this.requestTrackTimeBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.trkTImeLbl = new System.Windows.Forms.Label();
            this.requestTocDataBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tocLbl = new System.Windows.Forms.Label();
            this.elpOnBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.elpOffBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.elpLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trkLbl = new System.Windows.Forms.Label();
            this.clrBtn = new System.Windows.Forms.Button();
            this.nxTrkBtn = new System.Windows.Forms.Button();
            this.bkTrkBtn = new System.Windows.Forms.Button();
            this.reqTrkNameBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.trkName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.discNameLbl = new System.Windows.Forms.Label();
            this.reqMdlNameBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.mdlNameLbl = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.trkNameBox = new System.Windows.Forms.TextBox();
            this.setTrkName = new System.Windows.Forms.Button();
            this.setDskNameBtn = new System.Windows.Forms.Button();
            this.eraseBtn = new System.Windows.Forms.Button();
            this.reqDiscDataBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.discDataLbl = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.TextBox();
            this.reqStatusBtn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(65, 115);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(75, 23);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(171, 44);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 1;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(252, 44);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // comBox
            // 
            this.comBox.Location = new System.Drawing.Point(65, 45);
            this.comBox.Name = "comBox";
            this.comBox.Size = new System.Drawing.Size(100, 22);
            this.comBox.TabIndex = 3;
            // 
            // playpauseBtn
            // 
            this.playpauseBtn.Location = new System.Drawing.Point(308, 115);
            this.playpauseBtn.Name = "playpauseBtn";
            this.playpauseBtn.Size = new System.Drawing.Size(75, 23);
            this.playpauseBtn.TabIndex = 4;
            this.playpauseBtn.Text = "PlayPause";
            this.playpauseBtn.UseVisualStyleBackColor = true;
            this.playpauseBtn.Click += new System.EventHandler(this.playpauseBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(227, 115);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 5;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(146, 115);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(75, 23);
            this.pauseBtn.TabIndex = 6;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // rmOnBtn
            // 
            this.rmOnBtn.Location = new System.Drawing.Point(65, 73);
            this.rmOnBtn.Name = "rmOnBtn";
            this.rmOnBtn.Size = new System.Drawing.Size(156, 23);
            this.rmOnBtn.TabIndex = 7;
            this.rmOnBtn.Text = "Remote On";
            this.rmOnBtn.UseVisualStyleBackColor = true;
            this.rmOnBtn.Click += new System.EventHandler(this.rmOnBtn_Click);
            // 
            // rmOffBtn
            // 
            this.rmOffBtn.Location = new System.Drawing.Point(227, 73);
            this.rmOffBtn.Name = "rmOffBtn";
            this.rmOffBtn.Size = new System.Drawing.Size(156, 23);
            this.rmOffBtn.TabIndex = 8;
            this.rmOffBtn.Text = "Remote Off";
            this.rmOffBtn.UseVisualStyleBackColor = true;
            this.rmOffBtn.Click += new System.EventHandler(this.rmOffBtn_Click);
            // 
            // trackPlayBtn
            // 
            this.trackPlayBtn.Location = new System.Drawing.Point(191, 21);
            this.trackPlayBtn.Name = "trackPlayBtn";
            this.trackPlayBtn.Size = new System.Drawing.Size(156, 23);
            this.trackPlayBtn.TabIndex = 9;
            this.trackPlayBtn.Text = "Track Play";
            this.trackPlayBtn.UseVisualStyleBackColor = true;
            this.trackPlayBtn.Click += new System.EventHandler(this.trackPlayBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 310);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(405, 123);
            this.textBox1.TabIndex = 10;
            // 
            // mechState
            // 
            this.mechState.AutoSize = true;
            this.mechState.Location = new System.Drawing.Point(513, 44);
            this.mechState.Name = "mechState";
            this.mechState.Size = new System.Drawing.Size(32, 17);
            this.mechState.TabIndex = 11;
            this.mechState.Text = "???";
            // 
            // trackPauseBtn
            // 
            this.trackPauseBtn.Location = new System.Drawing.Point(191, 50);
            this.trackPauseBtn.Name = "trackPauseBtn";
            this.trackPauseBtn.Size = new System.Drawing.Size(156, 23);
            this.trackPauseBtn.TabIndex = 13;
            this.trackPauseBtn.Text = "Track Pause";
            this.trackPauseBtn.UseVisualStyleBackColor = true;
            this.trackPauseBtn.Click += new System.EventHandler(this.trackPauseBtn_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(56, 21);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 14;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // autoOnBtn
            // 
            this.autoOnBtn.Location = new System.Drawing.Point(516, 310);
            this.autoOnBtn.Name = "autoOnBtn";
            this.autoOnBtn.Size = new System.Drawing.Size(156, 23);
            this.autoOnBtn.TabIndex = 15;
            this.autoOnBtn.Text = "Auto Pause On";
            this.autoOnBtn.UseVisualStyleBackColor = true;
            this.autoOnBtn.Click += new System.EventHandler(this.autoOnBtn_Click);
            // 
            // autoOffBtn
            // 
            this.autoOffBtn.Location = new System.Drawing.Point(516, 339);
            this.autoOffBtn.Name = "autoOffBtn";
            this.autoOffBtn.Size = new System.Drawing.Size(156, 23);
            this.autoOffBtn.TabIndex = 16;
            this.autoOffBtn.Text = "Auto Pause Off";
            this.autoOffBtn.UseVisualStyleBackColor = true;
            this.autoOffBtn.Click += new System.EventHandler(this.autoOffBtn_Click);
            // 
            // ejectBtn
            // 
            this.ejectBtn.Location = new System.Drawing.Point(227, 144);
            this.ejectBtn.Name = "ejectBtn";
            this.ejectBtn.Size = new System.Drawing.Size(75, 23);
            this.ejectBtn.TabIndex = 17;
            this.ejectBtn.Text = "Eject";
            this.ejectBtn.UseVisualStyleBackColor = true;
            this.ejectBtn.Click += new System.EventHandler(this.ejectBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(423, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "MechState";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(423, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Alerts";
            // 
            // alertLbl
            // 
            this.alertLbl.AutoSize = true;
            this.alertLbl.Location = new System.Drawing.Point(475, 61);
            this.alertLbl.Name = "alertLbl";
            this.alertLbl.Size = new System.Drawing.Size(0, 17);
            this.alertLbl.TabIndex = 22;
            // 
            // requestTrackTimeBtn
            // 
            this.requestTrackTimeBtn.Location = new System.Drawing.Point(363, 50);
            this.requestTrackTimeBtn.Name = "requestTrackTimeBtn";
            this.requestTrackTimeBtn.Size = new System.Drawing.Size(156, 23);
            this.requestTrackTimeBtn.TabIndex = 23;
            this.requestTrackTimeBtn.Text = "Request Track TIme";
            this.requestTrackTimeBtn.UseVisualStyleBackColor = true;
            this.requestTrackTimeBtn.Click += new System.EventHandler(this.requestTrackTimeBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(423, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "TrackTime";
            // 
            // trkTImeLbl
            // 
            this.trkTImeLbl.AutoSize = true;
            this.trkTImeLbl.Location = new System.Drawing.Point(513, 27);
            this.trkTImeLbl.Name = "trkTImeLbl";
            this.trkTImeLbl.Size = new System.Drawing.Size(32, 17);
            this.trkTImeLbl.TabIndex = 25;
            this.trkTImeLbl.Text = "???";
            // 
            // requestTocDataBtn
            // 
            this.requestTocDataBtn.Location = new System.Drawing.Point(516, 426);
            this.requestTocDataBtn.Name = "requestTocDataBtn";
            this.requestTocDataBtn.Size = new System.Drawing.Size(156, 23);
            this.requestTocDataBtn.TabIndex = 26;
            this.requestTocDataBtn.Text = "Request Toc Data";
            this.requestTocDataBtn.UseVisualStyleBackColor = true;
            this.requestTocDataBtn.Click += new System.EventHandler(this.requestTocDataBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(423, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Toc";
            // 
            // tocLbl
            // 
            this.tocLbl.AutoSize = true;
            this.tocLbl.Location = new System.Drawing.Point(464, 79);
            this.tocLbl.Name = "tocLbl";
            this.tocLbl.Size = new System.Drawing.Size(32, 17);
            this.tocLbl.TabIndex = 28;
            this.tocLbl.Text = "???";
            // 
            // elpOnBtn
            // 
            this.elpOnBtn.Location = new System.Drawing.Point(516, 368);
            this.elpOnBtn.Name = "elpOnBtn";
            this.elpOnBtn.Size = new System.Drawing.Size(156, 23);
            this.elpOnBtn.TabIndex = 29;
            this.elpOnBtn.Text = "Elapsed Time On";
            this.elpOnBtn.UseVisualStyleBackColor = true;
            this.elpOnBtn.Click += new System.EventHandler(this.elpOnBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "Raw Data";
            // 
            // elpOffBtn
            // 
            this.elpOffBtn.Location = new System.Drawing.Point(516, 397);
            this.elpOffBtn.Name = "elpOffBtn";
            this.elpOffBtn.Size = new System.Drawing.Size(156, 23);
            this.elpOffBtn.TabIndex = 31;
            this.elpOffBtn.Text = "Elapsed Time Off";
            this.elpOffBtn.UseVisualStyleBackColor = true;
            this.elpOffBtn.Click += new System.EventHandler(this.elpOffBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(425, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "ElapsedTime";
            // 
            // elpLbl
            // 
            this.elpLbl.AutoSize = true;
            this.elpLbl.Location = new System.Drawing.Point(532, 10);
            this.elpLbl.Name = "elpLbl";
            this.elpLbl.Size = new System.Drawing.Size(62, 17);
            this.elpLbl.TabIndex = 33;
            this.elpLbl.Text = "60m 60s";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(594, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 34;
            this.label8.Text = "CurrentTrack";
            // 
            // trkLbl
            // 
            this.trkLbl.AutoSize = true;
            this.trkLbl.Location = new System.Drawing.Point(703, 10);
            this.trkLbl.Name = "trkLbl";
            this.trkLbl.Size = new System.Drawing.Size(32, 17);
            this.trkLbl.TabIndex = 35;
            this.trkLbl.Text = "254";
            // 
            // clrBtn
            // 
            this.clrBtn.Location = new System.Drawing.Point(10, 330);
            this.clrBtn.Name = "clrBtn";
            this.clrBtn.Size = new System.Drawing.Size(75, 23);
            this.clrBtn.TabIndex = 36;
            this.clrBtn.Text = "Clear";
            this.clrBtn.UseVisualStyleBackColor = true;
            this.clrBtn.Click += new System.EventHandler(this.clrBtn_Click);
            // 
            // nxTrkBtn
            // 
            this.nxTrkBtn.Location = new System.Drawing.Point(65, 144);
            this.nxTrkBtn.Name = "nxTrkBtn";
            this.nxTrkBtn.Size = new System.Drawing.Size(75, 23);
            this.nxTrkBtn.TabIndex = 37;
            this.nxTrkBtn.Text = "NextTrack";
            this.nxTrkBtn.UseVisualStyleBackColor = true;
            this.nxTrkBtn.Click += new System.EventHandler(this.nxTrkBtn_Click);
            // 
            // bkTrkBtn
            // 
            this.bkTrkBtn.Location = new System.Drawing.Point(146, 144);
            this.bkTrkBtn.Name = "bkTrkBtn";
            this.bkTrkBtn.Size = new System.Drawing.Size(75, 23);
            this.bkTrkBtn.TabIndex = 38;
            this.bkTrkBtn.Text = "BackTrack";
            this.bkTrkBtn.UseVisualStyleBackColor = true;
            this.bkTrkBtn.Click += new System.EventHandler(this.bkTrkBtn_Click);
            // 
            // reqTrkNameBtn
            // 
            this.reqTrkNameBtn.Location = new System.Drawing.Point(363, 21);
            this.reqTrkNameBtn.Name = "reqTrkNameBtn";
            this.reqTrkNameBtn.Size = new System.Drawing.Size(156, 23);
            this.reqTrkNameBtn.TabIndex = 39;
            this.reqTrkNameBtn.Text = "Request Track Name";
            this.reqTrkNameBtn.UseVisualStyleBackColor = true;
            this.reqTrkNameBtn.Click += new System.EventHandler(this.reqTrkNameBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(423, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 40;
            this.label9.Text = "TrackName";
            // 
            // trkName
            // 
            this.trkName.AutoSize = true;
            this.trkName.Location = new System.Drawing.Point(521, 95);
            this.trkName.Name = "trkName";
            this.trkName.Size = new System.Drawing.Size(32, 17);
            this.trkName.TabIndex = 41;
            this.trkName.Text = "???";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(516, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "Request Disc Name";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(423, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 17);
            this.label10.TabIndex = 43;
            this.label10.Text = "DiscName";
            // 
            // discNameLbl
            // 
            this.discNameLbl.AutoSize = true;
            this.discNameLbl.Location = new System.Drawing.Point(510, 115);
            this.discNameLbl.Name = "discNameLbl";
            this.discNameLbl.Size = new System.Drawing.Size(32, 17);
            this.discNameLbl.TabIndex = 44;
            this.discNameLbl.Text = "???";
            // 
            // reqMdlNameBtn
            // 
            this.reqMdlNameBtn.Location = new System.Drawing.Point(516, 513);
            this.reqMdlNameBtn.Name = "reqMdlNameBtn";
            this.reqMdlNameBtn.Size = new System.Drawing.Size(156, 23);
            this.reqMdlNameBtn.TabIndex = 45;
            this.reqMdlNameBtn.Text = "Request Model Name";
            this.reqMdlNameBtn.UseVisualStyleBackColor = true;
            this.reqMdlNameBtn.Click += new System.EventHandler(this.reqMdlNameBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(423, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 17);
            this.label11.TabIndex = 46;
            this.label11.Text = "ModelName";
            // 
            // mdlNameLbl
            // 
            this.mdlNameLbl.AutoSize = true;
            this.mdlNameLbl.Location = new System.Drawing.Point(521, 132);
            this.mdlNameLbl.Name = "mdlNameLbl";
            this.mdlNameLbl.Size = new System.Drawing.Size(32, 17);
            this.mdlNameLbl.TabIndex = 47;
            this.mdlNameLbl.Text = "???";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(308, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 48;
            this.button2.Text = "Rec";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // trkNameBox
            // 
            this.trkNameBox.Location = new System.Drawing.Point(100, 82);
            this.trkNameBox.Name = "trkNameBox";
            this.trkNameBox.Size = new System.Drawing.Size(419, 22);
            this.trkNameBox.TabIndex = 49;
            // 
            // setTrkName
            // 
            this.setTrkName.Location = new System.Drawing.Point(525, 50);
            this.setTrkName.Name = "setTrkName";
            this.setTrkName.Size = new System.Drawing.Size(156, 23);
            this.setTrkName.TabIndex = 50;
            this.setTrkName.Text = "Set Track Name";
            this.setTrkName.UseVisualStyleBackColor = true;
            this.setTrkName.Click += new System.EventHandler(this.setTrkName_Click);
            // 
            // setDskNameBtn
            // 
            this.setDskNameBtn.Location = new System.Drawing.Point(525, 81);
            this.setDskNameBtn.Name = "setDskNameBtn";
            this.setDskNameBtn.Size = new System.Drawing.Size(156, 23);
            this.setDskNameBtn.TabIndex = 51;
            this.setDskNameBtn.Text = "Set Disc Name";
            this.setDskNameBtn.UseVisualStyleBackColor = true;
            this.setDskNameBtn.Click += new System.EventHandler(this.setDskNameBtn_Click);
            // 
            // eraseBtn
            // 
            this.eraseBtn.Location = new System.Drawing.Point(525, 20);
            this.eraseBtn.Name = "eraseBtn";
            this.eraseBtn.Size = new System.Drawing.Size(156, 23);
            this.eraseBtn.TabIndex = 52;
            this.eraseBtn.Text = "Erase Track";
            this.eraseBtn.UseVisualStyleBackColor = true;
            this.eraseBtn.Click += new System.EventHandler(this.eraseBtn_Click);
            // 
            // reqDiscDataBtn
            // 
            this.reqDiscDataBtn.Location = new System.Drawing.Point(516, 484);
            this.reqDiscDataBtn.Name = "reqDiscDataBtn";
            this.reqDiscDataBtn.Size = new System.Drawing.Size(156, 23);
            this.reqDiscDataBtn.TabIndex = 54;
            this.reqDiscDataBtn.Text = "Request Disc Data";
            this.reqDiscDataBtn.UseVisualStyleBackColor = true;
            this.reqDiscDataBtn.Click += new System.EventHandler(this.reqDiscDataBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(425, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 17);
            this.label12.TabIndex = 55;
            this.label12.Text = "DiscData";
            // 
            // discDataLbl
            // 
            this.discDataLbl.AutoSize = true;
            this.discDataLbl.Location = new System.Drawing.Point(504, 150);
            this.discDataLbl.Name = "discDataLbl";
            this.discDataLbl.Size = new System.Drawing.Size(32, 17);
            this.discDataLbl.TabIndex = 56;
            this.discDataLbl.Text = "???";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(102, 484);
            this.status.Multiline = true;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Size = new System.Drawing.Size(405, 204);
            this.status.TabIndex = 57;
            // 
            // reqStatusBtn
            // 
            this.reqStatusBtn.Location = new System.Drawing.Point(10, 507);
            this.reqStatusBtn.Name = "reqStatusBtn";
            this.reqStatusBtn.Size = new System.Drawing.Size(73, 52);
            this.reqStatusBtn.TabIndex = 58;
            this.reqStatusBtn.Text = "Request Status";
            this.reqStatusBtn.UseVisualStyleBackColor = true;
            this.reqStatusBtn.Click += new System.EventHandler(this.reqStatusBtn_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(63, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 17);
            this.label13.TabIndex = 59;
            this.label13.Text = "Serial Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 487);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 60;
            this.label1.Text = "Status";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 17);
            this.label14.TabIndex = 61;
            this.label14.Text = "NameEntry";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.reqTrkNameBtn);
            this.groupBox1.Controls.Add(this.requestTrackTimeBtn);
            this.groupBox1.Controls.Add(this.trackPlayBtn);
            this.groupBox1.Controls.Add(this.trackPauseBtn);
            this.groupBox1.Controls.Add(this.eraseBtn);
            this.groupBox1.Controls.Add(this.trkNameBox);
            this.groupBox1.Controls.Add(this.setTrkName);
            this.groupBox1.Controls.Add(this.setDskNameBtn);
            this.groupBox1.Location = new System.Drawing.Point(46, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 119);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Track Controls";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(4, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 17);
            this.label15.TabIndex = 63;
            this.label15.Text = "Track";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(516, 542);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(156, 23);
            this.button4.TabIndex = 63;
            this.button4.Text = "Request All Track Name";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 750);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.reqStatusBtn);
            this.Controls.Add(this.status);
            this.Controls.Add(this.discDataLbl);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.reqDiscDataBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.mdlNameLbl);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.reqMdlNameBtn);
            this.Controls.Add(this.discNameLbl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trkName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bkTrkBtn);
            this.Controls.Add(this.nxTrkBtn);
            this.Controls.Add(this.clrBtn);
            this.Controls.Add(this.trkLbl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.elpLbl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.elpOffBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.elpOnBtn);
            this.Controls.Add(this.tocLbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.requestTocDataBtn);
            this.Controls.Add(this.trkTImeLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.alertLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ejectBtn);
            this.Controls.Add(this.autoOffBtn);
            this.Controls.Add(this.autoOnBtn);
            this.Controls.Add(this.mechState);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rmOffBtn);
            this.Controls.Add(this.rmOnBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.playpauseBtn);
            this.Controls.Add(this.comBox);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.playBtn);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(818, 797);
            this.Name = "Form1";
            this.Text = "Sony MDS Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.TextBox comBox;
        private System.Windows.Forms.Button playpauseBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button rmOnBtn;
        private System.Windows.Forms.Button rmOffBtn;
        private System.Windows.Forms.Button trackPlayBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label mechState;
        private System.Windows.Forms.Button trackPauseBtn;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button autoOnBtn;
        private System.Windows.Forms.Button autoOffBtn;
        private System.Windows.Forms.Button ejectBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label alertLbl;
        private System.Windows.Forms.Button requestTrackTimeBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label trkTImeLbl;
        private System.Windows.Forms.Button requestTocDataBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label tocLbl;
        private System.Windows.Forms.Button elpOnBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button elpOffBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label elpLbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label trkLbl;
        private System.Windows.Forms.Button clrBtn;
        private System.Windows.Forms.Button nxTrkBtn;
        private System.Windows.Forms.Button bkTrkBtn;
        private System.Windows.Forms.Button reqTrkNameBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label trkName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label discNameLbl;
        private System.Windows.Forms.Button reqMdlNameBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label mdlNameLbl;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox trkNameBox;
        private System.Windows.Forms.Button setTrkName;
        private System.Windows.Forms.Button setDskNameBtn;
        private System.Windows.Forms.Button eraseBtn;
        private System.Windows.Forms.Button reqDiscDataBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label discDataLbl;
        private System.Windows.Forms.TextBox status;
        private System.Windows.Forms.Button reqStatusBtn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button4;
    }
}

