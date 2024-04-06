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

        private void SceneStarted(string sceneName)
        {
            PlayStartLevelAnimation();
        }

        public void LoadGameLevelEnviroment()
        {
            //in this point load player and all environment
            Log.PrintYellow("Load environment");
            _ui.Show<SettingViewModel>();
        }

        public void PlayStartLevelAnimation()
        {
            Log.PrintYellow("Play Start animation");
        }

        public void SceneReadyToStart()
        {
            _sceneManagementService.SceneReadyToStart = true;
        }
    }
}