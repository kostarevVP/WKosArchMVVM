using Assets.Game.Services.ProgressService.api;
using System;
using UnityEngine;

namespace WKosArch.Services.SaveLoadService
{
    public class SaveLoadFeature : ISaveLoadFeature
    {
        private const string ProgressKEY = "Progress";

        public event Action OnSaveStarted;

        private readonly IProgressFeature _progressService;

        public SaveLoadFeature(IProgressFeature progressService)
        {
            _progressService = progressService;
        }

        public GameProgress LoadProgress()
        {
            var json = PlayerPrefs.GetString(ProgressKEY);
            var save = JsonUtility.FromJson<GameProgress>(json);

            return save;
        }

        public void SaveProgress()
        {
            OnSaveStarted?.Invoke();

            var json = JsonUtility.ToJson(_progressService.Progress);
            PlayerPrefs.SetString(ProgressKEY, json);
            PlayerPrefs.Save();
        }

        public void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
                SaveProgress();
        }

        public void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
                SaveProgress();
        }
    }
}