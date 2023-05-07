using ColorBlend.Models;
using ColorBlend.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ColorBlend.ViewModels
{
    public class ColorsBasicViewModel : INotifyPropertyChanged, IColorsViewModel
    {
        #region Fields
        private string color = "rgb(0, 0, 0)";
        private string color2 = "rgb(0, 0, 0)";
        private string colorMixed = "rgb(0, 0, 0)";
        private List<ColorsSet> colorsSetList = new();
        private bool isBusy = false;
        private BlendService colorService = new();
        private ColorsSet colorsSet = new();
        #endregion

        #region Propereties
        public string Color1
        {
            get => color;
            set
            {
                color = value;
                colorsSet.Color1 = color;
                colorsSet = colorService.MixColors(colorsSet);
                ColorMixed = colorsSet.ColorMixed;
                OnPropertyChanged();
            }
        }
        public string Color2
        {
            get => color2;
            set
            {
                color2 = value;
                colorsSet.Color2 = color2;
                colorsSet = colorService.MixColors(colorsSet);
                ColorMixed = colorsSet.ColorMixed;
                OnPropertyChanged();
            }
        }
        public string ColorMixed
        {
            get => colorMixed;
            set
            {
                colorMixed = value;
                OnPropertyChanged();
            }
        }
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }
        public List<ColorsSet> ColorsSetList
        {
            get => colorsSetList;
            private set
            {
                colorsSetList = value;
                OnPropertyChanged();
            }
        }
        public ColorsSet ColorsSet
        {
            get => colorsSet;
            set
            {
                colorsSet = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public ColorsBasicViewModel()
        {
            colorsSet.Color1 = Color1;
            colorsSet.Color2 = Color2;
            colorsSet.ColorMixed = ColorMixed;
        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        public void SaveColorsSet(ColorsSet colorsSet)
        {
            IsBusy = true;
            colorsSet.TimeMixed = DateTime.Now.ToLocalTime();
            if (colorsSet.Id.Equals(Guid.Empty))
            {
                colorsSet.Id = Guid.NewGuid();
            }
            else
            {
                colorsSetList.Remove(colorsSet);
            }
            colorsSet = colorService.MixColors(colorsSet);
            ColorMixed = colorsSet.ColorMixed;
            colorsSetList.Add(colorsSet);
            OnPropertyChanged(nameof(ColorsSetList));
            IsBusy = false;
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
