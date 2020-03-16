using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Pointers
{ 
    using UnityEngine.EventSystems;

    public class PointerEnterAdapter : PointerAdapterBase<IPointerEnter>
    {
        protected override bool Action(PointerEventData data)
        {
            return Value.OnPointerEnter(data);
        }
    }
}
