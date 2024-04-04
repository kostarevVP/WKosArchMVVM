﻿using UnityEngine;
using WKosArch.Services.UIService.Common;

namespace Lukomor.MVVM.Binders
{
    public class CloseWindowWithAnimationBinder : ObservableBinder<bool>
    {
        [SerializeField] private GameObject _destroyingGameObject;
        [Space]
        [SerializeField]
        private Transition _transitionOut = default;

        protected override async void OnPropertyChanged(bool forced)
        {
            if (!forced)
            {
                await _transitionOut.Play();
            }

            Destroy(_destroyingGameObject);
        }

#if UNITY_EDITOR
        private void Reset()
        {
            if (!_destroyingGameObject)
            {
                _destroyingGameObject = gameObject;
            }
        }
#endif
    }

}