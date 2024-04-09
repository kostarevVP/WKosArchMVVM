using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using Lukomor;
using Lukomor.MVVM;
using System;
using UnityEngine;
using WKosArch.Services.UIService;
using WKosArch.Services.UIService.UI;

namespace Assets._Game_.Services.UI_Service.Implementation
{
    public interface IUserInterfaceFactory : IDisposable
    {
        void Build(UISceneConfig config);
        void Construct(IDIContainer dIContainer, IUserInterface userInterface);

        View CreateOrGetActiveView(UiViewModel viewModel, bool openForced = false, Transform root = null);
        UiViewModel CreateOrGetViewModel<TUiViewModel>() where TUiViewModel : UiViewModel, new();

        void Close(UiViewModel currentUiViewModel, bool forcedHide = false);
        void Hide(UiViewModel viewModel, bool forcedHide = false);
        void Close(string fullName, bool forcedHide = false);
        void Hide(string fullName, bool forcedHide = false);
    }
}