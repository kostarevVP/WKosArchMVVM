using Lukomor;
using WKosArch.UIService.Views.Windows;

public class SettingViewModel : Lukomor.WindowViewModel, IHomeWindow
{
    public void OpenSettingMenuWindow()
    {
        UI.Show<MainMenuWindowModel>();
    }

    public void OpenQuitGame()
    {
        
    }
} 