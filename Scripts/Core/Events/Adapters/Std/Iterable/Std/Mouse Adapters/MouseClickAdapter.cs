using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Iterable.Mouse
{
    public class MouseClickAdapter : IterableAdapterBase<IMouseUpAsButton>
    {
        protected override bool Action()
        {
            return Value.OnMouseClick();
        }
    }
}
