using Lukomor;
using System;

namespace WKosArch.Services.UIService.UI
{
    public interface IUserInterface : IDisposable
    {
        void Build(UISceneConfig config);

        void Show<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : UiViewModel, new();
        void Hide<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : UiViewModel;
        void Close<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : UiViewModel;
        void Back(bool hideCurrentWindow = true, bool forced = false);
        void CloseAllWindowInStack();
    }
}