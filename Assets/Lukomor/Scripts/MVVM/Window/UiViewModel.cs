using Lukomor.MVVM;
using System.Reactive.Linq;
using System;
using WKosArch.Services.UIService.Common;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Services.UIService.UI;

namespace Lukomor
{
    public abstract class UiViewModel : IViewModel
    {
        public UILayer TargetLayer { get; set; }
        public IObservable<bool> Opened { get; }
        public IObservable<bool> Closed { get; }
        public IObservable<bool> Hided { get; }

        public IDIContainer DiContainer => _dIContainer;
        public IUserInterface UI => _userInterface;

        private IDIContainer _dIContainer;
        private IUserInterface _userInterface;

        private event Action<bool> _opened;
        private event Action<bool> _closed;
        private event Action<bool> _hided;


        protected UiViewModel()
        {
            Opened = Observable.FromEvent<bool>(a => _opened += a, a => _opened -= a);
            Closed = Observable.FromEvent<bool>(a => _closed += a, a => _closed -= a);
            Hided = Observable.FromEvent<bool>(a => _hided  += a, a => _hided -= a);
        }

        public void Inject(IDIContainer dIContainer, IUserInterface userInterface)
        {
            _dIContainer = dIContainer;
            _userInterface = userInterface;
        }

        public void Open(bool forced = false) => 
            _opened?.Invoke(forced);

        public void Close(bool forced = false) => 
            _closed?.Invoke(forced);

        public void Hide(bool forced = false) =>
            _hided?.Invoke(forced);
    }
}
