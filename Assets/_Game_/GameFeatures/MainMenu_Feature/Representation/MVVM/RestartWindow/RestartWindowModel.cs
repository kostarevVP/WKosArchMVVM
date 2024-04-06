using WKosArch.Services.Scenes;
using WKosArch.UIService.Views.Windows;

public class RestartWindowModel : WindowViewModel
{
    private ISaveLoadFeature _saveLoadService => DiContainer.Resolve<ISaveLoadFeature>();
    private ISceneManagementFeature _sceneManagementService => DiContainer.Resolve<ISceneManagementFeature>();

    internal void RestartGame()
    {
        _saveLoadService.SaveProgress();
        _sceneManagementService.ReloadScene();
    }
}
