using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using Lukomor;
using Lukomor.MVVM;
using WKosArch.Services.UIService;
using WKosArch.Services.UIService.UI;

namespace Assets._Game_.Services.UI_Service.Implementation
{
    public interface IUserInterfaceFactory
    {
        void Build(UISceneConfig config);
        void Construct(IDIContainer dIContainer, IUserInterface userInterface);

        void Close<TUiViewModel>() where TUiViewModel : UiViewModel;
        void Hide<TUiViewModel>() where TUiViewModel : UiViewModel;

        View GetOrCreateActiveView(UiViewModel viewModel);
        UiViewModel GetOrCreateViewModel<TUiViewModel>() where TUiViewModel : UiViewModel, new();
    }
}