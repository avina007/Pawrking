using PawrkingSample.Classes;
using PawrkingSample.Pages;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawrkingSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
            CreateUsernameEntry.Completed += CreatePasswordEntry_Completed;
            CreatePasswordEntry.Completed += RegisterButtonClicked;
        }

        public void CreatePasswordEntry_Completed(object sender, EventArgs e)
        {
            CreatePasswordEntry.Focus();
        }

        private async void CancelRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void RegisterButtonClicked(object sender, EventArgs e)
        {
            Student student = new Student();

            student.Id = CreateUsernameEntry.Text;
            student.password = CreatePasswordEntry.Text;
            student.isAdmin = false;

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Student>();
                Student temp = conn.FindWithQuery<Student>("select * from Student where Id=?", CreateUsernameEntry.Text);
                if (temp.Id == student.Id)
                    DisplayAlert("Error", "User Already Exists Try Again!", "Ok");
                else
                {
                    conn.Insert(student);
                    //if username is unique then we insert new user to table and navigate
                    //else we have an alert pop up to try again
                    await Navigation.PushAsync(new HomePage(student.Id));
                }
                }
            

        }
    }
}