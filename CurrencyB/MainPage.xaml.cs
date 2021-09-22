using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CurrencyB.Models;
using CurrencyB.Services;

namespace CurrencyB
{

    public partial class MainPage : ContentPage
    {
        Wallet Model = new Wallet();

        public APIService api = new APIService();

        


        public MainPage()
        {
            InitializeComponent();

            accessAPI();

           
        }

        public async void accessAPI()
        {

            //displaying error message if there's no internet, if the API call is wrong or if the URL changes.
            
            if (await api.GetCurrencyConvertor() == false)
            {
                await DisplayAlert("Error, please check internet connection.", "Also check exchange website is still live", "OK");
            }
            
        }

       


        public void updateUI()
        {

            labelOneDollarNumber.Text = $"({Model.OneDollarCoins})";
            labelOneDollarTotal.Text = $" $ {Model.OneDollarCoins.ToString("F")}";


            labelFiftyCentsNumber.Text = $"({Model.FiftyCentCoins})";
            labelFiftyCentsTotal.Text = $" $ {(0.5 * Model.FiftyCentCoins).ToString("F")}";

            labelTenCentsNumber.Text = $"({Model.TenCentCoins})";
            labelTenCentsTotal.Text = $" $ {(0.1 * Model.TenCentCoins).ToString("F")}";

            labelFiveCentsNumber.Text = $"({Model.FiveCentCoins})";
            labelFiveCentsTotal.Text = $" $ {(0.05 * Model.FiveCentCoins).ToString("F")}";


            labelFinalTotalAmount.Text = $" $ {Model.TotalValue().ToString("F")} ";

            
        }

        /// Add a $1 coin

        void buttonAddOneDollar_Clicked(System.Object sender, System.EventArgs e)
        {
            Model.AddOneDollar();
            updateUI();
        }

        /// Subtract a $1 coin. Validates that there is one to remove.

        void buttonMinusOneDollar_Clicked(System.Object sender, System.EventArgs e)
        {
            if (Model.OneDollarCoins <= 0)
            {
                DisplayAlert("Not enough coins", "You must have coins to subtract.", "OK");

            }
            else
            {
                Model.SubtractOneDollar();
                updateUI();
            }
        }



        /// Exchanging 1x $1 coin for 2x 50c coins. This validates that at least one coin is available.

        void buttonOneDollarDown_Clicked(System.Object sender, System.EventArgs e)
        {

            if (Model.OneDollarCoins == 0)
            {
                DisplayAlert("Not enough coins", "You need at least 1 x $1 coins to convert to 50c.", "OK");


            }
            else
            {
                Model.OneDollarExchangedToFiftyCents();



                updateUI();
            }




        }


        /// Add a 50c coin

        void buttonAddFiftyCents_Clicked(System.Object sender, System.EventArgs e)
        {
            Model.AddFiftyCents();

            updateUI();
        }

        /// Subtract a 50c coin. Validates that one is available to remove.

        void buttonMinusFiftyCents_Clicked(System.Object sender, System.EventArgs e)
        {
            if (Model.FiftyCentCoins <= 0)
            {
                DisplayAlert("Not enough coins", "You must have coins to subtract.", "OK");

            }
            else
            {
                Model.SubtractFiftyCents();
                updateUI();
            }
        }



        /// Exchanging 2x 50c coins for 1x $1 coin. It validates whether 2x 50c coins are available before exchanging them.

        void buttonFiftyCentsUp_Clicked(System.Object sender, System.EventArgs e)
        {


            if (Model.FiftyCentCoins >= 2)
            {
                Model.FiftyCentsExchangedToOneDollar();



                updateUI();
            }
            else
            {
                DisplayAlert("Not enough coins", "You need at least 2 x 50c coins to convert to $1.", "OK");
            }



        }

        /// Exchanging 1x 50c coins for 5x 10c coin. It validates if one coin is available.

