using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using PawrkingSample.Pages;
using Xamarin.Essentials;

namespace PawrkingSample.ClassPages
{
    public class CreateParkingLotVM : INotifyPropertyChanged
    {
        private string lotname;
 
        public string LotName
        {
            get { return lotname; }
            set
            {
                lotname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LotName"));
            }
        }
        private string row;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Row
        {
            get { return row; }
            set
            {
                row = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Row"));
            }
        }
        private int col;
        public int Col
        {
  
            get { return col; }
            set
            {
                col = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Col"));

            }

        }

        public Command AddLotCommand
        {
            get
            {
                return new Command(() =>
                {
                    AddLot();
                });
            }
        }

        private async void AddLot()
        {
            if(string.IsNullOrEmpty(LotName) || string.IsNullOrEmpty(Row) || string.IsNullOrEmpty(Col.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            }
            else
            {
                var lot = await FBParkingHelper.AddLot(LotName, Row, Col);

                if(lot)
                {
                    await App.Current.MainPage.DisplayAlert("Lot Added Successfully", "", "Ok");
                    await App.Current.MainPage.Navigation.PushAsync(new CreateParkingLot());
                }
            }
        }

    }
}
