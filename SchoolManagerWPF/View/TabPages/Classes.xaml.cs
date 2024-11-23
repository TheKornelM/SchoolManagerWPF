using SchoolManagerModel.Utils;
using System.ComponentModel;
using System.Resources;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagerViewModel.View.TabPages
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

        private ClassesViewModel getNewClassesViewModel(ResourceManager resourceManager)
        {
            var classesViewModel = new ClassesViewModel(resourceManager);
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
