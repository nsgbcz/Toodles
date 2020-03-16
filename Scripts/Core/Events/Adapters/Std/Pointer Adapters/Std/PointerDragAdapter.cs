using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Pointers
{ 
    using UnityEngine.EventSystems;

    public class PointerDragAdapter : PointerAdapterBase<IPointerDrag>
    {
        protected override bool Action(PointerEventData data)
        {
            return Value.OnPointerDrag(data);
        }
    }
}
