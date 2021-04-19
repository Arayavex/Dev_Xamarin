using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace labCalcSalarial.Model
{
    public class CalcSModel : INotifyPropertyChanged
    {
        private decimal totalSalary;
        private decimal enfermedadMaternidad;
        private decimal invalidezMuerte;
        private decimal bancoPopular;
        private decimal association;
        private decimal salarioGravable;
        private decimal impuestoRenta;
        private decimal totalDeducciones;
        private decimal ingresosNetos;

        //Metodo aparte


        //Metodo para Label 'Salario Bruto y Comisiones' (Sugerencia)
        public decimal Salary { get; set; }

        //Metodo para el Label 'Ingresos salariales ocasionales' (Sugerencia)
        public decimal OtherSalary { get; set; }

        //Metodo para el Label 'Reembolso de gastos no salariales ni gravables' (Sugerencia)
        public decimal Refund { get; set; }

        //Dato por defecto de la asosiacion
        public decimal Aso { get; set; }

        //Plan de pensiones Complementarias (sugerencia)
        public decimal PensionesComplementarias { get; set; }

        //Dato de Total Ingresos Laborales 
        public decimal TotalSalary
        {
            get { return totalSalary; }

            set
            {
                totalSalary = value;
                OnPropertyChanged();
            }
        }

        //Dato de enfermedad y maternidad del %5.5
        public decimal EnfermedadMaternidad
        {
            get { return enfermedadMaternidad; }
            set
            {
                enfermedadMaternidad = value;
                OnPropertyChanged();
            }
        }

        //Dato para invalidez y muerte del %3.84
        public decimal InvalidezMuerte
        {
            get { return invalidezMuerte; }

            set
            {
                invalidezMuerte = value;
                OnPropertyChanged();
            }
        }

        // Dato Aporte Trabajador Banco Popular %1
        public decimal BancoPopular
        {
            get { return bancoPopular; }

            set
            {
                bancoPopular = value;
                OnPropertyChanged();
            }
        }

        //Metodo para el Label 'Asosiacion Solidarista'
        public decimal Association
        {
            get { return association; }
            set
            {
                association = value;
                OnPropertyChanged();
            }
        }

        //Dato de Salario Gravable
        public decimal SalarioGravable
        {
            get { return salarioGravable; }
            set
            {
                salarioGravable = value;
                OnPropertyChanged();
            }
        }

        //Dato de Impuestos sobre la Renta empleados
        public decimal ImpuestoRenta
        {
            get { return impuestoRenta; }
            set
            {
                impuestoRenta = value;
                OnPropertyChanged();
            }
        }

        //Dato de Total de Deducciones
        public decimal TotalDeducciones
        {
            get { return totalDeducciones; ; }

            set
            {
                totalDeducciones = value;
                OnPropertyChanged();
            }
        }

        //Dato de ingresos netos
        public decimal IngresosNetos 
        {
            get { return ingresosNetos; }
            
            set
            {
                ingresosNetos = value;
                OnPropertyChanged();
            }
        }



        #region Implementación
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

