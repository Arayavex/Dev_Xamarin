using AppFinance.Model;
using AppFinance.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFinance.ViewModel
{
    public class LoginViewModel
    {

        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
            irInicio = new Command(NavigateToInicio);
            validarUser = new Command(async () => {
                await ValidarUser();
            });
        }


        private void NavigateToInicio(object obj)
        {
            Navigation.PushAsync(new Homepage());
        }

        public string User { get; set; }
        public string Pass { get; set; }
        public Command irInicio { get; set; }
        public Command validarUser { get; set; }
        private INavigation Navigation;

        public async Task ValidarUser()
        {
            var o = new JObject(
                    new JProperty("user", User),
                    new JProperty("pass", Pass)
                );

            string jsonString = o.ToString();
            var cliente = new System.Net.Http.HttpClient();
            var httpContent = new StringContent(jsonString);

            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var respuesta = await cliente.PostAsync("https://guarded-cove-17725.herokuapp.com/usuarios", httpContent);

            if (respuesta.IsSuccessStatusCode)
            {

                Console.WriteLine("test");
                var json = await respuesta.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UserModel>(json);
                Console.WriteLine(data);
                var id = data._id;
                App.Current.Properties["id"] = id;
                await Navigation.PushAsync(new Homepage());
            }
            else
            {
                //await DisplayAlert("Alert", "No existe");
                await App.Current.MainPage.DisplayAlert("Error", "Usuario incorrecto", "OK");
            }

        }

    }
}
