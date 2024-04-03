using System;
using Lukomor.MVVM;
using Lukomor.MVVM.Binders;

namespace Lukomor
{
    public class SempleBinder : EmptyBinder
    {
        protected override IDisposable BindInternal(IViewModel viewModel)
        {
            return null;
        }
    }
}
