using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestHospital.ViewModels;

namespace TestHospital.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualAppointment : ContentPage
    {
        public ActualAppointment()
        {
            InitializeComponent();
            BindingContext = new ActualAppointmentViewModel();
        }
    }
}