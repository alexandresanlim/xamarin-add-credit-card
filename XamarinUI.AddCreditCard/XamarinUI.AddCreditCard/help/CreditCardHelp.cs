using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XamarinUI.AddCreditCard.help
{
    public static class CreditCardHelp
    {
        public enum CardType
        {
            Undefined, MasterCard, Visa, AmericanExpress, Discover, JCB
        };

        public static bool IsACreditCardValid(this string cardNumber)
        {
            return cardNumber.GetCardTypeFromRegularExpression() != CardType.Undefined;
        }

        public static CardType GetCardTypeFromRegularExpression(this string cardNumber)
        {
            //https://www.regular-expressions.info/creditcard.html
            if (Regex.Match(cardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
            {
                return CardType.Visa;
            }

            if (Regex.Match(cardNumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
            {
                return CardType.MasterCard;
            }

            if (Regex.Match(cardNumber, @"^3[47][0-9]{13}$").Success)
            {
                return CardType.AmericanExpress;
            }

            if (Regex.Match(cardNumber, @"^6(?:011|5[0-9]{2})[0-9]{12}$").Success)
            {
                return CardType.Discover;
            }

            if (Regex.Match(cardNumber, @"^(?:2131|1800|35\d{3})\d{11}$").Success)
            {
                return CardType.JCB;
            }

            return CardType.Undefined;
        }

        public static CardType GetCardType(this string cardNumber)
        {
            if (cardNumber.StartsWith("4"))
            {
                return CardType.Visa;
            }

            if (cardNumber.StartsWith("5"))
            {
                return CardType.MasterCard;
            }

            if (cardNumber.StartsWith("3"))
            {
                return CardType.AmericanExpress;
            }

            if (cardNumber.StartsWith("6"))
            {
                return CardType.Discover;
            }

            if (cardNumber.StartsWith("35"))
            {
                return CardType.JCB;
            }

            return CardType.Undefined;
        }

        public static string GetLogoUrl(this CardType cardType)
        {
            switch (cardType)
            {
                
                case CardType.MasterCard:
                    return "https://brand.mastercard.com/content/dam/mccom/brandcenter/thumbnails/mastercard_circles_92px_2x.png";
                case CardType.Visa:
                    return "https://usa.visa.com/dam/VCOM/regional/lac/ENG/Default/Partner%20With%20Us/Payment%20Technology/visapos/full-color-800x450.jpg";
                case CardType.AmericanExpress:
                    return "https://about.americanexpress.com/sites/americanexpress.newshq.businesswire.com/files/imagecache/logo_fullnode_thumb/logo/image/AXP_BlueBoxLogo_EXTRALARGEscale_RGB_DIGITAL_1600x1600.png";
                case CardType.Discover:
                    return "https://www.discover.com/company/images/newsroom/media-downloads/discover.png";
                case CardType.JCB:
                    return "http://www.jcbeurope.eu/about/emblem_slogan/images/index/logo_img01.jpg";
                case CardType.Undefined:
                default:
                    return "";
            }
        }
    }
}
