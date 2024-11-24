using SchoolManagerModel.Entities;
using SchoolManagerModel.Entities.UserModel;
using SchoolManagerViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchoolManagerWPF.View;

/// <summary>
/// Interaction logic for StudentUI.xaml
/// </summary>
public partial class StudentUI : Window
{
    public StudentUI(Student student)
    {
        InitializeComponent();
        Style = (Style)FindResource(typeof(Window));
        GetViewModel2(student);
    }

    public async void GetViewModel2(Student student)
    {
        var viewmodel = new StudentMarksViewModel(student);
        viewmodel.Marks = new ObservableCollection<DetailedMarkViewModel>(await GetMarksAsync(student));
        StudentMarksControl.DataContext = viewmodel;
    }

    public async void SetViewModel(Student student)
    {
        var viewmodel = new StudentMarksViewModel(student);
        //viewmodel.Marks = new ObservableCollection<Mark>(await viewmodel.GetMarksAsync());
        StudentMarksControl.DataContext = viewmodel;
    }

    public async Task<List<DetailedMarkViewModel>> GetMarksAsync(Student student)
    {
        var marks = new List<DetailedMarkViewModel>();
        marks.Add(new DetailedMarkViewModel()
        {
            Grade = 5,
            Student = student,
            Subject = new Subject()
            {
                Class = student.Class,
                Name = "Test",
                Teacher = new Teacher() { User = student.User }
            },
            SubmitDate = DateTime.Today,
            Notes = "Test"
        });
        marks.Add(new DetailedMarkViewModel()
        {
            Grade = 1,
            Student = student,
            Subject = new Subject()
            {
                Class = student.Class,
                Name = "Test",
                Teacher = new Teacher() { User = student.User }
            },
            SubmitDate = DateTime.Today,
            Notes = "Test2"
        });

        await Task.Delay(500);
        return marks;
    }
}
