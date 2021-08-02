using System.ComponentModel;

namespace Count4U.Service.Model
{
    public class NumberViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _number = 42;

        public int Number
        {
            get => _number;
            set
            {
                if (value != _number)
                {
                    _number = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Number)));
                }
            }
        }
    }
}
