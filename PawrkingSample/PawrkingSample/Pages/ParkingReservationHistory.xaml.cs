using PawrkingSample.Classes;
using PawrkingSample.ClassPages;
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
    public partial class ParkingReservationHistory : ContentPage
    {
        string email;
        ReservationHistoyVM prhVM;
        public ParkingReservationHistory(string e)
        {
            InitializeComponent();
            email = e;
            prhVM = new ReservationHistoyVM(email);
            BindingContext = prhVM;
        }

       
    }
}