using SchoolManagerModel.Entities;
using SchoolManagerWPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagerWPF.View.Controls
{
    public partial class CheckBoxList : UserControl
    {
        public CheckBoxList()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ObjectsProperty =
            DependencyProperty.Register(
                "Objects",
                typeof(IEnumerable<CheckBoxListItem<Subject>>),
                typeof(CheckBoxList),
                new PropertyMetadata(null, OnObjectsChanged));

        public IEnumerable<CheckBoxListItem<Subject>> Objects
        {
            get => (IEnumerable<CheckBoxListItem<Subject>>)GetValue(ObjectsProperty);
            set => SetValue(ObjectsProperty, value);
        }

        public static readonly DependencyProperty AllSubjectsSelectedProperty =
            DependencyProperty.Register(
                "AllSubjectsSelected",
                typeof(bool),
                typeof(CheckBoxList),
                new PropertyMetadata(false));

        public bool AllSubjectsSelected
        {
            get => (bool)GetValue(AllSubjectsSelectedProperty);
            set => SetValue(AllSubjectsSelectedProperty, value);
        }

        private static void OnObjectsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (CheckBoxList)d;
            control.UpdateAllSubjectsSelectedState();
        }

        private void UpdateAllSubjectsSelectedState()
        {
            if (Objects != null)
            {
                AllSubjectsSelected = Objects.All(item => item.IsChecked);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateAllSubjectsSelectedState();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateAllSubjectsSelectedState();
        }
    }
}
