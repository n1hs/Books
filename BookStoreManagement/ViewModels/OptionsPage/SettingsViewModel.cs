using MaterialDesignThemes.Wpf;
using System;
using MaterialDesignColors;
using System.Collections.Generic;

namespace BookStoreManagement.ViewModels.OptionsPage
{
    public class SettingsViewModel : ViewBaseModel
    {
        #region Properties
        private bool isDark;

        public bool IsDark
        {
            get { return isDark; }
            set { isDark = value;
                ModifyTheme(theme => theme.SetBaseTheme(isDark ? Theme.Dark : Theme.Light));
                NotifyOfPropertyChange("IsDark");
            }
        }

        public IEnumerable<Swatch> Swatches { get; }


        #endregion
        public SettingsViewModel()
        {
            Swatches = new SwatchesProvider().Swatches;
        }

        #region



        private void ModifyTheme(Action<ITheme> modificationAction)
        {
            PaletteHelper paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            paletteHelper.SetTheme(theme);
        }
        #endregion
    }

}
