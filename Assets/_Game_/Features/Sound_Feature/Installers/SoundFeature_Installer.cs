using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using WKosArch.DependencyInjection;

namespace WKosArch.Services.SoundService
{
    [CreateAssetMenu(fileName = "SoundFeature_Installer", menuName = "Game/Installers/SoundFeature_Installer")]
    public class SoundFeature_Installer : FeatureInstaller
    {
        public override IFeature Create(IDIContainer container)
        {
            ISoundFeature feature = new SoundFeature();

            RegisterFeatureAsSingleton(container, feature);

            return feature;
        }

        public override void Dispose() { }

        private void RegisterFeatureAsSingleton(IDIContainer container, ISoundFeature feature)
        {
            container.RegisterSingleton(_ => feature);
            Log.PrintColor($"[ISoundFeature] Create and RegesterSingleton", Color.cyan);
        }
    }
}