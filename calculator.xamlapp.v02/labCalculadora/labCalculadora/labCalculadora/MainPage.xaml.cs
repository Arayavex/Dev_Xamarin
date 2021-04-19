using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace labCalculadora
{
    public partial class MainPage : ContentPage
    {
        int state = 1;
        string op; //Operaciones
        double number_one, number_two; //numeros


        public MainPage()
        {
            InitializeComponent();
            BorrarNumero(this, null);
        }

        //Evento para cuando se escoje un numero
        void PressNumbero(object sender, EventArgs e)
        {
            Button button1 = (Button)sender;

            //Validacion antes de que tocar el boton
            string pressed = button1.Text;

            //si el resultado es 0 en el "text Box" entonces se necesita direccionar la calculadora a que exluya el 0 cuando se tocan botones
            if (this.showResult.Text == "0" || state < 0) //at first current state is 1
            {
                this.showResult.Text = "";

                if (state < 0)
                    state *= -1;
            }

            this.showResult.Text += pressed;

            double number;

            if (double.TryParse(this.showResult.Text, out number))
            {
                this.showResult.Text = number.ToString("N0");
                if (state == 1)
                {
                    number_one = number;
                }
                else
                {
                    number_two = number;
                }
            }
        }


        //Evento para cuando se selecciona algun operador de la calculadora
        public void CalcOperadores(object sender, EventArgs e)
        {
            state = -2;
            Button button2 = (Button)sender;
            string pressed = button2.Text;
            op = pressed;
        }

        //Metodo para limpiar el Label que muestra los numeros cuando se toca el boton "AC"
        public void BorrarNumero(object sender, EventArgs e)
        {
            number_one = 0;
            number_two = 0;
            state = 1;
            this.showResult.Text = "0";
        }

        //Metodo para calcular el resultado al tocar el boton "="
        public void CalcResultado(object sender, EventArgs e)
        {
            if (state == 2)
            {
                //Variable result que se apoya con la clase C# "OperatorHelper"
                var result = Operadores.Calcular(number_one, number_two, op);

                this.showResult.Text = result.ToString();
                number_one = (double)result;
                state = -1;
            }
        }

        //Metodo para calcular el porcentaje en la calculadora
        public void CalcPorcentaje(object sender, EventArgs e)
        {
            if ((state == -1) || (state == 1))
            {
                var result = number_one / 100; //variable number_one definida arriba
                this.showResult.Text = result.ToString();
                number_one = result;
                state = -1;
            }
        }
    }
}
