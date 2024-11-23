using System.Windows;
using System.Windows.Controls;

namespace SchoolManagerViewModel.View.Controls;

public partial class ValidatedField : UserControl
{
    public ValidatedField()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty LabelContentProperty =
        DependencyProperty.Register("LabelContent", typeof(string), typeof(ValidatedField), new PropertyMetadata(string.Empty));

    public string LabelContent
    {
        get { return (string)GetValue(LabelContentProperty); }
        set { SetValue(LabelContentProperty, value); }
    }

    public static readonly DependencyProperty FieldValueProperty =
        DependencyProperty.Register("FieldValue", typeof(string), typeof(ValidatedField), new PropertyMetadata(string.Empty));

    public string FieldValue
    {
        get { return (string)GetValue(FieldValueProperty); }
        set { SetValue(FieldValueProperty, value); }
    }

    public static readonly DependencyProperty ValidationErrorProperty =
        DependencyProperty.Register("ValidationError", typeof(string), typeof(ValidatedField), new PropertyMetadata(string.Empty));

    public string ValidationError
    {
        get { return (string)GetValue(ValidationErrorProperty); }
        set { SetValue(ValidationErrorProperty, value); }
    }
}
