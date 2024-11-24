using SchoolManagerModel.Entities;
using SchoolManagerModel.Entities.UserModel;
using SchoolManagerModel.Managers;
using SchoolManagerModel.Persistence;
using System.Collections.ObjectModel;

namespace SchoolManagerViewModel;

public class StudentMarksViewModel(Student student) : ViewModelBase
{
    #region Private fields
    private ObservableCollection<Mark> _marks = [];
    #endregion

    #region Public properties
    public ObservableCollection<Mark> Marks
    {
        get => _marks;
        set => SetField(ref _marks, value, nameof(Marks));
    }
    #endregion

    #region Constructors
    #endregion

    #region Public methods
    public async Task<List<Mark>> GetMarksAsync()
    {
        using var dbContext = new SchoolDbContext();
        var subjectDatabase = new SubjectDatabase(dbContext);
        var subjectManager = new SubjectManager(subjectDatabase);

        return await subjectManager.GetStudentMarksAsync(student);
    }
    #endregion
}
