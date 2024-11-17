using SchoolManagerModel.Entities;
using SchoolManagerModel.Entities.UserModel;
using SchoolManagerModel.Managers;
using SchoolManagerModel.Persistence;
using SchoolManagerModel.Utils;
using SchoolManagerModel.Validators;
using SchoolManagerWPF.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Resources;

namespace SchoolManagerWPF.ViewModel;

internal class AddUserViewModel : ViewModelBase
{
    #region Private Fields
    private readonly ResourceManager _resourceManager;
    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _confirmPassword = string.Empty;
    private string _email = string.Empty;
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private Role _selectedRole = Role.Student;
    private bool _isStudent = false;
    private Class? _class;

    private string _usernameValidatorErrors = string.Empty;
    private string _emailValidatorErrors = string.Empty;
    private string _passwordValidatorErrors = string.Empty;
    private string _confirmPasswordValidatorErrors = string.Empty;
    private string _firstNameValidatorErrors = string.Empty;
    private string _lastNameValidatorErrors = string.Empty;
    private bool _hasSelectedClass;
    public ObservableCollection<Class> _classes = [];
    #endregion

    #region Public Properties
    public string Username
    {
        get => _username;
        set
        {
            SetField(ref _username, value, nameof(Username));
            ValidateUsernameAsync(_username);
            AddUserCommand.NotifyCanExecuteChanged();
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
            AddUserCommand.NotifyCanExecuteChanged();
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
            AddUserCommand.NotifyCanExecuteChanged();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            SetField(ref _email, value, nameof(Email));
            ValidateEmailAsync(_email);
            AddUserCommand.NotifyCanExecuteChanged();
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
            AddUserCommand.NotifyCanExecuteChanged();
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
            AddUserCommand.NotifyCanExecuteChanged();
        }
    }

    public Role SelectedRole
    {
        get => _selectedRole;
        set
        {
            SetField(ref _selectedRole, value, nameof(SelectedRole));
            IsStudent = _selectedRole == Role.Student;
        }
    }

    public bool IsStudent
    {
        get => _isStudent;
        set => SetField(ref _isStudent, value, nameof(IsStudent));
    }

    public bool HasSelectedClass
    {
        get => _hasSelectedClass;
        set => SetField(ref _hasSelectedClass, value, nameof(HasSelectedClass));
    }

    public ObservableCollection<Class> Classes
    {
        get => _classes;
        set => SetField(ref _classes, value, nameof(Classes));
    }

    public Class? Class
    {
        get => _class;
        set
        {
            SetField(ref _class, value, nameof(Class));
            AddUserCommand.NotifyCanExecuteChanged();
        }
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

    public Action? SuccessfulUserAdd;
    public Action? FailedUserAdd;
    #endregion

    #region Commands
    public AddUserCommand AddUserCommand { get; }
    #endregion

    #region Constructor
    public AddUserViewModel(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
        AddUserCommand = new AddUserCommand(this);
        GetClassesAsync();
    }
    #endregion

    #region Private Methods
    private async void GetClassesAsync()
    {
        ClassDatabase db = new ClassDatabase(new SchoolDbContext());
        var classManager = new ClassManager(db);
        _classes = new ObservableCollection<Class>(await classManager.GetClassesAsync());
    }

    private async void ValidateUsernameAsync(string username)
    {
        try
        {
            using var dbContext = new SchoolDbContext();
            var userDatabase = new UserDatabase(dbContext);
            var userManager = new UserManager(userDatabase);
            var validator = new ValidNotExistsUserValidator(userManager, _resourceManager);

            var validationResult = await validator.ValidateAsync(new User { Username = username });
            UsernameValidatorErrors = ValidationErrors.GetErrorsFormatted(validationResult);
        }
        catch (Exception ex)
        {
            UsernameValidatorErrors = ex.Message;
        }
    }

    private async void ValidateEmailAsync(string email)
    {
        try
        {
            using var dbContext = new SchoolDbContext();
            var userDatabase = new UserDatabase(dbContext);
            var userManager = new UserManager(userDatabase);
            var validator = new ValidNotExistsEmailValidator(userManager, _resourceManager);

            var validationResult = await validator.ValidateAsync(new User { Email = email });
            EmailValidatorErrors = ValidationErrors.GetErrorsFormatted(validationResult);
        }
        catch (Exception ex)
        {
            EmailValidatorErrors = ex.Message;
        }
    }
    #endregion
}
