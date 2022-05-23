using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;




namespace Car_Accident_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadAllAccidents();
            ReadData();
            DisplayFirstTenRows();
            ReadDrivers();
            ReadLocations();
            ReadAccidentsNumbers();
        }

        List<ObjectToDisplay> AllRecords = new List<ObjectToDisplay>();
        List<Driver> DriversNames = new List<Driver>();
        List<Accident> AllAcc = new List<Accident>();
        List<string> AllLocations = new List<string>();
        private void DisplayAllBTN_Click(object sender, RoutedEventArgs e)
        {
            ReadData();
            DataGridXaml.Items.Clear();
            for (int i = 0; i < AllRecords.Count; i++)
            {
                DataGridXaml.Items.Add(AllRecords[i]);
            }
        }

        
        
        private void SearchBTN_Click(object sender, RoutedEventArgs e)
        {
            //SearchByLocation();
            //SearchByDriverName();
            //SearchByAccidentNumber();
            //SearchByDriverGender();
            //SearchByNumberOfDeath();
            SearchByAccidentCause();
        }

        public void LoadAllAccidents()
        {
            AccLocation_TB.Text = "";

        }
        
        public void DisplayFirstTenRows()
        {
            DataGridXaml.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                DataGridXaml.Items.Add(AllRecords[i]);
            }
        }

        public void ReadData()
        {
            string filePath = "Data.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();
            
            
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                Driver dri = new Driver();
                Driver Aggrieved = new();

                dri.DriverName = entries[0];
                dri.DriverPhoneNumber = entries[1];
                dri.DriverLicensesNumber = entries[2];
                dri.LicenseDate = entries[3];
                dri.DriverAge = entries[4];
                dri.DriverEmail = entries[5];
                dri.DriverGender = entries[6];
                Aggrieved.DriverName = entries[11];

                
                Accident Acc = new Accident(dri,Aggrieved);
                Acc.AccidentLocation = entries[7];
                Acc.AccidentNumber = entries[8];
                Acc.NumberOfDeath = entries[9];
                Acc._AccidentCause = entries[10];
                

                ObjectToDisplay obj2 = new ObjectToDisplay(Acc);
                AllRecords.Add(obj2);
                AllAcc.Add(Acc);
            }
           
        }
        public void ReadDrivers()
        {
            Driver TempDriver = new();
            Driver TempAggrieved = new();
            Accident TempAcc = new(TempDriver,TempAggrieved);
            string TempDriverName;
            List<string> Names = new List<string>();


            for(int i=0;i<AllRecords.Count;i++)
            {
                TempAcc = AllAcc[i];
                TempDriverName = TempAcc.getAccidentDriver().DriverName;
                if(!Names.Contains(TempDriverName))
                {
                    Names.Add(TempDriverName);
                    //DriverName_CB.Items.Add(TempDriverName);
                }
            }
            DriversNames.Add(TempDriver);
            //DriverName_CB.ItemsSource = Names;
        }

        
        
        public void ReadLocations()
        {
            Driver TempDriver = new();
            Driver TempAggrieved = new();
            Accident TempAcc = new(TempDriver,TempAggrieved);
            string TempLocation;
            List<string> Locations = new List<string>();


            for (int i = 0; i < AllRecords.Count; i++)
            {
                TempAcc = AllAcc[i];
                TempLocation = TempAcc.getAccidentLocation();
                if (!Locations.Contains(TempLocation))
                {
                    Locations.Add(TempLocation);
                    //DriverName_CB.Items.Add(TempDriverName);
                }
            }
            //AccLocation_TB.Text = Locations;
        }
        public void ReadAccidentsNumbers()
        {
            Driver TempDriver = new();
            Driver TempAggrieved = new();
            Accident TempAcc = new(TempDriver, TempAggrieved);
            string TempAccidentNumber;
            List<string> Accidents = new List<string>();


            for (int i = 0; i < AllRecords.Count; i++)
            {
                TempAcc = AllAcc[i];
                TempAccidentNumber = TempAcc.getAccidentNumber();
                if (!Accidents.Contains(TempAccidentNumber))
                {
                    Accidents.Add(TempAccidentNumber);
                    //DriverName_CB.Items.Add(TempDriverName);
                }
            }
            //AccNumber_TB.Text = Accidents;
        }
        public void SearchByLocation()
        {
            string LocationName = AccLocation_TB.Text;

            Driver TempDriver = new();
            Driver TempTheAggrieved = new();
            Accident TempAcc = new Accident(TempDriver,TempTheAggrieved);
            List<Accident> TempAccLocations_Obj = new List<Accident>();
            DataGridXaml.Items.Clear();
            for(int i=0;i<AllRecords.Count;i++)
            {
                TempAcc = AllAcc[i];
                if(TempAcc.getAccidentLocation() == LocationName)
                {
                    TempAccLocations_Obj.Add(TempAcc);
                    ObjectToDisplay TempDisplayObj = new ObjectToDisplay(TempAcc);
                    DataGridXaml.Items.Add(TempDisplayObj);
                }
            }
        }
        public void SearchByDriverName()
        {
            string Driver_Name = DriverName_TB.Text;

            Driver TempDriver = new();
            Driver TempAggrieved = new();
            Accident TempAcc = new Accident(TempDriver, TempAggrieved);
            List<Accident> TempDriverName_Obj = new List<Accident>();
            DataGridXaml.Items.Clear();
            for (int i = 0; i < AllRecords.Count; i++)
            {
                TempAcc = AllAcc[i];
                if (TempAcc.getAccidentDriver().DriverName == Driver_Name)
                {
                    TempDriverName_Obj.Add(TempAcc);
                    ObjectToDisplay TempDisplayObj = new ObjectToDisplay(TempAcc);
                    DataGridXaml.Items.Add(TempDisplayObj);
                }
            }
        }

        public void SearchByAccidentNumber()
        {
            string Accident_Number = AccNumber_TB.Text;

            Driver TempDriver = new();
            Driver TempAggrieved = new();
            Accident TempAcc = new Accident(TempDriver, TempAggrieved);
            //List<Accident> TempDriverName_Obj = new List<Accident>();
            DataGridXaml.Items.Clear();
            for (int i = 0; i < AllRecords.Count; i++)
            {
                TempAcc = AllAcc[i];
                if (TempAcc.getAccidentNumber() == Accident_Number)
                {
                    //TempDriverName_Obj.Add(TempAcc);
                    ObjectToDisplay TempDisplayObj = new ObjectToDisplay(TempAcc);
                    DataGridXaml.Items.Add(TempDisplayObj);
                    break;
                }
            }
        }

        public void SearchByDriverGender()
        {
            string _DriverGender = DriverGender_TB.Text;

            Driver TempDriver = new();
            Driver TempAggrieved = new();
            Accident TempAcc = new Accident(TempDriver, TempAggrieved);
            DataGridXaml.Items.Clear();
            for (int i = 0; i < AllRecords.Count; i++)
            {
                TempAcc = AllAcc[i];
                if (TempAcc.getAccidentDriver().DriverGender == _DriverGender)
                {
                    //TempDriverName_Obj.Add(TempAcc);
                    ObjectToDisplay TempDisplayObj = new ObjectToDisplay(TempAcc);
                    DataGridXaml.Items.Add(TempDisplayObj);
                }
            }
        }

        public void SearchByNumberOfDeath()
        {
            string _NumberOfDeath = NumberOfDeath_TB.Text;

            Driver TempDriver = new();
            Driver TempAggrieved = new();
            Accident TempAcc = new Accident(TempDriver, TempAggrieved);
            DataGridXaml.Items.Clear();
            for (int i = 0; i < AllRecords.Count; i++)
            {
                TempAcc = AllAcc[i];
                if (TempAcc.NumberOfDeath == _NumberOfDeath)
                {
                    //TempDriverName_Obj.Add(TempAcc);
                    ObjectToDisplay TempDisplayObj = new ObjectToDisplay(TempAcc);
                    DataGridXaml.Items.Add(TempDisplayObj);
                }
            }
        }
        public void SearchByAccidentCause()
        {
            string _AccidentCause = AccidentCause_TB.Text;

            Driver TempDriver = new();
            Driver TempAggrieved = new();
            Accident TempAcc = new Accident(TempDriver, TempAggrieved);
            DataGridXaml.Items.Clear();
            for (int i = 0; i < AllRecords.Count; i++)
            {
                TempAcc = AllAcc[i];
                if (TempAcc._AccidentCause == _AccidentCause)
                {
                    //TempDriverName_Obj.Add(TempAcc);
                    ObjectToDisplay TempDisplayObj = new ObjectToDisplay(TempAcc);
                    DataGridXaml.Items.Add(TempDisplayObj);
                }
            }
        }

        private void DriverName_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                SearchByDriverName();
            }
        }

        private void AccNumber_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchByAccidentNumber();
            }
        }

        private void AccLocation_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchByLocation();
            }
        }

        private void DriverGender_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchByDriverGender();
            }
        }

        private void NumberOfDeath_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchByNumberOfDeath();
            }
        }

        private void AccidentCause_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchByAccidentCause();
            }
        }
    }
}
