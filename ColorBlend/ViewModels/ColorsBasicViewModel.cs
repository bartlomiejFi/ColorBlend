using ColorBlend.Models;
using ColorBlend.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ColorBlend.ViewModels
{
    public class ColorsBasicViewModel : INotifyPropertyChanged, IColorsViewModel
    {
        #region Fields
        private string color;
        private string color2;
        private string color3;
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
                OnPropertyChanged();
            }
        }
        public string Color3
        {
            get => color3;
            set
            {
                color3 = value;
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

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        public void MixAndSaveColorsSet(ColorsSet colorsSet)
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
            Color3 = colorsSet.C3;

            colorsSetList.Add(colorsSet);
            OnPropertyChanged(nameof(ColorsSetList));
            IsBusy = false;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
