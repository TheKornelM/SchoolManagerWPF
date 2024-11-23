using SchoolManagerModel.Entities.UserModel;
using System.Windows;

namespace SchoolManagerViewModel.View
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

        }
    }
}
