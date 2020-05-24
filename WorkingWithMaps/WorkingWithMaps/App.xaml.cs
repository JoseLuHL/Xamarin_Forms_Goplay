using Plugin.SharedTransitions;
using PropertyApp;
using System;
using System.IO;
using Xamarin.Forms;
using XamarinSQLite;

namespace WorkingWithMaps
{
    public partial class App : Application
    {

        static SQLiteHelper db;
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new MainPageMapa());
            MainPage = new SharedTransitionNavigationPage(new MainPage());
        }
        public static SQLiteHelper SQLiteDb
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinSQLite.db3"));
                }
                return db;
            }
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
