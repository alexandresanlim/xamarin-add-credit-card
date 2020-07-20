using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace XamarinUI.AddCreditCard.Models
{
    public class CreditCartInfo
    {
        public string MaskedNumber { get; set; }

        /// <summary>
        /// Master Card, Visa e etc...
        /// </summary>
        public CardType Type { get; set; }

        public string TypeAndMasked => "(" + Type + ") " + MaskedNumber;

        public string TypeString => Type.ToString();

        public Color PrimaryColor { get; set; }

        public Color PrimaryDarkColor { get; set; }

        public DateTime Valid => DateTime.Now.AddYears(4);

        public string ValidPresentation => Valid.ToString("MM/yy");

        public static List<CreditCartInfo> GetData()
        {
            return new List<CreditCartInfo>
            {
                new CreditCartInfo
                {
                    MaskedNumber = "4444********4444",
                    Type = CardType.AmericanExpress,
                    PrimaryDarkColor = Color.FromHex("#C2185B"),
                    PrimaryColor = Color.FromHex("#E91E63")
                },
                new CreditCartInfo
                {
                    MaskedNumber = "1111********4444",
                    Type = CardType.AmericanExpress,
                    PrimaryDarkColor = Color.FromHex("#00796B"),
                    PrimaryColor = Color.FromHex("#009688")
                },
                new CreditCartInfo
                {
                    MaskedNumber = "4444********6666",
                    Type = CardType.AmericanExpress,
                    PrimaryDarkColor = Color.FromHex("#7B1FA2"),
                    PrimaryColor = Color.FromHex("#9C27B0")
                },
                new CreditCartInfo
                {
                    MaskedNumber = "7777********7777",
                    Type = CardType.AmericanExpress,
                    PrimaryDarkColor = Color.FromHex("#1976D2"),
                    PrimaryColor = Color.FromHex("#2196F3")
                },
                new CreditCartInfo
                {
                    MaskedNumber = "2222********5555",
                    Type = CardType.AmericanExpress,
                    PrimaryDarkColor = Color.FromHex("#388E3C"),
                    PrimaryColor = Color.FromHex("#4CAF50")
                },
                new CreditCartInfo
                {
                    MaskedNumber = "3333********4444",
                    Type = CardType.AmericanExpress,
                    PrimaryDarkColor = Color.FromHex("#512DA8"),
                    PrimaryColor = Color.FromHex("#673AB7")
                }
            };
        }
    }

    public enum CardType
    {
        Undefined, MasterCard, Visa, AmericanExpress, Discover, JCB
    };
}
