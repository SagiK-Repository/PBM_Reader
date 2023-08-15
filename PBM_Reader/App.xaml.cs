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
            mainViewModel.StopCommand.Execute(null);

            Environment.Exit(0);
        }
    }
}
