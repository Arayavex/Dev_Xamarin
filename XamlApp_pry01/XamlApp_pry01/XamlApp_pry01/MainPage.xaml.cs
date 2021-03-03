using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlApp_pry01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Method to Change Color
        private void ChangeColor(object sender, EventArgs e)
        {
            //Declaration of variables that will store the data of the sliders
            var red = redSlider.Value; //Need to add the property Value to each Slider
            var green = greenSlider.Value;
            var blue = blueSlider.Value;

            //Declarate a varibale of type Color that contains 3 parameters 
            Color bgColor = new Color(red, green, blue);
            boxColor.BackgroundColor = bgColor;//Then the color will be setted up to the Box
            lblDisplay.Text = ColorToHex(bgColor);//Finally we display the color in the Label using method ColorToHex()
        }

        //Method ColorToHex
        private string ColorToHex(Color color)
        {
            //Declarate variables 
            int red = (int)(color.R * 255);
            int green = (int)(color.G * 255);
            int blue = (int)(color.B * 255);
            int alpha = (int)(color.A * 255);
            
            return $"#{red:X2}{green:X2}{blue:X2}{alpha:X2}";
        }

    }
}
