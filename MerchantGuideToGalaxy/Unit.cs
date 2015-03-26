namespace MerchantGuideToGalaxy
{
    public class Unit
    {
        public double Value;
        public override string ToString()
        {
            return Value.ToString();
        }

        public static Unit operator *(Unit c1, Unit c2)
        {
            return new Unit { Value = c1.Value * c2.Value };
        }
    }
}