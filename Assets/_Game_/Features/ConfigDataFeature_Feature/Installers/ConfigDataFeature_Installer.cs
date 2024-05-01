using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using WKosArch.DependencyInjection;

namespace WKosArch.Services.StaticDataServices
{
    [CreateAssetMenu(fileName = "ConfigDataFeature_Installer", menuName = "Game/Installers/ConfigDataFeature_Installer")]
    public class ConfigDataFeature_Installer : FeatureInstaller
    {
        public override IFeature Create(IDIContainer container)
        {
            IAssetProviderFeature assetProviderService = container.Resolve<IAssetProviderFeature>();

            IConfigDataFeature feature = new ConfigDataFeature(assetProviderService);

            RegisterFeatureAsSingleton(container, feature);

            return feature;
        }

        public override void Dispose() { }

        private void RegisterFeatureAsSingleton(IDIContainer container, IConfigDataFeature feature)
        {
            container.RegisterSingleton(_ => feature);
            Log.PrintColor($"[IStaticDataFeature] Create and RegesterSingleton", Color.cyan);
        }
    } 
}
