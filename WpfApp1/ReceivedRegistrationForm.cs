using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ReceivedRegistrationForm
    {
        public int receivedRegistrationFormId;
        public int personalID;
        public DateTime date;
        public string countryName;
        public string cityName;
        public string streetName;
        public bool haveThePoliceBeenThere;
        public int policeNumberOfAccident;
        public bool isCarriageNeeded;
        public bool isReplacementCarNeeded;
        public string status;

        public ReceivedRegistrationForm()
        {
            //ReceivedRegistrationForm receivedRegistrationForm1 = new ReceivedRegistrationForm();
        }

        void SendBackRegistration(int receivedRegistrationID) { }
        void CancelRegistration(int receivedRegistrationID) { }
        void AcceptRegistration() { }
    }
}
