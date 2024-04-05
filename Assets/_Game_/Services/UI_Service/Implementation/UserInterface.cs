using Assets._Game_.Services.UI_Service.Implementation;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using Lukomor;
using System;
using System.Collections.Generic;
using UnityEngine;
using WKosArch.Extentions;
using WKosArch.UIService.Views.Windows;

namespace WKosArch.Services.UIService.UI
{
    public class UserInterface : IUserInterface, IDisposable
    {
        private IUserInterfaceFactory _uiFactory;
        private WindowsStack<WindowTreeNode> _windowStack = new WindowsStack<WindowTreeNode>();

        public Lukomor.WindowViewModel FocusedWindowViewModel { get; private set; }


        public UserInterface(IDIContainer container)
        {
            _uiFactory = UserInterfaceFactory.CreateInstance();
            _uiFactory.Construct(container, this);
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

        //public void CloseAllWindowInStack()
        //{
        //    var stackLenght = _windowStack.Length;

        //    for (int i = 0; i < stackLenght; i++)
        //    {
        //        var _currentWindowViewModelType = _windowStack.Pop();
        //        bool isHomeWindow = IsHomeWindowType(_currentWindowViewModelType);

        //        if (_uiFactory.UiViewModelsCache.TryGetValue(_currentWindowViewModelType, out Lukomor.UiViewModel currentUiView))
        //        {
        //            var _currentWindowViewModel = (WindowViewModel)currentUiView;
        //            if (!_currentWindowViewModel.Window.IsShown && isHomeWindow)
        //            {
        //                Show<Lukomor.WindowViewModel>(_currentWindowViewModelType);
        //            }
        //            else if (_currentWindowViewModel.Window.IsShown && !isHomeWindow)
        //            {
        //                bool forcedHide = (i != 0);

        //                _currentWindowViewModel.Window.Hide(forcedHide);
        //            }
        //        }
        //        else if (isHomeWindow)
        //        {
        //            Show<WindowViewModel>(_currentWindowViewModelType);
        //        }
        //    }
        //}

        //public void Show<TWindowViewModel>(bool hideWindow = true) where TWindowViewModel : UiViewModel
        //{
        //    Type uiViewModelType = typeof(TWindowViewModel);
        //    Show<TWindowViewModel>(uiViewModelType, hideWindow);
        //}

        //public void Show<TWindowViewModel>(Type uiViewModelType, bool hideWindow = true) where TWindowViewModel : UiViewModel
        //{
        //    if (FocusedWindowViewModel != null && hideWindow && typeof(Lukomor.WindowViewModel).IsAssignableFrom(uiViewModelType))
        //    {
        //        FocusedWindowViewModel.Window.Hide();
        //    }

        //    TWindowViewModel uiView = _uiFactory.ShowUiView<TWindowViewModel>(uiViewModelType);


        //    if (uiView is Lukomor.WindowViewModel)
        //    {
        //        FocusedWindowViewModel = uiView as Lukomor.WindowViewModel;
        //        FocusedWindowViewModel.transform.SetAsLastSibling();
        //        _windowStack.Push(uiView.GetType());
        //    }
        //}

        //public TWidgetViewModel ShowWidget<TWidgetViewModel>(Transform root) where TWidgetViewModel : WidgetViewModel
        //{
        //    Type widgetModelType = typeof(TWidgetViewModel);
        //    TWidgetViewModel widgetViewModel = _uiFactory.ShowWidgetView<TWidgetViewModel>(widgetModelType, root);

        //    widgetViewModel.transform.SetAsLastSibling();

        //    return widgetViewModel;
        //}

        public void Build(UISceneConfig config)
        {
            _uiFactory.Build(config);
        }

        private void OpenGameCloseWindowPopup()
        {

            Log.PrintColor($"OpenGameCloseWindow", Color.red);
        }

        private bool IsHomeWindowType(UiViewModel viewModel) =>
            typeof(IHomeWindow).IsAssignableFrom(viewModel.GetType());


        public void Show<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : UiViewModel, new()
        {
            if (hideCurrentWindow)
                FocusedWindowViewModel?.Close(forced);

            UiViewModel uiViewModel = _uiFactory.GetOrCreateViewModel<TUiViewModel>();
            _uiFactory.GetOrCreateActiveView(uiViewModel);

            AddWindowToWindowStack(uiViewModel);

        }

        private void AddWindowToWindowStack(UiViewModel uiViewModel)
        {
            if (uiViewModel is Lukomor.WindowViewModel windowViewModel)
            {
                FocusedWindowViewModel = windowViewModel;
                _windowStack.Push(new WindowTreeNode(windowViewModel));
            }
        }

        public void Close<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : UiViewModel
        {
            //_uiFactory.Close(typeof(TUiViewModel).FullName);
        }

        public void Hide<TUiViewModel>(bool hideCurrentWindow = true, bool forced = false) where TUiViewModel : UiViewModel
        {
            //_uiFactory.Hide<TUiViewModel>();
        }

        public void CloseAllWindowInStack()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _uiFactory.Dispose();
            _windowStack.Clear();
        }
    }

    public class WindowTreeNode
    {
        public UiViewModel WindowViewModel { get; }
        public List<UiViewModel> WidgetViewModels { get; }
        public bool HasChild => WidgetViewModels.Count > 0;

        public WindowTreeNode(UiViewModel windowName)
        {
            WindowViewModel = windowName;
            WidgetViewModels = new List<UiViewModel>();
        }

        public void AddWidget(UiViewModel name)
        {
            WidgetViewModels.Add(name);
        }

        public UiViewModel RemoveLastWindget()
        {
            UiViewModel name = null;

            if (WidgetViewModels.Count > 0)
            {
                name = WidgetViewModels[WidgetViewModels.Count - 1];
                WidgetViewModels.RemoveAt(WidgetViewModels.Count - 1);
            }

            return name;
        }


    }
}