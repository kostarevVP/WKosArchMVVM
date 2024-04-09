using Assets.Game.Services.ProgressService.api;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using WKosArch.Services.Scenes;
using UnityEngine;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Services.StaticDataServices;

namespace WKosArch.Features.LoadProgressFeature
{
    [CreateAssetMenu(fileName = "LoadProgressFeature_Installer", menuName = "Game/Installers/LoadProgressFeature_Installer")]
    public class LoadProgressFeature_Installer : FeatureInstaller
    {
        public override IFeature Create(IDIContainer container)
        {
            IProgressFeature progressService = container.Resolve<IProgressFeature>();
            ISaveLoadFeature saveLoadService = container.Resolve<ISaveLoadFeature>();
            IConfigDataFeature configDataService = container.Resolve<IConfigDataFeature>();
            ISceneManagementFeature sceneManagementService = container.Resolve<ISceneManagementFeature>();

            ILoadProgressFeature feature = new LoadProgressFeature(progressService, saveLoadService, configDataService);

            feature.LoadProgressOrInitNew();

            BindFeature(container, feature);

            sceneManagementService.LoadScene(progressService.Progress.SceneIndex);

            return feature;
        }

        public override void Dispose() { }

        private void BindFeature(IDIContainer container, ILoadProgressFeature feature)
        {
            container.Bind(feature);
            Log.PrintColor($"[ILoadProgressFeature] Create and Bind", Color.cyan);
        }
    } 
}
