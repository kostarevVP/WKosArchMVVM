using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using Lukomor;
using WKosArch.Services.UIService;
using WKosArch.Services.UIService.UI;

namespace Assets._Game_.Services.UI_Service.Implementation
{
    public interface IUserInterfaceFactory
    {
        void Build(UISceneConfig config);
        void Construct(IDIContainer dIContainer, IUserInterface userInterface);
        void CreateView(UiViewModel uiViewModel);
    }
}