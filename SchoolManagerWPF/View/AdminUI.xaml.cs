using SchoolManagerModel.Entities.UserModel;
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
            MessageBox.Show(admin.User.Username);
        }
    }
}
