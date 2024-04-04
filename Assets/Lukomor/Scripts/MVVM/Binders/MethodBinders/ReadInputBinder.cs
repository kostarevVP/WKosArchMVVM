using UnityEngine;

namespace Lukomor.MVVM.Binders
{
    public class ReadInputBinder : FloatMethodBinder
    {
        [SerializeField]
        private float _value;
    }
}