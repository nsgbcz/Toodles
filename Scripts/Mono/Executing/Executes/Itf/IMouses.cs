using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executes
{
    public interface IMouse
    {
        bool Action();
    }
    public interface IMouseUpAsButton : IMouse { }
    public interface IMouseDown : IMouse { }
    public interface IMouseDrag : IMouse { }
    public interface IMouseEnter : IMouse { }
    public interface IMouseExit : IMouse { }
    public interface IMouseOver : IMouse { }
    public interface IMouseUp : IMouse { }
}