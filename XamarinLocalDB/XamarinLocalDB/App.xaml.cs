using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using XamarinLocalDB.DataServices;

namespace XamarinLocalDB
{
    public partial class App : Application
    {
        private string dbpath = Path.Combine(FileSystem.AppDataDirectory, "userSQLiteDb.db3"); 
        public static ProductDatabaseController ProductDbController { get; private set; }
        public App()
        {
            InitializeComponent();

            ProductDbController = new ProductDatabaseController(dbpath);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
