using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagerWPF.View.TabPages
{
    /// <summary>
    /// Interaction logic for Subjects.xaml
    /// </summary>
    public partial class Subjects : UserControl
    {
        public Subjects()
        {
            InitializeComponent();

            // Skip viewmodel initialization in designer mode (to avoid designer crash)
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }
        }
    }
}
