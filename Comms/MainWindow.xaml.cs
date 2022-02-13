using System.Windows;
using Comms.ViewModels;

namespace Comms
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ClientCommsVm();
        }
    }
}
