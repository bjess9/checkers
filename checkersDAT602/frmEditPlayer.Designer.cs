namespace checkersDAT602
{
	partial class frmEditPlayer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPlayer));
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtPlayerName = new System.Windows.Forms.TextBox();
			this.txtRating = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.chkAdmin = new System.Windows.Forms.CheckBox();
			this.btnSet = new System.Windows.Forms.Button();
			this.lblSetMessage = new System.Windows.Forms.Label();
			this.cboStatus = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(9, 169);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(150, 169);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtPlayerName
			// 
			this.txtPlayerName.Location = new System.Drawing.Point(79, 6);
			this.txtPlayerName.Name = "txtPlayerName";
			this.txtPlayerName.Size = new System.Drawing.Size(142, 20);
			this.txtPlayerName.TabIndex = 2;
			// 
			// txtRating
			// 
			this.txtRating.Location = new System.Drawing.Point(79, 86);
			this.txtRating.Name = "txtRating";
			this.txtRating.Size = new System.Drawing.Size(142, 20);
			this.txtRating.TabIndex = 4;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(79, 32);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(100, 20);
			this.txtPassword.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Player Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Password";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 89);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Rating";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Admin Y/N";
			// 
			// chkAdmin
			// 
			this.chkAdmin.AutoSize = true;
			this.chkAdmin.Location = new System.Drawing.Point(79, 112);
			this.chkAdmin.Name = "chkAdmin";
			this.chkAdmin.Size = new System.Drawing.Size(15, 14);
			this.chkAdmin.TabIndex = 12;
			this.chkAdmin.UseVisualStyleBackColor = true;
			// 
			// btnSet
			// 
			this.btnSet.Location = new System.Drawing.Point(185, 30);
			this.btnSet.Name = "btnSet";
			this.btnSet.Size = new System.Drawing.Size(40, 23);
			this.btnSet.TabIndex = 13;
			this.btnSet.Text = "Set";
			this.btnSet.UseVisualStyleBackColor = true;
			this.btnSet.Visible = false;
			this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
			// 
			// lblSetMessage
			// 
			this.lblSetMessage.AutoSize = true;
			this.lblSetMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSetMessage.Location = new System.Drawing.Point(42, 140);
			this.lblSetMessage.Name = "lblSetMessage";
			this.lblSetMessage.Size = new System.Drawing.Size(151, 26);
			this.lblSetMessage.TabIndex = 14;
			this.lblSetMessage.Text = "The \'Set\' button must be used \r\nto change password.";
			this.lblSetMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblSetMessage.Visible = false;
			// 
			// cboStatus
			// 
			this.cboStatus.Enabled = false;
			this.cboStatus.FormattingEnabled = true;
			this.cboStatus.Location = new System.Drawing.Point(79, 59);
			this.cboStatus.Name = "cboStatus";
			this.cboStatus.Size = new System.Drawing.Size(121, 21);
			this.cboStatus.TabIndex = 15;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Status";
			// 
			// frmEditPlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(233, 204);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cboStatus);
			this.Controls.Add(this.lblSetMessage);
			this.Controls.Add(this.btnSet);
			this.Controls.Add(this.chkAdmin);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtRating);
			this.Controls.Add(this.txtPlayerName);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmEditPlayer";
			this.Text = "New/Edit";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditPlayer_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEditPlayer_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtPlayerName;
		private System.Windows.Forms.TextBox txtRating;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkAdmin;
		private System.Windows.Forms.Button btnSet;
		private System.Windows.Forms.Label lblSetMessage;
		private System.Windows.Forms.ComboBox cboStatus;
		private System.Windows.Forms.Label label3;
	}
}