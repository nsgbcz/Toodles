using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executes
{
    public interface IPointer
    {
        bool Action(PointerEventData data);
    }
    public interface IPointerClick 
    {
        bool Action(PointerEventData data);
    }
    public interface IPointerDown 
    {
        bool Action(PointerEventData data);
    }
    public interface IPointerDrag 
    {
        bool Action(PointerEventData data);
    }
    public interface IPointerEnter 
    {
        bool Action(PointerEventData data);
    }
    public interface IPointerExit 
    {
        bool Action(PointerEventData data);
    }
    public interface IPointerUp 
    {
        bool Action(PointerEventData data);
    }
}