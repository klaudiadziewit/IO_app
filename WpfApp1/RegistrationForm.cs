using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
     public class RegistrationForm
    {

        public int registrationID;
        public int personalID;
        public int date;
        public string countryName;
        public string cityName;
        public string streetName;
        public bool haveThePoliceBeenThere;
        public int policeNumberOfAccident;
        public bool isCarriageNeeded;
        public bool isReplacementCarNeeded;

 
        public RegistrationForm()
        {
           // RegistrationForm registrationForm1 = new RegistrationForm();
        }

        void ChangeRegistration(int registrationID) { }
        void DeleteRegistration(int registrationID) { }
        void SendRegistration() { }
        
    }
}
