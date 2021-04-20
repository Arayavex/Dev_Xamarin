using AppFinance.View;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFinance.ViewModel
{
    public class NuevaCuentaViewModel
    {

        public Command irHomepage { get; set; }

        public Command agregarCuenta { get; set; }


        public string nombre;
        public string balance;


        public string Balance { get; set; }
        public string Nombre { get; set; }

        private INavigation Navigation;

        public NuevaCuentaViewModel(INavigation navigation)
        {
            Navigation = navigation;
            irHomepage = new Command(NavigateToHomePage);
            agregarCuenta = new Command(async () => {
                await InsertData();
            });
        }

        private void NavigateToHomePage(object obj)
        {
            Navigation.PushAsync(new Homepage());
        }

        public async Task InsertData()
        {

            if (App.Current.Properties.ContainsKey("id"))
            {
                var id = App.Current.Properties["id"];
                var o = new JObject(
                    new JProperty("nombre", Nombre),
                    new JProperty("balance", Balance),
                    new JProperty("user", id)
                );

                string jsonString = o.ToString();
                var cliente = new HttpClient();
                var httpContent = new StringContent(jsonString);
                Console.WriteLine(o);
                Console.WriteLine(jsonString);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var respuesta = await cliente.PostAsync("https://guarded-cove-17725.herokuapp.com/cuentas/nuevaCuenta", httpContent);

                if (respuesta.IsSuccessStatusCode)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "cuenta agregada", "OK");
                    await Navigation.PushAsync(new Homepage());
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay usuario", "OK");
                await Navigation.PushAsync(new Login());
            }
        }

    }
}
