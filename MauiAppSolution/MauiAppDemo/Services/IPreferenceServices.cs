using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppDemo.Services
{
    public interface IPreferenceServices
    {
        string Theme { get; }
        int FontSize { get; } //student to practice

        bool IsDark { get; }

        event Action? OnChange;

        void Load();

        void SetTheme(bool dark);
        void SetFontSize(int size); //student to practice
    }
}
