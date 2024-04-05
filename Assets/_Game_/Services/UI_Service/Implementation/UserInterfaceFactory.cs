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

namespace Assets._Game_.Services.UI_Service.Implementation
{
    public class UserInterfaceFactory : MonoBehaviour, IUserInterfaceFactory
    {
        private const string PrefabPath = "[INTERFACE]";

        public Dictionary<string, UiViewModel> UiViewModelsCache => _createdUiViewModelsCache;
        public Dictionary<string, View> ViewCache => _createdViewCache;



        private static UserInterfaceFactory _instance;

        [SerializeField] private UILayerContainer[] _containers;

        private Dictionary<string, UiViewModel> _createdUiViewModelsCache = new();
        private Dictionary<string, View> _createdViewCache = new();

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

        public View CreateView(UiViewModel uiViewModel, Transform containerLayer = null)
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
                    if (containerLayer == null)
                    {
                        containerLayer = GetLayerContainer(uiViewModel.TargetLayer);
                    }
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

        public View GetOrCreateActiveView(UiViewModel viewModel, Transform containerLayer = null)
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
                view = CreateView(viewModel, containerLayer);

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

        private Transform GetLayerContainer(UILayer layer)
        {
            return _containers.FirstOrDefault(container => container.Layer == layer)?.transform;
        }

        public void Dispose()
        {
            _createdUiViewModelsCache.Clear();
        }
    }
}
