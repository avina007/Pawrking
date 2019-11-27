using PawrkingSample.Classes;
using PawrkingSample.ClassPages;
using PawrkingSample.Pages;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PawrkingSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public MainPage()
        {
            loginViewModel = new LoginViewModel();
            InitializeComponent();
            BindingContext = loginViewModel;

            EmailEntry.Completed += PasswordEntry_Complete;
            //PasswordEntry.Completed += SignIn_Clicked;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            EmailEntry.Focus();
        }

        public void PasswordEntry_Complete(object sender, EventArgs e)
        {
            PasswordEntry.Focus();
        }
       
    }
}
