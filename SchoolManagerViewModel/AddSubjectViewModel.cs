using SchoolManagerModel.Entities;
using SchoolManagerModel.Entities.UserModel;
using SchoolManagerModel.Managers;
using SchoolManagerModel.Persistence;
using SchoolManagerViewModel.Commands;
using System.Collections.ObjectModel;

namespace SchoolManagerViewModel;

public class AddSubjectViewModel : ViewModelBase
{
    #region Private fields
    private Class? _selectedClass;
    private Teacher? _selectedTeacher;

    #endregion

    #region Public properties
    public ObservableCollection<Class> Classes { get; private set; } = [];
    public ObservableCollection<Teacher> Teachers { get; private set; } = [];
    public AddSubjectCommand AddSubjectCommand { get; private set; }

    public Class? SelectedClass
    {
        get => _selectedClass;
        set
        {
            if (_selectedClass == value)
            {
                return;
            }

            SetField(ref _selectedClass, value, nameof(SelectedClass));
        }
    }

    public Teacher? SelectedTeacher
    {
        get => _selectedTeacher;
        set
        {
            if (_selectedTeacher == value)
            {
                return;
            }

            SetField(ref _selectedTeacher, value, nameof(SelectedTeacher));
        }
    }
    #endregion

    #region Constructors
    public AddSubjectViewModel()
    {
        AddSubjectCommand = new AddSubjectCommand(this);
    }
    #endregion

    #region Private methods
    #endregion

    #region Public methods
    public async Task LoadClasses()
    {
        using var dbContext = new SchoolDbContext();
        var classDatabase = new ClassDatabase(dbContext);
        var classManager = new ClassManager(classDatabase);

        Classes = new ObservableCollection<Class>(await classManager.GetClassesAsync());
    }

    public async Task LoadTeachers()
    {
        using var dbContext = new SchoolDbContext();
        var teacherDatabase = new TeacherDatabase(dbContext);
        var teacherManager = new TeacherManager(teacherDatabase);

        Teachers = new ObservableCollection<Teacher>(await teacherManager.GetTeacherUsersAsync());
    }

    #endregion
}
