using Lukomor.MVVM;
using System.Reactive.Linq;
using System;
using WKosArch.Services.UIService.Common;
using System.Reactive;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Services.UIService.UI;

namespace Lukomor
{
    public abstract class UiViewModel : IViewModel
    {
        public UILayer TargetLayer { get; set; }
        public IObservable<Unit> Opened { get; }
        public IObservable<bool> Closed { get; }
        public IDIContainer DiContainer { get; set; }
        public IUserInterface UI { get; set; }

        private IDIContainer _dIContainer;
        private IUserInterface _userInterface;

        private event Action<bool> _closed;
        private event Action<Unit> _opened;


        protected UiViewModel()
        {
            Opened = Observable.FromEvent<Unit>(a => _opened += a, a => _opened -= a);
            Closed = Observable.FromEvent<bool>(a => _closed += a, a => _closed -= a);
        }

        public void Inject(IDIContainer dIContainer, IUserInterface userInterface)
        {
            _dIContainer = dIContainer;
            _userInterface = userInterface;
        }

        public void Open() => 
            _opened?.Invoke(Unit.Default);

        public void Close(bool forced = false) => 
            _closed?.Invoke(forced);
    }
}
