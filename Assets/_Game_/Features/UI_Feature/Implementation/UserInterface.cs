using Assets._Game_.Services.UI_Service.Implementation;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using Lukomor;
using System;
using UnityEngine;
using WKosArch.Extentions;
using WKosArch.UIService.Views.Windows;

namespace WKosArch.Services.UIService.UI
{
    public class UserInterface : IUserInterface, IDisposable
    {
        public Lukomor.WindowViewModel FocusedWindowViewModel { get; private set; }

        private IUserInterfaceFactory _uiFactory;
        private WindowsStack<WindowTreeNode> _windowStack = new WindowsStack<WindowTreeNode>();


        public UserInterface(IDIContainer container)
        {
            _uiFactory = UserInterfaceFactory.CreateInstance();
            _uiFactory.Construct(container, this);
        }
        public void Build(UISceneConfig config) =>
            _uiFactory.Build(config);

        public void Show<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : UiViewModel, new()
        {
            if (hideCurrentWindow && FocusedWindowViewModel != null)
                _uiFactory.Close(FocusedWindowViewModel);

            UiViewModel uiViewModel = _uiFactory.GetOrCreateViewModel<TUiViewModel>();
            _uiFactory.GetOrCreateActiveView(uiViewModel);

            AddWindowToWindowStack(uiViewModel);
        }

        public void Back(bool hideCurrentWindow = true, bool forced = false)
        {
            var currentUiViewModel = _windowStack.Pop().WindowViewModel;

            if (IsHomeWindowType(currentUiViewModel))
            {
                _windowStack.Push(new WindowTreeNode(currentUiViewModel));
                OpenGameCloseWindowPopup();
                return;
            }

            if (hideCurrentWindow)
            {
                _uiFactory.Close(currentUiViewModel);
            }

            var previousUiViewModel = _windowStack.Pop().WindowViewModel;

            _uiFactory.GetOrCreateActiveView(previousUiViewModel);

            AddWindowToWindowStack(previousUiViewModel);
        }

        public void CloseAllWindowInStack()
        {
            var stackLenght = _windowStack.Length;

            for (int i = 0; i < stackLenght; i++)
            {
                var currentWindowViewModel = _windowStack.Pop().WindowViewModel;
                bool isHomeWindow = IsHomeWindowType(currentWindowViewModel);

                if (!isHomeWindow)
                {
                    bool forcedHide = (i != 0);

                    _uiFactory.Close(currentWindowViewModel, forcedHide);

                }
                else if (isHomeWindow)
                {
                    _uiFactory.GetOrCreateActiveView(currentWindowViewModel);
                    AddWindowToWindowStack(currentWindowViewModel);
                }
            }
        }

        public void Close<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : UiViewModel
        {
            var fullName = typeof(TUiViewModel).FullName;
            _uiFactory.Close(fullName);
        }

        public void Hide<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : UiViewModel
        {
            var fullName = typeof(TUiViewModel).FullName;
            _uiFactory.Hide(fullName);
        }

        public void Dispose()
        {
            _uiFactory.Dispose();
            _windowStack.Clear();
        }


        private void AddWindowToWindowStack(UiViewModel uiViewModel)
        {
            if (uiViewModel is Lukomor.WindowViewModel windowViewModel)
            {
                FocusedWindowViewModel = windowViewModel;
                _windowStack.Push(new WindowTreeNode(windowViewModel));
            }
        }
        private bool IsHomeWindowType(UiViewModel viewModel) =>
            typeof(IHomeWindow).IsAssignableFrom(viewModel.GetType());
        private void OpenGameCloseWindowPopup() =>
            Log.PrintColor($"OpenGameCloseWindow", Color.red);
    }
}