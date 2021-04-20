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
    public class EntranteViewModel : INotifyPropertyChanged
    {

            private EntranteModel entrantemodel;

            //Botones para redireccionar a las páginas del menú
            public Command irInicio { get; set; }
            public Command irPlanear { get; set; }
            public Command irAgregar { get; set; }
            public Command irReportes { get; set; }
            public Command irAjustes { get; set; }

            //Navegación
            private INavigation Navigation;

            public EntranteModel Entrantemodel
            {
                get => entrantemodel;
                set
                {
                    entrantemodel = value;
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

            public EntranteViewModel(INavigation navigation)
            {
                Navigation = navigation;
                //Redireccion de botones del menú
                irInicio = new Command(async () => await NavigateToInicioView());
               // irPlanear = new Command(async () => await NavigateToPlanearView());
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
