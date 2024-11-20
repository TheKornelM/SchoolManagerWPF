using SchoolManagerModel.Utils;
using SchoolManagerWPF.ViewModel;
using System.ComponentModel;
using System.Resources;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagerWPF.View.TabPages
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : UserControl
    {
        public AddUser()
        {
            InitializeComponent();

            // Skip viewmodel initialization in designer mode (to avoid designer crash)
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            var resourceManager = UIResourceFactory.GetNewResource();
            Users.DataContext = getNewUserViewModel(resourceManager);
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
