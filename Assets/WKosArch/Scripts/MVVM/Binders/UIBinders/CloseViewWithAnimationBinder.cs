﻿using UnityEngine;
using WKosArch.Services.UIService.Common;

namespace WKosArch.MVVM.Binders
{
    public class CloseViewWithAnimationBinder : ObservableBinder<bool>
    {
        [SerializeField] private GameObject _destroyingGameObject;
        [Space]
        [SerializeField]
        private Transition _transitionOut = default;

        protected override async void OnPropertyChanged(bool forced)
        {
            if (!forced && _transitionOut != default)
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
