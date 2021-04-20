using AppAmigos.v2.Helpers;
using AppAmigos.v2.Model;
using AppAmigos.v2.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppAmigos.v2.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Grouping<string, Amigos>> Amigos { get; set; }
        public Command agregarAmigo { get; set; }

        private INavigation Navigation;

        private Amigos amigoSeleccionado;
        public Command ItemTappedCommand { get; set; }


        public Amigos AmigoSeleccionado
        {
            get => amigoSeleccionado;
            set
            {
                amigoSeleccionado = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel(INavigation navigation)
        {
            AmigosRepository repository
                = new AmigosRepository();

            Amigos = repository.GetrAllGrouped();

            Navigation = navigation;

            agregarAmigo = new Command(async () => await NavigateToAmigoView());

            ItemTappedCommand = new Command(async () => await NavigateToEditAmigoView());

        }

        private async Task NavigateToEditAmigoView()
        {
            await Navigation.PushAsync(new AmigoView(AmigoSeleccionado), false);
        }

        private async Task NavigateToAmigoView()
        {
            await Navigation.PushAsync(new AmigoView());
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
