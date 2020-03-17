using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Iterable.Mouse
{
    public class MouseUpAdapter : IteratableAdapterBase<IMouseUp>
    {
        protected override bool Iterate()
        {
            return Value.OnMouseUp();
        }
    }
}
