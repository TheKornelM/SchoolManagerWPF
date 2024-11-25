using SchoolManagerModel.Entities.UserModel;
using SchoolManagerViewModel;
using System.Windows;

namespace SchoolManagerWPF.View
{
    /// <summary>
    /// Interaction logic for TeacherUI.xaml
    /// </summary>
    public partial class TeacherUI : Window
    {
        public TeacherUI(Teacher teacher)
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
            SetViewModel(teacher);
        }

        public async void SetViewModel(Teacher teacher)
        {
            var viewmodel = new AddShowMarksViewModel(teacher);
            await viewmodel.LoadSubjectsAsync();
            viewmodel.SuccessfulAdd = ((string message) => MessageBox.Show(message));
            viewmodel.FailedAdd = ((string message) => MessageBox.Show(message));
            AddShowMarksControl.DataContext = viewmodel;
        }
    }
}
