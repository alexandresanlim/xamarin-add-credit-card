using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamarinUI.AddCreditCard.Models;

namespace XamarinUI.AddCreditCard
{
    public class CreditCardListViewModel : ViewModelBase
    {
        public CreditCardListViewModel()
        {
            LoadDataCommand.Execute(null);
        }

        public Command LoadDataCommand => new Command(() =>
        {
            CreditCartList = new ObservableCollection<CreditCartInfo>(CreditCartInfo.GetData());
        });

        public Command NavigateToAddCardCommand => new Command(async () =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new MainPage());
        });

        private ObservableCollection<CreditCartInfo> _creditCartList;
        public ObservableCollection<CreditCartInfo> CreditCartList
        {
            set { SetProperty(ref _creditCartList, value); }
            get { return _creditCartList; }
        }
    }
}
