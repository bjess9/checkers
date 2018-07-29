using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace checkersDAT602
{
	public partial class frmEditPlayer : Form
	{

		public static readonly string[] statusType = { "Online", "Offline", "Waiting", "Ingame" };

		public frmEditPlayer()
		{
			InitializeComponent();
			cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
			cboStatus.DataSource = statusType;
			cboStatus.SelectedIndex = 0;
		}

		public bool ShowDialog(string prSelectedPlayer)
		{
			if (prSelectedPlayer != null)
			{
				DataTable lcGrabbedPlayer = clsDBConnection.SProcTable("grabPlayer", new Dictionary<string, object>
				{ ["prPlayerName"] = prSelectedPlayer });
				txtPlayerName.Text = lcGrabbedPlayer.Rows[0]["playerName"].ToString();
				cboStatus.Text = lcGrabbedPlayer.Rows[0]["playerStatus"].ToString();
				txtRating.Text = lcGrabbedPlayer.Rows[0]["rating"].ToString();
				string lcAdminStatus = lcGrabbedPlayer.Rows[0]["admin"].ToString();

				prSelectedPlayer = txtPlayerName.Text;

				txtPlayerName.Enabled = string.IsNullOrWhiteSpace(txtPlayerName.Text);
				lblSetMessage.Visible = true;
				btnSet.Visible = true;

				cboStatus.Enabled = true;
			}

			return ShowDialog() == DialogResult.OK;

		}
		

		private void btnCancel_Click(object sender, EventArgs e)
		{
			clearEditForm();
			DialogResult = DialogResult.Cancel;
		}

		private void btnSet_Click(object sender, EventArgs e)
		{
			
			if (string.IsNullOrWhiteSpace(txtPassword.Text) == false)
			{
				DialogResult lcResult = MessageBox.Show("Are you sure you want to set new user password?",
														"Important Question",
														MessageBoxButtons.YesNo);
				if (lcResult == DialogResult.Yes)
				{
					byte lcSetPasswordResult = Convert.ToByte(clsDBConnection.DbFunction("updateNewUserPassword", new Dictionary<string, object>

					{
						["prPlayerName"] = txtPlayerName.Text,
						["prPassword"] = txtPassword.Text
					}));

					if (lcSetPasswordResult == 1)
					{
						MessageBox.Show("Password Write Successful");
					}
				}
			}
			else
			{
				MessageBox.Show("Password can not be blank for White Space.");
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			string lcAdminCheckStatus;

			if (chkAdmin.Checked)
			{
				lcAdminCheckStatus = "Y";
			}
			else
			{
				lcAdminCheckStatus = "N";
			}
			try
			{
				string lcPassword;
				if (txtPlayerName.Enabled == true)
				{
					lcPassword = txtPassword.Text;

					byte lcAddResult = Convert.ToByte(clsDBConnection.DbFunction("addOrEditPlayer", new Dictionary<string, object>

					{
						["prPlayerName"] = txtPlayerName.Text,
						["prPassword"] = lcPassword,
						["prStatus"] = cboStatus.Text,
						["prRating"] = txtRating.Text,
						["prAdmin"] = lcAdminCheckStatus,
						["prAddOrEdit"] = 0

					}));
					DialogResult = DialogResult.OK;

				}
				else lcPassword = null;
				byte lcEditResult = Convert.ToByte(clsDBConnection.DbFunction("addOrEditPlayer", new Dictionary<string, object>

				{
					["prPlayerName"] = txtPlayerName.Text,
					["prPassword"] = lcPassword,
					["prStatus"] = cboStatus.Text,
					["prRating"] = txtRating.Text,
					["prAdmin"] = lcAdminCheckStatus,
					["prAddOrEdit"] = 1

				}));
				clearEditForm();
				DialogResult = DialogResult.OK;
			}
			catch (Exception)
			{
				MessageBox.Show("Error Creating/Editing player, ensure you are using letters and numbers inside input fields.",
									"Add/Edit Player",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation,
									MessageBoxDefaultButton.Button1);
			}
		}

		private void clearEditForm()
		{
			txtPlayerName.Text = null;
			txtRating.Text = null;
			txtPassword.Text = null;
			txtPlayerName.Enabled = true;
			lblSetMessage.Visible = false;
			btnSet.Visible = false;
		}

		private void frmEditPlayer_FormClosing(object sender, FormClosingEventArgs e)
		{
			clearEditForm();
		}

		private void frmEditPlayer_FormClosed(object sender, FormClosedEventArgs e)
		{
			clearEditForm();
		}
	}
}
