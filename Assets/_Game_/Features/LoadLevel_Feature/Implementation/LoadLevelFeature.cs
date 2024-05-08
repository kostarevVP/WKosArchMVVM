using WKosArch.Extentions;
using WKosArch.Services.Scenes;
using WKosArch.Services.UIService.UI;

namespace WKosArch.Features.LoadLevelFeature
{
    public class LoadLevelFeature : ILoadLevelFeature
    {
        private ISceneManagementFeature _sceneManagementService;
        private IUserInterface _ui;

        public LoadLevelFeature(ISceneManagementFeature sceneManagementService, IUserInterface ui)
        {
            _sceneManagementService = sceneManagementService;
            _ui = ui;

            Subscribe();
        }
        public void Dispose() 
        {
            Log.PrintRed("LoadLevelFeature Dispose");
            Unsubscribe();
        }

        private void Subscribe()
        {
            _sceneManagementService.OnSceneLoaded += SceneLoaded;
            _sceneManagementService.OnSceneStarted += SceneStarted;
        }

        private void Unsubscribe()
        {
            _sceneManagementService.OnSceneLoaded -= SceneLoaded;
            _sceneManagementService.OnSceneStarted -= SceneStarted;
        }

        private void SceneLoaded(string sceneName)
        {
            LoadGameLevelEnviroment();
            SceneReadyToStart();
        }
        public void LoadGameLevelEnviroment()
        {
            Log.PrintYellow("Load environment");
            _ui.Show<SettingViewModel>();
            _ui.Show<FpsInfoHudViewModel>();
            _ui.Show<JoystickHudModel>();
            _ui.Show<InputTextHudModel>();
        }

        private void SceneStarted(string sceneName)
        {
           
        }

        public void SceneReadyToStart()
        {
            _sceneManagementService.SceneReadyToStart = true;
        }
    }
}