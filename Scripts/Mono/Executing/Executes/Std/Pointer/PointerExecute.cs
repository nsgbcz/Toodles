using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

namespace Toodles.Executes
{
    public class PointerExecute : ConcreteExecute<IPointer>, IPointer
    {
        public bool Action(PointerEventData data)
        {
            if (execute != null && execute.Action(data))
            {
                Destroy(this);
                return true;
            }
            return false;
        }
    }
}