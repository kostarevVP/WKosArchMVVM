using Lukomor;

public class MainMenuViewModel : WindowViewModel
{
    public void OpenAboutUsWindow()
    {
        UI.Show<AboutUsWindowModel>();
    }

    public void OpenAudioSettingsWindow()
    {

    }

    public void OpenQuitWindow()
    {

    }

    public void OpenRestartWindow()
    {
        UI.Show<RestartWindowModel>();
    }
}
