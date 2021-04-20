using AppAmigos.v2.Model;
using AppAmigos.v2.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAmigos.v2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AmigoView : ContentPage
    {
        //Para editar un amigo y reutilizar la vista
        public AmigoView(Amigos amigo = null)//se le pasa por parametro un amigo y en caso de que no se le asigne una instancia pues va ser igual a null
        {
            InitializeComponent();
            if (amigo == null)//Se ejecuta si se esta creando un nuevo amigo
            {
                //Me llama el constructor el ViewViewModel
                BindingContext = new AmigosViewViewModel(Navigation);
            }
            else//De lo contrario se ejecuta el else para hacer la actualizacion de un amigo
            {
                //A diferencia del otro binding context, se envia por parametro el amigo
                BindingContext = new AmigosViewViewModel(Navigation, amigo);
            }
        }
    }
}