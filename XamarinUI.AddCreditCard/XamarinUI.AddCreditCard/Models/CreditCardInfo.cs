using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinUI.AddCreditCard.Models
{
    public class CreditCardInfo
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

        public string IconFromType => Type.GetLogo();

        public static List<CreditCardInfo> GetData()
        {
            return new List<CreditCardInfo>
            {
                new CreditCardInfo
                {
                    MaskedNumber = "4444********4444",
                    Type = CardType.MasterCard,
                    PrimaryDarkColor = Color.FromHex("#C2185B"),
                    PrimaryColor = Color.FromHex("#E91E63")
                },
                new CreditCardInfo
                {
                    MaskedNumber = "1111********4444",
                    Type = CardType.Discover,
                    PrimaryDarkColor = Color.FromHex("#00796B"),
                    PrimaryColor = Color.FromHex("#009688")
                },
                new CreditCardInfo
                {
                    MaskedNumber = "4444********6666",
                    Type = CardType.Visa,
                    PrimaryDarkColor = Color.FromHex("#7B1FA2"),
                    PrimaryColor = Color.FromHex("#9C27B0")
                },
                new CreditCardInfo
                {
                    MaskedNumber = "7777********7777",
                    Type = CardType.AmericanExpress,
                    PrimaryDarkColor = Color.FromHex("#1976D2"),
                    PrimaryColor = Color.FromHex("#2196F3")
                },
                new CreditCardInfo
                {
                    MaskedNumber = "2222********5555",
                    Type = CardType.Discover,
                    PrimaryDarkColor = Color.FromHex("#388E3C"),
                    PrimaryColor = Color.FromHex("#4CAF50")
                },
                new CreditCardInfo
                {
                    MaskedNumber = "3333********4444",
                    Type = CardType.JCB,
                    PrimaryDarkColor = Color.FromHex("#512DA8"),
                    PrimaryColor = Color.FromHex("#673AB7")
                }
            };
        }
    }

    public static class CreditCartInfoExtention
    {
        public static string GetLogo(this CardType cardType)
        {
            switch (cardType)
            {
                case CardType.MasterCard:
                    return "\uf1f1";
                case CardType.Visa:
                    return "\uf1f0";
                case CardType.AmericanExpress:
                    return "\uf1f3";
                case CardType.Discover:
                    return "\uf1f2";
                case CardType.JCB:
                    return "\uf24b";
            }

            return "";
        }
    }


    public enum CardType
    {
        Undefined, MasterCard, Visa, AmericanExpress, Discover, JCB
    };
}
