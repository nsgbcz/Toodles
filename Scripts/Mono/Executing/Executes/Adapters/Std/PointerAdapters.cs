using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes.Adapters
{
    using Actions;
    using Executes;
    using UnityEngine.EventSystems;

    public class PointerAdapter : BaseAdapter<IPointer>, IAction, IIteratable, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D
    {
        void IAction.Action()
        {
            Value.Action(null); ;
        }

        bool IIteratable.Iterate()
        {
            return Value.Action(null);
        }

        bool IMouse.Action()
        {
            return Value.Action(null);
        }

        bool IPointer.Action(PointerEventData data)
        {
            return Value.Action(data);
        }

        bool ICollision.Action(Collision coll)
        {
            return Value.Action(null);
        }

        bool ICollision2D.Action(Collision2D coll)
        {
            return Value.Action(null);
        }

        bool ITrigger.Action(Collider coll)
        {
            return Value.Action(null);
        }

        bool ITrigger2D.Action(Collider2D coll)
        {
            return Value.Action(null);
        }
    }
    public class PointerClickAdapter : BaseAdapter<IPointerClick>, IPointer
    {
        bool IPointer.Action(PointerEventData data)
        {
            return Value.Action(data);
        }
    }
    public class PointerDownAdapter : BaseAdapter<IPointerDown>, IPointer
    {
        bool IPointer.Action(PointerEventData data)
        {
            return Value.Action(data);
        }
    }
    public class PointerDragAdapter : BaseAdapter<IPointerDrag>, IPointer
    {
        bool IPointer.Action(PointerEventData data)
        {
            return Value.Action(data);
        }
    }
    public class PointerEnterAdapter : BaseAdapter<IPointerEnter>, IPointer
    {
        bool IPointer.Action(PointerEventData data)
        {
            return Value.Action(data);
        }
    }
    public class PointerExitAdapter : BaseAdapter<IPointerExit>, IPointer
    {
        bool IPointer.Action(PointerEventData data)
        {
            return Value.Action(data);
        }
    }
    public class PointerUpAdapter : BaseAdapter<IPointerUp>, IPointer
    {
        bool IPointer.Action(PointerEventData data)
        {
            return Value.Action(data);
        }
    }
}
