using SchoolManagerModel.Validators;
using System.Resources;

namespace SchoolManagerWPF.ViewModel;

internal class AddUserViewModel : ViewModelBase
{
    private readonly ResourceManager _resourceManager;
    #region Public fields
    public string Username
    {
        get { return _username; }
        set
        {
            SetField(ref _username, value, nameof(Username));

            var validator = new UsernameValidator(_resourceManager);
            var validationResult = validator.Validate(_username);

            // Update UsernameValidatorErrors based on validation result
            UsernameValidatorErrors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
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
            SetField(ref _usernameValidatorErrors, value, "UsernameValidatorErrors");
        }
    }

    #endregion

    #region Private fields
    private string _username = String.Empty;
    private string _password = String.Empty;
    private string _usernameValidatorErrors = String.Empty;

    //private SecureString _password = new NetworkCredential("", String.Empty).SecurePassword;
    #endregion

    #region Constructors
    public AddUserViewModel(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
    }

    #endregion
}
