using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace checkersDAT602
{

	public partial class frmAdminScreen : Form
	{
		private frmEditPlayer _frmEditPlayer = new frmEditPlayer();

		public frmAdminScreen()
		{
			InitializeComponent();
		}

		public bool ShowDialog(string prLoggedInPlayer)
		{

			lblLoggedInName.Text = prLoggedInPlayer;

			return ShowDialog() == DialogResult.OK;

		}

		private void tmrAdminPlayersRefresh_Tick(object sender, EventArgs e)
		{

			int lcCurrentIndex = lstAdminScreenPlayers.SelectedIndex;

			DataTable lcOnlinePlayers = clsDBConnection.SProcTable("grabPlayers", new Dictionary<string, object>
			{ ["prPlayerName"] = lblLoggedInName.Text });

			lstAdminScreenPlayers.DataSource = null;

			lstAdminScreenPlayers.DataSource = (from DataRow lcRow in lcOnlinePlayers.Rows
												select	lcRow["playerName"] + " " + "\t" + "\t" + 
														lcRow["playerStatus"] + "\t" + "\t" + 
														lcRow["rating"] + "\t" + "\t" + lcRow["admin"]).ToList();

			if (lcCurrentIndex > lcOnlinePlayers.Rows.Count - 1)
			{
				lstAdminScreenPlayers.SelectedIndex = -1;
			}
			else if (lcCurrentIndex != 0)
				lstAdminScreenPlayers.SelectedIndex = lcCurrentIndex;

		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;

		}

		private void frmAdminScreen_Load(object sender, EventArgs e)
		{
			tmrAdminPlayersRefresh.Start();
			tmrAdminGamesRefresh.Start();
		}

		private void tmrAdminGamesRefresh_Tick(object sender, EventArgs e)
		{
			updateAdminGames();
		}

		private void updateAdminGames()
		{
			int lcCurrentIndex = lstGames.SelectedIndex;

			DataTable lcGames = clsDBConnection.SProcTable("grabGames", new Dictionary<string, object>
			{ ["prPlayerName"] = lblLoggedInName.Text });

			lstGames.DataSource = null;

			lstGames.DataSource = (from DataRow lcRow in lcGames.Rows
								   select	lcRow["gameID"] + " " + "\t" + 
											lcRow["timeElapsed"] + "\t" + lcRow["timeStarted"] + "\t" + 
											lcRow["currentTurn"] + "\t" + lcRow["playerName1"] + "\t" + 
											lcRow["playerName2"]).ToList();

			if (lcCurrentIndex > lcGames.Rows.Count - 1)
			{
				lstGames.SelectedIndex = -1;
			}
			else
				lstGames.SelectedIndex = lcCurrentIndex;
		}

		private void btnAddPlayer_Click(object sender, EventArgs e)
		{
			_frmEditPlayer.ShowDialog(null);
		}

		private void btnEditPlayer_Click(object sender, EventArgs e)
		{
			if (lstAdminScreenPlayers.SelectedIndex != -1)
			{
				string lcPlayers = lstAdminScreenPlayers.SelectedItem.ToString();
				string lcSelectedPlayer = lcPlayers.Split(' ').FirstOrDefault();
				_frmEditPlayer.ShowDialog(lcSelectedPlayer);
				
			}
			else
				MessageBox.Show("You must select a player to Edit",
									"Edit Player",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation,
									MessageBoxDefaultButton.Button1);
		}

		private void btnDeletePlayer_Click(object sender, EventArgs e)
		{

			try
			{
				string lcPlayers = lstAdminScreenPlayers.SelectedItem.ToString();
				string lcSelectedPlayer = lcPlayers.Split(' ').FirstOrDefault();
				lstGames.SelectedIndex = -1;

				byte lcDeleteResult = Convert.ToByte(clsDBConnection.DbFunction("deletePlayer", new Dictionary<string, object>
				
				{ ["Name"] = lcSelectedPlayer }));

				if (lcDeleteResult == 1)
				{
					MessageBox.Show("Deletion Successful.",
										"Delete Player",
										MessageBoxButtons.OK,
										MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button1);
				}
				else
					MessageBox.Show("Deletion not Successful.",
										"Delete Player",
										MessageBoxButtons.OK,
										MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button1);
			}
			catch (Exception)
			{
				MessageBox.Show("Player may be currently in a game, please try again later.",
										"Delete Player",
										MessageBoxButtons.OK,
										MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button1);

			}
		}

		private void btnKillSelectedGame_Click(object sender, EventArgs e)
		{
			try
			{
				string lcGames = lstGames.SelectedItem.ToString();
				string lcGameID = lcGames.Split(' ').FirstOrDefault();
				lstGames.SelectedIndex = -1;

				byte lcDeleteGameResult = Convert.ToByte(clsDBConnection.DbFunction("deleteGame", new Dictionary<string, object>

				{ ["gameID"] = lcGameID }));

				if (lcDeleteGameResult == 1)
				{
					MessageBox.Show("Deletion Successful.",
										"Delete Game",
										MessageBoxButtons.OK,
										MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button1);
				}
				else
					MessageBox.Show("Deletion not Successful.",
										"Delete Game",
										MessageBoxButtons.OK,
										MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button1);
			}
			catch (Exception)
			{
				MessageBox.Show("Error, please try again later.",
										"Delete Game",
										MessageBoxButtons.OK,
										MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button1);
			}
			
			updateAdminGames();
		}
	}
}
