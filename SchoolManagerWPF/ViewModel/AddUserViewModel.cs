using SchoolManagerModel.Utils;
using SchoolManagerModel.Validators;
using System.Resources;

namespace SchoolManagerWPF.ViewModel;

internal class AddUserViewModel : ViewModelBase
{
    private readonly ResourceManager _resourceManager;

    #region Public Properties
    public string Username
    {
        get => _username;
        set
        {
            SetField(ref _username, value, nameof(Username));

            var validator = new UsernameValidator(_resourceManager);

            // Update UsernameValidatorErrors based on validation result
            UsernameValidatorErrors = ValidationErrors.GetErrorsFormatted(validator.Validate(_username));
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            SetField(ref _password, value, nameof(Password));

            var passwordValidator = new PasswordValidator(_resourceManager).Validate(_password);
            PasswordValidatorErrors = ValidationErrors.GetErrorsFormatted(passwordValidator);
        }
    }

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set
        {
            SetField(ref _confirmPassword, value, nameof(ConfirmPassword));
            var confirmPasswordValidator = new ConfirmPasswordValidator(_resourceManager).Validate((_password, _confirmPassword));
            ConfirmPasswordValidatorErrors = ValidationErrors.GetErrorsFormatted(confirmPasswordValidator);
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            SetField(ref _email, value, nameof(Email));
            var validator = new EmailValidator(_resourceManager);
            EmailValidatorErrors = ValidationErrors.GetErrorsFormatted(validator.Validate(_email));
        }
    }

    public string FirstName
    {
        get => _firstName;
        set
        {
            SetField(ref _firstName, value, nameof(FirstName));
            var validator = new NotEmptyValidator(_resourceManager);
            FirstNameValidatorErrors = ValidationErrors.GetErrorsFormatted(validator.Validate(_firstName));
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            SetField(ref _lastName, value, nameof(LastName));
            var validator = new NotEmptyValidator(_resourceManager);
            LastNameValidatorErrors = ValidationErrors.GetErrorsFormatted(validator.Validate(_lastName));
        }
    }

    public int SelectedRole
    {
        get => _selectedRole;
        set => SetField(ref _selectedRole, value, nameof(SelectedRole));
    }

    public string UsernameValidatorErrors
    {
        get => _usernameValidatorErrors;
        set => SetField(ref _usernameValidatorErrors, value, nameof(UsernameValidatorErrors));
    }

    public string EmailValidatorErrors
    {
        get => _emailValidatorErrors;
        set => SetField(ref _emailValidatorErrors, value, nameof(EmailValidatorErrors));
    }

    public string PasswordValidatorErrors
    {
        get => _passwordValidatorErrors;
        set => SetField(ref _passwordValidatorErrors, value, nameof(PasswordValidatorErrors));
    }
    public string ConfirmPasswordValidatorErrors
    {
        get => _confirmPasswordValidatorErrors;
        set => SetField(ref _confirmPasswordValidatorErrors, value, nameof(ConfirmPasswordValidatorErrors));
    }

    public string FirstNameValidatorErrors
    {
        get => _firstNameValidatorErrors;
        set => SetField(ref _firstNameValidatorErrors, value, nameof(FirstNameValidatorErrors));
    }

    public string LastNameValidatorErrors
    {
        get => _lastNameValidatorErrors;
        set => SetField(ref _lastNameValidatorErrors, value, nameof(LastNameValidatorErrors));
    }

    #endregion

    #region Private Fields
    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _confirmPassword = string.Empty;
    private string _email = string.Empty;
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private int _selectedRole;

    private string _usernameValidatorErrors = string.Empty;
    private string _emailValidatorErrors = string.Empty;
    private string _passwordValidatorErrors = string.Empty;
    private string _confirmPasswordValidatorErrors = string.Empty;
    private string _firstNameValidatorErrors = string.Empty;
    private string _lastNameValidatorErrors = string.Empty;
    #endregion

    #region Constructors
    public AddUserViewModel(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
    }
    #endregion

}
