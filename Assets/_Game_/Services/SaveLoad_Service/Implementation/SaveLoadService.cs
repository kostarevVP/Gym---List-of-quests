using Assets.Game.Services.ProgressService.api;
using UnityEngine;

namespace WKosArch.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKEY = "Progress";
        public bool IsReady => _isReady;

        private readonly IProgressService _progressService;
        private bool _isReady;


        public SaveLoadService(IProgressService progressService)
        {
            _progressService = progressService;

            _isReady = true;
        }

        public GameProgress LoadProgress()
        {
            var save = PlayerPrefs.GetString(ProgressKEY)?.ToDeserialized<GameProgress>();
            PlayerPrefs.Save();
            return save;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(ProgressKEY, _progressService.Progress.ToJson());
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