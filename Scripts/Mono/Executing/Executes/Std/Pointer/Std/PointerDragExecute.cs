using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Mono
{
    public class PointerDragExecute : PointerExecute, IDragHandler, IPointerDrag
    {
        public void OnDrag(PointerEventData eventData)
        {
            OnPointer(eventData);
        }

        public bool OnPointerDrag(PointerEventData data)
        {
            return OnPointer(data);
        }
    }
}