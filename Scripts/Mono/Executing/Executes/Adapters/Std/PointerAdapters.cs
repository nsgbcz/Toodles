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
            Value.OnPointer(null); ;
        }

        bool IIteratable.Iterate()
        {
            return Value.OnPointer(null);
        }

        bool IMouse.OnMouse()
        {
            return Value.OnPointer(null);
        }

        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.OnPointer(data);
        }

        bool ICollision.OnCollision(Collision coll)
        {
            return Value.OnPointer(null);
        }

        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Value.OnPointer(null);
        }

        bool ITrigger.OnTrigger(Collider coll)
        {
            return Value.OnPointer(null);
        }

        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Value.OnPointer(null);
        }
    }
    public class PointerClickAdapter : BaseAdapter<IPointerClick>, IPointer
    {
        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.OnPointerClick(data);
        }
    }
    public class PointerDownAdapter : BaseAdapter<IPointerDown>, IPointer
    {
        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.OnPointerDown(data);
        }
    }
    public class PointerDragAdapter : BaseAdapter<IPointerDrag>, IPointer
    {
        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.OnPointerDrag(data);
        }
    }
    public class PointerEnterAdapter : BaseAdapter<IPointerEnter>, IPointer
    {
        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.OnPointerEnter(data);
        }
    }
    public class PointerExitAdapter : BaseAdapter<IPointerExit>, IPointer
    {
        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.OnPointerExit(data);
        }
    }
    public class PointerUpAdapter : BaseAdapter<IPointerUp>, IPointer
    {
        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.OnPointerUp(data);
        }
    }
}
