using Lukomor;
using WKosArch.Extentions;

public class SettingViewModel : WindowViewModel
{
    public void OpenSettingMenuWindow()
    {
        Log.PrintYellow("SettingViewModel OpenSettingMenuWindow");
        UI.Show<MainMenuViewModel>();
    }
} 