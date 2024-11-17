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
                MessageBox.Show(UIResourceFactory.GetNewResource().GetString("SuccessfullyRegistration"));
            });
            Users.DataContext = vm;
        }
    }
}
