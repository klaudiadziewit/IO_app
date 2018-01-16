using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ReceivedRegistrationForm
    {
        int receivedRegistrationFormId;
        int personalID;
        DateTime date;
        string countryName;
        string cityName;
        string streetName;
        List<T> personalNumbersOfPeopleTakingPartInAccident;
        bool haveThePoliceBeenThere;
        int policeNumberOfAccident;
        bool isCarriageNeeded;
        bool isReplacementCarNeeded;

        public ReceivedRegistrationForm()
        {
            ReceivedRegistrationForm receivedRegistrationForm1 = new ReceivedRegistrationForm();
        }

        void SendBackRegistration(int receivedRegistrationID) { }
        void CancelRegistration(int receivedRegistrationID) { }
        void AcceptRegistration() { }
    }
}
