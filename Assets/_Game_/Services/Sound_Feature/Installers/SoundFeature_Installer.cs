using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;

namespace WKosArch.Services.SoundService
{
    [CreateAssetMenu(fileName = "SoundFeature_Installer", menuName = "Game/Installers/SoundFeature_Installer")]
    public class SoundFeature_Installer : FeatureInstaller
    {
        public override IFeature Create(IDIContainer container)
        {
            ISoundFeature feature = new SoundFeature();

            BindFeature(container, feature);

            return feature;
        }

        public override void Dispose() { }

        private void BindFeature(IDIContainer container, ISoundFeature feature)
        {
            container.Bind(feature);
            Log.PrintColor($"[ISoundService] Create and Bind", Color.cyan);
        }
    }
}