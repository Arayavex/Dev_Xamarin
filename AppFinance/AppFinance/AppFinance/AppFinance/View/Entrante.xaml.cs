using AppFinance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFinance.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Entrante : ContentPage
    {
        public Entrante()
        {
            InitializeComponent();
            BindingContext = new EntranteViewModel(Navigation);
        }
    }
}