using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppDemo.Services
{
    public class PreferenceServices : IPreferenceServices
    {
        private const string ThemeKey = "app_theme";
      //  private const string FontSizeKey = "font_size";

        public event Action? OnChange;

        //changing of preference can ONLY be done within this class!!!!
        public string Theme { get; private set; } = "light";
       // public int FontSize { get; private set; } = 16;

        public bool IsDark => Theme == "dark";

        public void Load()
        {
            //get current setting
            Theme = Preferences.Get(ThemeKey, "light");
        //    FontSize = Preferences.Get(FontSizeKey, 16);
        }

        public void SetTheme(bool dark)
        {
            //light or dark?
            Theme = dark ? "dark" : "light";
            //set preference
            Preferences.Set(ThemeKey, Theme);
            //signal system of change
            Notify();
        }

        //public void SetFontSize(int size)
        //{
        //    FontSize = size;
        //    Preferences.Set(FontSizeKey, size);
        //    Notify();
        //}

        //signal system of change
        //OnChange is an event variable
        private void Notify() => OnChange?.Invoke();
    }
}
