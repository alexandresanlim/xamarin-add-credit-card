using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinUI.AddCreditCard.extention;

namespace XamarinUI.AddCreditCard
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            ResetProps();
        }

        private void ResetProps()
        {
            CardSimulationInfo = new ViewFlipper();

            PanelNumber = new StackLayout
            {
                IsVisible = true
            };

            PanelName = new StackLayout
            {
                IsVisible = false
            };

            PanelValid = new StackLayout
            {
                IsVisible = false
            };

            PanelCvv = new StackLayout
            {
                IsVisible = false
            };

            EntryName = new Entry();

            LogoCreditCard = new Image();
        }

        public Command NextCommand => new Command(() =>
        {
            if (PanelNumber.IsVisible)
            {
                PanelNumber.IsVisible = false;
                PanelName.IsVisible = !PanelNumber.IsVisible;
                return;
            }

            if (PanelName.IsVisible)
            {
                PanelName.IsVisible = false;
                PanelValid.IsVisible = !PanelName.IsVisible;
                return;
            }

            if (PanelValid.IsVisible)
            {
                PanelValid.IsVisible = false;
                PanelCvv.IsVisible = !PanelValid.IsVisible;
                CardSimulationInfo.FlipState = extention.FlipState.Back;
                return;
            }

            if (PanelCvv.IsVisible)
            {
                PanelCvv.IsVisible = false;
                PanelNumber.IsVisible = !PanelCvv.IsVisible;
                CardSimulationInfo.FlipState = extention.FlipState.Front;
                return;
            }

        });

        private async Task ValidatedEntry()
        {
            //Page.DisplayAlert()
        }

        private ViewFlipper _cardSimulationInfo;
        public ViewFlipper CardSimulationInfo
        {
            set { SetProperty(ref _cardSimulationInfo, value); }
            get { return _cardSimulationInfo; }
        }

        private StackLayout _panelNumber;
        public StackLayout PanelNumber
        {
            set { SetProperty(ref _panelNumber, value); }
            get { return _panelNumber; }
        }

        private StackLayout _panelName;
        public StackLayout PanelName
        {
            set { SetProperty(ref _panelName, value); }
            get { return _panelName; }
        }

        private StackLayout _panelValid;
        public StackLayout PanelValid
        {
            set { SetProperty(ref _panelValid, value); }
            get { return _panelValid; }
        }

        private StackLayout _panelCvv;
        public StackLayout PanelCvv
        {
            set { SetProperty(ref _panelCvv, value); }
            get { return _panelCvv; }
        }

        private Entry _entryNumber;
        public Entry EntryNumber
        {
            set { SetProperty(ref _entryNumber, value); }
            get { return _entryNumber; }
        }

        private Entry _entryName;
        public Entry EntryName
        {
            set { SetProperty(ref _entryName, value); }
            get { return _entryName; }
        }

        private Entry _entryValid;
        public Entry EntryValid
        {
            set { SetProperty(ref _entryValid, value); }
            get { return _entryValid; }
        }

        private Entry _entryCvv;
        public Entry EntryCvv
        {
            set { SetProperty(ref _entryCvv, value); }
            get { return _entryCvv; }
        }

        private Image _logoCreditCard;
        public Image LogoCreditCard
        {
            set { SetProperty(ref _logoCreditCard, value); }
            get { return _logoCreditCard; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
