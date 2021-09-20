using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospital.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestHospital.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentsPage : ContentPage
    {
        public AppointmentsPage()
        {
            InitializeComponent();
            BindingContext = new LoginClass();
        }

        async void OnBookHospitalTapped(object Sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ActualAppointment());
        }

        async void OnBookDoctorsTapped(Object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ActualAppointment());
        }
    }
}