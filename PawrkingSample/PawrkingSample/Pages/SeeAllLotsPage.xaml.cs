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
    public partial class SeeAllLotsPage : ContentPage
    {
        string email;
        SeeAllLotsVM seeAllLotsVM;

        public SeeAllLotsPage(string e)
        {
            InitializeComponent();
            LotVM.Refresh();
            email = e;
            seeAllLotsVM = new SeeAllLotsVM(email);
            BindingContext = seeAllLotsVM;
        }
        
     
    }
}