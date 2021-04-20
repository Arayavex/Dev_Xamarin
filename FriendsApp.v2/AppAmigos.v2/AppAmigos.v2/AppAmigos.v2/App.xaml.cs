using AppAmigos.v2.Data;
using AppAmigos.v2.Services;
using Xamarin.Forms;

namespace AppAmigos.v2
{
    public partial class App : Application
    {
        //Propiedad static de tipo AmigosDatabase
        private static AmigosDatabase database;

        public static AmigosDatabase Database
        {
            get //Obtiene la ruta
            {
                if (database == null)
                {
                    database =
                        new AmigosDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("amigodb.db3"));
                }
                return database;
            }

            set => database = value;
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
