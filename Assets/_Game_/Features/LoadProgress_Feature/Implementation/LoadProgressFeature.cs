using Assets.Game.Services.ProgressService.api;
using WKosArch.Services.StaticDataServices;

namespace WKosArch.Features.LoadProgressFeature
{
    public class LoadProgressFeature : ILoadProgressFeature
    {
        public bool IsReady => _isReady;

        private readonly IProgressFeature _progressService;
        private readonly ISaveLoadFeature _saveLoadService;
        private readonly IStaticDataFeature _staticDataService;

        private bool _isReady;

        public LoadProgressFeature(IProgressFeature progressService, ISaveLoadFeature saveLoadService, IStaticDataFeature staticDataService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _staticDataService = staticDataService;

            _isReady = true;
        }

        public void LoadProgressOrInitNew() =>
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();

        private GameProgress NewProgress()
        {
            var progress = new GameProgress();

            progress.SceneIndex = _staticDataService.GameProgressConfig.SceneIndex;

            return progress;
        }
    } 
}
