using System;

namespace Count4U.Model.Common
{		 
    public class FromFtpItem 
    {
        private string _file;
		private string _name;
		private bool _isFolder;
		private string _size;
		private string _date;
		private DateTime _dateTimeCreated;

		public FromFtpItem()
        {
    
        }

		public string Name
		{
			get { return this._name; }
			set
			{
				this._name = value;
			}
		}
		public string File
		{
			get { return this._file; }
			set
			{
				this._file = value;
			}
		}

		public bool IsFolder
		{
			get { return this._isFolder; }
            set
            {
				this._isFolder = value;
            }
        }

		public string Size
		{
			get { return this._size; }
			set
			{
				this._size = value;
			}
		}

		public string Date
		{
			get { return this._date; }
			set
			{
				this._date = value;
			}
		}

		public DateTime DateTimeCreated
		{
			get { return this._dateTimeCreated; }
			set
			{
				this._dateTimeCreated = value;
			}
		}
			
      


  
    }
}