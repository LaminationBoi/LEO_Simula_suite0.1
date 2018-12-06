using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NPlot;


namespace LEO_Simula_suite0._1
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {

        public string BatteryDirectory = @"C:\Users\Guillermo Presa\source\repos\LEO_Simula_suite0.1\LEO_Simula_suite0.1\Data\Batteries";

        public List<int> Voltage = new List<int>();
        public List<int> Capacity0 = new List<int>();
        public List<int> Capacity1 = new List<int>();
        public List<int> Capacity2 = new List<int>();
        public List<int> Capacity3 = new List<int>();

        public MainForm()
        {

            InitializeComponent();

            //Load the batteries names found in the txt in the baterry data directory
            string[] FileNames = Directory.GetFiles(BatteryDirectory, "*.txt").Select(Path.GetFileName).ToArray();

            for (int i = 0; i < FileNames.Length ; i++)
            {
                if (FileNames[i] != "Data_format.txt")
                {
                    Battery_Selector_Combo_Box.Items.Add(FileNames[i].Remove(FileNames[i].Length - 4));
                }

            }

            Battery_read_data();


        }



        //Read data from the battery data txt
        private void Battery_read_data()
        {

            string[] content = System.IO.File.ReadLines(@"C:\Users\Guillermo Presa\source\repos\LEO_Simula_suite0.1\LEO_Simula_suite0.1\Data\Batteries\Konion.txt").ToArray();
            string name = content[1].Split('"', '"')[1];
            int lenght = content.Length;
            int InternalResistance = Convert.ToInt32(content[5].Split('"', '"')[1]);
            int NomCapacity = Convert.ToInt32(content[4].Split('"', '"')[1]);           //Check whether its an int first
            int count = content[5].Split('/').Length - 1;

            for (int b = 0; b < count; b++)
            {

                for (int i = 6; i < lenght; i++)
                {
                    //Voltage.Add(Convert.ToInt32(content[b].Split('/')[0]));


                }

            }

            Voltage.Add(1);
            Voltage.Add(2);
            Voltage.Add(3);

            Capacity0.Add(3);
            Capacity0.Add(2);
            Capacity0.Add(1);

            Battery_grapher(20);


        }

        //Graphs the data of a battery with the starting and cutoff voltage.

        private void Battery_grapher(int Discharge)
        {
            string SeriesName = Discharge + "Amps";
            

            chart1.Series.Add(SeriesName);
            chart1.Series[SeriesName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[SeriesName].Points.DataBindXY(Voltage, Capacity0);

        }

        //Every time the selected battery changes, the data is re-read and the graph is updated.
        //Needed: ALL. Check if you can read the file so this does not crash. 
        private void Battery_Selector_Combo_Box_SelectedIndexChanged(object sender, EventArgs e)
        {



           
        }

    }
}
