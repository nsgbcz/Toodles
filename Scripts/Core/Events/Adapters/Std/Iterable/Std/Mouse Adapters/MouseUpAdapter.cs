using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Iterable.Mouse
{
    public class MouseUpAdapter : IterableAdapterBase<IMouseUp>
    {
        protected override bool Action()
        {
            return Value.OnMouseUp();
        }
    }
}
