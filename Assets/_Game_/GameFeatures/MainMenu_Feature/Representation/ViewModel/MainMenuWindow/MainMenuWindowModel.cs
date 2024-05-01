using WKosArch;

public class MainMenuWindowModel : WindowViewModel
{
    public void OpenAboutUsWindow()
    {
        UI.Show<AboutUsWindowModel>();
    }

    public void OpenAudioSettingsWindow()
    {

    }

    public void OpenQuitWindow() => 
        UI.Show<QuitGameWindowModel>(false);

    public void OpenRestartWindow() => 
        UI.Show<RestartWindowModel>(false);
}
