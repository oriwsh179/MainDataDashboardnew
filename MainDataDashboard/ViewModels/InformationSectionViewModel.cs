using MainDataDashboard.Helpers;
using MainDataDashboard.Models;
using MainDataDashboard.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace MainDataDashboard.ViewModels
{
    public class InformationSectionViewModel : ViewModelBase
    {
        private readonly ICommand _showDetailsCommand;

        public ObservableCollection<StatusItem> CarStatuses { get; } = new();
        public ObservableCollection<DeptOfficeItem> DeptOfficeData { get; } = new();
        public ICommand ShowDetailsCommand => _showDetailsCommand;

        public InformationSectionViewModel()
        {
            _showDetailsCommand = new RelayCommand(ShowDetails);
            LoadData();
        }

        private void LoadData()
        {
            // تحميل البيانات باستخدام DbHelper
            CarStatuses.AddRange(DbHelper.GetCarStatuses());
            DeptOfficeData.AddRange(DbHelper.GetDeptOfficeData());
            SetColors();
        }

        private void SetColors()
        {
            foreach (var item in CarStatuses)
            {
                item.Color = item.Status switch
                {
                    "موجود" => Brushes.Green,
                    "مباع" => Brushes.Red,
                    "مسقط" => Brushes.Orange,
                    _ => Brushes.Gray
                };
            }
        }

        private void ShowDetails()
        {
            var detailsWindow = new InformationDetailsWindow
            {
                DataContext = this
            };
            detailsWindow.ShowDialog();
        }
    }
}