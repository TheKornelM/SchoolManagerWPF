using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows;

namespace SchoolManagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("hu-HU");
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ResourceManager manager;
            string lang = GetLanguageCode();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            manager = new ResourceManager("SchoolManagerWF.Resources.UI",
                Assembly.GetExecutingAssembly());
            var login = new Login();
            login.Show();
            this.Hide();
            login.Closed += (s, args) => this.Close();
        }
        public string GetLanguageCode()
        {
            return languageComboBox.SelectedIndex switch
            {
                1 => "hu-HU",
                _ => "en-EN"
            };
        }

        private void languageComboBox_SelectedIndexChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (languageComboBox.SelectedIndex)
            {
                case 1:
                    continueButton.Content = "Tovább";
                    break;
                case 2:
                    continueButton.Content = "Continue";
                    break;
            }

            //  continueButton.IsEnabled = languageComboBox.SelectedIndex != 0;
        }
    }



}