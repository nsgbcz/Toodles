using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executes
{
    public class PointerClickExecute : PointerExecute, IPointerClickHandler, IPointerClick
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Action(eventData);
        }
    }
}