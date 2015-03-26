namespace MerchantGuideToGalaxy.Commodities
{
    public class Iron : Commodity
    {
        public override Unit GetUnitValue()
        {
            return new Unit { Value = 195.5 };
        }
    }
}