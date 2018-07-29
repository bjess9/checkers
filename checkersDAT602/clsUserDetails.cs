namespace checkersDAT602
{
	class clsUserDetails
	{
		string _selectedPlayer;
		string _loggedInPlayerName;

		public string LoggedInPlayerName
		{
			get
			{
				return _loggedInPlayerName;
			}

			set
			{
				_loggedInPlayerName = value;
			}
		}

		public string SelectedPlayer
		{
			get
			{
				return _selectedPlayer;
			}

			set
			{
				_selectedPlayer = value;
			}
		}
	}
}
