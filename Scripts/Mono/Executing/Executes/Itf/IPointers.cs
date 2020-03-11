using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executes
{
    public interface IPointer
    {
        bool Action(PointerEventData data);
    }
    public interface IPointerClick : IPointer { }
    public interface IPointerDown : IPointer { }
    public interface IPointerDrag : IPointer { }
    public interface IPointerEnter : IPointer { }
    public interface IPointerExit : IPointer { }
    public interface IPointerUp : IPointer { }
}