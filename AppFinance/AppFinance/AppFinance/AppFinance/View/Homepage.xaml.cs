using ProyectoFinal.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFinance.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Homepage : ContentPage
    {
        public Homepage()
        {
            InitializeComponent();
            BindingContext = new HomepageViewModel(Navigation);
            
        }
    }
}