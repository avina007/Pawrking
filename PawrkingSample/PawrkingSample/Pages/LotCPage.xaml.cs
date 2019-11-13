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
        Student user;
        public LotCPage()
        {
            InitializeComponent();
             
        }
        public LotCPage(string id)
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Student>();
                user = conn.FindWithQuery<Student>("select * from Student where Id=?", id);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LotCProgressBar.Progress = .75;
        }

        public async void ReserveButton_Clicked(object sender, EventArgs e)
        {
           // await Navigation.PushAsync(new MainPage());
        }

        public async void CancelButton_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new SeeAllLotsPage(user.Id));
        }

    }
}