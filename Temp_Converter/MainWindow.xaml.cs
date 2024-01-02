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

namespace Temp_Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ConvertToFahrenheit_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(inputTemp.Text, out double celsius))
            {
                double fahrenheit = celsius * 9 / 5 + 32;
                outputBlock.Text = $"{fahrenheit:F2} °F";
                RecordTemperature(celsius, fahrenheit, "CtoF");
            }
        }

        private void ConvertToCelsius_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(inputTemp.Text, out double fahrenheit))
            {
                double celsius = (fahrenheit - 32) * 5 / 9;
                outputBlock.Text = $"{celsius:F2} °C";
                RecordTemperature(fahrenheit, celsius, "FtoC");
            }
        }
        private void RecordTemperature(double input, double output, string conversionType)
        {
            string filePath = "temps_recorded.txt";
            string record = $"{DateTime.Now}: {input} converted to {output} ({conversionType})\n";

            // To format the recording of the text to two decimal places, use the code below.
            //string formattedInput = input.ToString("F2");
            //string formattedOutput = output.ToString("F2");
            //string record = $"{DateTime.Now}: {formattedInput} converted to {formattedOutput} ({conversionType})\n";

            File.AppendAllText(filePath, record);
        }
    }
}
