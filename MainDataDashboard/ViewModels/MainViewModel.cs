using System.Windows.Input;

namespace MainDataDashboard.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand ShowDashboardCommand { get; }
        public ICommand ShowInformationCommand { get; }

        public MainViewModel()
        {
            ShowDashboardCommand = new RelayCommand(ShowDashboard);
            ShowInformationCommand = new RelayCommand(ShowInformation);
            ShowDashboard();
        }

        private void ShowDashboard()
        {
            CurrentView = new DashboardViewModel();
        }

        private void ShowInformation()
        {
            CurrentView = new InformationViewModel();
        }
    }
}