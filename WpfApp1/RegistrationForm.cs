using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class RegistrationForm
    {
        int registrationID;
        int personalID;
        DateTime date;
        string countryName;
        string cityName;
        string streetName;
        List <T> personalNumbersOfPeopleTakingPartInAccident;
        bool haveThePoliceBeenThere;
        int policeNumberOfAccident;
        bool isCarriageNeeded;
        bool isReplacementCarNeeded;

        public RegistrationForm()
        {
            RegistrationForm registrationForm1 = new RegistrationForm();
        }

        void ChangeRegistration(int registrationID) { }
        void DeleteRegistration(int registrationID) { }
        void SendRegistration() { }
        
    }
}
