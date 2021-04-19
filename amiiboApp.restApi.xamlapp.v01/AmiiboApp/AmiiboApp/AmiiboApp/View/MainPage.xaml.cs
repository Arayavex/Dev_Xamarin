using AmiiboApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AmiiboApp
{
    public partial class MainPage : ContentPage
    {
        //Propiedad referencia al ViewModel
        public MainPageViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ViewModel = new MainPageViewModel();
            await ViewModel.LoadCharacters();
            this.BindingContext = ViewModel;
        }

    }
}
