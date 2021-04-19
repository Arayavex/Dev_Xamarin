using AmiiboApp.Helpers;
using AmiiboApp.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace AmiiboApp.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Amiibo> _amiibosModel;
        public ObservableCollection<Character> AmiiboCharacter { get; set; }


        public ObservableCollection<Amiibo> AmiibosModel 
        { 
            get => _amiibosModel; 
            set
            {
                _amiibosModel = value;
                OnPropertyChanged();
            } 
        }

        public ICommand SearchCommand { get; set; }

        public MainPageViewModel()
        {
            //Con el command se desea atrapar informacion del SearchBar desde el UI
            SearchCommand =
                new Command(async (param) =>
                {
                    IsBusy = true;
                    var character = param as Character;
                    if (character != null)
                    {
                        string url = $"https://www.amiiboapi.com/api/amiibo/?character={character.name}"; //Variable interpolada para que pueda leer el valor real de 'text'
                        var service =
                            new HttpHelper<AmiibosModel>();
                        var amiibos =
                            await service.GetRestServiceDataAsync(url);
                        AmiibosModel = new ObservableCollection<Amiibo>(amiibos.amiibo);
                    }
                    IsBusy = false;
                });
        }

        public async Task LoadCharacters()
        {
            IsBusy = true;
            var url = "https://www.amiiboapi.com/api/character/";
            var service =
                new HttpHelper<AmiiboCharacter>();
            var characters = await service.GetRestServiceDataAsync(url);
            AmiiboCharacter = new ObservableCollection<Character>(characters.amiibo);
            IsBusy = false;

        }
    }
}
