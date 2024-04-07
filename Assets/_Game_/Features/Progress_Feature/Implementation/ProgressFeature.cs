using Assets.Game.Services.ProgressService.api;

namespace WKosArch.Services.ProgressService
{
    public class ProgressFeature : IProgressFeature
    {
        public GameProgress Progress { get; set; }
    }
}