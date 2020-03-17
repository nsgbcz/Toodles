using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Iterable.Mouse
{
    public class MouseOverAdapter : IteratableAdapterBase<IMouseOver>
    {
        protected override bool Iterate()
        {
            return Value.OnMouseOver();
        }
    }
}
