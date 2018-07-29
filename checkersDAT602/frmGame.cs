using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace checkersDAT602
{
	public partial class frmGame : Form
	{
		private const string _FIELD = "Tile";
		clsGameDetails _gameDetails = new clsGameDetails();
		public frmGame()
		{
			createTiles();
			InitializeComponent();

		}

		public bool ShowDialog(string prPlayer, string prOpponent, int prGameID, string prColor)
		{

			_gameDetails.PlayerOne = prPlayer;
			_gameDetails.PlayerTwo = prOpponent;
			_gameDetails.GameID = prGameID;
			_gameDetails.Color = prColor;

			//grabCounters();
			updateCounters();

			if (prColor == "r")
			{
				_gameDetails.Color = "r";
			}
			else if (prColor == "w")
				_gameDetails.Color = "w";

			lblGameID.Text = ("Game ID: " + _gameDetails.GameID.ToString());
			tmrGame.Start();
			updatePlayers();

			return ShowDialog() == DialogResult.OK;
		}

		private void updatePlayers()
		{
			lblPlayerOne.Text = _gameDetails.PlayerOne;
			lblPlayerTwo.Text = _gameDetails.PlayerTwo;
		}

		private void createTiles()
		{
			const int lcLABEL_MARGIN = 100;
			const int lcSPACING = 75;
			const int lcGRID_SIZE = 8;
			int lcRunning = 0;

			for (int lcRow = 0; lcRow < lcGRID_SIZE; lcRow++)
			{

				for (int lcColumn = 0; lcColumn < lcGRID_SIZE; lcColumn++)
				{
					Label lcLabel = new Label();
					lcLabel.Name = _FIELD + lcRow.ToString() + lcColumn.ToString();
					lcLabel.Location = new System.Drawing.Point(lcLABEL_MARGIN + lcColumn * lcSPACING,
					lcLABEL_MARGIN + lcRow * lcSPACING);
					lcLabel.Size = new System.Drawing.Size(lcSPACING, lcSPACING);
					lcLabel.BorderStyle = BorderStyle.FixedSingle;
					lcLabel.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
					lcLabel.Click += new System.EventHandler(Field_Click);
					if (lcRunning % 2 == 0)
						lcLabel.BackColor = Color.Black;
					else
						lcLabel.BackColor = Color.Red;
					Controls.Add(lcLabel);
					lcRunning++;
				}
				lcRunning++;
			}
		}
		private void Field_Click(object sender, EventArgs e)
		{

			string lcCurrentTurn = Convert.ToString(clsDBConnection.DbFunction("checkTurn", new Dictionary<string, object>
			{
				["prGameID"] = _gameDetails.GameID
			}));

			if (lcCurrentTurn == _gameDetails.Color)
			{
				if (_gameDetails.SelectedCheckerRow == 0 && _gameDetails.SelectedCheckerCol == 0)
				{
					selectChecker(sender);
				}
				else
				{
					selectMoveTo(sender);

					// send selected checker and selected moveTo tile to database
					byte lcMoveResult = Convert.ToByte(clsDBConnection.DbFunction("moveChecker", new Dictionary<string, object>
					{
						["prGameID"] = _gameDetails.GameID,
						["prColor"] = _gameDetails.Color,
						["prSelectedCheckerRow"] = _gameDetails.SelectedCheckerRow,
						["prSelectedCheckerCol"] = _gameDetails.SelectedCheckerCol,
						["prSelectedMoveToRow"] = _gameDetails.SelectedMoveToRow,
						["prSelectedMoveToCol"] = _gameDetails.SelectedMoveToCol,
					}));
					if (lcMoveResult == 3)
					{
						MessageBox.Show("You cant jump out of the grid!!!");
					}
					else if (lcMoveResult == 2)
					{

						checkerOut();

						//Jump over function
						byte lcJumpMoveResult = Convert.ToByte(clsDBConnection.DbFunction("jumpMove", new Dictionary<string, object>
						{
							["prGameID"] = _gameDetails.GameID,
							["prColor"] = _gameDetails.Color,
							["prSelectedCheckerRow"] = _gameDetails.SelectedCheckerRow,
							["prSelectedCheckerCol"] = _gameDetails.SelectedCheckerCol,
							["prSelectedMoveToRow"] = _gameDetails.SelectedMoveToRow,
							["prSelectedMoveToCol"] = _gameDetails.SelectedMoveToCol,
						}));


						//count opposing players checkers
						byte lcOpponentCheckerCount = Convert.ToByte(clsDBConnection.DbFunction("countOpponentsCheckers", new Dictionary<string, object>
						{
							["prGameID"] = _gameDetails.GameID,
							["prColor"] = _gameDetails.Color
						}));

						if (lcOpponentCheckerCount == 0)
						{
							updateCounters();
							endGame();
							MessageBox.Show("You have won!!!!!!!");
						}
						//WIN RESULT IF COUNT 0

						//PLAYERS EXIT GAME

						//WINNER GETS POINTS ADDED TO SCORE IN DATABASE



						// if jumpmoveresult = second jump possible
						// give player another turn where they can ONLY make the jump move
						if (lcJumpMoveResult == 1)
						{
							updateCounters();
							changeTurn();
						}
						else if (lcJumpMoveResult == 2)
						{
							MessageBox.Show("Double jump test confirmed");
							updateCounters();
							changeTurn();
						}
						else
						{
							MessageBox.Show("failed jump, check code");
						}

						updateCounters();
						resetSelectedTiles();

					}
					else if (lcMoveResult == 1)
					{
						updateCounters();
						//recolourTiles();
						resetSelectedTiles();
						changeTurn();
					}
					else if (lcMoveResult == 0)
					{
						updateCounters();
						resetSelectedTiles();
					}
				}
			}
		}

		private void checkerOut()
		{
			_gameDetails.CheckersCount = _gameDetails.CheckersCount - 1;
		}

		private void changeTurn()
		{
			byte lcChangeTurnResult = Convert.ToByte(clsDBConnection.DbFunction("changeTurn", new Dictionary<string, object>
			{
				["prGameID"] = _gameDetails.GameID
			}));

			if (lcChangeTurnResult == 0)
			{
				MessageBox.Show("Changing turn error");
			}
		}

		private void resetSelectedTiles()
		{
			_gameDetails.SelectedCheckerRow = 0;
			_gameDetails.SelectedCheckerCol = 0;
			_gameDetails.SelectedMoveToRow = 0;
			_gameDetails.SelectedCheckerRow = 0;

			foreach (Control lcLabel in Controls)
				if (lcLabel.Name == _gameDetails.HighlightedChecker)
				{
					(lcLabel as Label).BackColor = Color.Red;
				}
		}

		private void recolourTiles()
		{
			const int lcGRID_SIZE = 8;
			int lcRunning = 0;

			foreach (Control lcLabel in Controls)
			{
				if (lcLabel.Name.StartsWith("Tile"))
				{
					for (int lcRow = 0; lcRow < lcGRID_SIZE; lcRow++)
					{

						for (int lcColumn = 0; lcColumn < lcGRID_SIZE; lcColumn++)
						{

							if (lcRunning % 2 == 0)
							{
								lcLabel.BackColor = Color.Black;
							}
							else
							{
								lcLabel.BackColor = Color.Red;
							}

							lcRunning++;
						}
						lcRunning++;
					}
				}
			}
		}

		private void selectMoveTo(object sender)
		{
			byte lcTestSelectedMoveToRow = Convert.ToByte((sender as Control).Name.Substring(_FIELD.Length, 1));
			byte lcTestSelectedMoveToCol = Convert.ToByte((sender as Control).Name.Substring(_FIELD.Length + 1, 1));

			foreach (Control lcLabel in Controls)
				if (lcLabel.Name.StartsWith("Tile"))
				{

					byte lcRowIndex = 0;

					do
					{

						if (Convert.ToByte(_gameDetails.Counters.Rows[lcRowIndex]["y"]) != lcTestSelectedMoveToRow
							&& (Convert.ToByte(_gameDetails.Counters.Rows[lcRowIndex]["x"]) != lcTestSelectedMoveToCol))
						{

							_gameDetails.SelectedMoveToRow = lcTestSelectedMoveToRow;
							_gameDetails.SelectedMoveToCol = lcTestSelectedMoveToCol;

							break;
						}

						else

							lcRowIndex++;

					} while (lcRowIndex < 24);  //(lcX < 8 && lcY < 8);
				}
		}

		private void selectChecker(object sender)
		{
			byte lcTestSelectedRow = Convert.ToByte((sender as Control).Name.Substring(_FIELD.Length, 1));
			byte lcTestSelectedCol = Convert.ToByte((sender as Control).Name.Substring(_FIELD.Length + 1, 1));

			foreach (Control lcLabel in Controls)
				if (lcLabel.Name.StartsWith("Tile"))
				{

					byte lcCheckersCount = Convert.ToByte(clsDBConnection.DbFunction("countCheckers", new Dictionary<string, object>
					{
						["prGameID"] = _gameDetails.GameID
					}));

					_gameDetails.CheckersCount = lcCheckersCount;

					byte lcRowIndex = 0;

					do
					{

						if (Convert.ToByte(_gameDetails.Counters.Rows[lcRowIndex]["y"]) == lcTestSelectedRow
							&& (Convert.ToByte(_gameDetails.Counters.Rows[lcRowIndex]["x"]) == lcTestSelectedCol))
						{

							_gameDetails.SelectedCheckerRow = lcTestSelectedRow;
							_gameDetails.SelectedCheckerCol = lcTestSelectedCol;

							if (lcLabel.Name == _FIELD + lcTestSelectedRow + lcTestSelectedCol)
							{
								(lcLabel as Label).BackColor = Color.Yellow;
								_gameDetails.HighlightedChecker = lcLabel.Name;
							}

							break;
						}

						else

							lcRowIndex++;

					} while (lcRowIndex < _gameDetails.CheckersCount);  //(lcX < 8 && lcY < 8);
				}
		}

		private void btnResign_Click(object sender, EventArgs e)
		{
			endGame();
		}

		private void endGame()
		{
			tmrGame.Stop();
			byte lcPlayerStatusChange = Convert.ToByte(clsDBConnection.DbFunction("changePlayerStatus", new Dictionary<string, object>
			{
				["prNewStatus"] = 1,
				["prPlayerName"] = _gameDetails.PlayerOne
			}));

			byte lcOpponentStatusChange = Convert.ToByte(clsDBConnection.DbFunction("changePlayerStatus", new Dictionary<string, object>
			{
				["prNewStatus"] = 1,
				["prPlayerName"] = _gameDetails.PlayerTwo
			}));

			byte lcEndGameResult = Convert.ToByte(clsDBConnection.DbFunction("endGame", new Dictionary<string, object>
			{
				["prGameID"] = _gameDetails.GameID
			}));

			lblGameID.Text = null;
			lblPlayerTwo.Text = null;
			lblPlayerOne.Text = null;
			DialogResult = DialogResult.Cancel;
		}

		private void tmrGame_Tick(object sender, EventArgs e)
		{
			checkForGameEnd();
			updateCounters();

			string lcCurrentTurn = Convert.ToString(clsDBConnection.DbFunction("checkTurn", new Dictionary<string, object>
			{
				["prGameID"] = _gameDetails.GameID
			}));

			if (lcCurrentTurn == "r")
			{
				lblCurrentTurn.Text = "Red";
				lblCurrentTurn.BackColor = Color.Red;
			}
			else if (lcCurrentTurn == "w")
			{
				lblCurrentTurn.Text = "White";
				lblCurrentTurn.BackColor = Color.White;
			}
		}

		private void checkForGameEnd()
		{
			byte lcResignCheck = Convert.ToByte(clsDBConnection.DbFunction("checkForResign", new Dictionary<string, object>
			{
				["prGameID"] = _gameDetails.GameID
			}));

			if (lcResignCheck == 0)
			{
				tmrGame.Stop();
				lblGameID.Text = null;
				lblPlayerTwo.Text = null;
				lblPlayerOne.Text = null;
				DialogResult = DialogResult.Cancel;
			}
		}

		private void updateCounters()
		{

			DataTable lcCounters = clsDBConnection.SProcTable("grabCounters", new Dictionary<string, object>
			{ ["prGameID"] = _gameDetails.GameID });

			_gameDetails.Counters = lcCounters;

			foreach (Control lcLabel in Controls)
				if (lcLabel.Name.StartsWith("Tile"))
				{

					byte lcY = Convert.ToByte(lcLabel.Name.Substring(lcLabel.Name.Length - 2, 1)); // Y substring from Tile name
					byte lcX = Convert.ToByte(lcLabel.Name.Substring(lcLabel.Name.Length - 1, 1));

					byte lcCheckersCount = Convert.ToByte(clsDBConnection.DbFunction("countCheckers", new Dictionary<string, object>
					{
						["prGameID"] = _gameDetails.GameID
					}));

					_gameDetails.CheckersCount = lcCheckersCount;

					byte lcRowIndex = 0;

					do
					{
						checkForGameEnd();
						string lcColor = Convert.ToString(lcCounters.Rows[lcRowIndex]["colour"]);
						if (Convert.ToByte(lcCounters.Rows[lcRowIndex]["y"]) == lcY
							&& (Convert.ToByte(lcCounters.Rows[lcRowIndex]["x"]) == lcX))
						{

							if (lcColor == "r")
							{
								(lcLabel as Label).Image = Properties.Resources.imageedit_3_3042085710;
							}
							else if (lcColor == "w")
							{
								(lcLabel as Label).Image = Properties.Resources.imageedit_5_55142226962;
							}
							else if (lcColor == "rC")
							{
								(lcLabel as Label).Image = Properties.Resources.redCrownv2;
							}
							else if (lcColor == "wC")
							{
								(lcLabel as Label).Image = Properties.Resources.whiteCrownV2;
							}

							break;
						}
						else (lcLabel as Label).Image = null;
						lcRowIndex++;
					} while (lcRowIndex < _gameDetails.CheckersCount);
				}
		}

		private void btnUpdateCounters_Click(object sender, EventArgs e)
		{
			updateCounters();
		}
	}
}
