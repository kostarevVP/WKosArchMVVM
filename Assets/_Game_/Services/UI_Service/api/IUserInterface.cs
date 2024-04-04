using Lukomor;

namespace WKosArch.Services.UIService.UI
{
    public interface IUserInterface
    {
        //void Show<TWindowViewModel>(bool hideWindow = true) where TWindowViewModel : Lukomor.UiViewModel;
        //void Show<TWindowViewModel>() where TWindowViewModel : Lukomor.UiViewModel;

        //void Show<TWindowViewModel>(Type uiViewModelType, bool hideWindow = true) where TWindowViewModel : Lukomor.UiViewModel;
        //TWidgetViewModel ShowWidget<TWidgetViewModel>(Transform root) where TWidgetViewModel : WidgetViewModel;
        
        //void Back(bool hideCurrentWindow = true, bool forced = false);
        //void CloseAllWindowInStack();
        void Build(UISceneConfig config);
        void Hide<TUiViewModel>() where TUiViewModel : UiViewModel;
        void Show<TUiViewModel>() where TUiViewModel : UiViewModel, new();
    }
}