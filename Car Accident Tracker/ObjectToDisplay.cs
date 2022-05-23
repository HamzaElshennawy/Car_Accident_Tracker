using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Accident_Tracker
{
    public class ObjectToDisplay
    {
        public string DriverName { set; get; }
        public string DriverPhoneNumber { set; get; }
        public string DriverLicensesNumber { set; get; }

        public string LicenseDate { set; get; }
        public string DriverAge { set; get; }
        public string DriverEmail { set; get; }
        public string DriverGender { set; get; }

        public string AccidentLocation { get; set; }
        public string AccidentNumber { get; set; }


        public ObjectToDisplay(string driverName, string driverPhoneNumber, string driverLicensesNumber,
            string licenseDate, string driverAge, string driverEmail,
            string driverGender, string accidentLocation,
            string accidentNumber)
        {
            DriverName = driverName;
            DriverPhoneNumber = driverPhoneNumber;
            DriverLicensesNumber = driverLicensesNumber;
            LicenseDate = licenseDate;
            DriverAge = driverAge;
            DriverEmail = driverEmail;
            DriverGender = driverGender;
            AccidentLocation = accidentLocation;
            AccidentNumber = accidentNumber;
        }
        public ObjectToDisplay(Accident Acc)
        {
            DriverName = Acc.getAccidentDriver().DriverName;
            DriverPhoneNumber = Acc.getAccidentDriver().DriverPhoneNumber;
            DriverLicensesNumber = Acc.getAccidentDriver().DriverLicensesNumber;
            LicenseDate = Acc.getAccidentDriver().LicenseDate;
            DriverAge = Acc.getAccidentDriver().DriverAge;
            DriverEmail = Acc.getAccidentDriver().DriverEmail;
            DriverGender = Acc.getAccidentDriver().DriverGender;
            AccidentLocation = Acc.AccidentLocation;
            AccidentNumber = Acc.AccidentNumber;
        }
    }
}
