using Xamarin.Forms;
using labCalcSalarial.ModelView;

namespace labCalcSalarial
{
    public partial class MainPage : ContentPage
    {
        //Constructor de la class MainPage
        public MainPage()
        {
            InitializeComponent();

            //Objeto BindingContext le permite a la UI utilizar una fuente de datos que estan en el Model 'CalcSModel'
            this.BindingContext = 
                new MainPageViewModel();
        }
    }
}
