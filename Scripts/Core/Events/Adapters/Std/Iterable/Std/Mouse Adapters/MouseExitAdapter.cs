using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Iterable.Mouse
{
    public class MouseExitAdapter : IterableAdapterBase<IMouseExit>
    {
        protected override bool Action()
        {
            return Value.OnMouseExit();
        }
    }
}
