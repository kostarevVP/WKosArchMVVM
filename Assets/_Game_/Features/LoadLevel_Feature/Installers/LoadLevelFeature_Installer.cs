using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using WKosArch.Services.Scenes;
using UnityEngine;
using WKosArch.Services.UIService;
using WKosArch.Services.UIService.UI;

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

            BindFeature(container, feature);

            return feature;
        }

        public override void Dispose() { }

        private void BindFeature(IDIContainer container, ILoadLevelFeature feature)
        {
            container.Bind(feature);
            Log.PrintColor($"[SaveLoadFeature] Create and Bind", Color.cyan);
        }
    }
}
