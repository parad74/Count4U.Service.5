using RestApi.Shared;
using System.ComponentModel;

namespace Count4U.Service.Model
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _selectedString = "Maui";
		private Customer _selectedCustomer = new Customer();

		public string SelectedString
        {
            get => _selectedString;
            set
            {
                if (value != _selectedString)
                {
                    _selectedString = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedString)));
                }
            }
        }


		public Customer SelectedCustomer
			{
			get => _selectedCustomer;
			set
			{
				if (value != _selectedCustomer)
				{
					_selectedCustomer = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCustomer)));
				}
			}
		}
	}
}
