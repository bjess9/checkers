namespace checkersDAT602
{
    partial class frmHomeScreen
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHomeScreen));
			this.dataSet1 = new System.Data.DataSet();
			this.pbAdminTools = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnLogout = new System.Windows.Forms.Button();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pbChallenge = new System.Windows.Forms.PictureBox();
			this.lstOnlinePlayers = new System.Windows.Forms.ListBox();
			this.lblLoggedInName = new System.Windows.Forms.Label();
			this.lblLoggedInAs = new System.Windows.Forms.Label();
			this.tmrOnlinePlayersRefresh = new System.Windows.Forms.Timer(this.components);
			this.grpAdminTools = new System.Windows.Forms.GroupBox();
			this.tmrCheckForChallenge = new System.Windows.Forms.Timer(this.components);
			this.tmrWaitingForChallengeResponse = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbAdminTools)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbChallenge)).BeginInit();
			this.grpAdminTools.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			// 
			// pbAdminTools
			// 
			this.pbAdminTools.BackColor = System.Drawing.Color.Khaki;
			this.pbAdminTools.Image = global::checkersDAT602.Properties.Resources.oficcial_256;
			this.pbAdminTools.Location = new System.Drawing.Point(12, 32);
			this.pbAdminTools.Name = "pbAdminTools";
			this.pbAdminTools.Size = new System.Drawing.Size(66, 49);
			this.pbAdminTools.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbAdminTools.TabIndex = 13;
			this.pbAdminTools.TabStop = false;
			this.pbAdminTools.Click += new System.EventHandler(this.pbAdminTools_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(0, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Administrator Tools";
			// 
			// btnLogout
			// 
			this.btnLogout.BackColor = System.Drawing.Color.Red;
			this.btnLogout.Location = new System.Drawing.Point(289, 358);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Size = new System.Drawing.Size(75, 23);
			this.btnLogout.TabIndex = 93;
			this.btnLogout.Text = "Logout";
			this.btnLogout.UseVisualStyleBackColor = false;
			this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox3.Image = global::checkersDAT602.Properties.Resources.Online_Players;
			this.pictureBox3.Location = new System.Drawing.Point(94, 7);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(184, 32);
			this.pictureBox3.TabIndex = 12;
			this.pictureBox3.TabStop = false;
			// 
			// pbChallenge
			// 
			this.pbChallenge.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.pbChallenge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pbChallenge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pbChallenge.Image = global::checkersDAT602.Properties.Resources.Challenge;
			this.pbChallenge.Location = new System.Drawing.Point(118, 283);
			this.pbChallenge.Name = "pbChallenge";
			this.pbChallenge.Size = new System.Drawing.Size(128, 36);
			this.pbChallenge.TabIndex = 94;
			this.pbChallenge.TabStop = false;
			this.pbChallenge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbChallenge_MouseDown);
			// 
			// lstOnlinePlayers
			// 
			this.lstOnlinePlayers.FormattingEnabled = true;
			this.lstOnlinePlayers.Location = new System.Drawing.Point(12, 45);
			this.lstOnlinePlayers.Name = "lstOnlinePlayers";
			this.lstOnlinePlayers.Size = new System.Drawing.Size(344, 199);
			this.lstOnlinePlayers.TabIndex = 95;
			// 
			// lblLoggedInName
			// 
			this.lblLoggedInName.AutoSize = true;
			this.lblLoggedInName.BackColor = System.Drawing.Color.Transparent;
			this.lblLoggedInName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLoggedInName.Location = new System.Drawing.Point(100, 247);
			this.lblLoggedInName.Name = "lblLoggedInName";
			this.lblLoggedInName.Size = new System.Drawing.Size(132, 13);
			this.lblLoggedInName.TabIndex = 96;
			this.lblLoggedInName.Text = "You are logged in as: ";
			// 
			// lblLoggedInAs
			// 
			this.lblLoggedInAs.AutoSize = true;
			this.lblLoggedInAs.BackColor = System.Drawing.Color.Transparent;
			this.lblLoggedInAs.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblLoggedInAs.Location = new System.Drawing.Point(21, -4);
			this.lblLoggedInAs.Name = "lblLoggedInAs";
			this.lblLoggedInAs.Size = new System.Drawing.Size(0, 13);
			this.lblLoggedInAs.TabIndex = 1;
			// 
			// tmrOnlinePlayersRefresh
			// 
			this.tmrOnlinePlayersRefresh.Interval = 1000;
			this.tmrOnlinePlayersRefresh.Tick += new System.EventHandler(this.tmrOnlinePlayersRefresh_Tick);
			// 
			// grpAdminTools
			// 
			this.grpAdminTools.BackColor = System.Drawing.Color.Transparent;
			this.grpAdminTools.Controls.Add(this.pbAdminTools);
			this.grpAdminTools.Controls.Add(this.label1);
			this.grpAdminTools.Location = new System.Drawing.Point(2, 290);
			this.grpAdminTools.Name = "grpAdminTools";
			this.grpAdminTools.Size = new System.Drawing.Size(98, 91);
			this.grpAdminTools.TabIndex = 97;
			this.grpAdminTools.TabStop = false;
			this.grpAdminTools.Visible = false;
			// 
			// tmrCheckForChallenge
			// 
			this.tmrCheckForChallenge.Tick += new System.EventHandler(this.tmrCheckForChallenge_Tick);
			// 
			// tmrWaitingForChallengeResponse
			// 
		
			// 
			// frmHomeScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::checkersDAT602.Properties.Resources.UZKEjzG;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(376, 388);
			this.Controls.Add(this.grpAdminTools);
			this.Controls.Add(this.lblLoggedInAs);
			this.Controls.Add(this.lblLoggedInName);
			this.Controls.Add(this.lstOnlinePlayers);
			this.Controls.Add(this.pbChallenge);
			this.Controls.Add(this.btnLogout);
			this.Controls.Add(this.pictureBox3);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmHomeScreen";
			this.Text = "Jess\' Checkers";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHomeScreen_FormClosing);
			this.Load += new System.EventHandler(this.frmHomeScreen_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbAdminTools)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbChallenge)).EndInit();
			this.grpAdminTools.ResumeLayout(false);
			this.grpAdminTools.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.PictureBox pbAdminTools;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnLogout;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pbChallenge;
		private System.Windows.Forms.ListBox lstOnlinePlayers;
		private System.Windows.Forms.Label lblLoggedInName;
		private System.Windows.Forms.Label lblLoggedInAs;
		private System.Windows.Forms.Timer tmrOnlinePlayersRefresh;
		private System.Windows.Forms.GroupBox grpAdminTools;
		private System.Windows.Forms.Timer tmrCheckForChallenge;
		private System.Windows.Forms.Timer tmrWaitingForChallengeResponse;
	}
}