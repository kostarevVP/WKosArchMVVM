using Lukomor;
using System;

namespace WKosArch.Services.UIService.UI
{
    public interface IUserInterface : IDisposable
    {
        void Build(UISceneConfig config);

        void Show<TUiViewModel>() where TUiViewModel : UiViewModel, new();
        void Hide<TUiViewModel>() where TUiViewModel : UiViewModel;
        void Close<TUiViewModel>() where TUiViewModel : UiViewModel;
        void Back(bool hideCurrentWindow = true, bool forced = false);
        void CloseAllWindowInStack();
    }
}