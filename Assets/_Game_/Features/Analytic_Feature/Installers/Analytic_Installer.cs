using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using WKosArch.DependencyInjection;

namespace WKosArch.Services.AnalyticService
{
    [CreateAssetMenu(fileName = "Analytic_Installer", menuName = "Game/Installers/Analytic_Installer")]
    public class Analytic_Installer : FeatureInstaller
    {
        public override IFeature Create(IDIContainer container)
        {
            IAnalyticService feature = new AnalyticLogService();

            RegisterFeatureAsSingleton(container, feature);

            return feature;
        }
        public override void Dispose() { }

        private void RegisterFeatureAsSingleton(IDIContainer container, IAnalyticService feature)
        {
            container.RegisterSingleton(_ => feature);
            Log.PrintColor($"[IAnalyticService] Create and RegisterSingleton", Color.cyan);
        }
    }
}