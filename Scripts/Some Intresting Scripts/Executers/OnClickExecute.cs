using MyDelegates;
using System.Collections.Generic;
using UnityEngine;

public class OnClickExecute : Execute
{
    public enum EventTime { MouseDown, MouseUp, MouseDrag, MouseEnter, MouseExit, MouseOver, MouseUpAsButton }

    [Tooltip("Copy/Paste >Reference< of ISetValue<Vector2> from MethList (for collision)")]
    public List<ISetValue<Vector2>> SetVector = new List<ISetValue<Vector2>>();

    public MyEnumMask EventMask = new MyEnumMask(typeof(EventTime));

    public override void Action()
    {
        if (SetVector.Count > 0)
        {
            Vector2 pos = Camering.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            foreach (var item in SetVector) item.SetValue(pos);
        }
        base.Action();
    }

    private void OnMouseDown()
    {
        if (EventMask.IsExecuteAble(EventTime.MouseDown))
            Action();
    }
    private void OnMouseUp()
    {
        if (EventMask.IsExecuteAble(EventTime.MouseUp))
            Action();
    }
    private void OnMouseDrag()
    {
        if (EventMask.IsExecuteAble(EventTime.MouseDrag))
            Action();
    }
    private void OnMouseEnter()
    {
        if (EventMask.IsExecuteAble(EventTime.MouseEnter))
            Action();
    }
    private void OnMouseExit()
    {
        if (EventMask.IsExecuteAble(EventTime.MouseExit))
            Action();
    }
    private void OnMouseOver()
    {
        if (EventMask.IsExecuteAble(EventTime.MouseOver))
            Action();
    }
    void OnMouseUpAsButton()
    {
        if (EventMask.IsExecuteAble(EventTime.MouseUpAsButton))
            Action();
    }
}
