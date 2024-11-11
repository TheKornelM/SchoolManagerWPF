using SchoolManagerModel.Entities.UserModel;
using System.Windows;

namespace SchoolManagerWPF.View
{
    /// <summary>
    /// Interaction logic for StudentUI.xaml
    /// </summary>
    public partial class StudentUI : Window
    {
        public StudentUI(Student student)
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
        }
    }
}
