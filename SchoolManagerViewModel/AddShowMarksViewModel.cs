using SchoolManagerModel.Entities;
using SchoolManagerModel.Entities.UserModel;
using SchoolManagerModel.Managers;
using SchoolManagerModel.Persistence;
using SchoolManagerModel.Utils;
using SchoolManagerWPF.Commands;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace SchoolManagerViewModel;

public class AddShowMarksViewModel : ViewModelBase
{
    #region Private Fields
    private bool _isSubjectSelected;
    private bool _isStudentSelected;
    private ObservableCollection<int> _grades = new() { 1, 2, 3, 4, 5 };
    private Teacher _teacher;
    private ObservableCollection<Subject> _subjects = [];
    private ObservableCollection<Student> _students = [];
    #endregion

    #region Public Properties
    public ObservableCollection<Subject> Subjects { get => _subjects; set => SetField(ref _subjects, value, nameof(Subjects)); }
    public ObservableCollection<Student> Students { get => _students; set => SetField(ref _students, value, nameof(Students)); }
    public MarkViewModel Mark { get; set; } = new();
    public Action<string>? SuccessfulAdd { get; set; }
    public Action<string>? FailedAdd { get; set; }

    public bool IsSubjectSelected
    {
        get => Mark.Subject != null;
        set
        {
            _isSubjectSelected = value;
            OnPropertyChanged(nameof(IsSubjectSelected));
        }
    }

    public bool IsStudentSelected
    {
        get => Mark.Student != null;
        set
        {
            _isStudentSelected = value;
            OnPropertyChanged(nameof(IsStudentSelected));
        }
    }

    public ObservableCollection<int> Grades
    {
        get => _grades;
        set => SetField(ref _grades, value, nameof(Grades));
    }

    public ICommand AddMarkCommand { get; }
    #endregion

    #region Constructor
    public AddShowMarksViewModel(Teacher teacher)
    {
        _teacher = teacher;
        AddMarkCommand = new RelayCommand(AddMark, CanAddMark);
        Mark.Grade = 1;
        Mark.PropertyChanged += (_, e) =>
        {
            Debug.WriteLine("Changed property: " + e.PropertyName);
            if (e.PropertyName == nameof(Mark.Subject))
            {
                IsSubjectSelected = Mark.Subject != null;
                LoadStudentsAsync();
            }

            if (e.PropertyName == nameof(Mark.Student))
                IsStudentSelected = Mark.Student != null;
        };
    }
    #endregion

    #region Public methods
    public async Task LoadSubjectsAsync()
    {
        using var dbContext = new SchoolDbContext();
        var teacherDatabase = new TeacherDatabase(dbContext);
        var teacherManager = new TeacherManager(teacherDatabase);

        var result = await teacherManager.GetCurrentTaughtSubjectsAsync(_teacher);
        result.Add(new Subject()
        {
            Class = new Class(12, 'D'),
            Name = "ok",
            Teacher = new Teacher() { User = _teacher.User }
        });
        result.Add(new Subject()
        {
            Class = new Class(12, 'D'),
            Name = "ok2",
            Teacher = new Teacher() { User = _teacher.User }
        });


        Subjects = new ObservableCollection<Subject>(result);
        Mark.Subject = Subjects.FirstOrDefault();
    }

    private async void LoadStudentsAsync()
    {
        using var dbContext = new SchoolDbContext();
        var subjectsDatabase = new SubjectDatabase(dbContext);
        var subjectsManager = new SubjectManager(subjectsDatabase);

        var result = await subjectsManager.GetSubjectStudentsAsync(Mark.Subject ?? throw new NullReferenceException());

        SetField(ref _students, new ObservableCollection<Student>(result), nameof(Students));
        Mark.Student = Students.FirstOrDefault();
        Debug.WriteLine(Mark.Student?.User.Name);
    }

    #endregion

    #region Private methods
    private async void AddMark()
    {
        using var dbContext = new SchoolDbContext();
        var subjectsDatabase = new SubjectDatabase(dbContext);
        var subjectsManager = new SubjectManager(subjectsDatabase);

        var resourceManager = UIResourceFactory.GetNewResource();
        try
        {
            await subjectsManager.AddSubjectMarkAsync(new Mark()
            {
                Student = Mark.Student,
                Subject = Mark.Subject,
                Grade = Mark.Grade,
                Notes = Mark.Notes,
                SubmitDate = DateTime.Today
            });
            SuccessfulAdd?.Invoke(resourceManager.GetString("SuccessfullyAdded") ?? "Added successfully");
        }
        catch (Exception ex)
        {
            this.FailedAdd?.Invoke(ex.Message);
        }

    }

    private bool CanAddMark()
    {
        return Mark.Subject != null && Mark.Student != null;
    }

    #endregion
}
