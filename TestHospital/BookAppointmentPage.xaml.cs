using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestHospital.ViewModels;
using TestHospital.Views;

namespace TestHospital
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookAppointmentPage : Shell
    {
        public BookAppointmentPage()
        {
            InitializeComponent();
            BindingContext = new LoginClass();
        }
    }
}