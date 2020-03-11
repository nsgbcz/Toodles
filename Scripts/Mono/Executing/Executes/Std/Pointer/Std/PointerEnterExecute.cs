using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executes
{
    public class PointerEnterExecute : PointerExecute, IPointerEnterHandler, IPointerEnter
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            Action(eventData);
        }
    }
}