using PawrkingSample.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PawrkingSample.ClassPages
{
    class SeeAllLotsVM
    {
        string email;
        public SeeAllLotsVM(string email2)
        {
            email = email2;
        }

        public Command LotCButonClicked
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PushAsync(new LotCPage(email));
                });
            }
        }

        public Command PS1ButtonClicked
        {
            get
            {
                return new Command(() =>
                {
                    //App.Current.MainPage.Navigation.PushAsync(new PS1Page(email));
                });
            }
        }

        public Command LotPButtonClicked
        {
            get
            {
                return new Command(() =>
                {
                    //App.Current.MainPage.Navigation.PushAsync(new LotPPage());
                });
            }
        }
        public Command CancelButtonClicked
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PushAsync(new HomePage(email));
                });
            }
        }

    }
}
