using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace checkersDAT602
{
	public partial class frmLoginScreen : Form
	{

		public frmLoginScreen()
		{
			InitializeComponent();
			MessageBox.Show(clsDBConnection.DbFunction("database", null).ToString());
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void login()
		{
			byte lcLoginResult = Convert.ToByte(clsDBConnection.DbFunction("login", new Dictionary<string, object>

			{ ["Name"] = txtLoginUserName.Text, ["Pwd"] = txtLoginPassword.Text }));

			switch (lcLoginResult)
			{
				case 0:
					
					Hide();

						frmHomeScreen _frmHomeScreen = new frmHomeScreen();
						string lcLoginUserName = txtLoginUserName.Text;
						txtLoginPassword.Text = "";
						_frmHomeScreen.ShowDialog(lcLoginUserName);
					
					Show();
					break;
				case 1:
					MessageBox.Show("Your password is incorrect.",
									"Login",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation,
									MessageBoxDefaultButton.Button1);
					break;
				case 2:
					DialogResult lcDialogResult = MessageBox.Show("Username not found, would you like to register as a new user?",
															"Username not found.",
															MessageBoxButtons.YesNo);
					if (lcDialogResult == DialogResult.Yes)
					{
						register();
					}
					else
					{
						txtLoginPassword.Text = ("");
						txtLoginUserName.Text = ("");
					}
					break;
			}
		}

		private void register()
		{
			byte lcRegisterResult = Convert.ToByte(clsDBConnection.DbFunction("register", new Dictionary<string, object>

			{ ["Name"] = txtLoginUserName.Text, ["Pwd"] = txtLoginPassword.Text }));

			if (lcRegisterResult == 1)
			{
				MessageBox.Show("Registration Successful!");

				Hide();

					frmHomeScreen _frmHomeScreen = new frmHomeScreen();
					string lcLoginUserName = txtLoginUserName.Text;
					_frmHomeScreen.ShowDialog(txtLoginUserName.Text);

				
				txtLoginPassword.Text = "";
				Show();
			}
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			login();
		}
	}
}
