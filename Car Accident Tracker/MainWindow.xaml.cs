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
        }

        List<ObjectToDisplay> AllRecords = new List<ObjectToDisplay>();
        List<Driver> DriversNames = new List<Driver>();
        List<Accident> AllAcc = new List<Accident>();
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

        }

        public void LoadAllAccidents()
        {
            AccLocation_CB.Items.Clear();
            AccLocation_CB.Items.Add("Cairo");
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


                dri.DriverName = entries[0];
                dri.DriverPhoneNumber = entries[1];
                dri.DriverLicensesNumber = entries[2];
                dri.LicenseDate = entries[3];
                dri.DriverAge = entries[4];
                dri.DriverEmail = entries[5];
                dri.DriverGender = entries[6];

                Accident Acc = new Accident(dri);
                Acc.AccidentLocation = entries[7];
                Acc.AccidentNumber = entries[8];

                ObjectToDisplay obj = new ObjectToDisplay(dri.DriverName, dri.DriverPhoneNumber, dri.DriverLicensesNumber, dri.LicenseDate, dri.DriverAge, dri.DriverEmail
                    , dri.DriverGender, Acc.AccidentLocation, Acc.AccidentNumber);
                ObjectToDisplay obj2 = new ObjectToDisplay(Acc);
                //DataGridXaml.Items.Add(obj);
                AllRecords.Add(obj2);
                AllAcc.Add(Acc);
                
            }
        }
        public void ReadDrivers()
        {
            Driver TempDriver = new();
            Accident TempAcc = new(TempDriver);
            string TempDriverName;
            List<string> Names = new List<string>();


            for(int i=0;i<AllRecords.Count;i++)
            {
                TempAcc = AllAcc[i];
                TempDriverName = TempAcc.getAccidentDriver().DriverName;
                if(!Names.Contains(TempDriverName))
                {
                    Names.Add(TempDriverName);
                    DriverName_CB.Items.Add(TempDriverName);
                }
            }
            DriversNames.Add(TempDriver);
            
        }
    }
}
