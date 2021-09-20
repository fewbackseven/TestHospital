using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Plugin.FirebaseAuth;
using Xamarin.Forms;
using TestHospital.Services;
using System.Linq;

namespace TestHospital.ViewModels
{
    public class LoginClass : BaseViewModel
    { 
        public AsyncCommand GetRegistered { get; }
        public AsyncCommand VerifyOTPCommand { get; }
        private string _nameDetails, _emailId, _phoneNumber, _verificationId, _OTPrecieved;
        private bool _isOTPtextvisible, _isOTPsendVisible, _isLoggedIn;

        public LoginClass()
        {
            GetRegistered = new AsyncCommand(SendOTP);
            VerifyOTPCommand = new AsyncCommand(VerifyOTP);
            CheckLoggedUser();

        }

        
        private async void CheckLoggedUser()
        {
            LoginService getUser = new LoginService();
            //List<User> user  = new List<User>();

            var user = await getUser.GetAllUser();
            var id= user.Count();


            if (id == null || id == 0)
            {
                _isLoggedIn = false;
                OnPropertyChanged("IsLoggedIn");
            }
            else
            {
                _isLoggedIn = true;
                var user1 = await getUser.GetUser(1);
                _nameDetails = user1.FullName;
                OnPropertyChanged("FullNameDetails");
                OnPropertyChanged("IsLoggedIn");

            }
        }
        
        
        public string OTPCode
        { get { return _OTPrecieved; }
            set
            {
                if (_OTPrecieved != value)
                    _OTPrecieved = value;
                OnPropertyChanged("OTPCode");
            }
        }

        public bool IsLoggedIn
        {
            get {return !_isLoggedIn; }
            set
            {                
                if (_isLoggedIn != value)
                    _isLoggedIn = value;
            }

        }
        public string FullNameDetails
        {
            get { return _nameDetails; }
            set
            {
                if (value != _nameDetails)
                    _nameDetails = value;
                OnPropertyChanged("FullNameDetails");
            }
        }

        public string EmailIdDetails
        {
            get { return _emailId; }
            set
            {
                if (value != _emailId)
                    _emailId = value;
                OnPropertyChanged("EmailIdDetails");
            }
        }

        public string PhoneNumberDetails
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                    _phoneNumber = value;
                OnPropertyChanged("PhoneNumberDetails");
            }
        }

        

        public bool IsOtpenabled
        {
            get { return _isOTPtextvisible; }
            set
            {
                if (_isOTPtextvisible != value)
                    _isOTPtextvisible = value;
            }
         }

        public bool IsBtnOTPenabled
        {
            get { return _isOTPsendVisible; }
            set
            {
                if (_isOTPsendVisible != value)
                    _isOTPsendVisible = value;
            }
        }

        
        async Task SendOTP()
        {
            try
            {
                // var verificationResult = await CrossFirebaseAuth.Current.PhoneAuthProvider.VerifyPhoneNumberAsync(PhoneNumberDetails);
                //_verificationId = verificationResult.VerificationId;
                //await Task.Delay(1000);
                _isOTPsendVisible = true;
                _isOTPtextvisible = true;
                OnPropertyChanged("IsBtnOTPenabled");
                OnPropertyChanged("IsOtpenabled");
                
            }
            catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Some Error!",e.Message.ToString(), "okay");
            }
        }

        
        async Task VerifyOTP()
        {
            try
            {
                //var credential = CrossFirebaseAuth.Current.PhoneAuthProvider.GetCredential(_verificationId, OTPCode);
                //var result = await CrossFirebaseAuth.Current.Instance.SignInWithCredentialAsync(credential);
                LoginService _user = new LoginService();
                await _user.AddUser(FullNameDetails, EmailIdDetails, PhoneNumberDetails);
            }
            catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Some Error!", e.Message.ToString(), "okay");
            }
        }
       

    }
}
