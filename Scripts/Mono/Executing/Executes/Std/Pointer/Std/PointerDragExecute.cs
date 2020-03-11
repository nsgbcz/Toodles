using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executes
{
    public class PointerDragExecute : PointerExecute, IDragHandler, IPointerDrag
    {
        public void OnDrag(PointerEventData eventData)
        {
            Action(eventData);
        }
    }
}