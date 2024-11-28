using SchoolManagerModel.Entities.UserModel;
using SchoolManagerViewModel;
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
        SetViewModel(student);
    }

    public async void SetViewModel(Student student)
    {
        var viewmodel = new StudentMarksViewModel(student);
        await viewmodel.LoadMarksAsync();
        StudentMarksControl.DataContext = viewmodel;
    }
}
