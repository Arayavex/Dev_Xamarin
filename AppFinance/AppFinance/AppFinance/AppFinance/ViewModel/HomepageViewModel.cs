using AppFinance;
using AppFinance.Model;
using AppFinance.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinal.ViewModel
{
    public class HomepageViewModel : INotifyPropertyChanged
    {
        public HomepageViewModel(INavigation navigation)
        {

            Task.Run(async () =>
            {
                Console.WriteLine("in constrcutor");
                await InitializeDataAsync();
            });

            Navigation = navigation;
            irAgregar = new Command(NavigateToAgregar);
            irNuevaCuenta = new Command(NavigateToNuevaCuenta);

            Console.WriteLine(ListaCuentas);
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public Command irAgregar { get; set; }
        public Command irNuevaCuenta { get; set; }
        public Command agregaCuenta { get; set; }

        private ObservableCollection<CuentaModel> cuentas;
        public ObservableCollection<CuentaModel> ListaCuentas
        {
            get => cuentas;
            set
            {
                cuentas = value;
                OnPropertyChanged();
            }
        }

        private INavigation Navigation;


        private async Task InitializeDataAsync()
        {
            ListaCuentas = await GetData();
            Console.WriteLine("new test");
        }

        /*public async Task<ObservableCollection<CuentaModel>> GetData()
        {
            if (ListaCuentas == null) {
                var cliente = new HttpClient();
                var respuesta = await cliente.GetAsync("http://localhost:3001/cuentas");
                if (respuesta.IsSuccessStatusCode)
                {
                    var jsonResultado = await cliente.GetStringAsync("http://localhost:3001/cuentas");
                    Console.WriteLine(jsonResultado);
                    var data = JsonConvert.DeserializeObject<ObservableCollection<CuentaModel>>(jsonResultado);
                    return data;
                }
                else { Console.WriteLine("errrroooooor"); }
            }
            Console.WriteLine("idk whatever");
            return ListaCuentas;
        }*/

        public async Task<ObservableCollection<CuentaModel>> GetData()
        {
            if (ListaCuentas == null)
            {
                var id = App.Current.Properties["id"];
                var o = new JObject(
                        new JProperty("id", id)
                    );

                string jsonString = o.ToString();
                var cliente = new HttpClient();
                var httpContent = new StringContent(jsonString);
                Console.WriteLine(o);
                Console.WriteLine(jsonString);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var respuesta = await cliente.PostAsync("https://guarded-cove-17725.herokuapp.com/cuentas", httpContent);

                if (respuesta.IsSuccessStatusCode)
                {
                    var json = await respuesta.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ObservableCollection<CuentaModel>>(json);
                    return data;
                }
            }

            return ListaCuentas;

        }


        private void NavigateToNuevaCuenta(object obj)
        {
            Navigation.PushAsync(new NuevaCuenta());
        }

        private void NavigateToAgregar(object obj)
        {
            Navigation.PushAsync(new Agregar());
        }
    }
}
