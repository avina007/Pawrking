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
    public partial class SeeAllLotsPage : ContentPage
    {
        Student user;
        public SeeAllLotsPage()
        {
            InitializeComponent();
        }
        public SeeAllLotsPage(string id)
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Student>();
                user = conn.FindWithQuery<Student>("select * from Student where Id=?", id);
            }
        }
        private async void LotCButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new LotCPage(user.Email));
        }
        private async void PS1Button_Clicked(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new MainPage(user.Id));
        }
        private async void LotPButton_Clicked(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new MainPage(user.Id));
        }
        private async void CancelButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new HomePage(user.Email));
        }
    }
}