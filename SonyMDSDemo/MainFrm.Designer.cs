namespace SonyMDSDemo
{
    partial class MainFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.trkName = new System.Windows.Forms.Label();
            this.elpLbl = new System.Windows.Forms.Label();
            this.ejectTimer = new System.Windows.Forms.Timer(this.components);
            this.ejectBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.recBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.trkName);
            this.panel1.Controls.Add(this.elpLbl);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 100);
            this.panel1.TabIndex = 5;
            // 
            // trkName
            // 
            this.trkName.AutoSize = true;
            this.trkName.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trkName.ForeColor = System.Drawing.Color.Gold;
            this.trkName.Location = new System.Drawing.Point(13, 50);
            this.trkName.Name = "trkName";
            this.trkName.Size = new System.Drawing.Size(0, 38);
            this.trkName.TabIndex = 7;
            // 
            // elpLbl
            // 
            this.elpLbl.AutoSize = true;
            this.elpLbl.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elpLbl.ForeColor = System.Drawing.Color.Gold;
            this.elpLbl.Location = new System.Drawing.Point(13, 10);
            this.elpLbl.Name = "elpLbl";
            this.elpLbl.Size = new System.Drawing.Size(233, 38);
            this.elpLbl.TabIndex = 6;
            this.elpLbl.Text = "000t 00m 00s";
            // 
            // ejectTimer
            // 
            this.ejectTimer.Interval = 1000;
            this.ejectTimer.Tick += new System.EventHandler(this.ejectTimer_Tick);
            // 
            // ejectBtn
            // 
            this.ejectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ejectBtn.Image = global::SonyMDSDemo.Properties.Resources.ejectbtn;
            this.ejectBtn.Location = new System.Drawing.Point(8, 171);
            this.ejectBtn.Name = "ejectBtn";
            this.ejectBtn.Size = new System.Drawing.Size(120, 60);
            this.ejectBtn.TabIndex = 6;
            this.ejectBtn.UseVisualStyleBackColor = true;
            this.ejectBtn.Click += new System.EventHandler(this.ejectBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backBtn.Image = global::SonyMDSDemo.Properties.Resources.backtrack;
            this.backBtn.Location = new System.Drawing.Point(134, 105);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(120, 60);
            this.backBtn.TabIndex = 4;
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nextBtn.Image = global::SonyMDSDemo.Properties.Resources.nexttrack;
            this.nextBtn.Location = new System.Drawing.Point(386, 105);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(120, 60);
            this.nextBtn.TabIndex = 3;
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pauseBtn.Image = global::SonyMDSDemo.Properties.Resources.pausebtn;
            this.pauseBtn.Location = new System.Drawing.Point(134, 171);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(120, 60);
            this.pauseBtn.TabIndex = 2;
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stopBtn.Image = global::SonyMDSDemo.Properties.Resources.stopbtn;
            this.stopBtn.Location = new System.Drawing.Point(260, 171);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(120, 60);
            this.stopBtn.TabIndex = 1;
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.playBtn.Image = global::SonyMDSDemo.Properties.Resources.playbtn1;
            this.playBtn.Location = new System.Drawing.Point(260, 105);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(120, 60);
            this.playBtn.TabIndex = 0;
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // recBtn
            // 
            this.recBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.recBtn.Image = global::SonyMDSDemo.Properties.Resources.recbtn;
            this.recBtn.Location = new System.Drawing.Point(386, 171);
            this.recBtn.Name = "recBtn";
            this.recBtn.Size = new System.Drawing.Size(120, 60);
            this.recBtn.TabIndex = 7;
            this.recBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gold;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(735, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mono";
            this.label1.Visible = false;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.recBtn);
            this.Controls.Add(this.ejectBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.playBtn);
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label trkName;
        private System.Windows.Forms.Label elpLbl;
        private System.Windows.Forms.Button ejectBtn;
        private System.Windows.Forms.Timer ejectTimer;
        private System.Windows.Forms.Button recBtn;
        private System.Windows.Forms.Label label1;
    }
}