using WKosArch;

public class QuitGameWindowModel : WindowViewModel
{
    private ISaveLoadFeature _saveLoadService => DiContainer.Resolve<ISaveLoadFeature>();

    public void CloseAplication()
    {
        _saveLoadService.SaveProgress();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
