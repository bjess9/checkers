namespace checkersDAT602
{
    partial class frmAdminScreen
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminScreen));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnDeletePlayer = new System.Windows.Forms.Button();
			this.btnKillSelectedGame = new System.Windows.Forms.Button();
			this.lblLoggedInName = new System.Windows.Forms.Label();
			this.lstAdminScreenPlayers = new System.Windows.Forms.ListBox();
			this.tmrAdminPlayersRefresh = new System.Windows.Forms.Timer(this.components);
			this.tmrAdminGamesRefresh = new System.Windows.Forms.Timer(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.lstGames = new System.Windows.Forms.ListBox();
			this.btnAddPlayer = new System.Windows.Forms.Button();
			this.btnEditPlayer = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::checkersDAT602.Properties.Resources.Player_Details;
			this.pictureBox1.Location = new System.Drawing.Point(326, 446);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(182, 29);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox2.Image = global::checkersDAT602.Properties.Resources.Administrator_Tools;
			this.pictureBox2.Location = new System.Drawing.Point(84, 12);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(641, 78);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox3.Image = global::checkersDAT602.Properties.Resources.Running_Games;
			this.pictureBox3.Location = new System.Drawing.Point(326, 175);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(182, 29);
			this.pictureBox3.TabIndex = 5;
			this.pictureBox3.TabStop = false;
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.Red;
			this.btnExit.Location = new System.Drawing.Point(367, 716);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 93;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = false;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnDeletePlayer
			// 
			this.btnDeletePlayer.BackColor = System.Drawing.Color.Red;
			this.btnDeletePlayer.Location = new System.Drawing.Point(474, 482);
			this.btnDeletePlayer.Name = "btnDeletePlayer";
			this.btnDeletePlayer.Size = new System.Drawing.Size(130, 23);
			this.btnDeletePlayer.TabIndex = 94;
			this.btnDeletePlayer.Text = "Delete Selected Player";
			this.btnDeletePlayer.UseVisualStyleBackColor = false;
			this.btnDeletePlayer.Click += new System.EventHandler(this.btnDeletePlayer_Click);
			// 
			// btnKillSelectedGame
			// 
			this.btnKillSelectedGame.BackColor = System.Drawing.Color.Red;
			this.btnKillSelectedGame.Location = new System.Drawing.Point(367, 210);
			this.btnKillSelectedGame.Name = "btnKillSelectedGame";
			this.btnKillSelectedGame.Size = new System.Drawing.Size(107, 23);
			this.btnKillSelectedGame.TabIndex = 95;
			this.btnKillSelectedGame.Text = "Kill Selected Game";
			this.btnKillSelectedGame.UseVisualStyleBackColor = false;
			this.btnKillSelectedGame.Click += new System.EventHandler(this.btnKillSelectedGame_Click);
			// 
			// lblLoggedInName
			// 
			this.lblLoggedInName.AutoSize = true;
			this.lblLoggedInName.BackColor = System.Drawing.Color.Transparent;
			this.lblLoggedInName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLoggedInName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblLoggedInName.Location = new System.Drawing.Point(447, 93);
			this.lblLoggedInName.Name = "lblLoggedInName";
			this.lblLoggedInName.Size = new System.Drawing.Size(29, 13);
			this.lblLoggedInName.TabIndex = 97;
			this.lblLoggedInName.Text = "fred";
			// 
			// lstAdminScreenPlayers
			// 
			this.lstAdminScreenPlayers.FormattingEnabled = true;
			this.lstAdminScreenPlayers.Location = new System.Drawing.Point(213, 511);
			this.lstAdminScreenPlayers.Name = "lstAdminScreenPlayers";
			this.lstAdminScreenPlayers.Size = new System.Drawing.Size(391, 199);
			this.lstAdminScreenPlayers.TabIndex = 98;
			// 
			// tmrAdminPlayersRefresh
			// 
			this.tmrAdminPlayersRefresh.Enabled = true;
			this.tmrAdminPlayersRefresh.Interval = 1000;
			this.tmrAdminPlayersRefresh.Tick += new System.EventHandler(this.tmrAdminPlayersRefresh_Tick);
			// 
			// tmrAdminGamesRefresh
			// 
			this.tmrAdminGamesRefresh.Enabled = true;
			this.tmrAdminGamesRefresh.Tick += new System.EventHandler(this.tmrAdminGamesRefresh_Tick);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label4.Location = new System.Drawing.Point(331, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(111, 13);
			this.label4.TabIndex = 100;
			this.label4.Text = "You are Logged in as:";
			// 
			// lstGames
			// 
			this.lstGames.FormattingEnabled = true;
			this.lstGames.Location = new System.Drawing.Point(213, 241);
			this.lstGames.Name = "lstGames";
			this.lstGames.Size = new System.Drawing.Size(391, 199);
			this.lstGames.TabIndex = 101;
			// 
			// btnAddPlayer
			// 
			this.btnAddPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.btnAddPlayer.Location = new System.Drawing.Point(213, 482);
			this.btnAddPlayer.Name = "btnAddPlayer";
			this.btnAddPlayer.Size = new System.Drawing.Size(119, 23);
			this.btnAddPlayer.TabIndex = 102;
			this.btnAddPlayer.Text = "Add New Player";
			this.btnAddPlayer.UseVisualStyleBackColor = false;
			this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
			// 
			// btnEditPlayer
			// 
			this.btnEditPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.btnEditPlayer.Location = new System.Drawing.Point(338, 482);
			this.btnEditPlayer.Name = "btnEditPlayer";
			this.btnEditPlayer.Size = new System.Drawing.Size(130, 23);
			this.btnEditPlayer.TabIndex = 103;
			this.btnEditPlayer.Text = "Edit Selected Player";
			this.btnEditPlayer.UseVisualStyleBackColor = false;
			this.btnEditPlayer.Click += new System.EventHandler(this.btnEditPlayer_Click);
			// 
			// frmAdminScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::checkersDAT602.Properties.Resources.R9yYLhe;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(812, 761);
			this.Controls.Add(this.btnEditPlayer);
			this.Controls.Add(this.btnAddPlayer);
			this.Controls.Add(this.lstGames);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lstAdminScreenPlayers);
			this.Controls.Add(this.lblLoggedInName);
			this.Controls.Add(this.btnKillSelectedGame);
			this.Controls.Add(this.btnDeletePlayer);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmAdminScreen";
			this.Text = "Jess\' Checkers";
			this.Load += new System.EventHandler(this.frmAdminScreen_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnDeletePlayer;
		private System.Windows.Forms.Button btnKillSelectedGame;
		private System.Windows.Forms.Label lblLoggedInName;
		private System.Windows.Forms.ListBox lstAdminScreenPlayers;
		private System.Windows.Forms.Timer tmrAdminPlayersRefresh;
		private System.Windows.Forms.Timer tmrAdminGamesRefresh;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox lstGames;
		private System.Windows.Forms.Button btnAddPlayer;
		private System.Windows.Forms.Button btnEditPlayer;
	}
}