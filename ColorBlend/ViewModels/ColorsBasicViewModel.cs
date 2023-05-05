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
        private ColorService colorService = new();
        private ColorsSet colorsSet = new();
        #endregion

        #region Propereties
        public string Color
        {
            get => color;
            set
            {
                color = value;
                colorsSet.C1 = color;
                colorsSet = colorService.MixColors(colorsSet);
                ColorMixed = colorsSet.C3;
                OnPropertyChanged();
            }
        }
        public string Color2
        {
            get => color2;
            set
            {
                color2 = value;
                colorsSet.C2 = color2;
                colorsSet = colorService.MixColors(colorsSet);
                ColorMixed = colorsSet.C3;
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
            colorsSet.C1 = Color;
            colorsSet.C2 = Color2;
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
