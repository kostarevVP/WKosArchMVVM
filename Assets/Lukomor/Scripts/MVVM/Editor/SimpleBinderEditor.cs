using UnityEditor;
using Binder = Lukomor.MVVM.Binders.Binder;

namespace Lukomor.MVVM.Editor
{
    [CustomEditor(typeof(Binder), true)]
    public class SimpleBinderEditor : BinderEditor
    {
        protected override void DrawProperties()
        {
            
        }
    }
}
