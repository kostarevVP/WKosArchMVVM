using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Services.Scenes;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Services.StaticDataServices;
using UnityEngine;
using WKosArch.Extentions;

namespace  WKosArch.Services.UIService

{
    [CreateAssetMenu(fileName = "UiFeature_Installer", menuName = "Game/Installers/UiFeature_Installer")]
    public class UiFeature_Installer : FeatureInstaller
    {
        public override IFeature Create(IDIContainer container)
        {
            ISceneManagementFeature sceneMenegmentService = container.Resolve<ISceneManagementFeature>();
            IConfigDataFeature configDataService = container.Resolve<IConfigDataFeature>();

            IUiFeature feature = new UiFeature(configDataService, sceneMenegmentService, container);

            BindFeature(container, feature);

            container.Bind(feature.UI);

            Log.PrintColor($"[UI] Create and Bind", Color.cyan);

            return feature;
        }

        public override void Dispose() { }
        private void BindFeature(IDIContainer container, IUiFeature feature)
        {
            container.Bind(feature);
            Log.PrintColor($"[IUiFeature] Create and Bind", Color.cyan);
        }
    }
}