using Lukomor;
using System;
using WKosArch.Extentions;

public class SettingViewModel : UiViewModel
{
    public IObservable<float> MusicValue { get; }
    public IObservable<int> IntValure { get; }
    public IObservable<bool> BoolValue { get; }
    public void OpenSettingMenuWindow()
    {
        Log.PrintYellow("SettingViewModel OpenSettingMenuWindow");
    }

    public void ReadInputValue(float value)
    {

    }
} 