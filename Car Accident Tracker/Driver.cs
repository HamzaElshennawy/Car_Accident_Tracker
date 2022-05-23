using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Accident_Tracker
{
    public class Driver
    {
        static string DriverID;
        public string DriverName { set; get;}
        public string DriverPhoneNumber { set; get; }
        public string DriverLicensesNumber { set; get; }

        public string LicenseDate { set; get; }
        public string DriverAge { set; get; }
        public string DriverEmail { set; get; }
        public string DriverGender { set; get; }

        public Driver(string driverName, 
            string driverPhoneNumber, string driverLicensesNumber, string licenseDate, 
            string driverAge, string driverEmail, string driverGender)
        {
            DriverName = driverName;
            DriverPhoneNumber = driverPhoneNumber;
            DriverLicensesNumber = driverLicensesNumber;
            LicenseDate = licenseDate;
            DriverAge = driverAge;
            DriverEmail = driverEmail;
            DriverGender = driverGender;
        }

        public Driver()
        {
        }

        public string getDriverName()
        { return DriverName; }

        public string getPhoneNumber()
        { return DriverPhoneNumber; }

        public string getLicensesNumber()
        { return DriverLicensesNumber; }
        public string getLicenseDate()
        { return LicenseDate.ToString(); }

        public string getDriverAge()
        { return DriverAge; }

        public string getDriverEmail()
        { return DriverEmail; }

        public string getDriverGender()
        { return DriverGender; }


    }
}
