namespace checkersDAT602
{
    partial class frmGame
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGame));
			this.lblPlayerTwo = new System.Windows.Forms.Label();
			this.lblPlayerOne = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnResign = new System.Windows.Forms.Button();
			this.lblGameID = new System.Windows.Forms.Label();
			this.tmrGame = new System.Windows.Forms.Timer(this.components);
			this.btnUpdateCounters = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblCurrentTurn = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblPlayerTwo
			// 
			this.lblPlayerTwo.AutoSize = true;
			this.lblPlayerTwo.BackColor = System.Drawing.Color.Transparent;
			this.lblPlayerTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayerTwo.ForeColor = System.Drawing.Color.Black;
			this.lblPlayerTwo.Location = new System.Drawing.Point(210, 33);
			this.lblPlayerTwo.Name = "lblPlayerTwo";
			this.lblPlayerTwo.Size = new System.Drawing.Size(247, 42);
			this.lblPlayerTwo.TabIndex = 66;
			this.lblPlayerTwo.Text = "anthony2962";
			// 
			// lblPlayerOne
			// 
			this.lblPlayerOne.AutoSize = true;
			this.lblPlayerOne.BackColor = System.Drawing.Color.Transparent;
			this.lblPlayerOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayerOne.ForeColor = System.Drawing.Color.Black;
			this.lblPlayerOne.Location = new System.Drawing.Point(279, 720);
			this.lblPlayerOne.Name = "lblPlayerOne";
			this.lblPlayerOne.Size = new System.Drawing.Size(260, 42);
			this.lblPlayerOne.TabIndex = 67;
			this.lblPlayerOne.Text = "aeroplane727";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(299, 12);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 16);
			this.label5.TabIndex = 68;
			this.label5.Text = "Player Two";
			// 
			// btnResign
			// 
			this.btnResign.BackColor = System.Drawing.Color.Red;
			this.btnResign.Location = new System.Drawing.Point(9, 793);
			this.btnResign.Name = "btnResign";
			this.btnResign.Size = new System.Drawing.Size(75, 56);
			this.btnResign.TabIndex = 92;
			this.btnResign.Text = "Resign";
			this.btnResign.UseVisualStyleBackColor = false;
			this.btnResign.Click += new System.EventHandler(this.btnResign_Click);
			// 
			// lblGameID
			// 
			this.lblGameID.AutoSize = true;
			this.lblGameID.Location = new System.Drawing.Point(12, 9);
			this.lblGameID.Name = "lblGameID";
			this.lblGameID.Size = new System.Drawing.Size(0, 13);
			this.lblGameID.TabIndex = 98;
			// 
			// tmrGame
			// 
			this.tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
			// 
			// btnUpdateCounters
			// 
			this.btnUpdateCounters.Location = new System.Drawing.Point(479, 25);
			this.btnUpdateCounters.Name = "btnUpdateCounters";
			this.btnUpdateCounters.Size = new System.Drawing.Size(103, 21);
			this.btnUpdateCounters.TabIndex = 103;
			this.btnUpdateCounters.Text = "Update Counters";
			this.btnUpdateCounters.UseVisualStyleBackColor = true;
			this.btnUpdateCounters.Click += new System.EventHandler(this.btnUpdateCounters_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(367, 704);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 16);
			this.label3.TabIndex = 107;
			this.label3.Text = "Player One";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(867, 75);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 20);
			this.label1.TabIndex = 108;
			this.label1.Text = "Current Turn";
			// 
			// lblCurrentTurn
			// 
			this.lblCurrentTurn.AutoSize = true;
			this.lblCurrentTurn.BackColor = System.Drawing.Color.Red;
			this.lblCurrentTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCurrentTurn.Location = new System.Drawing.Point(838, 105);
			this.lblCurrentTurn.Name = "lblCurrentTurn";
			this.lblCurrentTurn.Size = new System.Drawing.Size(153, 73);
			this.lblCurrentTurn.TabIndex = 109;
			this.lblCurrentTurn.Text = "Red";
			// 
			// frmGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::checkersDAT602.Properties.Resources.UZKEjzG;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1085, 861);
			this.Controls.Add(this.lblCurrentTurn);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnUpdateCounters);
			this.Controls.Add(this.lblGameID);
			this.Controls.Add(this.btnResign);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblPlayerOne);
			this.Controls.Add(this.lblPlayerTwo);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmGame";
			this.Text = "Jess\' Checkers";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPlayerTwo;
        private System.Windows.Forms.Label lblPlayerOne;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnResign;
		private System.Windows.Forms.Label lblGameID;
		private System.Windows.Forms.Timer tmrGame;
		private System.Windows.Forms.Button btnUpdateCounters;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblCurrentTurn;
	}
}