using Lukomor.MVVM.Binders;
using UnityEditor;

namespace Lukomor.MVVM.Editor
{
    [CustomEditor(typeof(EmptyBinder), true)]
    public class EmptyBinderEditor : BinderEditor
    {
        protected override void DrawProperties()
        {
           
        }
    }
}
