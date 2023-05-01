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

        string Color { get; set; }

        string Color2 { get; set; }

        string Color3 { get; set; }
        void MixAndSaveColorsSet(ColorsSet colorsSet);
    }
}
