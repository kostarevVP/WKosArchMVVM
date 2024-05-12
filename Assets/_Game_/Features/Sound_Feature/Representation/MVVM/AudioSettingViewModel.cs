using DG.Tweening;
using System;
using System.Reactive.Subjects;
using UnityEngine;
using WKosArch.Extentions;
using WKosArch.Reactive;

namespace WKosArch.Services.SoundService
{
    public class AudioSettingViewModel : WindowViewModel
    {
        private const float MinimalVolume = 0.0001f;

        private ISoundFeature _soundService => DiContainer.Resolve<ISoundFeature>();

        private float _previousMusicVolumeValue;
        private float _previousSFXVolumeValue;
        private float _previousUIVolumeValue;

        public float MusicVolumeValue { get; private set; }
        public float SFXVolumeValue { get; private set; }
        public float UIVolumeValue { get; private set; }
        public bool MusicToggleState { get; private set; }
        public bool SFXToggle { get; private set; }
        public bool UIToggle { get; private set; }
        public bool HapticToogle { get; private set; }


        public IObservable<string> SomeObservableText => _someObservableText;
        public IObservable<string> SomeReactivePropertyText => _someReactivePropertyText;
        public IObservable<float> SFXVolume => _sfxVolume;

        private readonly Subject<string> _someObservableText = new();
        private readonly ReactiveProperty<string> _someReactivePropertyText = new();

        private readonly ReactiveProperty<float> _sfxVolume = new();    

        public AudioSettingViewModel()
        {
            Log.PrintYellow("Constructor in AudioSettingViewModel");
            _someObservableText.OnNext("Your awesome observableText");
            _someReactivePropertyText.Value = "Your awesome reactivePropertyText";
            //GetValueFromSettingSO();
        }

        public override void Subscribe()
        {
            base.Subscribe();

        }

        public void EmptyMethod() { }
        public void FloatMethod(float value) { }
        public void BoolMethod(bool value) { }
        public void IntMethod(int value) { }
        public void Vector2Method(Vector2 value) { }
        public void Vecotr3Method(Vector3 value) { }

        public void Vector3IntMethod(Vector3Int value) { }
        public void Vector2IntMethod(Vector2Int value) { }


        internal void SetMusicValue(float value)
        {
            if (value <= MinimalVolume)
            {
                _soundService.SetVolumeMusic(MinimalVolume);
                MusicVolumeValue = MinimalVolume;
                SwitchMusic(false);
            }
            else
            {
                if (!MusicToggleState)
                {
                    _previousMusicVolumeValue = MusicVolumeValue;
                    MusicVolumeValue = value;
                    _soundService.SetVolumeMusic(value);
                    SwitchMusic(true);
                }
                else
                {
                    _previousMusicVolumeValue = MusicVolumeValue;
                    MusicVolumeValue = value;
                    _soundService.SetVolumeMusic(value);
                }
            }
        }

        internal void SetSFXValue(float value)
        {
            if (value <= MinimalVolume)
            {
                _soundService.SetVolumeSfx(MinimalVolume);
                SFXVolumeValue = MinimalVolume;
                SwithcSFX(false);
            }
            else
            {
                if (!SFXToggle && SFXVolumeValue < value)
                {
                    _previousSFXVolumeValue = SFXVolumeValue;
                    _soundService.SetVolumeSfx(value);
                    SFXVolumeValue = value;
                    SwithcSFX(true);
                }
                else
                {
                    _previousSFXVolumeValue = SFXVolumeValue;
                    _soundService.SetVolumeSfx(value);
                    SFXVolumeValue = value;
                }
            }
        }

        internal void SetUiValue(float value)
        {
            if (value <= MinimalVolume)
            {
                _soundService.SetVolumeUI(MinimalVolume);
                UIVolumeValue = MinimalVolume;
                SwithcUI(false);
            }
            else
            {
                if (!UIToggle && UIVolumeValue < value)
                {
                    _previousUIVolumeValue = UIVolumeValue;
                    _soundService.SetVolumeUI(value);
                    UIVolumeValue = value;
                    SwithcUI(true);
                }
                else
                {
                    _previousUIVolumeValue = UIVolumeValue;
                    _soundService.SetVolumeUI(value);
                    UIVolumeValue = value;
                }
            }
        }


        internal void SwitchMusic(bool isEnabled)
        {
            MusicToggleState = isEnabled;

            if (isEnabled)
            {
                _soundService.UnmuteMusic();

                if (MusicVolumeValue <= _previousMusicVolumeValue)
                    MusicVolumeValue = _previousMusicVolumeValue;
            }
            else
            {
                _soundService.MuteMusic();
                MusicVolumeValue = MinimalVolume;
            }
            //Refresh();
        }

        internal void SwithcSFX(bool isEnabled)
        {
            SFXToggle = isEnabled;

            if (isEnabled)
            {
                _soundService.UnmuteSfx();

                if (SFXVolumeValue <= _previousSFXVolumeValue)
                    SFXVolumeValue = _previousSFXVolumeValue;
            }
            else
            {
                _soundService.MuteSfx();
                SFXVolumeValue = MinimalVolume;
            }

            //Refresh();
        }

        internal void SwithcUI(bool isEnabled)
        {
            UIToggle = isEnabled;

            if (isEnabled)
            {
                _soundService.UnmuteUI();

                if (UIVolumeValue <= _previousUIVolumeValue)
                    UIVolumeValue = _previousUIVolumeValue;
            }
            else
            {
                _soundService.MuteUI();
                UIVolumeValue = MinimalVolume;
            }

            //Refresh();
        }

        public void SwitchHaptic(bool isEnabled)
        {
            _soundService.SwitchHaptic(isEnabled);
            HapticToogle = isEnabled;
        }

        private void GetValueFromSettingSO()
        {
            var settigs = _soundService.SoundManager.MMSoundManager.settingsSo.Settings;

            MusicVolumeValue = _previousMusicVolumeValue = settigs.MusicVolume;
            SFXVolumeValue = _previousSFXVolumeValue = settigs.SfxVolume;
            UIVolumeValue = _previousUIVolumeValue = settigs.UIVolume;

            MusicToggleState = settigs.MusicOn;
            SFXToggle = settigs.SfxOn;
            UIToggle = settigs.UIOn;

            HapticToogle = _soundService.SoundManager.HapticReceiver.hapticsEnabled;
        }
    }
}