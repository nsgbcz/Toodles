using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Mono
{
    public class PointerClickExecute : PointerExecute, IPointerClickHandler, IPointerClick
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            OnPointer(eventData);
        }

        bool IPointerClick.OnPointerClick(PointerEventData data)
        {
            return OnPointer(data);
        }
    }
}