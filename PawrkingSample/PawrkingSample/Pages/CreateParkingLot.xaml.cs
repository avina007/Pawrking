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
using PawrkingSample.ClassPages;


namespace PawrkingSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateParkingLot : ContentPage
    {
        //Student user;
        CreateParkingLotVM createParkingLotVM;
        
        public CreateParkingLot()
        {
            InitializeComponent();
            createParkingLotVM = new CreateParkingLotVM();
            LotNameEntry.Completed += LotNameEntry_Completed;
            RowEntry.Completed += RowEntry_Completed;
            BindingContext = createParkingLotVM;

            //ColEntry.Completed += AddLotButtonClicked;
            /*using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Student>();
                user = conn.FindWithQuery<Student>("select * from Student where Id=?", id);
            }*/
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
            //await Navigation.PushAsync(new HomePage(user.Email));
        }

        /*
        private async void AddLotButtonClicked(object sender, EventArgs e)
        {
            ParkingLot parkinglot = new ParkingLot();

            parkinglot.Name = LotNameEntry.Text;
            parkinglot.Row = RowEntry.Text;
            parkinglot.Col = int.Parse(ColEntry.Text);
            parkinglot.Open = true;

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<ParkingLot>();

                conn.Insert(parkinglot);

                DisplayAlert("Added New Lot", parkinglot.Name.ToString(), "OK");

                //await Navigation.PushAsync(new ParkingReservationHistory());


            }


        }*/
    }
}