using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Toodles.Executers
{
    public class PointerDownExecute : PointerExecute, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
           base.Action(eventData);
        }
    }
}