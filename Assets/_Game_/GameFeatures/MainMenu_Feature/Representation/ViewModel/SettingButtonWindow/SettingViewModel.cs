using WKosArch;

public class SettingViewModel : WKosArch.WindowViewModel, IHomeWindow
{
    public void OpenSettingMenuWindow()
    {
        UI.Show<MainMenuWindowModel>();
    }

    public void OpenQuitGame()
    {
        
    }
} 