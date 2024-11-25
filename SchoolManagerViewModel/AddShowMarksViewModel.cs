using SchoolManagerModel.Entities;
using SchoolManagerModel.Entities.UserModel;
using System.Collections.ObjectModel;

namespace SchoolManagerViewModel;

public class AddShowMarksViewModel
{
    #region Private fields
    #endregion

    #region Public properties
    public ObservableCollection<Subject> Subjects { get; set; } = [];
    public ObservableCollection<Student> Students { get; set; } = [];
    public bool IsSubjectSelected { get; set; } = false;
    public bool IsStudentSelected { get; set; } = false;

    public MarkViewModel Mark { get; set; } = new();
    #endregion


}
