using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executes
{
    public interface IPointer
    {
        bool OnPointer(PointerEventData data);
    }
    public interface IPointerClick 
    {
        bool OnPointerClick(PointerEventData data);
    }
    public interface IPointerDown 
    {
        bool OnPointerDown(PointerEventData data);
    }
    public interface IPointerDrag 
    {
        bool OnPointerDrag(PointerEventData data);
    }
    public interface IPointerEnter 
    {
        bool OnPointerEnter(PointerEventData data);
    }
    public interface IPointerExit 
    {
        bool OnPointerExit(PointerEventData data);
    }
    public interface IPointerUp 
    {
        bool OnPointerUp(PointerEventData data);
    }
}