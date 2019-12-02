using PawrkingSample.Classes;
using PawrkingSample.ClassPages;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entry = Microcharts.Entry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawrkingSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LotPPage : ContentPage
    {
        string email;
        LotVM lotVM;
        string LotName = "Lot P";

        public LotPPage(string e)
        {
            InitializeComponent();
            email = e;
            lotVM = new LotVM(email, LotName);
            BindingContext = lotVM;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            int free = lotVM.GetFree;
            int total = lotVM.GetAllSpotCount;
            int busy = total - free;
            List<Entry> entries = new List<Entry>
            {
                new Entry((float)busy)
                {
                    Color = SkiaSharp.SKColor.Parse("#ff0000"),
                    ValueLabel=Convert.ToString(busy),
                    Label = "Busy",
                },
                new Entry((float)free)
                {
                    Color = SkiaSharp.SKColor.Parse("#008000"),
                    ValueLabel=Convert.ToString(free),
                    Label = "Open",
                },
            };
            BusyChart.Chart = new Microcharts.DonutChart
            {
                Entries = entries,
                LabelTextSize = 45,
                HoleRadius = .7f,
                Margin = 35,
            };
        }

        private void SpaceChocen(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as ParkingLot;
            lotVM.SpaceChosen(details.Row, details.Col);
        }
    }
}