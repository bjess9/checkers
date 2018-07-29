namespace checkersDAT602
{
	class clsAddOrDelete
	{
		string _adminCheckStatus;
		byte _addOrEdit;

		public string AdminCheckStatus
		{
			get
			{
				return _adminCheckStatus;
			}

			set
			{
				_adminCheckStatus = value;
			}
		}

		public byte AddOrEdit
		{
			get
			{
				return _addOrEdit;
			}

			set
			{
				_addOrEdit = value;
			}
		}
	}
}
