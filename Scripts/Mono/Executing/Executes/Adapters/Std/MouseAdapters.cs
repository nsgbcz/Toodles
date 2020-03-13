using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes.Adapters
{
    using Actions;
    using UnityEngine.EventSystems;

    public class MouseAdapter : BaseAdapter<IMouse>, IAction, IIteratable, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D
    {
        void IAction.Action()
        {
            Value.OnMouse(); ;
        }

        bool IIteratable.Iterate()
        {
            return Value.OnMouse();
        }

        bool IMouse.OnMouse()
        {
            return Value.OnMouse();
        }

        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.OnMouse();
        }

        bool ICollision.OnCollision(Collision coll)
        {
            return Value.OnMouse();
        }

        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Value.OnMouse();
        }

        bool ITrigger.OnTrigger(Collider coll)
        {
            return Value.OnMouse();
        }

        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Value.OnMouse();
        }
    }
    public class MouseClickAdapter : BaseAdapter<IMouseUpAsButton>, IMouse
    {
        bool IMouse.OnMouse()
        {
            return Value.OnMouseClick();
        }
    }
    public class MouseDownAdapter : BaseAdapter<IMouseDown>, IMouse
    {
        bool IMouse.OnMouse()
        {
            return Value.OnMouseDown();
        }
    }
    public class MouseDragAdapter : BaseAdapter<IMouseDrag>, IMouse
    {
        bool IMouse.OnMouse()
        {
            return Value.OnMouseDrag();
        }
    }
    public class MouseEnterAdapter : BaseAdapter<IMouseEnter>, IMouse
    {
        bool IMouse.OnMouse()
        {
            return Value.OnMouseEnter();
        }
    }
    public class MouseExitAdapter : BaseAdapter<IMouseExit>, IMouse
    {
        bool IMouse.OnMouse()
        {
            return Value.OnMouseExit();
        }
    }
    public class MouseOverAdapter : BaseAdapter<IMouseOver>, IMouse
    {
        bool IMouse.OnMouse()
        {
            return Value.OnMouseOver();
        }
    }
    public class MouseUpAdapter : BaseAdapter<IMouseUp>, IMouse
    {
        bool IMouse.OnMouse()
        {
            return Value.OnMouseUp();
        }
    }
}
