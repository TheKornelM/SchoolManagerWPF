using SchoolManagerModel.Validators;
using System.Reflection;
using System.Resources;
using System.Windows;

namespace SchoolManagerWPF.ViewModel;

internal class AddUserViewModel : ViewModelBase
{
    #region Public fields
    public string Username
    {
        get { return _username; }
        set
        {
            SetField(ref _username, value, "Username");
            var resourceManager = new ResourceManager("SchoolManagerWF.Resources.UI",
                Assembly.GetExecutingAssembly());
            var validationResult = new UsernameValidator(resourceManager).Validate(Username);
            UsernameValidatorErrors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            MessageBox.Show("nok");
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

    public string UsernameValidatorErrors
    {
        get { return _usernameValidatorErrors; }
        set
        {
            SetField(ref _username, value, "Username");
        }
    }

    #endregion

    #region Private fields
    private string _username = String.Empty;
    private string _password = String.Empty;
    private string _usernameValidatorErrors = String.Empty;
    //private SecureString _password = new NetworkCredential("", String.Empty).SecurePassword;
    #endregion
}
