using System.Collections;
using UnityEngine;

namespace Toodles.Handlers
{
    public class CourutineEventHandler : MonoBehaviour
    {
        private static CourutineEventHandler _get = null;
        private static CourutineEventHandler Get
        {
            get
            {
                Init();
                return _get;
            }
        }
        static void Init()
        {
            if (_get == null)
            {
                _get = GameObject.FindObjectOfType<CourutineEventHandler>();

                if (!ApplicationHandler.Quitting && _get == null)
                {
                    _get = new GameObject("EventHandler").AddComponent<CourutineEventHandler>();
                    DontDestroyOnLoad(_get);
                }
            }
        }

        public static Coroutine Start(IEnumerator coroutine)
        {
            return Get?.StartCoroutine(coroutine);
        }
        public static void Stop(Coroutine coroutine)
        {
            Get?.StopCoroutine(coroutine);
        }
    }
}

