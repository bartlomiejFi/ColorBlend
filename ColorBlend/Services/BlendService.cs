using ColorBlend.Models;
using System.Text.RegularExpressions;

namespace ColorBlend.Services
{
    public class BlendService
    {
        #region Fields
        float R;
        float G;
        float B;
        float A;
        float R2;
        float G2;
        float B2;
        float A2;
        #endregion

        #region Events

        #endregion

        #region Properties

        ColorsSet ColorsSet = new ColorsSet();

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public ColorsSet MixColors(ColorsSet colorsSet)
        {
            ColorsSet = colorsSet;

            A = 0;
            A2 = 0;

            RgbRead(ColorsSet.Color1, out R, out G, out B, out A);
            RgbRead(ColorsSet.Color2, out R2, out G2, out B2, out A2);

            var Rmixed = Math.Round((R + R2) / 2);
            var Gmixed = Math.Round((G + G2) / 2);
            var Bmixed = Math.Round((B + B2) / 2);
            var Amixed = Math.Round((A + A2) / 2, 2).ToString().Replace(",", ".");

            ColorsSet.ColorMixed = "rgba("
                + Rmixed + ", "
                + Gmixed + ", "
                + Bmixed + ", "
                + Amixed + ")";

            ColorsSet.MixingResultInfo = "R: " + Rmixed + "  G: " + Gmixed + "  B: " + Bmixed + "  A: " + Amixed;
            ColorsSet.Color1Info = "R: " + R + "  G: " + G + "  B: " + B + "  A: " + A;
            ColorsSet.Color2Info = "R: " + R2 + "  G: " + G2 + "  B: " + B2 + "  A: " + A2;

            return ColorsSet;
        }

        private void RgbRead(string color, out float R, out float G, out float B, out float A)
        {
            var RgbPattern = @"rgb[(](?<R>[0-9]*), (?<G>[0-9]*), (?<B>[0-9]*)(.*)|rgba[(](?<R>[0-9]*), (?<G>[0-9]*), (?<B>[0-9]*), (?<A>[0-9]*\.?[0-9]*)(.*)";

            R = 0;
            G = 0;
            B = 0;
            A = 0;

            MatchCollection matchCollection = Regex.Matches(color, RgbPattern);

            foreach (Match match in matchCollection)
            {
                R = float.Parse(match.Groups["R"].ToString());
                G = float.Parse(match.Groups["G"].ToString());
                B = float.Parse(match.Groups["B"].ToString());
                float.TryParse(match.Groups["A"].ToString().Replace(".", ","), out A);
                if (A == 0)
                    A = 1;
            }
        }
        #endregion
    }
}
