using SchoolManagerViewModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagerWPF.View.TabPages;

/// <summary>
/// Interaction logic for Roster.xaml
/// </summary>
public partial class Roster : UserControl
{
    public Roster()
    {
        InitializeComponent();

        // Skip viewmodel initialization in designer mode (to avoid designer crash)
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
        {
            return;
        }

        RosterGrid.DataContext = new RosterViewModel();
    }
}
