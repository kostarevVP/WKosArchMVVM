using Assets.Game.Services.ProgressService.api;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;

namespace WKosArch.Services.SaveLoadService
{
    [CreateAssetMenu(fileName = "SaveLoadFeature_Installer", menuName = "Game/Installers/SaveLoadFeature_Installer")]
    public class SaveLoadFeature_Installer : FeatureInstaller
    {
        public override IFeature Create(IDIContainer container)
        {
            IProgressFeature progressFeature = container.Resolve<IProgressFeature>();

            ISaveLoadFeature feature = new SaveLoadFeature(progressFeature);

            BindFeature(container, feature);

            return feature;
        }

        public override void Dispose() { }

        private void BindFeature(IDIContainer container, ISaveLoadFeature feature)
        {
            container.Bind(feature);
            Log.PrintColor($"[ISaveLoadFeature] Create and Bind", Color.cyan);
        }
    }
}
