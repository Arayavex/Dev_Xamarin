using AppFinance.Model;
using AppFinance.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFinance.ViewModel
{
    public class AgregarViewModel : INotifyPropertyChanged
    {
            private AgregarModel agregarmodel;

            //Comandos de botones para ir a la página de entrante y gastos
            public Command irEntrante { get; set; }
            public Command irGastos { get; set; }

            public Command irLogin { get; set; }

            //Botones para redireccionar a las páginas del menú
            public Command irInicio { get; set; }
            public Command irPlanear { get; set; }
            public Command irAgregar { get; set; }
            public Command irReportes { get; set; }
            public Command irAjustes { get; set; }

            //Navegación
            private INavigation Navigation;

            public AgregarModel Agregarmodel
            {
                get => agregarmodel;
                set
                {
                    agregarmodel = value;
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

            public AgregarViewModel(INavigation navigation)
            {
                Navigation = navigation;
                //Redireccion de botones de entrante y gastos
                irEntrante = new Command(async () => await NavigateToEntranteView());
                irGastos = new Command(async () => await NavigateToGastosView());
                //Redireccion de botones del menú
                irInicio = new Command(async () => await NavigateToInicioView());
                //irPlanear = new Command(async () => await NavigateToPlanearView());
                irAgregar = new Command(async () => await NavigateToAgregarView());
                //irReportes = new Command(async () => await NavigateToReportesView());
                //irAjustes = new Command(async () => await NavigateToAjustesView());
                irLogin = new Command(async () => await NavigateToLogin());
            }

        //Metodos Async funcionales

        private async Task NavigateToLogin()
        {
            await Navigation.PushAsync(new Login());
        }


        private async Task NavigateToAgregarView()
        {
            await Navigation.PushAsync(new Agregar());
        }

        private async Task NavigateToInicioView()
        {
            await Navigation.PushAsync(new Homepage());
        }

        private async Task NavigateToGastosView()
        {
            await Navigation.PushAsync(new Gastos());
        }

        private async Task NavigateToEntranteView()
        {
            await Navigation.PushAsync(new Entrante());//Llama la vista
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
