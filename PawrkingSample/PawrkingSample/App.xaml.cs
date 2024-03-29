﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawrkingSample
{
    public partial class App : Application
    {
        public static string FilePath;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string filepath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            FilePath = filepath;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
