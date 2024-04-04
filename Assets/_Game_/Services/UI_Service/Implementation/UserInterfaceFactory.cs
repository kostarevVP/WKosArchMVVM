using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using Lukomor;
using Lukomor.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WKosArch.Extentions;
using WKosArch.Services.UIService;
using WKosArch.Services.UIService.Common;
using WKosArch.Services.UIService.UI;
using WKosArch.UIService.Views.Widgets;

namespace Assets._Game_.Services.UI_Service.Implementation
{
    public class UserInterfaceFactory : MonoBehaviour, IUserInterfaceFactory, IDisposable
    {
        private const string PrefabPath = "[INTERFACE]";

        public Dictionary<string, UiViewModel> UiViewModelsCache => _createdUiViewModelsCache;
        public Dictionary<string, View> ViewCache => _createdViewCache;



        [SerializeField] private UILayerContainer[] _containers;

        private static UserInterfaceFactory _instance;

        private Dictionary<string, UiViewModel> _createdUiViewModelsCache = new();
        private Dictionary<string, View> _createdViewCache = new();

        private Dictionary<Type, WidgetViewModel> _createdWidgetViewModelsCache = new();

        private IDIContainer _diContainer;
        private IUserInterface _ui;

        private UISceneConfig _uiSceneConfig;

        public void Construct(IDIContainer dIContainer, IUserInterface ui)
        {
            _diContainer = dIContainer;
            _ui = ui;
        }

        public static UserInterfaceFactory CreateInstance()
        {
            if (_instance != null)
            {
                Debug.LogWarning($"UserInterface CreateInstance _instance = {_instance}");
                return _instance;
            }

            var prefab = Resources.Load<UserInterfaceFactory>(PrefabPath);
            _instance = Instantiate(prefab);
            DontDestroyOnLoad(_instance);

            return _instance;
        }

        public void Build(UISceneConfig config)
        {
            _uiSceneConfig = config;
        }

        //public TUiViewModel ShowUiView<TUiViewModel>() where TUiViewModel : Lukomor.UiViewModel
        //{
        //    Type uiViewModelType = typeof(TUiViewModel);

        //    return ShowUiView<TUiViewModel>(uiViewModelType);
        //}

        //public TUiViewModel ShowUiView<TUiViewModel>(Type uiViewModelType) where TUiViewModel : Lukomor.UiViewModel
        //{
        //    TUiViewModel uiViewModel = null;

        //    if (_createdUiViewModelsCache.TryGetValue(uiViewModelType, out var viewModel))
        //    {
        //        uiViewModel = viewModel as TUiViewModel;
        //    }
        //    else
        //    {
        //        uiViewModel = CreateUiViewModel<TUiViewModel>(uiViewModelType);
        //    }

        //    ActivateWindowViewModel(uiViewModel);

        //    return uiViewModel;
        //}

        //public TWidgetViewModel ShowWidgetView<TWidgetViewModel>(Type widgetModelType, Transform root) where TWidgetViewModel : WidgetViewModel
        //{
        //    TWidgetViewModel widgetViewModel = null;

        //    if (_createdWidgetViewModelsCache.TryGetValue(widgetModelType, out var viewModel))
        //    {
        //        if (!viewModel.gameObject.IsUnityNull())
        //        {
        //            widgetViewModel = viewModel as TWidgetViewModel;
        //        }
        //        else
        //        {
        //            widgetViewModel = CreateWidgetViewModel<TWidgetViewModel>(widgetModelType, root);
        //        }
        //    }
        //    else
        //    {
        //        widgetViewModel = CreateWidgetViewModel<TWidgetViewModel>(widgetModelType, root);
        //    }

        //    return widgetViewModel;
        //}

        //private TUiViewModel CreateWidgetViewModel<TUiViewModel>(Type typeViewModel, Transform root) where TUiViewModel : WidgetViewModel
        //{
        //    TUiViewModel prefabWidgetViewModel = null;

        //    if (_uiSceneConfig.TryGetWidgetPrefab(typeViewModel, out TUiViewModel prefab))
        //    {
        //        if (prefab == null)
        //        {
        //            Log.PrintWarning($"Couldn't open window ({typeViewModel}). Maybe its not add to UISceneConfig for this Scene");
        //        }
        //        else
        //        {
        //            prefabWidgetViewModel = Instantiate(prefab, root);
        //            prefabWidgetViewModel.InjectDI(_diContainer);

        //            if (prefabWidgetViewModel.IsSingleInstance)
        //            {
        //                _createdWidgetViewModelsCache[typeViewModel] = prefabWidgetViewModel;
        //            }
        //        }
        //    }

        //    return prefabWidgetViewModel;
        //}


        //private TUiViewModel CreateUiViewModel<TUiViewModel>(TUiViewModel uiViewModel) where TUiViewModel : Lukomor.UiViewModel
        //{
        //    Type uiViewModelType = uiViewModel.GetType();

        //    return CreateUiViewModel<TUiViewModel>(uiViewModelType);
        //}

        public View CreateView(UiViewModel uiViewModel)
        {
            View view = null;

            if (_uiSceneConfig.WindowMappings.TryGetValue(uiViewModel.GetType().FullName, out View prefabView))
            {
                if (prefabView == null)
                {
                    Log.PrintWarning($"Couldn't open View for ({uiViewModel}). Maybe its not add to UISceneConfig for this Scene");
                }
                else
                {
                    Transform containerLayer = GetLayerContainer(uiViewModel.TargetLayer);
                    view = Instantiate(prefabView, containerLayer);
                    view.Bind(uiViewModel);
                }
            }
            else
            {
                Log.PrintWarning($"Couldn't find View for ({uiViewModel}). Maybe its not add to UISceneConfig for this Scene");
            }

            return view;
        }


