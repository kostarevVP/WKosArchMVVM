using System;
using WKosArch.Reactive;

namespace WKosArch.Sound_Feature
{
    public class AudioSettingViewModel : WindowViewModel
    {
        private const float MIN_VOLUME = 0.0001f;

        public IObservable<float> MusicVolume => _musicVolume;
        public IObservable<float> SFXVolume => _sfxVolume;

        public IObservable<bool> MusicToggle => _musicToggle;
        public IObservable<bool> SFXToggle => _sFXToggle;

        public IObservable<bool> HapticToggle => _hapticToggle;

        private ISoundFeature _soundFeature => DiContainer.Resolve<ISoundFeature>();


        private readonly ReactiveProperty<float> _musicVolume = new();
        private readonly ReactiveProperty<float> _sfxVolume = new();
        private readonly ReactiveProperty<float> _uIVolume = new();

        private readonly ReactiveProperty<bool> _sFXToggle = new();
        private readonly ReactiveProperty<bool> _musicToggle = new();
        private readonly ReactiveProperty<bool> _UIToggle = new();
        private readonly ReactiveProperty<bool> _hapticToggle = new();


        private float _previousMusicVolumeValue;
        private float _previousSFXVolumeValue;
        private float _previousUIVolumeValue;


        public override void Subscribe()
        {
            base.Subscribe();

            GetValueFromSettingSO();
        }

        public void SetMusicValue(float value)
        {
            if (value <= MIN_VOLUME)
            {
                _soundFeature.SetVolumeMusic(MIN_VOLUME);
                _musicVolume.Value = MIN_VOLUME;
                SwitchMusic(false);
            }
            else
            {
                if (!_musicToggle.Value)
                {
                    _previousMusicVolumeValue = _musicVolume.Value;
                    _musicVolume.Value = value;
                    _soundFeature.SetVolumeMusic(value);
                    SwitchMusic(true);
                }
                else
                {
                    _previousMusicVolumeValue = _musicVolume.Value;
                    _musicVolume.Value = value;
                    _soundFeature.SetVolumeMusic(value);
                }
            }
        }

        public void SetSFXValue(float value)
        {
            if (value <= MIN_VOLUME)
            {
                _soundFeature.SetVolumeSfx(MIN_VOLUME);
                _sfxVolume.Value = MIN_VOLUME;
                SwithcSFX(false);
            }
            else
            {
                if (!_sFXToggle.Value && _sfxVolume.Value < value)
                {
                    _previousSFXVolumeValue = _sfxVolume.Value;
                    _soundFeature.SetVolumeSfx(value);
                    _sfxVolume.Value = value;
                    SwithcSFX(true);
                }
                else
                {
                    _previousSFXVolumeValue = _sfxVolume.Value;
                    _soundFeature.SetVolumeSfx(value);
                    _sfxVolume.Value = value;
                }
            }
        }

        public void SetUiValue(float value)
        {
            if (value <= MIN_VOLUME)
            {
                _soundFeature.SetVolumeUI(MIN_VOLUME);
                _uIVolume.Value = MIN_VOLUME;
                SwithcUI(false);
            }
            else
            {
                if (!_UIToggle.Value && _uIVolume.Value < value)
                {
                    _previousUIVolumeValue = _uIVolume.Value;
                    _soundFeature.SetVolumeUI(value);
                    _uIVolume.Value = value;
                    SwithcUI(true);
                }
                else
                {
                    _previousUIVolumeValue = _uIVolume.Value;
                    _soundFeature.SetVolumeUI(value);
                    _uIVolume.Value = value;
                }
            }
        }


        public void SwitchMusic(bool isEnabled)
        {
            _musicToggle.Value = isEnabled;

            if (isEnabled)
            {
                _soundFeature.UnmuteMusic();

                if (_musicVolume.Value <= _previousMusicVolumeValue)
                    _musicVolume.Value = _previousMusicVolumeValue;
            }
            else
            {
                _soundFeature.MuteMusic();
                _musicVolume.Value = MIN_VOLUME;
            }
        }

        public void SwithcSFX(bool isEnabled)
        {
            _sFXToggle.Value = isEnabled;

            if (isEnabled)
            {
                _soundFeature.UnmuteSfx();

                if (_sfxVolume.Value <= _previousSFXVolumeValue)
                    _sfxVolume.Value = _previousSFXVolumeValue;
            }
            else
            {
                _soundFeature.MuteSfx();
                _sfxVolume.Value = MIN_VOLUME;
            }
        }

        public void SwithcUI(bool isEnabled)
        {
            _UIToggle.Value = isEnabled;

            if (isEnabled)
            {
                _soundFeature.UnmuteUI();

                if (_uIVolume.Value <= _previousUIVolumeValue)
                    _uIVolume.Value = _previousUIVolumeValue;
            }
            else
            {
                _soundFeature.MuteUI();
                _uIVolume.Value = MIN_VOLUME;
            }
        }

        public void SwitchHaptic(bool isEnabled)
        {
            _soundFeature.SwitchHaptic(isEnabled);
            _hapticToggle.Value = isEnabled;
        }

        private void GetValueFromSettingSO()
        {
            var settigs = _soundFeature.SoundManager.MMSoundManager.settingsSo.Settings;

            _previousMusicVolumeValue = settigs.MusicVolume;
            _musicVolume.Value = settigs.MusicVolume;

            _previousSFXVolumeValue = settigs.SfxVolume;
            _sfxVolume.Value = settigs.SfxVolume;

            _previousUIVolumeValue = settigs.UIVolume;
            _uIVolume.Value = settigs.UIVolume;

            _musicToggle.Value = settigs.MusicOn;
            _sFXToggle.Value = settigs.SfxOn;
            _UIToggle.Value = settigs.UIOn;

            _hapticToggle.Value = _soundFeature.SoundManager.HapticReceiver.hapticsEnabled;
        }
    }
}