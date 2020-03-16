using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

namespace Toodles.Mono
{
    public class PointerExecute : ConcreteExecute<IPointer>, IPointer
    {
        public bool OnPointer(PointerEventData data)
        {
            if (execute != null && execute.OnPointer(data))
            {
                Destroy(this);
                return true;
            }
            return false;
        }
    }
}