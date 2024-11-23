using SchoolManagerViewModel.View;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagerViewModel
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
            var viewModel = new LoginViewModel();
            viewModel.FailedLogin = (error) => MessageBox.Show($"Login Failed: {error}");
            viewModel.ShowStudentInterface = (student) =>
            {
                StudentUI studentUI = new StudentUI(student);
                studentUI.Show();
                this.Close();
            };
            viewModel.ShowAdminInterface = (admin) =>
            {
                var adminUI = new AdminUI(admin);
                adminUI.Show();
                this.Close();
            };
            viewModel.ShowTeacherInterface = (teacher) =>
            {
                var teacherUI = new TeacherUI(teacher);
                teacherUI.Show();
                this.Close();
            };
            this.DataContext = viewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
        }



    }
}
