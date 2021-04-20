using AppFinance.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFinance.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaCuenta : ContentPage
    {
        public NuevaCuenta()
        {
            InitializeComponent();
            BindingContext = new NuevaCuentaViewModel(Navigation);
        }
    }
}