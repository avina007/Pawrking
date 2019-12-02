﻿using PawrkingSample.Classes;
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
    public partial class ReservationPage : ContentPage
    {

        string email;
        string lotname;
        string row;
        int col;
        int timelength;
        DateTime starttime;
        //VIEW MODEL CONSTRUCTOR

        public ReservationPage(string e, string lname, string r, int c)
        {
            InitializeComponent();
            email = e;
            lotname = lname;
            row = r;
            col = c;
            //VIEW MODEL Value Transfer
            //BINDINGCONTEXT HERE
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();

        }
    }
}