using ColorBlend.Models;
using System.Text.RegularExpressions;

namespace ColorBlend.Services
{
    public class ColorService
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
            MatchCollection matchCollection =
                Regex.Matches(ColorsSet.C1,
                @"rgb[(](?<R>[0-9]*), (?<G>[0-9]*), (?<B>[0-9]*)(.*)|rgba[(](?<R>[0-9]*), (?<G>[0-9]*), (?<B>[0-9]*), (?<A>[0-9]*\.?[0-9]*)(.*)");
            MatchCollection matchCollection2 =
                Regex.Matches(ColorsSet.C2,
                @"rgb[(](?<R>[0-9]*), (?<G>[0-9]*), (?<B>[0-9]*)(.*)|rgba[(](?<R>[0-9]*), (?<G>[0-9]*), (?<B>[0-9]*), (?<A>[0-9]*\.?[0-9]*)(.*)");

            A = 0;
            A2 = 0;
            foreach (Match match in matchCollection)
            {
                R = float.Parse(match.Groups["R"].ToString());
                G = float.Parse(match.Groups["G"].ToString());
                B = float.Parse(match.Groups["B"].ToString());
                float.TryParse(match.Groups["A"].ToString().Replace(".", ","), out A);
                if (A == 0)
                    A = 1;
            }
            foreach (Match match in matchCollection2)
            {
                R2 = float.Parse(match.Groups["R"].ToString());
                G2 = float.Parse(match.Groups["G"].ToString());
                B2 = float.Parse(match.Groups["B"].ToString());
                float.TryParse(match.Groups["A"].ToString().Replace(".", ","), out A2);
                if (A2 == 0)
                    A2 = 1;
            }
            ColorsSet.C3 = "rgba("
                + Math.Round((R + R2) / 2) + ", "
                + Math.Round((G + G2) / 2) + ", "
                + Math.Round((B + B2) / 2) + ", "
                + Math.Round((A + A2) / 2, 2).ToString().Replace(",", ".") + ")";
            return ColorsSet;
        }

        #endregion
    }
}
