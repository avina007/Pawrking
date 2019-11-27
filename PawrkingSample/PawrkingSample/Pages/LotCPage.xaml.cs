﻿using PawrkingSample.Classes;
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
        string email;
        ParkingLot lot;
        public LotCPage()
        {
            InitializeComponent();
             
        }
        public LotCPage(string e)
        {
            email = e;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<ParkingLot>();
                var openSpots = conn.Table<ParkingLot>().ToList();
                List<ParkingLot> add = new List<ParkingLot>();
                foreach (ParkingLot item in openSpots)
                {            
                    if (item.Open && item.LotName == "Lot C")
                    {
                        add.Add(item);
                    }
                }               
                LotListView.ItemsSource = add;             
                LotCProgressBar.Progress = Convert.ToDouble(add.Count)/Convert.ToDouble(openSpots.Count);
            }
            
        }

        public async void ReserveButton_Clicked(object sender, EventArgs e)
        {
           // await Navigation.PushAsync(new MainPage());
        }

        public async void CancelButton_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new SeeAllLotsPage(email));
        }

    }
}