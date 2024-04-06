using System;
using WKosArch.Domain.Features;

public interface ISaveLoadFeature : IFocusPauseFeature
{
    event Action OnSaveStarted;
    public GameProgress LoadProgress();
    public void SaveProgress();
}
