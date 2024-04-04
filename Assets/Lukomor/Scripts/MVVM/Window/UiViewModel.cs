using Lukomor.MVVM;
using System.Reactive.Linq;
using System;
using WKosArch.Services.UIService.Common;
using System.Reactive;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;

namespace Lukomor
{
    public abstract class UiViewModel : IViewModel
    {
        public UILayer TargetLayer { get; set; }
        public IObservable<Unit> Opened { get; }
        public IObservable<bool> Closed { get; }
        public IDIContainer DiContainer => _dIContainer;

        private IDIContainer _dIContainer;

        private event Action<bool> _closed;
        private event Action<Unit> _opened;


        protected UiViewModel(/*IDIContainer dIContainer*/)
        {
            //_dIContainer = dIContainer;
            Opened = Observable.FromEvent<Unit>(a => _opened += a, a => _opened -= a);
            Closed = Observable.FromEvent<bool>(a => _closed += a, a => _closed -= a);
        }

        public void Open() => 
            _opened?.Invoke(Unit.Default);

        public void Close(bool forced) => 
            _closed?.Invoke(forced);
    }
}
