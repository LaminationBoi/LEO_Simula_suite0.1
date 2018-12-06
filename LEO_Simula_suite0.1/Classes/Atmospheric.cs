using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LEO_Simula_suite0._1
{
    public class Atmosphere
    {

        public int layer;
        public double Gravity = 9.80065;
        public int GasConstant = 287;
        public double pressure;
        List<int> LayersHeight = new List<int> { 0, 11000, 20000, 32000, 47000, 51000, 71000, 86000, 86000 };
        List<double> LayersA = new List<double> { -0.0065, 0, 0.0010, 0.0028, 0, -0.0028, -0.002, -0.002 };
        List<double> LayersPressure = new List<double> { 101325, 22632, 5474.9, 868.02, 110.91, 66.939, 3.9564, 0.3734 };
        List<double> LayersTemperature = new List<double> { 288.15, 216.65, 216.65, 228.65, 270.65, 270.65, 214.65, 186.87 };
        List<double> LayersDensity = new List<double> { 1.225, 0.3639, 0.0880, 0.0132, 0.0020 };

        public int GetLayerWithAltitude(double targetaltitude, string units)
        {

            if (units != "m")
            {
                if (units == "ft")
                {
                    targetaltitude = 0.3048 * targetaltitude;
                }
                else if (units == "FL")
                {
                    targetaltitude = 100 * targetaltitude;
                }
                else
                {
                    targetaltitude = 0;
                }

            }

            layer = -1;

            foreach (var height in LayersHeight)
            {
                if (height < targetaltitude)
                {
                    layer = layer + 1;
                }
            }

            return layer;

        }

        public double PressureAtAltitude(float targetaltitude, string units)
        {

            layer = GetLayerWithAltitude(targetaltitude, units);
            if (LayersA[layer] != 0.0)
            {
                ///pressure = LayersPressure[layer] * ((LayersTemperature[layer] + LayersA[layer] * targetaltitude - LayersHeight[layer]) / LayersTemperature[layer]) ^ (-Gravity /(LayersA[layer] * GasConstant) - 1));
                pressure = 5;
            }

            return pressure;

        }



    }







}

