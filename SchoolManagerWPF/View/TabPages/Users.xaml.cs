using SchoolManagerViewModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagerWPF.View.TabPages;
/// <summary>
/// Interaction logic for Users.xaml
/// </summary>
public partial class Users : UserControl
{
    public Users()
    {
        InitializeComponent();

        // Skip viewmodel initialization in designer mode (to avoid designer crash)
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
        {
            return;
        }

        var viewmodel = new FilterUsersViewModel();
        DataContext = viewmodel;
        Loaded += async (_, _) => await viewmodel.LoadAllUser();
    }
}
