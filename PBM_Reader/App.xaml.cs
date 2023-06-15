using PBM_Reader.View;
using PBM_Reader.ViewModel;
using System.Windows;

namespace PBM_Reader
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainViewModel = new MainViewModel();
            var mainView = new MainView(mainViewModel);
            mainView.Show();
        }
    }
}
