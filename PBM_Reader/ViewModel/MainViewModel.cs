using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using PBM_Reader.Common.Static;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PBM_Reader.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
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
        public ICommand StopCommand { get; private set; }
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
            StopCommand = new DelegateCommand(_stopCommand);
        }
        #endregion


        #region Command Method
        private void _connectCommand()
        {
            string commandResult = getPetabridgeStatusCommand(IP, PORT);

            foreach (string result in TextAnalysis.GetPBMStatusString(commandResult))
            {
                Text += result + "\n";
            }

            if (Text.Contains("~~~") || Text.Contains("pbm : 'pbm'"))
                Text = ">>>>>>>>>>> Not Install PBM Now <<<<<<<<<<<<<<<<<";
        }

        private void _stopCommand()
        {
        }
        #endregion

        #region private Method
        private string getPetabridgeStatusCommand(string ip, string port)
        {
            PowerShellHandling powerShellHandling = new PowerShellHandling();

            string command = $"pbm {ip}:{port} cluster show";
            string result = powerShellHandling.ExecuteCommand(command);

            powerShellHandling.Close();

            return result;
        }
        #endregion
    }
}
