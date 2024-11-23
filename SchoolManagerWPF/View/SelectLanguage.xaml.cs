using System.Windows;

namespace SchoolManagerViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SelectLanguage : Window
    {
        public SelectLanguage()
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("hu-HU");
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
            var model = new LanguageSelectViewModel();
            model.LoginShowAction = new Action(() =>
            {
                Login login = new Login();
                login.Show();
                this.Close();
            });
            this.DataContext = model;
        }

    }
}