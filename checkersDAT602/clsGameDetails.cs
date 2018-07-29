using System.Data;

namespace checkersDAT602
{
	class clsGameDetails
	{

		private int _gameID;
		private string _playerOne;
		private string _playerTwo;
		private DataTable _counters;

		private byte selectedCheckerRow;
		private byte selectedCheckerColumn;

		private string highlightedChecker;

		private byte selectedMoveToRow;
		private byte selectedMoveToCol;
		// 0 = red     1 = white
		private string _color;
		private int _checkersCount = 24;

		public int GameID
		{
			get
			{
				return _gameID;
			}

			set
			{
				_gameID = value;
			}
		}

		public string PlayerOne
		{
			get
			{
				return _playerOne;
			}

			set
			{
				_playerOne = value;
			}
		}

		public string PlayerTwo
		{
			get
			{
				return _playerTwo;
			}

			set
			{
				_playerTwo = value;
			}
		}

		public string Color
		{
			get
			{
				return _color;
			}

			set
			{
				_color = value;
			}
		}

		public DataTable Counters
		{
			get
			{
				return _counters;
			}

			set
			{
				_counters = value;
			}
		}

		public byte SelectedCheckerRow
		{
			get
			{
				return selectedCheckerRow;
			}

			set
			{
				selectedCheckerRow = value;
			}
		}

		public byte SelectedCheckerCol
		{
			get
			{
				return selectedCheckerColumn;
			}

			set
			{
				selectedCheckerColumn = value;
			}
		}

		public byte SelectedMoveToRow
		{
			get
			{
				return selectedMoveToRow;
			}

			set
			{
				selectedMoveToRow = value;
			}
		}

		public byte SelectedMoveToCol
		{
			get
			{
				return selectedMoveToCol;
			}

			set
			{
				selectedMoveToCol = value;
			}
		}

		public int CheckersCount
		{
			get
			{
				return _checkersCount;
			}

			set
			{
				_checkersCount = value;
			}
		}

		public string HighlightedChecker
		{
			get
			{
				return highlightedChecker;
			}

			set
			{
				highlightedChecker = value;
			}
		}

	}
}
