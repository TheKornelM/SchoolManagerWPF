using System.Windows;
using System.Windows.Controls;

namespace SchoolManagerViewModel.View.Controls;

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

    public static readonly DependencyProperty ResetPasswordProperty =
    DependencyProperty.Register("ResetPassword", typeof(bool), typeof(ValidatedPasswordField),
        new PropertyMetadata(false, OnResetPasswordChanged));

    public bool ResetPassword
    {
        get { return (bool)GetValue(ResetPasswordProperty); }
        set { SetValue(ResetPasswordProperty, value); }
    }

    // Handle ResetPassword property change
    private static void OnResetPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is ValidatedPasswordField validatedPasswordField && (bool)e.NewValue)
        {
            validatedPasswordField.ResetPasswordBox();
        }
    }

    // Method to clear the PasswordBox
    private void ResetPasswordBox()
    {
        this.PasswordField.Clear();
        Password = string.Empty; // Reset SecurePassword
        ResetPassword = false; // Reset the flag after clearing
    }
}
