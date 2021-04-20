using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppAmigos.v2.Model
{
    public class Amigos : INotifyPropertyChanged
    {
        private string nombre;
        private string telefono;
        private string email;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }//Primary Key y es Autoincrementable

        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }
        public string Telefono
        {
            get => telefono;
            set
            {
                telefono = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
