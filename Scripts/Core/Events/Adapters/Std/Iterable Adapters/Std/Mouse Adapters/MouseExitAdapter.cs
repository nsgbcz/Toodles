using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Iterable.Mouse
{
    public class MouseExitAdapter : IteratableAdapterBase<IMouseExit>
    {
        protected override bool Iterate()
        {
            return Value.OnMouseExit();
        }
    }
}
