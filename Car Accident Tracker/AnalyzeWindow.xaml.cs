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
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace Car_Accident_Tracker
{
    /// <summary>
    /// Interaction logic for AnalyzeWindow.xaml
    /// </summary>
    public partial class AnalyzeWindow : Window
    {
        //public class driver
        //{
        //    public string Name { get; set; }
        //    public int Share { get; set; }
        //}
        class DriverCollection : System.Collections.ObjectModel.Collection<Driver>
        {
            public DriverCollection()
            {
                Add(new Driver { DriverName = "Mango", DriverAge = "10" });
                Add(new Driver { DriverName = "Mango", DriverAge = "10" });
                Add(new Driver { DriverName = "Mango", DriverAge = "10" });
                
            }
        }
        public AnalyzeWindow()
        {
            InitializeComponent();
            PointLabel = chartPoint =>
                    string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            var Gender = "Hamza";
            

            DataContext = this;
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        private void Chart1_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
