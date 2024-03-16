using Assets.Game.Services.ProgressService.api;
using System.Collections.Generic;

namespace WKosArch.Services.SoundService
{
    public class SoundService : ISoundService
    {
        public SoundManager SoundManager { get; private set; }
        public List<ISavedProgress> ProgressReaders { get; } = new List<ISavedProgress>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
        public bool IsReady => _isReady;


        private bool _isReady;

        public SoundService()
        {
            SoundManager = SoundManager.CreateInstance();
            
            RegisterProgressWatchers(SoundManager);

            _isReady = true;
        }

        public void MuteMusic() => 
            SoundManager.MMSoundManager.MuteMusic();

        public void MuteSfx() => 
            SoundManager.MMSoundManager.MuteSfx();

        public void MuteUI() => 
            SoundManager.MMSoundManager.MuteUI();

        public void SetVolumeMusic(float value) => 
            SoundManager.MMSoundManager.SetVolumeMusic(value);

        public void SetVolumeSfx(float value) => 
            SoundManager.MMSoundManager.SetVolumeSfx(value);

        public void SetVolumeUI(float value) => 
            SoundManager.MMSoundManager.SetVolumeUI(value);

        public void UnmuteMusic() => 
            SoundManager.MMSoundManager.UnmuteMusic();

        public void UnmuteSfx() => 
            SoundManager.MMSoundManager.UnmuteSfx();

        public void UnmuteUI() => 
            SoundManager.MMSoundManager.UnmuteUI();

        public void MuteAll() => 
            SoundManager.MMSoundManager.MuteMaster();

        public void UnmuteAll() => 
            SoundManager.MMSoundManager.UnmuteMaster();

        public void SwitchHaptic(bool isEnabled) => 
            SoundManager.HapticReceiver.hapticsEnabled = isEnabled;

        private void RegisterProgressWatchers(SoundManager gameObject)
        {
            foreach (var progressReader in gameObject.GetComponentsInChildren<ISavedProgress>())
            {
                Register(progressReader);
            }
        }

        private void Register(ISavedProgress progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
            {
                ProgressWriters.Add(progressWriter);
            }

            ProgressReaders.Add(progressReader);
        }
    }
}