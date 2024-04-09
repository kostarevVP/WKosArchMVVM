using Assets.Game.Services.ProgressService.api;
using WKosArch.Services.StaticDataServices;

namespace WKosArch.Features.LoadProgressFeature
{
    public class LoadProgressFeature : ILoadProgressFeature
    {
        private readonly IProgressFeature _progressService;
        private readonly ISaveLoadFeature _saveLoadService;
        private readonly IConfigDataFeature _configDataService;

        public LoadProgressFeature(IProgressFeature progressService, ISaveLoadFeature saveLoadService, IConfigDataFeature staticDataService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _configDataService = staticDataService;
        }

        public void LoadProgressOrInitNew() =>
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();

        private GameProgress NewProgress()
        {
            var progress = new GameProgress();

            progress.SceneIndex = _configDataService.GameProgressConfig.SceneIndex;

            return progress;
        }
    } 
}
