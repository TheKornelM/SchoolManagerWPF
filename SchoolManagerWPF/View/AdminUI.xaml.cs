using SchoolManagerModel.Entities.UserModel;
using SchoolManagerModel.Utils;
using SchoolManagerWPF.ViewModel;
using System.Windows;

namespace SchoolManagerWPF.View
{
    /// <summary>
    /// Interaction logic for AdminUI.xaml
    /// </summary>
    public partial class AdminUI : Window
    {
        public AdminUI(Admin admin)
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));

            // View models

            var vm = new AddUserViewModel(UIResourceFactory.GetNewResource());
            vm.SuccessfulUserAdd = new Action(() =>
            {
                PasswordField.Password = string.Empty;
                ConfirmPasswordField.Password = string.Empty;
                Users.DataContext = new AddUserViewModel(UIResourceFactory.GetNewResource());
                MessageBox.Show(UIResourceFactory.GetNewResource().GetString("SuccessfullyRegistration"));
            });
            vm.FailedUserAdd = new Action<string>((message) =>
            {
                MessageBox.Show(message);
            });
            Users.DataContext = vm;

            // ClassesViewModel

            var classesViewModel = new ClassesViewModel();
            Classes.DataContext = classesViewModel;
        }
    }
}
