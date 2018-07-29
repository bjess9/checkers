using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace checkersDAT602
{
	public partial class frmHomeScreen : Form
	{

		private clsUserDetails userDetails = new clsUserDetails();

		public frmHomeScreen()
		{
			InitializeComponent();
		}

		private void frmHomeScreen_Load(object sender, EventArgs e)
		{
			tmrOnlinePlayersRefresh.Start();
			tmrCheckForChallenge.Start();
		}

		public bool ShowDialog(string prUserName)
		{

			userDetails.LoggedInPlayerName = prUserName;

			lblLoggedInName.Text = ("You are Logged in as: " + userDetails.LoggedInPlayerName);

			// Checks for admin status of logging in player
			byte lcCheckAdminStatusResult = Convert.ToByte(clsDBConnection.DbFunction("checkAdminStatus", new Dictionary<string, object>
			{ ["prPlayerName"] = userDetails.LoggedInPlayerName }));

			if (lcCheckAdminStatusResult == 1)
			{
				grpAdminTools.Visible = true;
			}

			return ShowDialog() == DialogResult.OK;
		}

		private void btnLogout_Click(object sender, EventArgs e)
		{
			tmrOnlinePlayersRefresh.Stop();
			tmrCheckForChallenge.Stop();
			logout();

			DialogResult = DialogResult.Cancel;
		}

		private void tmrOnlinePlayersRefresh_Tick(object sender, EventArgs e)
		{

			int lcCurrentIndex = lstOnlinePlayers.SelectedIndex;

			DataTable lcOnlinePlayers = clsDBConnection.SProcTable("grabOnlinePlayers", new Dictionary<string, object>
			{ ["prPlayerName"] = userDetails.LoggedInPlayerName });

			lstOnlinePlayers.DataSource = null;

			lstOnlinePlayers.DataSource = (from DataRow lcRow in lcOnlinePlayers.Rows
										   select lcRow["playerName"] + " " + "\t" +
													lcRow["rating"]).ToList();

			if (lcCurrentIndex > lcOnlinePlayers.Rows.Count - 1)
			{
				lstOnlinePlayers.SelectedIndex = -1;
			}
			else
				lstOnlinePlayers.SelectedIndex = lcCurrentIndex;


		}

		private void pbAdminTools_Click(object sender, EventArgs e)
		{
			frmAdminScreen frmAdminScreen = new frmAdminScreen();
			Hide();

			frmAdminScreen.ShowDialog(userDetails.LoggedInPlayerName);

			Show();
		}

		private void frmHomeScreen_FormClosing(object sender, FormClosingEventArgs e)
		{
			tmrOnlinePlayersRefresh.Stop();
			tmrCheckForChallenge.Stop();
			logout();
			DialogResult = DialogResult.Cancel;
		}

		private void logout()
		{
			byte lcRegisterResult = Convert.ToByte(clsDBConnection.DbFunction("logout", new Dictionary<string, object>
			{ ["Name"] = userDetails.LoggedInPlayerName }));
			lblLoggedInName.Text = null;
		}

		private void pbChallenge_MouseDown(object sender, MouseEventArgs e)
		{

			if (lstOnlinePlayers.SelectedIndex != -1)
			{
				string lcPlayers = lstOnlinePlayers.SelectedItem.ToString();
				string lcSelectedPlayer = lcPlayers.Split(' ').FirstOrDefault();

				int lcNewGameID = Convert.ToInt16(clsDBConnection.DbFunction("newGameV1", new Dictionary<string, object>
				{
					["prChallenger"] = userDetails.LoggedInPlayerName,
					["prOpponent"] = lcSelectedPlayer
				}));

				int lcGameBoardInsertion = Convert.ToInt16(clsDBConnection.DbFunction("newGameBoard", new Dictionary<string, object>
				{
					["prChallenger"] = lcNewGameID
				}));

				if (lcNewGameID == 0)
				{
					MessageBox.Show("A game cannot start with either playing already being in a game!");
				}
				else
				{
					Hide();

					frmGame _frmGame = new frmGame();
					_frmGame.ShowDialog(userDetails.LoggedInPlayerName, lcSelectedPlayer, lcNewGameID, "r");

					Show();
				}
			}
		}

		private void tmrCheckForChallenge_Tick(object sender, EventArgs e)
		{

			// need gameID and challenger name
			int lcGameID = Convert.ToInt16(clsDBConnection.DbFunction("checkForGame", new Dictionary<string, object>
			{
				["prPlayerName"] = userDetails.LoggedInPlayerName
			}));

			


			if (lcGameID > 0)
			{
				string lcOpponent = Convert.ToString(clsDBConnection.DbFunction("retrieveOpponent", new Dictionary<string, object>
				{
					["prPlayerName"] = userDetails.LoggedInPlayerName
				}));
				tmrCheckForChallenge.Stop();

				Hide();

				frmGame _frmGame = new frmGame();
				_frmGame.ShowDialog(lcOpponent, userDetails.LoggedInPlayerName, lcGameID, "w");

				Show();

				tmrCheckForChallenge.Start();
			}
		}
	}
}

