using System.Linq;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        // split string and convert to int
        public static int SplitFirstInt(this string s)
        {
            return int.Parse(s.Split(':').First());
        }

        public static int SplitLastInt(this string s)
        {
            return int.Parse(s.Split(':').Last());
        }
    }
}
