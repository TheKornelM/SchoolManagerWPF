using SchoolManagerWPF.ViewModel.Commands;
using System.ComponentModel;

namespace SchoolManagerWPF.ViewModel;

internal class LoginViewModel : INotifyPropertyChanged
{
    #region Public fields
    public string Username
    {
        get { return _username; }
        set
        {
            SetField(ref _username, value, "Username");
        }
    }
    public string Password
    {
        get { return _password; }
        set
        {
            SetField(ref _password, value, "Password");
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    public LoginUserCommand LoginUserCommand { get; set; }
    public Action? SuccessfulLogin;
    public Action? FailedLogin;
    #endregion

    #region Private fields
    private string _username = String.Empty;
    private string _password = String.Empty;
    //private SecureString _password = new NetworkCredential("", String.Empty).SecurePassword;
    #endregion

    public LoginViewModel()
    {
        LoginUserCommand = new LoginUserCommand(this);
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
}
