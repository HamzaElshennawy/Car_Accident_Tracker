using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.


namespace Car_Accident_Tracker
{
    /// <summary>
    /// Interaction logic for AnalyzeWindow.xaml
    /// </summary>
    public partial class AnalyzeWindow : Window
    {
        public AnalyzeWindow()
        {
            InitializeComponent();

        }
        public void ConnectToDataBase()
        {
            DataTable dtAcc = new DataTable();
            DataTable dtDri = new DataTable();

            List<Driver> drivers = new List<Driver>();

//string query = "SELECT ";


            //if (!string.IsNullOrEmpty(DriverName_TB.Text))
            //{
            //    query += "";
            //}
            //if (!string.IsNullOrEmpty(DriverGender_TB.Text))
            //{

            //}


            //Drivers Table
            string connectionStringForDrivers = @"Data Source=ELSHENNAWY\SQLEXPRESS;Initial Catalog=CarsAccident;Integrated Security=True";
            SqlConnection conDri = new SqlConnection(connectionStringForDrivers);
            SqlDataAdapter dataAdapterDrivers = new SqlDataAdapter("Select * from DriverInfo", conDri);
            dataAdapterDrivers.Fill(dtDri);

            foreach (DataRow row in dtDri.Rows)
            {
                Driver TempDriver = new();

                TempDriver.DriverID = row["DriverID"].ToString();

                TempDriver.DriverName = row["DriverName"].ToString();
                TempDriver.DriverPhoneNumber = row["DriverPhoneNumber"].ToString();
                TempDriver.DriverLicensesNumber = row["DriverLicensesNumber"].ToString();
                TempDriver.LicenseDate = row["LicenseDate"].ToString();
                TempDriver.DriverAge = row["DriverAge"].ToString();
                TempDriver.DriverEmail = row["DriverEmail"].ToString();
                TempDriver.DriverGender = row["DriverGender"].ToString();

                drivers.Add(TempDriver);


            }

            //Accidents Table

            string connectionStringForAccident = @"Data Source=ELSHENNAWY\SQLEXPRESS;Initial Catalog=CarsAccident;Integrated Security=True";
            SqlConnection conAcc = new SqlConnection(connectionStringForAccident);

            SqlDataAdapter dataAdapterAccident = new SqlDataAdapter("Select  from Accident", conAcc);

            dataAdapterAccident.Fill(dtAcc);

            foreach (DataRow row in dtAcc.Rows)
            {
                string driverID;
                string _theAggrieved;

                Driver tempDriver = new();
                Driver TempDamaged = new();


                driverID = row["DriverID"].ToString();
                _theAggrieved = row["TheAggrieved"].ToString();

                bool driverFound = false;
                bool theAggrievedFound = false;

                int i = 0;

                while (driverFound == false || theAggrievedFound == false || i < drivers.Count)
                {

                    if (driverID == drivers[i].DriverID)
                    {
                        tempDriver = drivers[i];
                        driverFound = true;
                    }
                    if (drivers[i].DriverID == _theAggrieved)
                    {
                        TempDamaged = drivers[i];
                        theAggrievedFound = true;
                    }
                    i++;
                }
                Accident tempAccident = new Accident(tempDriver, TempDamaged);

                tempAccident.AccidentNumber = row["AccidentNumber"].ToString();
                tempAccident.NumberOfDeath = row["NumberOfDeath"].ToString();
                tempAccident.AccidentLocation = row["AccidentLocation"].ToString();
                tempAccident._AccidentCause = row["AccidentCause"].ToString();

                ObjectToDisplay tempObj = new ObjectToDisplay(tempAccident);
                
            }

        }

    }
}
