using PawrkingSample.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawrkingSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LotCPage : ContentPage
    {
        string email;
        
        public LotCPage(string e)
        {
            //InitializeComponent();
            email = e;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            
            
        }

        public async void ReserveButton_Clicked(object sender, EventArgs e)
        {
           // await Navigation.PushAsync(new MainPage());
        }

        

    }
}