        //private void ActivateWindowViewModel(UiViewModel uiViewModel)
        //{
        //    if (!uiViewModel.UiView.IsShown)
        //    {
        //        uiViewModel.Subscribe();

        //        var uiView = uiViewModel.UiView;

        //        uiView.Show();
        //        uiView.Hidden += OnWindowHidden;
        //        uiView.Destroyed += OnWindowDestroyed;
        //    }

        //    uiViewModel.Refresh();
        //}

        //private void OnWindowHidden(UiViewModel uiViewModel)
        //{
        //    uiViewModel.Unsubscribe();
        //}

        //private void OnWindowDestroyed(UiViewModel uiViewModel)
        //{
        //    OnWindowHidden(uiViewModel);

        //    _createdUiViewModelsCache.Remove(uiViewModel.GetType());
        //}

        private Transform GetLayerContainer(UILayer layer)
        {
            return _containers.FirstOrDefault(container => container.Layer == layer)?.transform;
        }

        //private void DestroyOldWindows()
        //{
        //    foreach (var createdWindowViewModelItem in _createdUiViewModelsCache)
        //    {
        //        Destroy(createdWindowViewModelItem.Value.gameObject);
        //    }

        //    _createdUiViewModelsCache.Clear();
        //    _createdWidgetViewModelsCache.Clear();
        //}

        //private void CreateNewUiViews()
        //{
        //    WindowViewModel[] windowPrefabsForCreating = _uiSceneConfig.WindowPrefabs;
        //    HudViewModel[] hudPrefabsForCreating = _uiSceneConfig.HudPrefabs;
        //    WidgetViewModel[] widgetPrefabsForCreating = _uiSceneConfig.WidgetPrefabs;

        //    foreach (WindowViewModel prefab in windowPrefabsForCreating)
        //    {
        //        if (prefab.WindowSettings.IsPreCached)
        //        {
        //            AddToUiViewModelToCash(prefab);
        //        }
        //    }

        //    foreach (HudViewModel prefab in hudPrefabsForCreating)
        //    {
        //        if (prefab.WindowSettings.IsPreCached)
        //        {
        //            AddToUiViewModelToCash(prefab);
        //        }
        //    }

        //}

        //private TUiViewModel AddToUiViewModelToCash<TUiViewModel>(TUiViewModel uiViewModel) where TUiViewModel : UiViewModel
        //{
        //    var viewModel = CreateUiViewModel(uiViewModel);

        //    HideUiViewModelInstantly(viewModel);

        //    if (viewModel.WindowSettings.OpenWhenCreated)
        //    {
        //        var type = viewModel.GetType();
        //        _ui.Show<TUiViewModel>(type);
        //    }

        //    return viewModel;
        //}

        //private static void HideUiViewModelInstantly<TUiViewModel>(TUiViewModel prefabUiViewModel) where TUiViewModel : ViewModel
        //{
        //    if (prefabUiViewModel is WindowViewModel)
        //    {
        //        var windowViewModel = prefabUiViewModel as WindowViewModel;
        //        windowViewModel.Window.HideInstantly();
        //    }
        //    if (prefabUiViewModel is HudViewModel)
        //    {
        //        var windowViewModel = prefabUiViewModel as HudViewModel;
        //        windowViewModel.Hud.HideInstantly();
        //    }
        //}

        public void Dispose()
        {
            _createdUiViewModelsCache.Clear();

        }

        public UiViewModel GetOrCreateViewModel<TUiViewModel>() where TUiViewModel : UiViewModel, new()
        {
            var fullName = typeof(TUiViewModel).FullName;

            if (_createdUiViewModelsCache.TryGetValue(fullName, out UiViewModel uiViewModel))
            {
                if (uiViewModel == null)
                {
                    _createdUiViewModelsCache.Remove(fullName);

                    uiViewModel = new TUiViewModel();
                    uiViewModel.Inject(_diContainer, _ui);

                    _createdUiViewModelsCache.Add(fullName, uiViewModel);
                }
            }
            else
            {
                uiViewModel = new TUiViewModel();
                uiViewModel.Inject(_diContainer, _ui);

                _createdUiViewModelsCache.Add(fullName, uiViewModel);
            }

            return uiViewModel;
        }

        public View GetOrCreateActiveView(UiViewModel viewModel)
        {
            var fullName = viewModel.GetType().FullName;

            if (_createdViewCache.TryGetValue(fullName, out View view))
            {
                if (!view.isActiveAndEnabled)
                {
                    view.gameObject.SetActive(true);
                }
                return view;
            }
            else
            {
                view = CreateView(viewModel);

                _createdViewCache.Add(fullName, view);
            }

            return view;
        }

        public void Close<TUiViewModel>() where TUiViewModel : UiViewModel
        {
            var fullName = typeof(TUiViewModel).FullName;

            _createdUiViewModelsCache[fullName].Close();
            _createdViewCache.Remove(fullName);
        }

        public void Hide<TUiViewModel>() where TUiViewModel : UiViewModel
        {
            var fullName = typeof(TUiViewModel).FullName;

            _createdUiViewModelsCache[fullName].Hide();
        }
    }
}
