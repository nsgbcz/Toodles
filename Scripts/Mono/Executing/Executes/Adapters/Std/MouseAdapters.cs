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
            Value.Action(); ;
        }

        bool IIteratable.Iterate()
        {
            return Value.Action();
        }

        bool IMouse.Action()
        {
            return Value.Action();
        }

        bool IPointer.Action(PointerEventData data)
        {
            return Value.Action();
        }

        bool ICollision.Action(Collision coll)
        {
            return Value.Action();
        }

        bool ICollision2D.Action(Collision2D coll)
        {
            return Value.Action();
        }

        bool ITrigger.Action(Collider coll)
        {
            return Value.Action();
        }

        bool ITrigger2D.Action(Collider2D coll)
        {
            return Value.Action();
        }
    }
    public class MouseClickAdapter : BaseAdapter<IMouseUpAsButton>, IMouse
    {
        bool IMouse.Action()
        {
            return Value.Action();
        }
    }
    public class MouseDownAdapter : BaseAdapter<IMouseDown>, IMouse
    {
        bool IMouse.Action()
        {
            return Value.Action();
        }
    }
    public class MouseDragAdapter : BaseAdapter<IMouseDrag>, IMouse
    {
        bool IMouse.Action()
        {
            return Value.Action();
        }
    }
    public class MouseEnterAdapter : BaseAdapter<IMouseEnter>, IMouse
    {
        bool IMouse.Action()
        {
            return Value.Action();
        }
    }
    public class MouseExitAdapter : BaseAdapter<IMouseExit>, IMouse
    {
        bool IMouse.Action()
        {
            return Value.Action();
        }
    }
    public class MouseOverAdapter : BaseAdapter<IMouseOver>, IMouse
    {
        bool IMouse.Action()
        {
            return Value.Action();
        }
    }
    public class MouseUpAdapter : BaseAdapter<IMouseUp>, IMouse
    {
        bool IMouse.Action()
        {
            return Value.Action();
        }
    }
}
