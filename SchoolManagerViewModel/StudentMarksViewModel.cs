using SchoolManagerModel.Entities.UserModel;
using SchoolManagerModel.Managers;
using SchoolManagerModel.Persistence;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SchoolManagerViewModel;

public class StudentMarksViewModel(Student student) : ViewModelBase
{
    #region Private fields
    private ObservableCollection<DetailedMarkViewModel> _marks = [];
    #endregion

    #region Public properties
    public ObservableCollection<DetailedMarkViewModel> Marks
    {
        get => _marks;
        set => SetField(ref _marks, value, nameof(Marks));
    }
    #endregion

    #region Constructors
    #endregion

    #region Public methods
    public async Task LoadMarksAsync()
    {
        using var dbContext = new SchoolDbContext();
        var subjectDatabase = new SubjectDatabase(dbContext);
        var subjectManager = new SubjectManager(subjectDatabase);

        var result = await subjectManager.GetStudentMarksAsync(student);

        _marks.Clear();

        foreach (var mark in result)
        {
            _marks.Add(new DetailedMarkViewModel()
            {
                Student = mark.Student,
                Subject = mark.Subject,
                SubmitDate = mark.SubmitDate,
                Grade = mark.Grade,
                Notes = mark.Notes,
            });
            Debug.WriteLine(mark.Subject.Teacher.User.Name);
        }


        //SetField(_marks, new ObservableCollection<Mark>(result), nameof(Marks));
    }
    #endregion
}
