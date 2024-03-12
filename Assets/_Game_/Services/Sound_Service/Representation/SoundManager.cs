using Assets.Game.Services.ProgressService.api;
using Lofelt.NiceVibrations;
using MoreMountains.Tools;
using UnityEngine;

namespace WKosArch.Services.SoundService
{
    public class SoundManager : MonoBehaviour, ISavedProgress
    {
        private const string PrefabPath = "[SOUND_MANGER]";

        public MMSoundManager MMSoundManager;
        [Space]
        public SFXFeedbackHolder SFXHolder;
        [Space]
        public MusicPlayer MusicPlayer;
        [Space]
        public UIFeedbackHolder UIHolder;
        [Space]
        public HapticReceiver HapticReceiver;


        private Vector3 _cashPosition = Vector3.zero;

        public static SoundManager CreateInstance()
        {
            var prefab = Resources.Load<SoundManager>(PrefabPath);
            var soundManager = Instantiate(prefab);


            DontDestroyOnLoad(soundManager.gameObject);

            return soundManager;
        }

        private void Awake() =>
            DontDestroyOnLoad(gameObject);

        private void Update()
        {
            UpdatePosition();
        }

        public void SaveProgress(GameProgress progress)
        {
            //MMSoundManager.SaveSettings();
            //progress.SoundSetting = MMSoundManager.settingsSo.Settings;

            //progress.Haptic = HapticReceiver.hapticsEnabled;
        }

        public void LoadProgress(GameProgress progress)
        {
            //MMSoundManager.settingsSo.Settings = progress.SoundSetting;
            //MMSoundManager.settingsSo.SaveSoundSettings();
            //MMSoundManager.LoadSettings();

            //HapticReceiver.hapticsEnabled = progress.Haptic;
        }

        private void UpdatePosition()
        {
            if (Camera.main != null)
                transform.position = Camera.main.transform.position;
        }
    }
}