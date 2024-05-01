using Assets.Game.Services.ProgressService.api;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using WKosArch.DependencyInjection;

namespace WKosArch.Services.ProgressService
{
    [CreateAssetMenu(fileName = "ProgressFeature_Installer", menuName = "Game/Installers/ProgressFeature_Installer")]
    public class ProgressFeature_Installer : FeatureInstaller
    {
        public override IFeature Create(IDIContainer container)
        {
            IProgressFeature feature = new ProgressFeature();

            RegisterFeatureAsSingleton(container, feature);

            return feature;
        }

        public override void Dispose() { }

        private void RegisterFeatureAsSingleton(IDIContainer container, IProgressFeature feature)
        {
            container.RegisterSingleton(_ => feature);
            Log.PrintColor($"[IProgressFeature] Create and RegesterSingleton", Color.cyan);
        }
    }
}