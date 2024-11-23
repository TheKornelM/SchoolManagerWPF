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
        private AddSubjectViewModel _viewModel;
        public Subjects()
        {
            InitializeComponent();

            // Skip viewmodel initialization in designer mode (to avoid designer crash)
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            _viewModel = new AddSubjectViewModel();
            this.Loaded += (s, e) => LoadSubjects();
            DataContext = _viewModel;
        }

        private async void LoadSubjects()
        {
            var task1 = _viewModel.LoadClasses();
            var task2 = _viewModel.LoadTeachers();

            await Task.WhenAll(task1, task2);
        }
    }
}
