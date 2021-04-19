using labCalcSalarial.Model;
using Xamarin.Forms;

namespace labCalcSalarial.ModelView
{
    /*Clase que debe contener toda la logica de la aplicacion, las operaciones... (Code Behind C#)
de la app de XAML*/

    public class MainPageViewModel
    {
        public Command OperationCommand { get; set; }
        public CalcSModel calcsModel { get; set; }


        //Constructor de la clase ModelView
        public MainPageViewModel()
        {
            OperationCommand = new Command(DoOperation);

            //Inicializacion del Objeto calcsModel
            calcsModel = new CalcSModel
            {
                Salary = 0M,
                OtherSalary = 0M,
                Refund = 0M,
                Aso = 0M
            };
        }

        //Metodo que contiene toda la logica de negocio
        private void DoOperation()
        {

            //Sumatoria de todos los ingresos (Salario, Otros in
            calcsModel.TotalSalary =
                ((calcsModel.Salary + calcsModel.OtherSalary + calcsModel.Refund));

            calcsModel.SalarioGravable = calcsModel.TotalSalary;

            //Calcular la enfermedad y maternidad del %5.5
            calcsModel.EnfermedadMaternidad =
                calcsModel.TotalSalary * 0.055M;

            //Se calcula el %3.84 de la Invalidez y Muerte
            calcsModel.InvalidezMuerte =
                calcsModel.TotalSalary * 0.0384M;

            //Se calcula el %1 del BP
            calcsModel.BancoPopular =
                calcsModel.TotalSalary * 0.01M;

            //Ingresar el porcentaje de rebajo de la asociacion
            calcsModel.Association =
                (calcsModel.TotalSalary * (calcsModel.Aso / 100));

            //Se hace el calculo del Impuesto sobre la renta
            calcsModel.ImpuestoRenta = 
                calcsModel.SalarioGravable * 0.023M;

            calcsModel.TotalDeducciones =
                (calcsModel.EnfermedadMaternidad + calcsModel.InvalidezMuerte
                + calcsModel.BancoPopular + calcsModel.Association + calcsModel.ImpuestoRenta);

            calcsModel.IngresosNetos =
                calcsModel.TotalSalary - calcsModel.TotalDeducciones;

        }

        /*
        //Metodo para calcular la renta
        public decimal CalcRenta()
        {
            decimal numero1 = 1260000;
            decimal numero2 = 850000;
            var value = 0M;

            if (numero1 <= calcsModel.SalarioGravable || calcsModel.SalarioGravable >= numero2)
            {
                value = calcsModel.SalarioGravable * 0.023M;
                calcsModel.ImpuestoRenta = value;

            }
            else
            {
                value = calcsModel.SalarioGravable * 0.05M;
                calcsModel.ImpuestoRenta = value;
            }

            return calcsModel.ImpuestoRenta;
        }
        */


    }
}
