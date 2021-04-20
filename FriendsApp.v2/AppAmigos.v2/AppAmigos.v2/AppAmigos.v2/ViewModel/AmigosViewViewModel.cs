using AppAmigos.v2.Model;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppAmigos.v2.ViewModel
{
    public class AmigosViewViewModel
    {

        public Command SaveCommand { get; set; }
        public Amigos nuevo { get; set; }

        //Para poder hacer un push y un pop a partir de la navegacion
        private INavigation Navigation;

        //Constructor se crea solo si vamos a hacer un nuevo amigo
        public AmigosViewViewModel(INavigation navigation)
        {
            nuevo = new Amigos();//Nueva instancia de Amigo
            SaveCommand = new Command(async () => await salvarAmigo());
            Navigation = navigation;//Propiedad navigation va ser igual al parametro del constructor
        }

        public AmigosViewViewModel(INavigation navigation, Amigos amigo)
        {
            nuevo = amigo;//new amigo va a ser igual al amigo que le estamos pasando
            SaveCommand = new Command(async () => await salvarAmigo());
            Navigation = navigation;
        }


        public async Task salvarAmigo()
        {
            await App.Database.SaveItemAsync(nuevo);
            await Navigation.PopToRootAsync();
        }

    }
}
