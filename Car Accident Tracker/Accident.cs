using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Car_Accident_Tracker
{
    public class Accident
    {
        
        public string AccidentLocation { get; set; }
        public string AccidentNumber { get; set; }
        public string NumberOfDeath {get; set; }
        List<string> AccidentCause = new List<string>(new string[] { "Drunk","No Brakes","Speeding","Using Phone","Breaking Traffic Sign"});
        public string _AccidentCause;

        Driver driver;
        Driver TheAggrieved;

        public Accident(string accidentLocation, string accidentNumber,string accidentCause ,Driver driver, Driver theAggrieved,string _numberOfDeath)
        {
            AccidentLocation = accidentLocation;
            AccidentNumber = accidentNumber;
            this.driver = driver;
            this.TheAggrieved = theAggrieved;
            if(AccidentCause.Contains(accidentCause))
            {
                this._AccidentCause = accidentCause;
            }
            else
            {
                MessageBox.Show("This is not a valid Cause!!");
            }
            this.NumberOfDeath = _numberOfDeath;
        }

        public Accident(Driver _driver, Driver theAggrieved)
        {
            this.driver = _driver;
            this.TheAggrieved = theAggrieved;
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
        public Driver getTheAggrievedName()
        {
            return TheAggrieved;
        }
    }
}
