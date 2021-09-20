using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.FirebaseAuth;
using TestHospital.ViewModels;

namespace TestHospital
{
    public partial class MainPage : ContentPage
    {
        
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LoginClass();
        }

       async void OnLoginClicked(object Sender, EventArgs e)
        {
            await MyScroll.ScrollToAsync(otpCodeSend, ScrollToPosition.End, true);
            await Shell.Current.GoToAsync(state: "//BookAppointmentPage");
            
        }

        
    }
}


