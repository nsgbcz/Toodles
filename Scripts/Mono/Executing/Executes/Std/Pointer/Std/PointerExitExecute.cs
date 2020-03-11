using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executes
{
    public class PointerExitExecute : PointerExecute, IPointerExitHandler, IPointerExit
    {
        public void OnPointerExit(PointerEventData eventData)
        {
            Action(eventData);
        }
    }
}