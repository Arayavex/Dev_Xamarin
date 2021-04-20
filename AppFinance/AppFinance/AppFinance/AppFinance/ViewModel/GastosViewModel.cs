using AppFinance.Model;
using AppFinance.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFinance.ViewModel
{
    public class GastosViewModel : INotifyPropertyChanged
    {

        private GastosModel gastosmodel;

        //Botones para redireccionar a las páginas del menú
        public Command irInicio { get; set; }
        public Command irPlanear { get; set; }
        public Command irAgregar { get; set; }
        public Command irReportes { get; set; }
        public Command irAjustes { get; set; }

        //Navegación
        private INavigation Navigation;

        public GastosModel Gastosmodel
        {
            get => gastosmodel;
            set
            {
                gastosmodel = value;
                OnPropertyChanged();
            }
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public GastosViewModel(INavigation navigation)
        {
            Navigation = navigation;
            //Redireccion de botones del menú
            irInicio = new Command(async () => await NavigateToInicioView());
            //irPlanear = new Command(async () => await NavigateToPlanearView());
            irAgregar = new Command(async () => await NavigateToAgregarView());
            //irReportes = new Command(async () => await NavigateToReportesView());
            //irAjustes = new Command(async () => await NavigateToAjustesView());
        }

      

        private async Task NavigateToAgregarView()
        {
            await Navigation.PushAsync(new Agregar());
        }

        private async Task NavigateToInicioView()
        {
            await Navigation.PushAsync(new Homepage());
        }

        /*
        Metodos no funcionales

         private async Task NavigateToAjustesView()
        {
            throw new NotImplementedException();
        }

        private async Task NavigateToReportesView()
        {
            throw new NotImplementedException();
        }
        
                private async Task NavigateToPlanearView()
        {
            throw new NotImplementedException();
        }
        
        */

    }
}
