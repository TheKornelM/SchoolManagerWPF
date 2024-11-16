using System.Windows;
using System.Windows.Controls;

namespace SchoolManagerWPF.View.Controls;

public partial class ValidatedPasswordField : UserControl
{
    public ValidatedPasswordField()
    {
        InitializeComponent();
    }

    // LabelContent Property
    public static readonly DependencyProperty LabelContentProperty =
        DependencyProperty.Register("LabelContent", typeof(string), typeof(ValidatedPasswordField), new PropertyMetadata(string.Empty));

    public string LabelContent
    {
        get { return (string)GetValue(LabelContentProperty); }
        set { SetValue(LabelContentProperty, value); }
    }

    // Password Property
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register("Password", typeof(string), typeof(ValidatedPasswordField), new PropertyMetadata(string.Empty));

    public string Password
    {
        get { return (string)GetValue(PasswordProperty); }
        set { SetValue(PasswordProperty, value); }
    }

    // ValidationError Property
    public static readonly DependencyProperty ValidationErrorProperty =
        DependencyProperty.Register("ValidationError", typeof(string), typeof(ValidatedPasswordField), new PropertyMetadata(string.Empty));

    public string ValidationError
    {
        get { return (string)GetValue(ValidationErrorProperty); }
        set { SetValue(ValidationErrorProperty, value); }
    }

    // Event handler for PasswordBox.PasswordChanged
    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (sender is PasswordBox passwordBox)
        {
            Password = passwordBox.Password; // Bind the PasswordBox's Password property
        }
    }
}
