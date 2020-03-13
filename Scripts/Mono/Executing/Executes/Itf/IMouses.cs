using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executes
{
    public interface IMouse
    {
        bool OnMouse();
    }
    public interface IMouseUpAsButton
    {
        bool OnMouseClick();
    }
    public interface IMouseDown
    {
        bool OnMouseDown();
    }
    public interface IMouseDrag
    {
        bool OnMouseDrag();
    }
    public interface IMouseEnter
    {
        bool OnMouseEnter();
    }
    public interface IMouseExit
    {
        bool OnMouseExit();
    }
    public interface IMouseOver
    {
        bool OnMouseOver();
    }
    public interface IMouseUp
    {
        bool OnMouseUp();
    }
}