        void buttonFiftyCentsDown_Clicked(System.Object sender, System.EventArgs e)
        {

            if (Model.FiftyCentCoins == 0)
            {
                DisplayAlert("Not enough coins", "You need at least 1 x 50c coins to convert to 10c.", "OK");

            }
            else
            {
                Model.FiftyCentsExchangedToTenCents();



                updateUI();
            }




        }

        /// Add a 10c coin

        void buttonAddTenCents_Clicked(System.Object sender, System.EventArgs e)
        {
            Model.AddTenCents();

            updateUI();
        }


        /// Subtract a 10c coin. Validates that one is available to remove.

        void buttonMinusTenCents_Clicked(System.Object sender, System.EventArgs e)
        {
            if (Model.TenCentCoins <= 0)
            {
                DisplayAlert("Not enough coins", "You must have coins to subtract.", "OK");

            }
            else
            {

                Model.SubtractTenCents();
                updateUI();

            }
        }



        /// Exchanging 5x 10c coins for 1x 50c coin. It validates whether 5x 10c coins are available before exchanging them.

        void buttonTenCentsUp_Clicked(System.Object sender, System.EventArgs e)
        {

            if (Model.TenCentCoins >= 5)
            {
                Model.TenCentsExchangedToFiftyCents();


                updateUI();
            }
            else
            {
                DisplayAlert("Not enough coins", "You need at least 5 x 10c coins to convert to 50c.", "OK");
            }


        }


        /// Exchanging 1x 10c coins for 2x 5c coin. It validates whether 1 x 10c coin is available before exchanging them.

        void buttonTenCentsDown_Clicked(System.Object sender, System.EventArgs e)
        {

            if (Model.TenCentCoins == 0)
            {
                DisplayAlert("Not enough coins", "You need at least 1 x 10c coins to convert to 5c.", "OK");

            }
            else
            {
                Model.TenCentsExchangedToFiveCents();



                updateUI();

            }

        }


        /// Add a 5c coin

        void buttonAddFiveCents_Clicked(System.Object sender, System.EventArgs e)
        {
            Model.AddFiveCents();
            updateUI();
        }

        /// Subtract a 5c coin. Validates that one is available to remove.

        void buttonMinusFiveCents_Clicked(System.Object sender, System.EventArgs e)
        {
            if (Model.FiveCentCoins <= 0)
            {
                DisplayAlert("Not enough coins", "You must have coins to subtract.", "OK");

            }
            else
            {
                Model.SubtractFiveCents();
                updateUI();
            }


        }


        /// Exchanging 2x 5c coins for 1x 10c coin. It validates whether 2x 5c coins are available before exchanging them.

        void buttonFiveCentsUp_Clicked(System.Object sender, System.EventArgs e)
        {

            if (Model.FiveCentCoins >= 2)
            {
                Model.FiveCentsExchangedToTenCents();



                updateUI();
            }
            else
            {
                DisplayAlert("Not enough coins", "You need at least 2 x 5c coins to convert to 10c.", "OK");
            }

        }

        /// Converts the total value to EUR using the currency convert class. Note that API base is EUR so needs to be converted from EUR to AUD then back to EUR.
        
        void buttonEUR_Clicked(System.Object sender, System.EventArgs e)
        {

            labelConvertedEur.Text = $" € {(Model.TotalValue()/api.main.rates.AUD).ToString("F")}";
        }



        /// Converts the total value to USD using the currency convert class. Note that API base is EUR so needs to be converted from EUR to AUD then back to USD.

        void buttonUSD_Clicked(System.Object sender, System.EventArgs e)
        {
            float usdExchange = api.main.rates.USD / api.main.rates.AUD;

            labelConvertedUSD.Text = $" $ {(Model.TotalValue()*(usdExchange)).ToString("F")}";

        }


        /// Converts the total value to PLN using the currency convert class. Note that API base is EUR so needs to be converted from EUR to AUD then back to PLN.
        
        void buttonPLN_Clicked(System.Object sender, System.EventArgs e)
        {
            float plnExchange = api.main.rates.PLN / api.main.rates.AUD;

            labelConvertedPLN.Text = $" {(Model.TotalValue() * (plnExchange)).ToString("F")} zł";
        }
    }
}
