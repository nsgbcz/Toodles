using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executes
{
    public class PointerUpExecute : PointerExecute, IPointerUpHandler, IPointerUp
    {
        public void OnPointerUp(PointerEventData eventData)
        {
            Action(eventData);
        }
    }
}