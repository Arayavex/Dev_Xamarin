using Xamarin.Forms;

namespace labCalcSalarial
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new labCalcSalarial.MainPage();
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
