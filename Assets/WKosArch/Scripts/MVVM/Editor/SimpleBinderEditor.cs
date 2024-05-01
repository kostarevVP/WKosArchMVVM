using UnityEditor;
using Binder = WKosArch.MVVM.Binders.Binder;

namespace WKosArch.MVVM.Editor
{
    [CustomEditor(typeof(Binder), true)]
    public class SimpleBinderEditor : BinderEditor
    {
        protected override void DrawProperties()
        {
            
        }
    }
}
