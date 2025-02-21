using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;

namespace ArenaHub_Avalonia.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> AvailablePorts { get; set; }
        public string SelectedPort { get; set; }
        public ObservableCollection<int> BaudRates { get; set; }
        public int SelectedBaudRate { get; set; }
        public ObservableCollection<int> DataBitsOptions { get; set; }
        public int SelectedDataBits { get; set; }
        public ObservableCollection<Parity> Parities { get; set; }
        public Parity SelectedParity { get; set; }
        public string LogMessages { get; set; }

        public ObservableCollection<PortViewModel> Ports { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            AvailablePorts = new ObservableCollection<string>(SerialPort.GetPortNames());
            BaudRates = new ObservableCollection<int> { 9600, 115200 };
            DataBitsOptions = new ObservableCollection<int> { 7, 8 };
            Parities = new ObservableCollection<Parity> { Parity.None, Parity.Odd, Parity.Even };

            Ports = new ObservableCollection<PortViewModel>
            {
                new PortViewModel { PortName = "Input 1" },
                new PortViewModel { PortName = "Input 2" },
                new PortViewModel { PortName = "Output Display" }
            };
        }
    }

    public class PortViewModel : INotifyPropertyChanged
    {
        public string PortName { get; set; }

        private string _selectedPort;
        public string SelectedPort
        {
            get => _selectedPort;
            set
            {
                if (_selectedPort != value)
                {
                    _selectedPort = value;
                    OnPropertyChanged(nameof(SelectedPort));
                    OnPropertyChanged(nameof(ConnectionStatus));
                }
            }
        }

        public string ConnectionStatus => string.IsNullOrEmpty(SelectedPort) ? "Disconnected" : "Connected";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
