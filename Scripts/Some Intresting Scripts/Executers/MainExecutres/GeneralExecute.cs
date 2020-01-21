using System.Collections;
using Sirenix.OdinInspector;

public class GeneralExecute : Execute
{
    public enum EventTime : byte
    {
        Awake, Start, LateStart, Update, FixedUpdate,
        LateUpdate, Enable, Disable, Destroy, Quit, LateQuit, LateEnable, Pause, LatePause, SceneUnloaded
    }

    public MyEnumMask myMask = new MyEnumMask(typeof(EventTime));

    void Awake()
    {
        if (myMask.IsExecuteAble(EventTime.Awake)) Action();
        if (myMask.IsExecuteAble(EventTime.Quit)) OnApplicationEventHandler.Subscribe(Action, OnApplicationEventHandler.EventType.OnQuit);
        if (myMask.IsExecuteAble(EventTime.LateQuit)) OnApplicationEventHandler.Subscribe(Action, OnApplicationEventHandler.EventType.OnLateQuit);
        if (myMask.IsExecuteAble(EventTime.Pause)) OnApplicationEventHandler.Subscribe(Action, OnApplicationEventHandler.EventType.OnPause);
        if (myMask.IsExecuteAble(EventTime.LatePause)) OnApplicationEventHandler.Subscribe(Action, OnApplicationEventHandler.EventType.OnLatePause);
    }

    IEnumerator Start()
    {
        if (myMask.IsExecuteAble(EventTime.Start)) Action();

        yield return null;

        if (myMask.IsExecuteAble(EventTime.LateStart)) Action();
    }

    void OnEnable()
    {
        if (myMask.IsExecuteAble(EventTime.Enable)) Action();

        if (myMask.IsExecuteAble(EventTime.Update)) GeneralExecuteHandler.Subscribe(Action, GeneralExecuteHandler.UpdateType.Update);
        if (myMask.IsExecuteAble(EventTime.FixedUpdate)) GeneralExecuteHandler.Subscribe(Action, GeneralExecuteHandler.UpdateType.FixedUpdate);
        if (myMask.IsExecuteAble(EventTime.LateUpdate)) GeneralExecuteHandler.Subscribe(Action, GeneralExecuteHandler.UpdateType.LateUpdate);

        if (myMask.IsExecuteAble(EventTime.LateEnable)) StartCoroutine(OnLateEnable());
    }
    IEnumerator OnLateEnable()
    {
        yield return null;
        Action();
    }
    void OnDisable()
    {
        if (myMask.IsExecuteAble(EventTime.Disable)) Action();

        if (myMask.IsExecuteAble(EventTime.Update)) GeneralExecuteHandler.Unsubscribe(Action, GeneralExecuteHandler.UpdateType.Update);
        if (myMask.IsExecuteAble(EventTime.FixedUpdate)) GeneralExecuteHandler.Unsubscribe(Action, GeneralExecuteHandler.UpdateType.FixedUpdate);
        if (myMask.IsExecuteAble(EventTime.LateUpdate)) GeneralExecuteHandler.Unsubscribe(Action, GeneralExecuteHandler.UpdateType.LateUpdate);
    }


    public void OnDestroy()
    {
        if (OnApplicationEventHandler.SceneQuit)
        {
            if (myMask.IsExecuteAble(EventTime.SceneUnloaded)) Action();
        }
        else if (myMask.IsExecuteAble(EventTime.Destroy)) Action();

        if (myMask.IsExecuteAble(EventTime.Quit)) OnApplicationEventHandler.Unsubscribe(Action, OnApplicationEventHandler.EventType.OnQuit);
        if (myMask.IsExecuteAble(EventTime.LateQuit)) OnApplicationEventHandler.Unsubscribe(Action, OnApplicationEventHandler.EventType.OnLateQuit);
        if (myMask.IsExecuteAble(EventTime.Pause)) OnApplicationEventHandler.Unsubscribe(Action, OnApplicationEventHandler.EventType.OnPause);
        if (myMask.IsExecuteAble(EventTime.LatePause)) OnApplicationEventHandler.Unsubscribe(Action, OnApplicationEventHandler.EventType.OnLatePause);
    }
}
