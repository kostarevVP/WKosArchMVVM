using WKosArch;
using WKosArch.Services.Scenes;

public class RestartWindowModel : WindowViewModel
{
    private ISaveLoadFeature _saveLoadService => DiContainer.Resolve<ISaveLoadFeature>();
    private ISceneManagementFeature _sceneManagementService => DiContainer.Resolve<ISceneManagementFeature>();

    public void RestartGame()
    {
        _saveLoadService.SaveProgress();
        _sceneManagementService.ReloadScene();
    }
}
