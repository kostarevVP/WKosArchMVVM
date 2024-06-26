﻿using WKosArch.Domain.Features;

namespace WKosArch.Sound_Feature
{
    public interface ISoundFeature : IFeature
    {
        SoundManager SoundManager { get; }

        void SetVolumeMusic(float value);
        void SetVolumeSfx(float value);
        void SetVolumeUI(float value);
        void SwitchHaptic(bool isEnabled);
        void MuteMusic();
        void MuteSfx();
        void MuteUI();
        void MuteAll();
        void UnmuteMusic();
        void UnmuteSfx();
        void UnmuteUI();
        void UnmuteAll();
    }
}