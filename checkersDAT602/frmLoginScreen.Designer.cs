namespace checkersDAT602
{
	partial class frmLoginScreen
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginScreen));
			this.txtLoginUserName = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.txtLoginPassword = new System.Windows.Forms.TextBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.btnLogin = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.SuspendLayout();
			// 
			// txtLoginUserName
			// 
			this.txtLoginUserName.BackColor = System.Drawing.Color.LightCyan;
			this.txtLoginUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtLoginUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLoginUserName.Location = new System.Drawing.Point(593, 750);
			this.txtLoginUserName.Name = "txtLoginUserName";
			this.txtLoginUserName.Size = new System.Drawing.Size(262, 31);
			this.txtLoginUserName.TabIndex = 0;
			this.txtLoginUserName.Text = "bob123";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::checkersDAT602.Properties.Resources.Welcome;
			this.pictureBox1.Location = new System.Drawing.Point(285, 209);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(859, 182);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(587, 765);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 13);
			this.label1.TabIndex = 3;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox2.Image = global::checkersDAT602.Properties.Resources.Username;
			this.pictureBox2.Location = new System.Drawing.Point(658, 715);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(129, 29);
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.Red;
			this.btnExit.Location = new System.Drawing.Point(12, 12);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 93;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = false;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// txtLoginPassword
			// 
			this.txtLoginPassword.BackColor = System.Drawing.Color.LightCyan;
			this.txtLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLoginPassword.Location = new System.Drawing.Point(593, 818);
			this.txtLoginPassword.Name = "txtLoginPassword";
			this.txtLoginPassword.Size = new System.Drawing.Size(262, 31);
			this.txtLoginPassword.TabIndex = 1;
			this.txtLoginPassword.Text = "password1";
			this.txtLoginPassword.UseSystemPasswordChar = true;
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox3.Image = global::checkersDAT602.Properties.Resources.Password;
			this.pictureBox3.Location = new System.Drawing.Point(658, 787);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(129, 28);
			this.pictureBox3.TabIndex = 5;
			this.pictureBox3.TabStop = false;
			// 
			// btnLogin
			// 
			this.btnLogin.BackColor = System.Drawing.Color.Transparent;
			this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLogin.ForeColor = System.Drawing.Color.Crimson;
			this.btnLogin.Location = new System.Drawing.Point(919, 782);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(120, 36);
			this.btnLogin.TabIndex = 2;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = false;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// frmLoginScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::checkersDAT602.Properties.Resources.UZKEjzG;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1424, 861);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.txtLoginPassword);
			this.Controls.Add(this.txtLoginUserName);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmLoginScreen";
			this.Text = "Jess\' Checkers";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.TextBox txtLoginUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.TextBox txtLoginPassword;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Button btnLogin;
	}
}

