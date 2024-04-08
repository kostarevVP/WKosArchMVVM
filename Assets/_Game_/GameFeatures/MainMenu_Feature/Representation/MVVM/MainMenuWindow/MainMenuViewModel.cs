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
        bool closeThisViewModel = false;
        UI.Show<QuitGameWindowModel>(closeThisViewModel);
    }

    public void OpenRestartWindow()
    {
        UI.Show<RestartWindowModel>();
    }
}
