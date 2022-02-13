using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ClientComms;
using Comms.Commands;

namespace Comms.ViewModels
{
    public class ClientCommsVm : INotifyPropertyChanged
    {
        private string _version;

        public ClientCommsVm()
        {
            GetVersionCommand = new RelayCommand(GetVersion);
        }

        public string Version
        {
            get => _version;
            set
            {
                _version = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetVersionCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GetVersion(object obj)
        {
            var commsClient = new CommsClient();
            Version = commsClient.GetVersion();
        }
    }
}
