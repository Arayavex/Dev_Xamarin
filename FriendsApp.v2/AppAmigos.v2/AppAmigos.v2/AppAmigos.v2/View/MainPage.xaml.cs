using AppAmigos.v2.ViewModel;
using Xamarin.Forms;

namespace AppAmigos.v2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Se va refrescar la lista para tener los elementos actualizados
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new
                MainPageViewModel(Navigation);
        }
    }
}
