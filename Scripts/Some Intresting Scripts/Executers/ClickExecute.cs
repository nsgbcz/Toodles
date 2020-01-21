using MyDelegates;
using System.Collections.Generic;
using UnityEngine;

public class ClickExecute : Execute
{
    public enum EventTime { OnDoubleClick, OnDoubleTwiceClick }

    [Tooltip("Copy/Paste !Reference! of ISetValue<Vector2> from MethList (for collision)")]
    public List<ISet<Vector2>> SetVector = new List<ISet<Vector2>>();

    public MyEnumMask EventMask = new MyEnumMask(typeof(EventTime));

    void Action(Vector2 pos)
    {
        foreach (var item in SetVector) item.Set = pos;
        Action();
    }

    void OnEnable()
    {
        if (EventMask.IsExecuteAble(EventTime.OnDoubleClick))
            ClickHandler.Get?.SubscribePointed(Action, ClickHandler.State.DoubleClick);
        if (EventMask.IsExecuteAble(EventTime.OnDoubleTwiceClick))
            ClickHandler.Get?.SubscribePointed(Action, ClickHandler.State.DoubleTwiceClick);
    }

    void OnDisable()
    {
        if (EventMask.IsExecuteAble(EventTime.OnDoubleClick))
            ClickHandler.Get?.UnsubscribePointed(Action, ClickHandler.State.DoubleClick);
        if (EventMask.IsExecuteAble(EventTime.OnDoubleTwiceClick))
            ClickHandler.Get?.UnsubscribePointed(Action, ClickHandler.State.DoubleTwiceClick);
    }
}
