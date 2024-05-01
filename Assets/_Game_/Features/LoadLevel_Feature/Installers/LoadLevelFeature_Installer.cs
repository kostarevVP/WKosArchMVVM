using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using WKosArch.Services.Scenes;
using UnityEngine;
using WKosArch.Services.UIService;
using WKosArch.Services.UIService.UI;
using WKosArch.DependencyInjection;

namespace WKosArch.Features.LoadLevelFeature
{
    [CreateAssetMenu(fileName = "LoadLevelFeature_Installer", menuName = "Game/Installers/LoadLevelFeature_Installer")]
    public class LoadLevelFeature_Installer : FeatureInstaller
    {
        public override IFeature Create(IDIContainer container)
        {
            ISceneManagementFeature sceneManagementService = container.Resolve<ISceneManagementFeature>();
            IUserInterface ui = container.Resolve<IUiFeature>().UI;

            ILoadLevelFeature feature = new LoadLevelFeature(sceneManagementService, ui);

            RegisterFeatureAsSingleton(container, feature);

            return feature;
        }

        public override void Dispose() { }

        private void RegisterFeatureAsSingleton(IDIContainer container, ILoadLevelFeature feature)
        {
            container.RegisterSingleton(_ => feature);
            Log.PrintColor($"[ILoadLevelFeature] Create and RegesterSingleton", Color.cyan);
        }
    }
}
