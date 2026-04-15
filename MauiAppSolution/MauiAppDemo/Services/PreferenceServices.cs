using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppDemo.Services
{
    public class PreferenceServices : IPreferenceServices
    {
        //do not want to retype throughout the class the same string over and over again
        //tip: create a constant variable.
        private const string ThemeKey = "app_theme"; 
        private const string FontSizeKey = "font_size"; 

        public event Action? OnChange; //interface

        //changing of preference can ONLY be done within this class!!!!
        public string Theme { get; private set; } = "light"; //interface
        public int FontSize { get; private set; } = 16; //interface

        public bool IsDark => Theme == "dark"; //interface

        public void Load() //interface
        {
            //get current setting
            Theme = Preferences.Get(ThemeKey, "light");
            FontSize = Preferences.Get(FontSizeKey, 16);
        }

        public void SetTheme(bool dark) //interface
        {
            //light or dark?
            Theme = dark ? "dark" : "light";
            //set preference
            Preferences.Set(ThemeKey, Theme);
            //signal system of change
            Notify();
        }

        public void SetFontSize(int size) //interface
        {
            FontSize = size;
            Preferences.Set(FontSizeKey, size);
            Notify();
        }

        //signal system of change
        //OnChange is an event variable
        private void Notify() => OnChange?.Invoke();
    }
}
