using MainDataDashboard.Helpers;
using MainDataDashboard.Models;
using MainDataDashboard.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MainDataDashboard.ViewModels
{
    public class SectionViewModel(string title, ICommand navigateCommand) : ViewModelBase
    {
        private readonly ICommand _navigateCommand = navigateCommand;

        public string Title { get; set; } = title;
        public bool IsActive { get; set; }

        public ObservableCollection<StatusItem> StatusItems { get; } = [];
        public ObservableCollection<DeptOfficeItem> DepartmentItems { get; } = [];
        public ICommand NavigateCommand => _navigateCommand;

        public void LoadData()
        {
            StatusItems.Clear();
            DepartmentItems.Clear();

            // الطريقة المثلى مع AddRange
            StatusItems.AddRange(
            [
                new() { Status = "موجود", Count = 120 },
                new() { Status = "مباع", Count = 45 }
            ]);

            // الطريقة البديلة إذا لم تعمل AddRange
            DepartmentItems.Add(new()
            {
                Department = "المعلوماتية",
                Office = "الفرع الرئيسي",
                Count = 56
            });
        }
    }
}