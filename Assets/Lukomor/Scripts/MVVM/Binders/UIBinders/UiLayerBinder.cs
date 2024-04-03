using System;
using UnityEngine;
using Lukomor.MVVM;
using Lukomor.MVVM.Binders;
using WKosArch.Services.UIService.Common;

namespace Lukomor
{
    public class UiLayerBinder : EmptyBinder
    {
        [SerializeField] private UILayer _layer;

        protected override IDisposable BindInternal(IViewModel viewModel)
        {
            if (viewModel is UiViewModel uiViewModel)
                uiViewModel.Layer = _layer;

            return null;
        }
    }
}
