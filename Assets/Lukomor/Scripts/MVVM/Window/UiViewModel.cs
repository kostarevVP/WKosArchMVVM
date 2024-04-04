using Lukomor.MVVM;
using System.Reactive.Linq;
using System;
using WKosArch.Services.UIService.Common;
using System.Reactive;

namespace Lukomor
{
    public class UiViewModel : IViewModel
    {
        public UILayer Layer { get; set; }
        public IObservable<Unit> Opened { get; }
        public IObservable<Unit> Closed { get; }


        private event Action<Unit> _closed;
        private event Action<Unit> _opened;


        protected UiViewModel()
        {
            Opened = Observable.FromEvent<Unit>(a => _opened += a, a => _opened -= a);
            Closed = Observable.FromEvent<Unit>(a => _closed += a, a => _closed -= a);
        }

        public void Open() => 
            _opened?.Invoke(Unit.Default);

        public void Close() => 
            _closed?.Invoke(Unit.Default);
    }
}
