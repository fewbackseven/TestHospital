using System;
using Xamarin.Forms;
using Plugin.FirebaseAuth;
using Xamarin.Forms.Xaml;
using TestHospital.Views;
using TestHospital.ViewModels;

namespace TestHospital
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LoginClass ln = new LoginClass();

            if(ln.IsLoggedIn==true)
                

            MainPage = new BookAppointmentPage();

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
