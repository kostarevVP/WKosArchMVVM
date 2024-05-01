using WKosArch.DependencyInjection;
using UnityEngine;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using WKosArch.Services.StaticDataServices;

[CreateAssetMenu(fileName = "QualityFeature_Installer", menuName = "Game/Installers/QualityFeature_Installer")]

public class QualityFeature_Installer : FeatureInstaller
{
    [SerializeField] private int _targetFPS = 30;

    public override IFeature Create(IDIContainer container)
    {
        var _staticDataService = container.Resolve<IConfigDataFeature>();

        IQualityFeature qualityFueature = new QualityFeature(_staticDataService.RenderQualityConfigMap);

        RegisterFeatureAsSingleton(container, qualityFueature);

        qualityFueature.SetFPSLimit(_targetFPS);

        return qualityFueature;
    }

    public override void Dispose() { }

    private void RegisterFeatureAsSingleton(IDIContainer container, IQualityFeature feature)
    {
        container.RegisterSingleton(_ => feature);
        Log.PrintColor($"[IQualityFeature] Create and RegesterSingleton", Color.cyan);
    }
}
