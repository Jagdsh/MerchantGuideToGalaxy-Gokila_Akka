using System;
using System.Text.RegularExpressions;
using MerchantGuideToGalaxy.Commodities;
using MerchantGuideToGalaxy.Validation;

namespace MerchantGuideToGalaxy
{
    public class RequestParser
    {
        private readonly RequestValidationProviders validationProviders;
        //private const string pattern = @"(?<Request>(HOW\sMUCH)|(HOW\sMANY\sCREDITS))(?:\sIS\s)(?<Numeral>(?=.*\bGLOB|PISH|PROK|TEGJ\b).*)(?<Commodity>SILVER|IRON|GOLD)";
        private const string pattern = @"(?<Request>(HOW\sMUCH)|(HOW\sMANY\sCREDITS))(?:\sIS\s)(?<Numeral>.*?)(?<Commodity>SILVER|IRON|GOLD|\?$)";

        public RequestParser(RequestValidationProviders validationProviders)
        {
            this.validationProviders = validationProviders;
        }

        public PurchaseRequest Parse(string request)
        {
            var match = Regex.Match(request, pattern);
            var romanNumeral = match.Groups["Numeral"].ToString().Trim();
            var comodity = match.Groups["Commodity"].ToString();

            validationProviders.GetVadlidationRules().ForEach(validator => validator.Validate(romanNumeral));

            Commodity commodity = GetCommodity(comodity);
            return new PurchaseRequest { Commodity = commodity, RomanNumeral = new RomanNumeral { Value = romanNumeral.Trim() }, IsValid = true };
        }

        private Commodity GetCommodity(string comodity)
        {
            switch (comodity)
            {
                case "SILVER":
                    return new Silver();
                case "IRON":
                    return new Iron();
                case "GOLD":
                    return new Gold();
                default:
                    return null;
            }
        }
    }
}