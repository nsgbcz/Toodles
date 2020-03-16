using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Pointers
{ 
    using UnityEngine.EventSystems;

    public class PointerClickAdapter : PointerAdapterBase<IPointerClick>
    {
        protected override bool Action(PointerEventData data)
        {
            return Value.OnPointerClick(data);
        }
    }
}
