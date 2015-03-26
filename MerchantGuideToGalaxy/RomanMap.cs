using System.Collections.Generic;

namespace MerchantGuideToGalaxy
{
    public class RomanMap
    {
        public static Dictionary<char, int> RomanNumeralMap = new Dictionary<char, int>
        {
            {'I', 1},{'V', 5},{'X', 10},{'L', 50},{'C', 100},{'D', 500},{'M', 1000}
        };

        public static Dictionary<string, char> WordRomanMap = new Dictionary<string, char>
        {
            {"GLOB",'I'},{"PROK",'V'},{"PISH",'X'},{"TEGJ",'L'}
        };

        public static Dictionary<char, string> RomanWordMap = new Dictionary<char, string>
        {
            {'I',"GLOB"},{'V',"PROK"},{'X',"PISH"},{'L',"TEGJ"}
        };

        public const string NoIdeaMessage = "I have no idea what you are talking about";

    }
}