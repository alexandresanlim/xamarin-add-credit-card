using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUI.AddCreditCard
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CreditCardListPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
