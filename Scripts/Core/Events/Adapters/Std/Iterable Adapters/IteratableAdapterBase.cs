using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Iterable
{
    using UnityEngine.EventSystems;
    public abstract class IteratableAdapterBase<T> : BaseAdapter<T>, IAction, IIteratable, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D
    {
        protected abstract bool Iterate();

        void IAction.Action()
        {
            Iterate();
        }

        bool IIteratable.Iterate()
        {
            return Iterate();
        }

        bool IMouse.OnMouse()
        {
            return Iterate();
        }

        bool IPointer.OnPointer(PointerEventData data)
        {
            return Iterate();
        }

        bool ICollision.OnCollision(Collision coll)
        {
            return Iterate();
        }

        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Iterate();
        }

        bool ITrigger.OnTrigger(Collider coll)
        {
            return Iterate();
        }

        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Iterate();
        }
    }
}
