using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executers
{
    public class PointerClickExecute : PointerExecute, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            base.Action(eventData);
        }
    }
}