using System.Collections.ObjectModel;
using System.IO.Ports;

namespace ArenaHub_Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
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

    public class PortViewModel : ReactiveObject
    {
        public string PortName { get; set; }
        public string SelectedPort { get; set; }
        public string ConnectionStatus => string.IsNullOrEmpty(SelectedPort) ? "Disconnected" : "Connected";
    }
}
