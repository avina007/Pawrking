using PawrkingSample.Classes;
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
        public MainPage()
        {
            InitializeComponent();
            UserNameEntry.Completed += PasswordEntry_Complete;
            PasswordEntry.Completed += SignIn_Clicked;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            UserNameEntry.Focus();
        }

        public void PasswordEntry_Complete(object sender, EventArgs e)
        {
            PasswordEntry.Focus();
        }

        private async void CreateAccountClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            Student user;
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Student>();
                user = conn.FindWithQuery<Student>("select * from Student where Id=?", UserNameEntry.Text);
            }
            if (String.IsNullOrWhiteSpace(UserNameEntry.Text) || String.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                DisplayAlert("Error", "Incorrect Username or Password", "Retry");
            }
            else if (user == null)
            {
                DisplayAlert("Error", "Username not Found please try again or create an account!", "Retry");
            }
            else if (user.password != PasswordEntry.Text)
            {
                DisplayAlert("Error", "Incorrect Password", "Retry");
            }
            else if(user.password == PasswordEntry.Text)
            {
                DisplayAlert("Welcome", user.Id , "ok");
                await Navigation.PushAsync(new HomePage());
            }
            
        }
    }
}
