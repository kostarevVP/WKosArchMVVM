using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;

namespace WKosArch.Services.AssetProviderService
{
    [CreateAssetMenu(fileName = "AssetProviderFeature_Installer", menuName = "Game/Installers/AssetProviderFeature_Installer")]
    public class AssetProviderFeature_Installer : FeatureInstaller
    {

        public override IFeature Create(IDIContainer container)
        {
            IAssetProviderFeature _feature = new AssetProviderFeature();

            BindFeature(container, _feature);
            return _feature;
        }

        public override void Dispose() { }

        private void BindFeature(IDIContainer container, IAssetProviderFeature feature)
        {
            container.Bind(feature);
            Log.PrintColor($"[AssetProviderFeature] Create and Bind", Color.cyan);
        }
    } 
}
