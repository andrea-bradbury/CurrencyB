﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CurrencyB.Models;
using CurrencyB.Services;


namespace CurrencyB
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {

            //((MainPage)MainPage).APIService.GetCurrencyConvertor();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}