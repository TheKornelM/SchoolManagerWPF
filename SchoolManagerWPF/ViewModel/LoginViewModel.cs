using SchoolManagerWPF.ViewModel.Commands;

namespace SchoolManagerWPF.ViewModel;

internal class LoginViewModel : ViewModelBase
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
    // public event PropertyChangedEventHandler? PropertyChanged;
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
}
