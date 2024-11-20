using AutoMapper;
using SchoolManagerModel.Entities;
using SchoolManagerModel.Managers;
using SchoolManagerModel.Persistence;
using SchoolManagerModel.Utils;
using SchoolManagerModel.Validators;
using SchoolManagerWPF.ViewModel.Commands;
using SchoolManagerWPF.ViewModel.EntityViewModels;
using System.Collections.ObjectModel;
using System.Resources;

namespace SchoolManagerWPF.ViewModel;

public class ClassesViewModel : ViewModelBase
{
    #region Private fields
    private ObservableCollection<ClassViewModel> _classes = [];
    private string _classYear = string.Empty;
    private string _class = string.Empty;
    private string _classValidationErrors = string.Empty;
    private string _classYearValidationErrors = string.Empty;

    #endregion

    #region Public properties
    public ObservableCollection<ClassViewModel> Classes
    {
        get => _classes;
        set
        {
            SetField(ref _classes, value, nameof(Classes));
        }
    }

    public string Class
    {
        get => _class;
        set
        {
            SetField(ref _class, value, nameof(Class));
            ClassValidationErrors = ValidationErrors.GetErrorsFormatted(new CharLetterValidator(ResourceManager).Validate(value));
            AddClassCommand.NotifyCanExecuteChanged();
        }
    }

    public string ClassYear
    {
        get => _classYear;
        set
        {
            SetField(ref _classYear, value, nameof(ClassYear));
            ClassYearValidationErrors = ValidationErrors.GetErrorsFormatted(new ClassYearStringValidator(ResourceManager).Validate(value));
            AddClassCommand.NotifyCanExecuteChanged();
        }
    }

    public string ClassValidationErrors
    {
        get => _classValidationErrors;
        set
        {
            SetField(ref _classValidationErrors, value, nameof(ClassValidationErrors));
        }
    }

    public string ClassYearValidationErrors
    {
        get => _classYearValidationErrors;
        set
        {
            SetField(ref _classYearValidationErrors, value, nameof(ClassYearValidationErrors));
        }
    }

    public ResourceManager ResourceManager { get; private set; }
    public Mapper Mapper { get; private set; }
    public Action? SuccessfulClassAdd { get; set; }
    public Action<string>? FailedClassAdd { get; set; }


    #endregion

    #region Commands
    public AddClassCommand AddClassCommand { get; set; }

    #endregion

    #region Constructor
    public ClassesViewModel(ResourceManager resourceManager)
    {
        ResourceManager = resourceManager;
        AddClassCommand = new AddClassCommand(this);
        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Class, ClassViewModel>();
            cfg.CreateMap<ClassViewModel, Class>();
        });
        Mapper = new Mapper(mapperConfiguration);

        GetClassesAsync();
    }

    #endregion

    #region Private methods
    private async void GetClassesAsync()
    {
        var dbContext = new SchoolDbContext();
        var classDatabase = new ClassDatabase(dbContext);
        var classManager = new ClassManager(classDatabase);
        var result = await classManager.GetClassesAsync();

        var mapped = new ObservableCollection<ClassViewModel>();
        foreach (var item in result)
        {
            mapped.Add(Mapper.Map<Class, ClassViewModel>(item));
        }

        _classes = mapped;
        ResetChangedStatus();
    }

    private void ResetChangedStatus()
    {
        foreach (var item in _classes)
        {
            item.IsChanged = false;
        }
    }

    #endregion
}