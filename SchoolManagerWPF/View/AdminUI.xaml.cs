using SchoolManagerModel.Entities.UserModel;
using SchoolManagerModel.Utils;
using SchoolManagerWPF.ViewModel;
using System.Resources;
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

            var resourceManager = UIResourceFactory.GetNewResource();
            Users.DataContext = getNewUserViewModel(resourceManager);
            Classes.DataContext = getNewClassesViewModel(resourceManager);
        }

        private ClassesViewModel getNewClassesViewModel(ResourceManager resourceManager)
        {
            var classesViewModel = new ClassesViewModel(resourceManager);
            classesViewModel.SuccessfulClassAdd = () =>
            {
                MessageBox.Show(resourceManager.GetString("SuccessfullyAdded"));
                Classes.DataContext = getNewClassesViewModel(resourceManager);
            };
            classesViewModel.FailedClassAdd = (string message) =>
            {
                MessageBox.Show(message);
            };
            return classesViewModel;
        }

        private AddUserViewModel getNewUserViewModel(ResourceManager resourceManager)
        {
            var vm = new AddUserViewModel(resourceManager);
            vm.SuccessfulUserAdd = new Action(() =>
            {
                PasswordField.Password = string.Empty;
                ConfirmPasswordField.Password = string.Empty;
                Users.DataContext = getNewUserViewModel(resourceManager);
                MessageBox.Show(resourceManager.GetString("SuccessfullyRegistration"));
            });
            vm.FailedUserAdd = new Action<string>((message) =>
            {
                MessageBox.Show(message);
            });

            return vm;
        }
    }
}
