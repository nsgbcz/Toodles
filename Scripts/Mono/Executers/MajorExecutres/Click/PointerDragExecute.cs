using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executers
{
    public class PointerDragExecute : PointerExecute, IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            base.Action(eventData);
        }
    }
}