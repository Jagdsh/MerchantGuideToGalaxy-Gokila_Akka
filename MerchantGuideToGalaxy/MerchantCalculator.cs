using System;
using MerchantGuideToGalaxy.Exceptions;

namespace MerchantGuideToGalaxy
{
    public class MerchantCalculator
    {
        private readonly RequestParser parser;
        private readonly RomanNumeralConvertor romanNumeralConvertor;

        public MerchantCalculator(RequestParser parser, RomanNumeralConvertor romanNumeralConvertor)
        {
            this.parser = parser;
            this.romanNumeralConvertor = romanNumeralConvertor;
        }

        public string Calculate(string request)
        {
            var purchaseRequest = GetPurchaseRequest(request.ToUpper());
            if (!purchaseRequest.IsValid)
                return purchaseRequest.ValidationResult;

            var units = romanNumeralConvertor.Convert(purchaseRequest.RomanNumeral);
            if (purchaseRequest.Commodity == null)
            {
                return string.Format("{0} is {1}", purchaseRequest.RomanNumeral.Value, units);
            }
            else
            {
                var credits = units * purchaseRequest.Commodity.GetUnitValue();
                return string.Format("{0} {1} is {2} Credits", purchaseRequest.RomanNumeral.Value, purchaseRequest.Commodity.GetType().Name,
                    credits);
            }
        }

        private PurchaseRequest GetPurchaseRequest(string request)
        {
            var purchaseRequest = new PurchaseRequest { IsValid = false };
            try
            {
                purchaseRequest = parser.Parse(request);
            }
            catch (InvalidRomanNumeralException romanNumeralException)
            {
                purchaseRequest.ValidationResult = romanNumeralException.Message;
            }
            catch (InvalidRequestException requestException)
            {
                purchaseRequest.ValidationResult = requestException.Message;
            }
            catch
            {
                purchaseRequest.ValidationResult = RomanMap.NoIdeaMessage;
            }
            return purchaseRequest;
        }
    }
}