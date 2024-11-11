using SchoolManagerModel.Persistence;
using System.Windows;

namespace SchoolManagerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var dbContext = new SchoolDbContext();
            dbContext.Database.EnsureCreated();
        }
    }

}
