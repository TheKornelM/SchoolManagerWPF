using SchoolManagerModel.Utils;
using SchoolManagerViewModel;
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
        private AddSubjectViewModel _viewModel = new();
        public Subjects()
        {
            InitializeComponent();

            // Skip viewmodel initialization in designer mode (to avoid designer crash)
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            _viewModel = CreateViewModel();
            LoadViewModelData();
            DataContext = _viewModel;
        }

        private async void LoadViewModelData()
        {
            var task1 = _viewModel.LoadClasses();
            var task2 = _viewModel.LoadTeachers();

            await Task.WhenAll(task1, task2);
        }

        private AddSubjectViewModel CreateViewModel()
        {
            var resourceManager = UIResourceFactory.GetNewResource();
            var viewmodel = new AddSubjectViewModel();
            viewmodel.SuccessfulAdd = new Action(() => MessageBox.Show(resourceManager.GetString("SuccessfullyAdded")));
            viewmodel.FailedAdd = new Action<string>((string message) => MessageBox.Show(message));
            return viewmodel;
        }
    }
}
