using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executers
{
    public class PointerUpExecute : PointerExecute, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData)
        {
            base.Action();
        }
    }
}