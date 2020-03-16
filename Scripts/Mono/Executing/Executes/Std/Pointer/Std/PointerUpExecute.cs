using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Mono
{
    public class PointerUpExecute : PointerExecute, IPointerUpHandler, IPointerUp
    {
        public void OnPointerUp(PointerEventData data)
        {
            OnPointer(data);
        }

        bool IPointerUp.OnPointerUp(PointerEventData data)
        {
            return OnPointer(data);
        }
    }
}