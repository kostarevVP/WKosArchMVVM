using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using WKosArch.Services.UIService.UI;


[CreateAssetMenu(fileName = " FpsInfoFeature_Installer", menuName = "Game/Installers/FpsInfoFeature_Installer")]
public class FpsInfoFeature_Installer : FeatureInstaller
{

    public override IFeature Create(IDIContainer container)
    {

        FpsInfoFeature feature = new FpsInfoFeature();

        BindFeature(container, feature);

        return feature;
    }

    public override void Dispose() { }

    private void BindFeature(IDIContainer container, FpsInfoFeature feature)
    {
        container.Bind(feature);
        Log.PrintColor($"[FpsInfoFeature_Installer] Create and Bind", Color.cyan);
    }
}
