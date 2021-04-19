using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace AmiiboApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;

        //Propiedades
        public bool IsBusy 
        { 
            get => _isBusy; 
            set
            {
                _isBusy = value;
                //Metodo para que cuando se haga un cambio en la propiedad, se notificara en la UI.
                OnPropertyChanged(); 
            }
                
        }

        //Region del PropertyChanged que funciona con el "INotifyPropertyChanged
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


    }
}
