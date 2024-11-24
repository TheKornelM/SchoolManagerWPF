using SchoolManagerModel.Utils;
using SchoolManagerViewModel;
using System.ComponentModel;
using System.Resources;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagerWPF.View.TabPages
{
    /// <summary>
    /// Interaction logic for Classes.xaml
    /// </summary>
    public partial class Classes : UserControl
    {
        public Classes()
        {
            InitializeComponent();

            // Skip viewmodel initialization in designer mode (to avoid designer crash)
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            var resourceManager = UIResourceFactory.GetNewResource();
            ClassesGrid.DataContext = getNewClassesViewModel(resourceManager);
        }

        private AdminClassesViewModel getNewClassesViewModel(ResourceManager resourceManager)
        {
            var classesViewModel = new AdminClassesViewModel(resourceManager);
            classesViewModel.SuccessfulClassAdd = () =>
            {
                MessageBox.Show(resourceManager.GetString("SuccessfullyAdded"));
                ClassesGrid.DataContext = getNewClassesViewModel(resourceManager);
            };
            classesViewModel.FailedClassAdd = (string message) =>
            {
                MessageBox.Show(message);
            };
            return classesViewModel;
        }
    }
}
