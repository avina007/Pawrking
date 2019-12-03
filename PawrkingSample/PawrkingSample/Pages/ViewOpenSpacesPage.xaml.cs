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
    public partial class ViewOpenSpacesPage : ContentPage
    {
        string email;
        ViewOpenSpacesVM viewOpenSpacesVM;

        public ViewOpenSpacesPage(string e)
        { 
            InitializeComponent();
            email = e;
            viewOpenSpacesVM = new ViewOpenSpacesVM(email);
            BindingContext = viewOpenSpacesVM;
        }
        private void SpaceChosen(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as ParkingLot;
            //ViewModel
            viewOpenSpacesVM.SpaceChosen(details.Row, details.Col);
        }

    }

    
}
