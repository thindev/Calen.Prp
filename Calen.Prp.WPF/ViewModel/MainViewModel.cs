using GalaSoft.MvvmLight;
using Calen.Prp.WPF.Model;

namespace Calen.Prp.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private string _Title = "资源计划";
        PagesManagerViewModel _resourceCenter = new PagesManagerViewModel();

        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                Set(()=>Title,ref _Title, value);
            }
        }

        public PagesManagerViewModel ResourceCenter
        {
            get
            {
                return _resourceCenter;
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel( )
        {
            ResourceCenter.LoadManagingPages();
        }

        public override void Cleanup()
        {
            // Clean up if needed
            base.Cleanup();
        }
    }
}