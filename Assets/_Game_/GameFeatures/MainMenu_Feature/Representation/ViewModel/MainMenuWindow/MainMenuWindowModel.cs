using WKosArch;
using WKosArch.Sound_Feature;

public class MainMenuWindowModel : WindowViewModel
{
    public void OpenAboutUsWindow() => 
        UI.Show<AboutUsWindowModel>();

    public void OpenAudioSettingsWindow() => 
        UI.Show<AudioSettingViewModel>();

    public void OpenQuitWindow() =>
        UI.Show<QuitGameWindowModel>(false);

    public void OpenRestartWindow() =>
        UI.Show<RestartWindowModel>(false);
}
