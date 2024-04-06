using Lukomor;
using WKosArch.Common.DIContainer;
using WKosArch.UIService.Views.Windows;

public class SettingViewModel : Lukomor.WindowViewModel, IHomeWindow
{
    public void OpenSettingMenuWindow()
    {
        UI.Show<MainMenuViewModel>();
    }

    public void OpenSoundSettingWindow()
    {
        
    }

    public void RestartLevel()
    {
       
    }
    public void QuitGame()
    {

    }
} 