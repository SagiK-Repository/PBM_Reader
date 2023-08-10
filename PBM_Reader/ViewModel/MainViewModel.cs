using DevExpress.Mvvm;
using PBM_Reader.Common.Static;
using PBM_Reader.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;

namespace PBM_Reader.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public Thread BackgroundThread;
        public bool IsThreadRunning;

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
            set
            {
                if (value < 100)
                    value = 100;
                if (value > 100000)
                    value = 100000;
                SetProperty(() => RepeatTime, value);
            }
        }
        public string Text
        {
            get { return GetProperty(() => Text); }
            set { SetProperty(() => Text, value); }
        }
        public ObservableCollection<AkkaStateModel> Grids { get; set; }
        #endregion

        #region Command
        public ICommand StartCommand { get; private set; }
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
            RepeatTime = 500;
            Grids = new ObservableCollection<AkkaStateModel>();
        }

        private void CommandInitiallize()
        {
            StartCommand = new DelegateCommand(_startCommand);
            StopCommand = new DelegateCommand(_stopCommand);
        }
        #endregion


        #region Command Method
        private void _startCommand()
        {
            IsThreadRunning = true;

            // Get the synchronization context of the UI thread
            SynchronizationContext uiContext = SynchronizationContext.Current;

            BackgroundThread = new Thread(() =>
            {
                while (IsThreadRunning)
                {
                    string commandResult = getPetabridgeStatusCommand(IP, PORT);

                    // Access UI elements on the UI thread
                    uiContext.Send((state) =>
                    {
                        Grids.Clear();
                        foreach (string result in TextAnalysis.GetPBMStatusString(commandResult))
                        {
                            var split = TextAnalysis.SplitString(result, new[] { "|" });
                            if (split.Count < 5)
                                Grids.Add(new AkkaStateModel(new List<string>() { "PMB의 상태를 다시 확인해주세요.", "", "ERROR", "", "" }));
                            else
                                Grids.Add(new AkkaStateModel(split));
                        }
                    }, null);

                    Thread.Sleep(RepeatTime);
                }
            });

            BackgroundThread.Start();
        }

        private void _stopCommand()
        {
            IsThreadRunning = false;
            if (BackgroundThread != null && BackgroundThread.IsAlive)
            {
                BackgroundThread.Join(1000);
                BackgroundThread.Abort();
            }
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
