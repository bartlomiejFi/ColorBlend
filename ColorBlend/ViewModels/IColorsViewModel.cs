using ColorBlend.Models;
using System.ComponentModel;

namespace ColorBlend.ViewModels
{
    public interface IColorsViewModel
    {
        bool IsBusy { get; set; }
        ColorsSet ColorsSet { get; set; }
        List<ColorsSet> ColorsSetList { get; }

        event PropertyChangedEventHandler PropertyChanged;

        string Color1 { get; set; }

        string Color2 { get; set; }

        string ColorMixed { get; set; }
        void SaveColorsSet(ColorsSet colorsSet);
    }
}
