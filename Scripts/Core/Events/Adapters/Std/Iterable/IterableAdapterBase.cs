using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Iterable
{
    using UnityEngine.EventSystems;
    public abstract class IterableAdapterBase<T> : BaseAdapter<T>, IAction, IIteratable, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D
    {
        protected abstract bool Action();

        void IAction.Action()
        {
            Action();
        }

        bool IIteratable.Iterate()
        {
            return Action();
        }

        bool IMouse.OnMouse()
        {
            return Action();
        }

        bool IPointer.OnPointer(PointerEventData data)
        {
            return Action();
        }

        bool ICollision.OnCollision(UnityEngine.Collision coll)
        {
            return Action();
        }

        bool ICollision2D.OnCollision2D(UnityEngine.Collision2D coll)
        {
            return Action();
        }

        bool ITrigger.OnTrigger(UnityEngine.Collider coll)
        {
            return Action();
        }

        bool ITrigger2D.OnTrigger2D(UnityEngine.Collider2D coll)
        {
            return Action();
        }
    }

}
