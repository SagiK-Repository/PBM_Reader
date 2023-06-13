using DevExpress.Xpf.Core;
using PBM_Reader.ViewModel;

namespace PBM_Reader.View
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : DXWindow
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
