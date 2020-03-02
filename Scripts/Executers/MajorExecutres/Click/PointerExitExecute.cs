using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executers
{
    public class PointerExitExecute : PointerExecute, IPointerExitHandler
    {
        public void OnPointerExit(PointerEventData eventData)
        {
            base.Action();
        }
    }
}