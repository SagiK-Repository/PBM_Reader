using DevExpress.Mvvm;
using PBM_Reader.Common.Static;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PBM_Reader.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Variable
        private bool _connectCommandSwitch = false;
        #endregion

        #region Property
        public string IP
        {
            get { return GetProperty(() => IP); }
            set { SetProperty(() => IP, value); }
        }
        public string PORT
        {
            get { return GetProperty(() => PORT); }
            set { SetProperty(() => PORT, value); }
        }
        public int RepeatTime
        {
            get { return GetProperty(() => RepeatTime); }
            set { SetProperty(() => RepeatTime, value); }
        }
        public string Text
        {
            get { return GetProperty(() => Text); }
            set { SetProperty(() => Text, value); }
        }
        // public ObservableCollection<string> Grids { get; set; }
        #endregion

        #region Command
        public ICommand ConnectCommand { get; private set; }
        #endregion

        #region Constructor & Initiallize Method
        public MainViewModel()
        {
            VariableInitiallize();
            CommandInitiallize();
        }

        private void VariableInitiallize()
        {
            IP = "127.0.0.1";
            PORT = "9100";
            RepeatTime = 1;
        }

        private void CommandInitiallize()
        {
            ConnectCommand = new DelegateCommand(_connectCommand);
        }
        #endregion


        #region Command Method
        private void _connectCommand()
        {
            _connectCommandSwitch = !_connectCommandSwitch;

            string firstCommand = $"pbm {IP}:{PORT}";
            string seconedCommand = "cluster show";

            PowerShellHandling powerShellHandling = new PowerShellHandling();

            Text = powerShellHandling.ExecuteCommand(firstCommand);

            // Text = powerShellHandling.ExecuteCommand(seconedCommand);

            powerShellHandling.Close();
        }
        #endregion
    }
}
