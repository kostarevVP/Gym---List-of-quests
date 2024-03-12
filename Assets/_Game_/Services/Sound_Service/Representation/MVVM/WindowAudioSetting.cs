using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

namespace WKosArch.Services.SoundService
{
    public class WindowAudioSetting : Window<AudioSettingViewModel>
    {
        [Space]
        [SerializeField] private Slider _sfxSlider;
        [SerializeField] private Slider _musicSlider;
        [Space]
        [SerializeField] private Toggle _sfxToggle;
        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private Toggle _hapticToggle;

        public override void Subscribe()
        {
            base.Subscribe();

            _sfxSlider?.onValueChanged.AddListener(SFXValueChanged);
            _musicSlider?.onValueChanged.AddListener(MusicValueChanged);

            _sfxToggle?.onValueChanged.AddListener(SFXToggleValueChanged);
            _musicToggle?.onValueChanged.AddListener(MusicToggleValueChanged);
            _hapticToggle?.onValueChanged.AddListener(HapticValueChanged);
        }


        public override void Unsubscribe()
        {
            base.Unsubscribe();

            _sfxSlider?.onValueChanged.RemoveListener(SFXValueChanged);
            _musicSlider?.onValueChanged.RemoveListener(MusicValueChanged);

            _sfxToggle?.onValueChanged.RemoveListener(SFXToggleValueChanged);
            _musicToggle?.onValueChanged.RemoveListener(MusicToggleValueChanged);
            _hapticToggle?.onValueChanged.RemoveListener(HapticValueChanged);
        }

        public override void Refresh()
        {
            base.Refresh();

            //null chek need when View not have some of this componetns
            if (_musicSlider != null)
                _musicSlider.value = ViewModel.MusicVolumeValue;
            if (_sfxSlider != null)
                _sfxSlider.value = ViewModel.SFXVolumeValue;

            if (_musicToggle != null)
                _musicToggle.isOn = ViewModel.MusicToggleState;
            if (_sfxToggle != null)
                _sfxToggle.isOn = ViewModel.SFXToggle;
            if (_hapticToggle != null)
                _hapticToggle.isOn = ViewModel.HapticToogle;
        }

        private void SFXValueChanged(float value)
        {
            ViewModel.SetSFXValue(value);
            ViewModel.SetUiValue(value);
        }

        private void MusicValueChanged(float value)
        {
            ViewModel.SetMusicValue(value);
        }

        private void SFXToggleValueChanged(bool isEnabled)
        {
            ViewModel.SwithcSFX(isEnabled);
            ViewModel.SwithcUI(isEnabled);
        }

        private void MusicToggleValueChanged(bool isEnabled)
        {
            ViewModel.SwitchMusic(isEnabled);
        }

        private void HapticValueChanged(bool isEnabled) =>
            ViewModel.SwitchHaptic(isEnabled);
    }
}
