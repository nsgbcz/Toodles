using System.Collections;
using UnityEngine;

namespace BP
{
    public class GeneralExecute : Execute
    {
        public enum EventTime : byte
        {
            Awake, Start, LateStart, Update, FixedUpdate,
            LateUpdate, Enable, Disable, Destroy, Quit, LateQuit, LateEnable, Pause, LatePause, SceneUnloaded
        }

        [SerializeField]
        private MyEnumMask eventTime = new MyEnumMask(typeof(EventTime));

        void Awake()
        {
            if (eventTime.IsExecuteAble(EventTime.Awake)) Action();
            if (eventTime.IsExecuteAble(EventTime.Quit)) OnApplicationEventHandler.Subscribe(Action, OnApplicationEventHandler.EventType.OnQuit);
            if (eventTime.IsExecuteAble(EventTime.LateQuit)) OnApplicationEventHandler.Subscribe(Action, OnApplicationEventHandler.EventType.OnLateQuit);
            if (eventTime.IsExecuteAble(EventTime.Pause)) OnApplicationEventHandler.Subscribe(Action, OnApplicationEventHandler.EventType.OnPause);
            if (eventTime.IsExecuteAble(EventTime.LatePause)) OnApplicationEventHandler.Subscribe(Action, OnApplicationEventHandler.EventType.OnLatePause);
        }

        IEnumerator Start()
        {
            if (eventTime.IsExecuteAble(EventTime.Start)) Action();

            yield return null;

            if (eventTime.IsExecuteAble(EventTime.LateStart)) Action();
        }

        void OnEnable()
        {
            if (eventTime.IsExecuteAble(EventTime.Enable)) Action();

            if (eventTime.IsExecuteAble(EventTime.Update)) GeneralExecuteHandler.Subscribe(Action, GeneralExecuteHandler.UpdateType.Update);
            if (eventTime.IsExecuteAble(EventTime.FixedUpdate)) GeneralExecuteHandler.Subscribe(Action, GeneralExecuteHandler.UpdateType.FixedUpdate);
            if (eventTime.IsExecuteAble(EventTime.LateUpdate)) GeneralExecuteHandler.Subscribe(Action, GeneralExecuteHandler.UpdateType.LateUpdate);

            if (eventTime.IsExecuteAble(EventTime.LateEnable)) StartCoroutine(OnLateEnable());
        }
        IEnumerator OnLateEnable()
        {
            yield return null;
            Action();
        }
        void OnDisable()
        {
            if (eventTime.IsExecuteAble(EventTime.Disable)) Action();

            if (eventTime.IsExecuteAble(EventTime.Update)) GeneralExecuteHandler.Unsubscribe(Action, GeneralExecuteHandler.UpdateType.Update);
            if (eventTime.IsExecuteAble(EventTime.FixedUpdate)) GeneralExecuteHandler.Unsubscribe(Action, GeneralExecuteHandler.UpdateType.FixedUpdate);
            if (eventTime.IsExecuteAble(EventTime.LateUpdate)) GeneralExecuteHandler.Unsubscribe(Action, GeneralExecuteHandler.UpdateType.LateUpdate);
        }


        public void OnDestroy()
        {
            if (OnApplicationEventHandler.SceneQuit)
            {
                if (eventTime.IsExecuteAble(EventTime.SceneUnloaded)) Action();
            }
            else if (eventTime.IsExecuteAble(EventTime.Destroy)) Action();

            if (eventTime.IsExecuteAble(EventTime.Quit)) OnApplicationEventHandler.Unsubscribe(Action, OnApplicationEventHandler.EventType.OnQuit);
            if (eventTime.IsExecuteAble(EventTime.LateQuit)) OnApplicationEventHandler.Unsubscribe(Action, OnApplicationEventHandler.EventType.OnLateQuit);
            if (eventTime.IsExecuteAble(EventTime.Pause)) OnApplicationEventHandler.Unsubscribe(Action, OnApplicationEventHandler.EventType.OnPause);
            if (eventTime.IsExecuteAble(EventTime.LatePause)) OnApplicationEventHandler.Unsubscribe(Action, OnApplicationEventHandler.EventType.OnLatePause);
        }
    }
}
