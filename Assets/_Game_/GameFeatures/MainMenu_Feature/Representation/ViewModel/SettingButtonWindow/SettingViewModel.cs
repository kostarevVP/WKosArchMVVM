using WKosArch;

public class SettingViewModel : WindowViewModel, IHomeWindow
{
    public void OpenSettingMenuWindow()
    {
        UI.Show<MainMenuWindowModel>();
    }

    public void OpenQuitGame()
    {
        UI.Show<QuitGameWindowModel>();
    }
} 