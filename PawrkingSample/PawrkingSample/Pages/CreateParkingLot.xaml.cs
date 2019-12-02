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
        CreateParkingLotVM createParkingLotVM;
        string email;
        public CreateParkingLot(string e)
        {
            email = e;
            InitializeComponent();
            createParkingLotVM = new CreateParkingLotVM(email);
            LotNameEntry.Completed += LotNameEntry_Completed;
            RowEntry.Completed += RowEntry_Completed;
            BindingContext = createParkingLotVM;
        }

        public void LotNameEntry_Completed(object sender, EventArgs e)
        {
            RowEntry.Focus();
        }

        public void RowEntry_Completed(object sender, EventArgs e)
        {
            ColEntry.Focus();
        }
    }
}