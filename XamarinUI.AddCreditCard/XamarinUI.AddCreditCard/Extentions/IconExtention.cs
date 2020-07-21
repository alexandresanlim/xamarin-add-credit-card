using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinUI.AddCreditCard.Extentions
{
    public static class IconExtention
    {
        public static string GetIconFontFamily(FontAwesomeType type = FontAwesomeType.solid)
        {
            var name = "";

            switch (type)
            {
                default:
                    IsAndroid(
                      () => name = "fa-solid-900.ttf#Font Awesome 5 Free",
                      () => name = "Font Awesome 5 Free");
                    break;

                case FontAwesomeType.solid:
                    IsAndroid(
                     () => name = "fa-solid-900.ttf#Font Awesome 5 Free",
                     () => name = "Font Awesome 5 Free");
                    break;

                case FontAwesomeType.brand:
                    IsAndroid(
                     () => name = "fa-brands-400.ttf#Font Awesome 5 Brands",
                     () => name = "Font Awesome 5 Brands");
                    break;
            }

            return name;
        }

        public enum FontAwesomeType
        {
            solid,
            brand
        }

        private static void IsAndroid(Action android, Action others)
        {
            if (Device.RuntimePlatform == Device.Android)
                android.Invoke();
            else
                others.Invoke();

        }
    }
}
