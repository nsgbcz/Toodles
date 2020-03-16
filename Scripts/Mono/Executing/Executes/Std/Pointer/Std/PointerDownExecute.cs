using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Toodles.Mono
{
    public class PointerDownExecute : PointerExecute, IPointerDownHandler, IPointerDown
    {
        public void OnPointerDown(PointerEventData eventData)
        {
           OnPointer(eventData);
        }

        bool IPointerDown.OnPointerDown(PointerEventData data)
        {
            return OnPointer(data);
        }
    }
}