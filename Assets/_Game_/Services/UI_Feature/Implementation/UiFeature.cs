using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Extentions;
using WKosArch.Services.Scenes;
using WKosArch.Services.StaticDataServices;
using WKosArch.Services.UIService.UI;

namespace WKosArch.Services.UIService
{
    public class UiFeature : IUiFeature
    {
        private readonly ISceneManagementFeature _sceneManagementService;
        private readonly IStaticDataFeature _staticDataService;

        public IUserInterface UI { get; private set; }

        public UiFeature(IStaticDataFeature staticDataService, ISceneManagementFeature sceneManagementService,
            IDIContainer container)
        {
            _staticDataService = staticDataService;
            _sceneManagementService = sceneManagementService;

            UI = new UserInterface(container);

            _sceneManagementService.OnSceneLoaded += SceneLoaded;
        }

        public void Dispose()
        {
            _sceneManagementService.OnSceneLoaded -= SceneLoaded;
        }

        private void SceneLoaded(string sceneName)
        {
            //SubScene from DOTS after open get same callBack SceneLoaded
            //Thats why there is TryGet before was like below
            //var config = _staticDataService.SceneConfigsMap[sceneName];
            if (_staticDataService.SceneConfigsMap.TryGetValue(sceneName, out var config))
            {
                UI.Build(config);
            }
            else
            {
                Log.PrintWarning($"Try to load for {sceneName} SceneConfig {config} in SceneConfigsMap result false");
            }
        }
    }
}