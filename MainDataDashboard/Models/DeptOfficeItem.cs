using System.ComponentModel;
using System.Runtime.CompilerServices;

public class DeptOfficeItem : INotifyPropertyChanged
{
    private string _department;
    private string _office;
    private int _count;

    public string Department
    {
        get => _department;
        set { _department = value; OnPropertyChanged(); }
    }

    public string Office
    {
        get => _office;
        set { _office = value; OnPropertyChanged(); }
    }

    public int Count
    {
        get => _count;
        set { _count = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}