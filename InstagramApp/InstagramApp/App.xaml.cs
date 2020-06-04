using InstagramApp.Data;
using InstagramApp.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace InstagramApp
{
    public partial class App : Application
    {
        static ApplicationDatabase _dbContext;
        public static ApplicationDatabase dbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new ApplicationDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3"));
                }
                return _dbContext;
            }
        }


        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new LogInPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
