using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;

namespace WKosArch.Services.StaticDataServices
{
    [CreateAssetMenu(fileName = "ConfigDataFeature_Installer", menuName = "Game/Installers/ConfigDataFeature_Installer")]
    public class ConfigDataFeature_Installer : FeatureInstaller
    {
        public override IFeature Create(IDIContainer container)
        {
            IAssetProviderFeature assetProviderService = container.Resolve<IAssetProviderFeature>();

            IConfigDataFeature feature = new ConfigDataFeature(assetProviderService);

            BindFeature(container, feature);

            return feature;
        }

        public override void Dispose() { }

        private void BindFeature(IDIContainer container, IConfigDataFeature feature)
        {
            container.Bind(feature);
            Log.PrintColor($"[IStaticDataFeature] Create and Bind", Color.cyan);
        }
    } 
}
