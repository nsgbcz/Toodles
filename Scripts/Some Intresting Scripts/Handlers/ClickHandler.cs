using System;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{

    public float holdTime = 0.1f;
    public float timeBetweenClick = 0.4f;

    private static ClickHandler _get = null;

    public static ClickHandler Get
    {
        get
        {
            if (_get == null)
            {
                _get = GameObject.FindObjectOfType<ClickHandler>();

                if (!OnApplicationEventHandler.Quit && _get == null)
                {
                    _get = new GameObject("ClickChecker").AddComponent<ClickHandler>();
                    //DontDestroyOnLoad(_get);
                }
            }
            return _get;
        }
    }

    void Awake()
    {
        if (_get == null) _get = this;
        else if (_get != this) Destroy(this);
    }

    Dictionary<int, float> downTime = new Dictionary<int, float>();

    void LateUpdate()
    {
        //if (GameScene.Stop) return;
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) Down(0);//, Camering.ScreenToWorldPoint(Input.mousePosition));
        else if (Input.GetMouseButtonUp(0)) Up(0, CameraHandler.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButtonDown(1)) Down(1);//, Camering.ScreenToWorldPoint(Input.mousePosition));
        else if (Input.GetMouseButtonUp(1)) Up(1, CameraHandler.ScreenToWorldPoint(Input.mousePosition));
#else
        var touches = Input.touches;
        //Touch[] endends = new Touch[0];

        for (int i = 0; i < touches.Length; i++)
        {
            if (touches[i].phase == TouchPhase.Began)
            {
                Down(touches[i].fingerId);
            }
            else if (touches[i].phase == TouchPhase.Ended)
            {
                Up(touches[i].fingerId, Camering.ScreenToWorldPoint(touches[i].position));
            }
        }
#endif
    }

    void Down(int id)//, Vector2 pos)
    {
        downTime.Remove(id);
        downTime.Add(id, Time.unscaledTime);
    }

    float lastDoubleClick = float.MinValue;
    float lastUp = float.MinValue;

    void Up(int id, Vector2 pos)
    {
        float lastDown;
        downTime.TryGetValue(id, out lastDown);
        downTime.Remove(id);

        if (Time.unscaledTime - lastDown > holdTime) return;

        var clickTime = Time.unscaledTime - lastUp;

        if (lastUp >= lastDown && clickTime <= holdTime)
        {
            if (Time.unscaledTime - lastDoubleClick <= timeBetweenClick)
            {
                lastUp = float.MinValue;
                lastDoubleClick = float.MinValue;
                DoubleTwiceClickPointed?.Invoke(pos);
                DoubleTwiceClick?.Invoke();
            }
            else { lastDoubleClick = Time.unscaledTime; }
        }
        else if (clickTime <= timeBetweenClick && Time.unscaledTime - lastDoubleClick > timeBetweenClick)
        {
            lastUp = float.MinValue;
            DoubleClickPointed?.Invoke(pos);
            DoubleClick?.Invoke();
        }
        else lastUp = Time.unscaledTime;
    }

    Action<Vector2> DoubleClickPointed, DoubleTwiceClickPointed;
    Action DoubleClick, DoubleTwiceClick;

    public enum State { DoubleClick, DoubleTwiceClick }
    public void SubscribePointed(Action<Vector2>[] acts, params State[] states)
    {
        foreach (var act in acts)
            SubscribePointed(act, states);
    }
    public void SubscribePointed(Action<Vector2> act, params State[] states)
    {
        foreach (var state in states) SubscribePointed(act, state);
    }
    public void SubscribePointed(Action<Vector2> act, State state)
    {
        switch (state)
        {
            case State.DoubleClick:
                DoubleClickPointed += act;
                break;
            case State.DoubleTwiceClick:
                DoubleTwiceClickPointed += act;
                break;
        }
    }
    public void Subscribe(Action act, State state)
    {
        switch (state)
        {
            case State.DoubleClick:
                DoubleClick += act;
                break;
            case State.DoubleTwiceClick:
                DoubleTwiceClick += act;
                break;
        }
    }

    public void UnsubscribePointed(Action<Vector2>[] acts, params State[] states)
    {
        foreach (var act in acts)
            UnsubscribePointed(act, states);
    }
    public void UnsubscribePointed(Action<Vector2> act, params State[] states)
    {
        foreach (var state in states) UnsubscribePointed(act, state);
    }
    public void UnsubscribePointed(Action<Vector2> act, State state)
    {
        switch (state)
        {
            case State.DoubleClick:
                DoubleClickPointed -= act;
                break;
            case State.DoubleTwiceClick:
                DoubleTwiceClickPointed -= act;
                break;
        }
    }
    public void Unsubscribe(Action act, State state)
    {
        switch (state)
        {
            case State.DoubleClick:
                DoubleClick -= act;
                break;
            case State.DoubleTwiceClick:
                DoubleTwiceClick -= act;
                break;
        }
    }
    void OnDestroy()
    {
        _get = null;
    }
}
