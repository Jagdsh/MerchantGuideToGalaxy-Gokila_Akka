namespace MerchantGuideToGalaxy.Commodities
{
    public class Silver : Commodity
    {
        public override Unit GetUnitValue()
        {
            return new Unit { Value = 17 };
        }
    }
}