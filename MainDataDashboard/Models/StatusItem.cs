using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace MainDataDashboard.Models
{
    public class StatusItem : INotifyPropertyChanged
    {
        private string _status;
        private int _count;
        private Brush _color;
        private bool _isSelected;

        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                    UpdateColor(); // Auto-update color when status changes
                }
            }
        }

        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged();
                }
            }
        }

        public Brush Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateColor()
        {
            Color = _status switch
            {
                "موجود" => Brushes.Green,
                "مباع" => Brushes.Red,
                "مسقط" => Brushes.Orange,
                "قيد التحويل" => Brushes.Blue,
                _ => Brushes.Gray
            };
        }

        // Helper method for cloning
        public StatusItem Clone()
        {
            return new StatusItem
            {
                Status = this.Status,
                Count = this.Count,
                Color = this.Color.Clone()
            };
        }
    }
}