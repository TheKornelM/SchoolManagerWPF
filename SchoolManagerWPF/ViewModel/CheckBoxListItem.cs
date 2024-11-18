using System.ComponentModel;

namespace SchoolManagerWPF.ViewModel;

public class CheckBoxListItem<T> : INotifyPropertyChanged
{
    private bool _isChecked;

    public required T Item { get; set; }

    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            if (_isChecked != value)
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
