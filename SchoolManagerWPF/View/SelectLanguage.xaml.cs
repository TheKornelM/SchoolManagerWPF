using SchoolManagerWPF.ViewModel;
using System.Windows;

namespace SchoolManagerWPF
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
            LanguageSelectViewModel model = new LanguageSelectViewModel();
            model.LoginShowAction = new Action(() =>
            {
                Login login = new Login();
                login.Show();
                this.Close();
            });
            this.DataContext = model;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // continueButton.Command.Execute(continueButton.CommandParameter);
            /* ResourceManager manager;
             string lang = GetLanguageCode();
             Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
             manager = new ResourceManager("SchoolManagerWF.Resources.UI",
                 Assembly.GetExecutingAssembly());
             var login = new Login();
             login.Show();
             this.Hide();
             login.Closed += (s, args) => this.Close();*/
        }
        public string GetLanguageCode()
        {
            return languageComboBox.SelectedIndex switch
            {
                0 => "hu-HU",
                _ => "en-EN"
            };
        }
    }
}