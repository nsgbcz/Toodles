using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Iterable.Mouse
{
    public class MouseDragAdapter : IterableAdapterBase<IMouseDrag>
    {
        protected override bool Action()
        {
            return Value.OnMouseDrag();
        }
    }
}
