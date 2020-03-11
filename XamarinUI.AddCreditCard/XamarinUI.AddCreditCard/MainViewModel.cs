using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinUI.AddCreditCard.extention;
using XamarinUI.AddCreditCard.help;

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
            Number = new EntryPage
            {
                Panel = new StackLayout
                {
                    IsVisible = true
                },
                BorderSpot = new Frame
                {
                    BorderColor = Color.Yellow
                }
            };

            Name = new EntryPage
            {
                Panel = new StackLayout
                {
                    IsVisible = false
                }
            };

            Valid = new EntryPage
            {
                Panel = new StackLayout
                {
                    IsVisible = false
                }
            };

            Cvv = new EntryPage
            {
                Panel = new StackLayout
                {
                    IsVisible = false
                }
            };

            ButtonText = new Label
            {
                Text = "Next"
            };

            CardSimulationInfo = new ViewFlipper();

            LogoCreditCard = new Image();
        }

        public Command NextCommand => new Command(() =>
        {
            if (Number.Panel.IsVisible)
            {
                if (!ValidatedNumberNext())
                    return;

                Number.Panel.IsVisible = false;
                Number.BorderSpot.BorderColor = Color.Transparent;
                Name.Panel.IsVisible = !Number.Panel.IsVisible;
                Name.BorderSpot.BorderColor = Color.Yellow;
                return;
            }

            if (Name.Panel.IsVisible)
            {
                if (!ValidatedNameNext())
                    return;

                Name.Panel.IsVisible = false;
                Name.BorderSpot.BorderColor = Color.Transparent;
                Valid.Panel.IsVisible = !Name.Panel.IsVisible;
                Valid.BorderSpot.BorderColor = Color.Yellow;
                return;
            }

            if (Valid.Panel.IsVisible)
            {
                if (!ValidatedValidNext())
                    return;

                Valid.Panel.IsVisible = false;
                Valid.BorderSpot.BorderColor = Color.Transparent;
                Cvv.Panel.IsVisible = !Valid.Panel.IsVisible;
                Cvv.BorderSpot.BorderColor = Color.Yellow;
                CardSimulationInfo.FlipState = extention.FlipState.Back;

                ButtonText.Text = "Done";

                return;
            }

            if (Cvv.Panel.IsVisible)
            {
                if (!ValidatedCvvNext())
                    return;

                Cvv.Panel.IsVisible = false;
                Cvv.BorderSpot.BorderColor = Color.Transparent;
                Number.Panel.IsVisible = !Cvv.Panel.IsVisible;
                Number.BorderSpot.BorderColor = Color.Yellow;
                CardSimulationInfo.FlipState = extention.FlipState.Front;

                ButtonText.Text = "Next";

                Save();
            }
        });

        private void Save()
        {

        }

        private bool ValidatedNumberNext()
        {
            Number.ErrorMsg.IsVisible = false;

            if (string.IsNullOrEmpty(Number?.Entry?.Text) || !Number.Entry.Text.Length.Equals(19) || !Number.Entry.Text.IsACreditCardValid())
            {
                Number.ErrorMsg.Text = "Invalid credit card number";
                Number.ErrorMsg.IsVisible = true;
                return false;
            }

            return true;
        }

        private bool ValidatedNameNext()
        {
            Name.ErrorMsg.IsVisible = false;

            if (string.IsNullOrEmpty(Name?.Entry?.Text) || !Name.Entry.Text.Contains(" "))
            {
                Name.ErrorMsg.Text = "Invalid holder name";
                Name.ErrorMsg.IsVisible = true;
                return false;
            }

            return true;
        }

        private bool ValidatedValidNext()
        {
            Valid.ErrorMsg.IsVisible = false;

            if (string.IsNullOrEmpty(Valid?.Entry?.Text) || !Valid.Entry.Text.Length.Equals(5))
            {
                Valid.ErrorMsg.Text = "Invalid valid date";
                Valid.ErrorMsg.IsVisible = true;
                return false;
            }

            var invalidDateMsg = "";

            var monthValid = new List<string> { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };

            var yearValid = new List<string>();

            for (int i = DateTime.UtcNow.Year; i < DateTime.UtcNow.AddYears(15).Year; i++)
            {
                yearValid.Add(i.ToString().Substring(2, 2));
            }

            if (!monthValid.Contains(Valid.Entry.Text.Substring(0, 2)))
                invalidDateMsg += "Invalid month\n";

            if (!yearValid.Contains(Valid.Entry.Text.Substring(3, 2)))
                invalidDateMsg += "Invalid year";

            if (!string.IsNullOrEmpty(invalidDateMsg))
            {
                Valid.ErrorMsg.Text = invalidDateMsg;
                Valid.ErrorMsg.IsVisible = true;
                return false;
            }

            return true;
        }

        private bool ValidatedCvvNext()
        {
            Cvv.ErrorMsg.IsVisible = false;

            if (string.IsNullOrEmpty(Cvv?.Entry?.Text) || Cvv.Entry.Text.Length < 3)
            {
                Cvv.ErrorMsg.Text = "Invalid Cvv";
                Cvv.ErrorMsg.IsVisible = true;
                return false;
            }

            return true;
        }

        private ViewFlipper _cardSimulationInfo;
        public ViewFlipper CardSimulationInfo
        {
            set { SetProperty(ref _cardSimulationInfo, value); }
            get { return _cardSimulationInfo; }
        }

        private EntryPage _number;
        public EntryPage Number
        {
            set { SetProperty(ref _number, value); }
            get { return _number; }
        }

        private EntryPage _name;
        public EntryPage Name
        {
            set { SetProperty(ref _name, value); }
            get { return _name; }
        }

        private EntryPage _valid;
        public EntryPage Valid
        {
            set { SetProperty(ref _valid, value); }
            get { return _valid; }
        }

        private EntryPage _cvv;
        public EntryPage Cvv
        {
            set { SetProperty(ref _cvv, value); }
            get { return _cvv; }
        }

        private Image _logoCreditCard;
        public Image LogoCreditCard
        {
            set { SetProperty(ref _logoCreditCard, value); }
            get { return _logoCreditCard; }
        }

        private Label _buttonText;
        public Label ButtonText
        {
            set { SetProperty(ref _buttonText, value); }
            get { return _buttonText; }
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

    public class EntryPage
    {
        public EntryPage()
        {
            Panel = new StackLayout();
            Entry = new Entry();
            ErrorMsg = new Label();
            BorderSpot = new Frame();
        }

        public StackLayout Panel { get; set; }

        public Entry Entry { get; set; }

        public Label ErrorMsg { get; set; }

        public Frame BorderSpot { get; set; }
    }
}
