using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Mono
{
    public class PointerExitExecute : PointerExecute, IPointerExitHandler, IPointerExit
    {
        public void OnPointerExit(PointerEventData eventData)
        {
            OnPointer(eventData);
        }

        bool IPointerExit.OnPointerExit(PointerEventData data)
        {
            return OnPointer(data);
        }
    }
}