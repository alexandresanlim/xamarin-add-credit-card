using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace XamarinUI.AddCreditCard.Controls
{
    public class CustomCard : Frame
    {
        public CustomCard()
        {
            HasShadow = !(Device.RuntimePlatform == Device.iOS);
            CornerRadius = 20;
            BackgroundColor = (Color)App.Current.Resources.FirstOrDefault(x => x.Key.Equals("accent")).Value;
        }
    }
}
