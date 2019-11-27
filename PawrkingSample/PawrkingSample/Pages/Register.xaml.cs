using PawrkingSample.Classes;
using PawrkingSample.Pages;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PawrkingSample.ClassPages;
using Xamarin.Forms.Xaml;

namespace PawrkingSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        RegisterVM registerVM;
        public Register()
        {
            InitializeComponent();
            registerVM = new RegisterVM();
            CreateEmailEntry.Completed += CreatePasswordEntry_Completed;
            CreatePasswordEntry.Completed += cfmpasswordentery_complete;
            BindingContext = registerVM;
        }

        public void CreatePasswordEntry_Completed(object sender, EventArgs e)
        {
            CreatePasswordEntry.Focus();
        }
        public void cfmpasswordentery_complete(object sender, EventArgs e)
        {
            cfmpasswordentery.Focus();
        }

        private async void CancelRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
       
    }
}