using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Iterable.Mouse
{
    public class MouseDownAdapter : IteratableAdapterBase<IMouseDown>
    {
        protected override bool Iterate()
        {
            return Value.OnMouseDown();
        }
    }
}
