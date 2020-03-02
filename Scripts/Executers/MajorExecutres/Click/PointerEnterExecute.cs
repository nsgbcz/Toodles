using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executers
{
    public class PointerEnterExecute : PointerExecute, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            base.Action();
        }
    }
}