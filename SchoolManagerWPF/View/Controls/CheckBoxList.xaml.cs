using SchoolManagerModel.Entities;
using SchoolManagerWPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagerWPF.View.Controls;

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
            new PropertyMetadata(null));


    public IEnumerable<CheckBoxListItem<Subject>> Objects
    {
        get => (IEnumerable<CheckBoxListItem<Subject>>)GetValue(ObjectsProperty);
        set => SetValue(ObjectsProperty, value);
    }
}
