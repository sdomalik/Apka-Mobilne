using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SaveCatch.Data;
using SaveCatch.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SaveCatch
{
    public partial class App : Application
    {
        private static LocalDB localDB;

        internal static LocalDB LocalDB
        {
            get
            {
                if (localDB == null)
                {
                    var fileHelper = DependencyService.Get<IFileHelper>();
                    var fileName = fileHelper.GetLocalFilePath("App.db3");
                    localDB = new LocalDB(fileName);
                }
                return localDB;
            }

        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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
