
using Assets._Game_.Services.UI_Service.Implementation;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using Lukomor;
using System;
using UnityEngine;
using WKosArch.Extentions;
using WKosArch.UIService.Views.Windows;

namespace WKosArch.Services.UIService.UI
{
    public class UserInterface : IUserInterface
    {
        private IUserInterfaceFactory _uiFactory;
        private WindowsStack _windowStack = new WindowsStack();

        public Lukomor.WindowViewModel FocusedWindowViewModel { get; private set; }


        public UserInterface(IDIContainer container)
        {
            _uiFactory = UserInterfaceFactory.CreateInstance();
            _uiFactory.Construct(container, this);
        }

        //public void Back(bool hideCurrentWindow = true, bool forced = false)
        //{
        //    var currentWindowType = _windowStack.Pop();

        //    if (IsHomeWindowType(currentWindowType))
        //    {
        //        OpenGameCloseWindow();
        //    }

        //    if (hideCurrentWindow)
        //    {
        //        FocusedWindowViewModel.Close(forced);
        //        FocusedWindowViewModel = null;
        //    }

        //    var previousWindowType = _windowStack.Pop();

        //    // chek in windowcache if there has windowViewModel else it`s mean that window was destroyed
        //    if (_uiFactory.UiViewModelsCache.TryGetValue(previousWindowType, out UiViewModel currentUiView))
        //    {
        //        var previousWindowViewModel = (WindowViewModel)currentUiView;

        //        if (!previousWindowViewModel.IsActive)
        //        {
        //            Show<WindowViewModel>(previousWindowType);
        //        }
        //    }
        //    else
        //    {
        //        Show<WindowViewModel>(previousWindowType);
        //    }
        //}

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

        //private void OpenGameCloseWindow()
        //{
        //    Log.PrintColor($"OpenGameCloseWindow", Color.red);
        //}

        private bool IsHomeWindowType(Type windowType) =>
            typeof(IHomeWindow).IsAssignableFrom(windowType);

        public void Show<TWindowViewModel>(UiViewModel uiViewModel) where TWindowViewModel : UiViewModel
        {
            //_uiFactory.CreateView(uiViewModel);
        }

        public void Show(UiViewModel uiViewModel)
        {
            //_uiFactory.CreateView(uiViewModel);
        }

        public void Show<TUiViewModel>() where TUiViewModel : UiViewModel, new() 
        {
           var viewModel = _uiFactory.GetOrCreateViewModel<TUiViewModel>();
           _uiFactory.GetOrCreateActiveView(viewModel);
        }

        public void Close<TUiViewModel>() where TUiViewModel: UiViewModel
        {
            _uiFactory.Close<TUiViewModel>();
        }

        public void Hide<TUiViewModel>() where TUiViewModel : UiViewModel
        {
            _uiFactory.Hide<TUiViewModel>();
        }
    }
}