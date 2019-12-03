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

    public partial class SearchByTimePage : ContentPage
    {
        string email;
        //string lotname;

        SearchByTimeVM searchByTimeVM;

        public SearchByTimePage(string e)
        {
            InitializeComponent();
            email = e;
            //lotname = lname;

            searchByTimeVM = new SearchByTimeVM(email);
            BindingContext = searchByTimeVM;
        }
    }
}
