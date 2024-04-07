
using Lukomor;

public partial class MainMenuWindowModel : WindowViewModel
{
    public void OpenAboutWindow() =>
        UI.Show<AboutUsWindowModel>();

    public void OpenQuitGameWindow() =>
        UI.Show<QuitGameWindowModel>();

    public void OpenRestartWindow() =>
        UI.Show<RestartWindowModel>();

    //public void OpenSoundWindow() =>
    //    UI.Show<AudioSettingWindowModel>();
}
