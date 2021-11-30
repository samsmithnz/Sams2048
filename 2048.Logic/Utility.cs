using System.Text;

namespace _2048.Logic
{
    public static class Utility
    {
        public static int GenerateRandomNumber(int minValue, int maxValue, int? seed = null)
        {
            if (seed == null)
            {
                Random rand = new();
                return rand.Next(minValue, maxValue);
            }
            else
            {
                Random rand = new((int)seed);
                return rand.Next(minValue, maxValue);
            }
        }

        public static string AddDividingLine(int length)
        {
            StringBuilder sb = new();
            for (int y = 0; y < length; y++)
            {
                sb.Append("--");
            }
            sb.Append('-');
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
