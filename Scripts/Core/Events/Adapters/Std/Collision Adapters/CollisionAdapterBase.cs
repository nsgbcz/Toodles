using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Collisions
{
    using UnityEngine.EventSystems;
    public abstract class CollisionAdapterBase<T> : BaseAdapter<T>, IAction, IIteratable, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D
    {
        protected abstract bool Action(UnityEngine.Collision coll);
        void IAction.Action()
        {
            Action(null);
        }

        bool IIteratable.Iterate()
        {
            return Action(null);
        }

        bool IMouse.OnMouse()
        {
            return Action(null);
        }

        bool IPointer.OnPointer(PointerEventData data)
        {
            return Action(null);
        }

        bool ICollision.OnCollision(Collision coll)
        {
            return Action(coll);
        }

        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Action(null);
        }

        bool ITrigger.OnTrigger(Collider coll)
        {
            return Action(null);
        }

        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Action(null);
        }
    }

}
