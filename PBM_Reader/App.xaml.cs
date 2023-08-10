using PBM_Reader.View;
using PBM_Reader.ViewModel;
using System;
using System.Windows;

namespace PBM_Reader
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        MainViewModel mainViewModel = new MainViewModel();


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainView mainView = new MainView(mainViewModel);
            mainView.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (mainViewModel.IsThreadRunning == true)
            {
                mainViewModel.IsThreadRunning = false;
                mainViewModel.BackgroundThread.Join(1000);
                mainViewModel.BackgroundThread.Abort();
            }
            
            Environment.Exit(0);
        }
    }
}
