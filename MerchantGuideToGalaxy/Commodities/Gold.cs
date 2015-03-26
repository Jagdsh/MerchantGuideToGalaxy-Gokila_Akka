namespace MerchantGuideToGalaxy.Commodities
{
    public class Gold : Commodity
    {
        public override Unit GetUnitValue()
        {
            return new Unit { Value = 14450 };
        }
    }
}