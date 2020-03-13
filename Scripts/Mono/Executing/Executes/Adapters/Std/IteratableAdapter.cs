using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes.Adapters
{
    using Actions;
    using UnityEngine.EventSystems;

    public class IteratableAdapter : BaseAdapter<IIteratable>, IAction, IIteratable, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D
    {
        void IAction.Action()
        {
            Value.Iterate();
        }

        bool IIteratable.Iterate()
        {
            return Value.Iterate();
        }

        bool IMouse.OnMouse()
        {
            return Value.Iterate();
        }

        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.Iterate();
        }

        bool ICollision.OnCollision(Collision coll)
        {
            return Value.Iterate();
        }

        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Value.Iterate();
        }

        bool ITrigger.OnTrigger(Collider coll)
        {
            return Value.Iterate();
        }

        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Value.Iterate();
        }
    }
}
