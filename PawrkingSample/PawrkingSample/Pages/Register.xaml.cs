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
            BindingContext = registerVM;
            CreatePasswordEntry.Completed += cfmpasswordentery_complete;
        }

        public void CreatePasswordEntry_Completed(object sender, EventArgs e)
        {
            CreatePasswordEntry.Focus();
        }
        public void cfmpasswordentery_complete(object sender, EventArgs e)
        {
            CreatePasswordEntry.Focus();
        }

        private async void CancelRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        /*

        private async void RegisterButtonClicked(object sender, EventArgs e)
        {
            Student student = new Student();

            student.Email = CreateUsernameEntry.Text;
            student.Password = CreatePasswordEntry.Text;
            student.isAdmin = false;

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Student>();
                Student temp = conn.FindWithQuery<Student>("select * from Student where Id=?", CreateUsernameEntry.Text);
                if (temp != null)
                    DisplayAlert("Error", "User Already Exists Try Again!", "Ok");
                else
                {
                    conn.Insert(student);
                    //if username is unique then we insert new user to table and navigate
                    //else we have an alert pop up to try again
                    await Navigation.PushAsync(new HomePage(student.Email));
                }
                }
            

        }*/
    }
}