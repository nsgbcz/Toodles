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
            if (_get == null && !ApplicationQuitHandler.Quitting)
            {
                _get = GameObject.FindObjectOfType<CourutineEventHandler>();

                if (_get == null)
                {
                    var obj = GameObject.Find("EventHandler");
                    if (obj == null) obj = new GameObject("EventHandler");

                    _get = obj.AddComponent<CourutineEventHandler>();
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

