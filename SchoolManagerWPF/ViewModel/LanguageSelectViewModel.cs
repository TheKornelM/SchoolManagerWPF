using SchoolManagerWPF.ViewModel.Commands;
using System.ComponentModel;

namespace SchoolManagerWPF.ViewModel;

internal class LanguageSelectViewModel : INotifyPropertyChanged
{
    public ShowLoginCommand ShowLoginCommand { get; private set; }

    public Action? LoginShowAction { get; set; } = null;

    public event PropertyChangedEventHandler? PropertyChanged;

    private int _languageId;

    public int LanguageId
    {
        get { return _languageId; }
        set
        {
            SetField(ref _languageId, value, "LanguageId");
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler? handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    protected bool SetField<T>(ref T field, T value, string propertyName)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        };

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public LanguageSelectViewModel()
    {
        ShowLoginCommand = new ShowLoginCommand(this);
    }

}
