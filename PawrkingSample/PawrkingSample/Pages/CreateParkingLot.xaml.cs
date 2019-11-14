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


namespace PawrkingSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateParkingLot : ContentPage
    {
        Student user;

        public CreateParkingLot()
        {
            InitializeComponent();
            LotNameEntry.Completed += LotNameEntry_Completed;
            RowEntry.Completed += RowEntry_Completed;
            ColEntry.Completed += AddLotButtonClicked;
        }
        public CreateParkingLot(string id)
        {
            InitializeComponent();
            LotNameEntry.Completed += LotNameEntry_Completed;
            RowEntry.Completed += RowEntry_Completed;
            ColEntry.Completed += AddLotButtonClicked;
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Student>();
                user = conn.FindWithQuery<Student>("select * from Student where Id=?", id);
            }
        }

        public void LotNameEntry_Completed(object sender, EventArgs e)
        {
            RowEntry.Focus();
        }

        public void RowEntry_Completed(object sender, EventArgs e)
        {
            ColEntry.Focus();
        }

        private async void CancelLotEntryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void AddLotButtonClicked(object sender, EventArgs e)
        {
            ParkingLot parkinglot = new ParkingLot();

            parkinglot.name = LotNameEntry.Text;
            parkinglot.row = RowEntry.Text;
            parkinglot.col = int.Parse(ColEntry.Text);
            parkinglot.open = true;

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<ParkingLot>();

                conn.Insert(parkinglot);

                DisplayAlert("Added New Lot", parkinglot.lotId.ToString(), "OK");

                //await Navigation.PushAsync(new ParkingReservationHistory());


            }


        }
    }
}