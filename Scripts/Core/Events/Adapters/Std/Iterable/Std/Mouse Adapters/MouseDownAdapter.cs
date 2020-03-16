using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Iterable.Mouse
{
    public class MouseDownAdapter : IterableAdapterBase<IMouseDown>
    {
        protected override bool Action()
        {
            return Value.OnMouseDown();
        }
    }
}
