using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application = System.Windows.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Project_ICT_AO___Tijl_Van_Caneghem
{
    /// <summary>
    // Info about the DMX Spot used in my project:
    /// Channel 1 is DMX RED channel
    /// Channel 2 is DMX Green channel
    /// Channel 3 is DMX Blue channel
    /// Channel 4 is Master level 
    /// Channel 5 has 2 options:
    ///                         - 0 is On
    ///                         - 1 is Off
    /// Based on the slider value a string is send trough the serialPort
    /// </summary>


    public partial class MainWindow : Window
    {

        SerialPort mySerialPort = new SerialPort("com3", 9600);
        char channelCode = 'c';
        char valueCode = 'w';

        
        public MainWindow()
        {
            InitializeComponent();

            //string all100 = "4c255W";
            mySerialPort.Open();


            //redSlider.ValueChanged += redSlider_ValueChanged;
            //greenSlider.ValueChanged += greenSlider_ValueChanged;
            //blueSlider.ValueChanged += blueSlider_ValueChanged;
            //masterSlider.ValueChanged += masterSldr_ValueChanged;

            //CheckRedValueSlider();
            //CheckGreenValueSlider();
            //CheckBlueValueSlider();
            //CheckMasterValueSlider();

            redSlider.ValueChanged += CheckWhenScroll;
            greenSlider.ValueChanged += CheckWhenScroll;
            blueSlider.ValueChanged += CheckWhenScroll;
            masterSlider.ValueChanged += CheckWhenScroll;

            btnOn.Click += new RoutedEventHandler(btnOn_Click);
            btnOff.Click += new RoutedEventHandler(btnOff_Click);

        }

        //private void redSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{

        //}

        //private void greenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{

        //}

        //private void blueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{

        //}

        //private void masterSldr_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    double distanceFromMin = masterSlider.Value - masterSlider.Minimum;
        //    double sliderRange = masterSlider.Maximum - masterSlider.Minimum;
        //    double sliderPercent = 100 * (distanceFromMin / sliderRange);
        //    masterSliderLabel.Content = Convert.ToInt32(sliderPercent);
        //}
        private void CheckWhenScroll(object sender,
                               RoutedPropertyChangedEventArgs<double> e)
        {
            CheckRedValueSlider();
            CheckGreenValueSlider();
            CheckBlueValueSlider();
            CheckMasterValueSlider();

        }


        /// <summary>
        /// what is commented out, is what I tried as code, I tried a lot more but deleted it.
        /// </summary>
        private void CheckRedValueSlider()
        {
            int channel = 1;
            int redValue = Convert.ToInt32(redSlider.Value);
            string sendDMX = String.Format("{0}{1}{2}{3}", channel, channelCode, redValue, valueCode);
            //string senddmx = Convert.ToString(channel) + "c" + Convert.ToString(redValue) + "w";
            //mySerialPort.Open();
            //mySerialPort.Write(Convert.ToString(sendDMX));
            mySerialPort.Write(sendDMX);
            //mySerialPort.Close();            
        }
                
        private void CheckGreenValueSlider()
        {
            int channel = 2;
            int greenValue = Convert.ToInt32(greenSlider.Value);
            string sendDMX = String.Format("{0}{1}{2}{3}", channel, channelCode, greenValue, valueCode);
            mySerialPort.Write(sendDMX);
            }
             

        private void CheckBlueValueSlider()
        {
            int channel = 3;
            int blueValue = Convert.ToInt32(blueSlider.Value);
            string sendDMX = String.Format("{0}{1}{2}{3}", channel, channelCode, blueValue, valueCode);
            mySerialPort.Write(sendDMX);
        }

        private void CheckMasterValueSlider()
        {
            int channel = 4;
            int masterValue = Convert.ToInt32(masterSlider.Value);
            string sendDMX = String.Format("{0}{1}{2}{3}", channel, channelCode, masterValue, valueCode);
            mySerialPort.Write(sendDMX);

        }

        private void btnOn_Click(object sender, RoutedEventArgs e)
        {            
            int channel = 5;
            char buttonOnValue = '0';
            string sendDMX = String.Format("{0}{1}{2}{3}", channel, channelCode, buttonOnValue, valueCode);
            mySerialPort.Write(sendDMX);
        }

        private void btnOff_Click(object sender, RoutedEventArgs e)
        {
            int channel = 5;
            char buttonOffValue = '1';
            string sendDMX = String.Format("{0}{1}{2}{3}", channel, channelCode, buttonOffValue, valueCode);
            mySerialPort.Write(sendDMX);
        }   

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mySerialPort.Write(Convert.ToString("5c1w"));
            mySerialPort.Close();
        }

    }
}
