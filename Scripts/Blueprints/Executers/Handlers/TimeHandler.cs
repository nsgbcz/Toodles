using System;
using System.Collections.Generic;
using UnityEngine;

namespace BP
{
    public class TimeHandler : MonoBehaviour
    {
        static TimeHandler _get;
        public static TimeHandler Get
        {
            get
            {
                if (_get == null)
                {
                    _get = GameObject.FindObjectOfType<TimeHandler>();

                    if (!OnApplicationEventHandler.Quit && _get == null)
                    {
                        _get = new GameObject("TimeEvent").AddComponent<TimeHandler>();
                    }
                }
                return _get;
            }
        }

        public static float TimeScale
        {
            get
            {
                return Time.timeScale;
            }
            set
            {
                Time.timeScale = value;
                Time.fixedDeltaTime = value * 0.045f;

                Get?.OnChangeTimeScale?.Invoke();
            }
        }

        Action OnChangeTimeScale;

        public static void TimeScaleSubscribe(Action act)
        {
            Get.OnChangeTimeScale += act;
        }
        public static void TimeScaleUnsubscribe(Action act)
        {
            Get.OnChangeTimeScale -= act;
        }

        void Awake()
        {
            if (Get != this) Destroy(gameObject);
            else DontDestroyOnLoad(gameObject);
        }

        public void Start()
        {
            //GameScene.Get.stateModul.Subscribe(Restart, GameScene.StateModul.State.GameOver);
        }

        List<Tuple<float, Action>> scaled = new List<Tuple<float, Action>>(),
            unscaled = new List<Tuple<float, Action>>();

        public void AddEvent(float time, Action act, bool scale)
        {
            if (scale)
            {
                scaled.Add(new Tuple<float, Action>(time, act));
                _sorting(scaled);
            }
            else
            {
                unscaled.Add(new Tuple<float, Action>(time, act));
                _sorting(scaled);
            }
        }

        public void AddEvent(Action act, float interval, bool scaled)
        {
            if (scaled)
            {
                this.scaled.Add(new Tuple<float, Action>(Time.time + interval, act));
                _sorting(this.scaled);
            }
            else
            {
                unscaled.Add(new Tuple<float, Action>(Time.unscaledTime + interval, act));
                _sorting(this.scaled);
            }
        }
        public void RemoveEvent(Action act, bool scaled)
        {
            if (scaled)
            {
                var i = this.scaled.FindIndex(e => e.Item2 == act);
                if (i > 0) this.scaled.RemoveAt(i);
            }
            else
            {
                var i = unscaled.FindIndex(e => e.Item2 == act);
                if (i > 0) unscaled.RemoveAt(i);
            }
        }

        public void RemoveEvent(Action act)
        {
            var i = scaled.FindIndex(e => e.Item2 == act);
            if (i > 0) scaled.RemoveAt(i);
            else
            {
                i = unscaled.FindIndex(e => e.Item2 == act);
                if (i > 0) unscaled.RemoveAt(i);
            }
        }

        static void _sorting(List<Tuple<float, Action>> list)
        {
            list.Sort((x, y) => x.Item1.CompareTo(y.Item1));
        }

        void LateUpdate()
        {
            //if (GameScene.Stop) return;

            while (scaled.Count > 0 && scaled[0].Item1 <= Time.time)
            {
                scaled[0].Item2?.Invoke();
                scaled.RemoveAt(0);
            }
            while (unscaled.Count > 0 && unscaled[0].Item1 <= Time.unscaledTime)
            {
                unscaled[0].Item2?.Invoke();
                unscaled.RemoveAt(0);
            }
        }

        public void Restart()
        {
            scaled.Clear();
            unscaled.Clear();
        }

        void OnDestroy()
        {
            //GameScene.Get?.stateModul.Unsubscribe(Restart, GameScene.StateModul.State.GameOver);
            _get = null;
        }
    }
}
