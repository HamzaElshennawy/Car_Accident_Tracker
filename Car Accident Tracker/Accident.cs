using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Accident_Tracker
{
    public class Accident
    {
        
        public string AccidentLocation { get; set; }
        public string AccidentNumber { get; set; }
        

        Driver driver;

        public Accident(string accidentLocation, string accidentNumber, Driver driver)
        {
            AccidentLocation = accidentLocation;
            AccidentNumber = accidentNumber;
            this.driver = driver;
            
        }

        public Accident(Driver _driver)
        {
            driver = _driver;
        }

        public string getAccidentLocation()
        {
            return AccidentLocation;
        }
        public string getAccidentNumber()
        {
            return AccidentNumber;
        }
        public Driver getAccidentDriver()
        {
            return driver;
        }
    }
}
