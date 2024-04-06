using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;

namespace WKosArch.Services.StaticDataServices
{
    [CreateAssetMenu(fileName = "StaticDataFeature_Installer", menuName = "Game/Installers/StaticDataFeature_Installer")]
    public class StaticDataFeature_Installer : FeatureInstaller
    {
        public override IFeature Create(IDIContainer container)
        {
            IAssetProviderFeature assetProviderService = container.Resolve<IAssetProviderFeature>();

            IStaticDataFeature feature = new StaticDataFeature(assetProviderService);

            BindFeature(container, feature);

            return feature;
        }

        public override void Dispose() { }

        private void BindFeature(IDIContainer container, IStaticDataFeature feature)
        {
            container.Bind(feature);
            Log.PrintColor($"[StaticDataFeature] Create and Bind", Color.cyan);
        }
    } 
}
