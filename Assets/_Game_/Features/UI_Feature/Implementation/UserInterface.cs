﻿using Assets._Game_.Services.UI_Service.Implementation;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using Lukomor;
using UnityEngine;
using WKosArch.Extentions;
using WKosArch.UIService.Views.Windows;

namespace WKosArch.Services.UIService.UI
{
    public class UserInterface : IUserInterface
    {
        public Lukomor.WindowViewModel FocusedWindowViewModel { get; private set; }

        private IUserInterfaceFactory _uiFactory;
        private ViewModelStack<ViewModelTreeNode> _windowStack = new();
        private ViewModelStack<ViewModelTreeNode> _hudStack = new();


        public UserInterface(IDIContainer container)
        {
            _uiFactory = UserInterfaceFactory.CreateInstance();
            _uiFactory.Construct(container, this);
        }

        public void Build(UISceneConfig config) =>
            _uiFactory.Build(config);

        public void Show<TUiViewModel>(bool hideCurrentWindow = true, bool hideForced = false, bool openForced = false) where TUiViewModel : UiViewModel, new()
        {
            var isWindowViewModel = typeof(Lukomor.WindowViewModel).IsAssignableFrom(typeof(TUiViewModel));
            if (hideCurrentWindow && FocusedWindowViewModel != null && isWindowViewModel)
                _uiFactory.Close(FocusedWindowViewModel, hideForced);

            UiViewModel uiViewModel = _uiFactory.CreateOrGetViewModel<TUiViewModel>();
            _uiFactory.CreateOrGetActiveView(uiViewModel, openForced);

            AddViewModelStack(uiViewModel);
        }
        public void Back(bool hideCurrentWindow = true, bool forced = false)
        {
            var currentUiViewModel = _windowStack.Pop().UiViewModel;

            if (IsHomeWindowType(currentUiViewModel))
            {
                _windowStack.Push(new ViewModelTreeNode(currentUiViewModel));
                OpenCloseGameWindowPopup();
                return;
            }

            if (hideCurrentWindow)
            {
                _uiFactory.Close(currentUiViewModel);
            }

            var previousUiViewModel = _windowStack.Pop().UiViewModel;

            _uiFactory.CreateOrGetActiveView(previousUiViewModel);

            AddViewModelStack(previousUiViewModel);
        }
        public void CloseAllWindowInStack()
        {
            var stackLenght = _windowStack.Length;

            for (int i = 0; i < stackLenght; i++)
            {
                var currentWindowViewModel = _windowStack.Pop().UiViewModel;
                bool isHomeWindow = IsHomeWindowType(currentWindowViewModel);

                if (!isHomeWindow)
                {
                    bool forcedHide = (i != 0);

                    _uiFactory.Close(currentWindowViewModel, forcedHide);

                }
                else if (isHomeWindow)
                {
                    _uiFactory.CreateOrGetActiveView(currentWindowViewModel);
                    AddViewModelStack(currentWindowViewModel);
                }
            }
        }

        public void ShowAllHudInStack(bool openForced = false)
        {
            foreach (var hudViewModel in _hudStack.ViewModelQueue)
            {
                _uiFactory.CreateOrGetActiveView(hudViewModel.UiViewModel, openForced);
            }
        }
        public void HideAllHudInStack(bool hideForce = false)
        {
            foreach (var hudViewModel in _hudStack.ViewModelQueue)
            {
                _uiFactory.Close(hudViewModel.UiViewModel.GetType().FullName, hideForce);
            }
        }
        public void CloseAllHudInStack(bool forcedHide = false)
        {
            var stackLenght = _hudStack.Length;

            for (int i = 0; i < stackLenght; i++)
            {
                var currentWindowViewModel = _hudStack.Pop().UiViewModel;

                _uiFactory.Close(currentWindowViewModel, forcedHide);
            }
        }


        public void CloseHud<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : HudViewModel
        {
            var fullName = typeof(TUiViewModel).FullName;
            _uiFactory.Close(fullName);
        }
        public void CloseWidget<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : WidgetViewModel
        {
            var fullName = typeof(TUiViewModel).FullName;
            _uiFactory.Close(fullName);
        }
        public void HideHud<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : HudViewModel
        {
            var fullName = typeof(TUiViewModel).FullName;
            _uiFactory.Hide(fullName);
        }
        public void HideWidget<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : WidgetViewModel
        {
            var fullName = typeof(TUiViewModel).FullName;
            _uiFactory.Hide(fullName);
        }

        public void Dispose()
        {
            _uiFactory.Dispose();
            _windowStack.Clear();
            _hudStack.Clear();
        }


        private void AddViewModelStack(UiViewModel uiViewModel)
        {
            if (uiViewModel is Lukomor.WindowViewModel windowViewModel)
            {
                FocusedWindowViewModel = windowViewModel;
                _windowStack.Push(new ViewModelTreeNode(windowViewModel));
            }
            if (uiViewModel is HudViewModel hudViewModel)
            {
                _hudStack.Push(new ViewModelTreeNode(hudViewModel));
            }
        }
        private bool IsHomeWindowType(UiViewModel viewModel) =>
            typeof(IHomeWindow).IsAssignableFrom(viewModel.GetType());
        private void OpenCloseGameWindowPopup() =>
            Log.PrintColor($"OpenGameCloseWindow", Color.red);
    }
}