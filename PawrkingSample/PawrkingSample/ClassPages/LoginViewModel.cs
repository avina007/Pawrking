﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using PawrkingSample.Pages;

namespace PawrkingSample.ClassPages
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel()
        {

        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }
        public Command SignUp
        {
            get
            {
                return new Command(() => { App.Current.MainPage.Navigation.PushAsync(new Register()); });
            }
        }

        private async void Login()
        {
            //null or empty field validation, check weather email and password is null or empty

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call GetUser function which we define in Firebase helper class
                var user = await FirebaseHelper.GetUser(Email);
                //firebase return null valuse if user data not found in database
                if (user != null)
                    if (Email == user.Email && Password == user.Password)
                    {
                        await App.Current.MainPage.DisplayAlert("Login Success", "Welcome " + user.Email , "Ok");
                        //Navigate to Wellcom page after successfuly login
                        //pass user email to welcom page
                        await App.Current.MainPage.Navigation.PushAsync(new HomePage(Email));
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
            }
        }
    }
}
