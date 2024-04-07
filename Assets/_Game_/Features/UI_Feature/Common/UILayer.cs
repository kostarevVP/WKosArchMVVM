using System;

namespace WKosArch.Services.UIService.Common
{
    [Serializable]
    public enum UILayer
    {
        Base = 0,
        UnderPopupFX = 50,
        Popup = 100,
        OverPopupFX = 150
    }
}