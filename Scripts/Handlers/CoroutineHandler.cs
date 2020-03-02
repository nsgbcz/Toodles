using System.Collections;
using UnityEngine;

namespace Toodles.Handlers
{
    public class CourutineHandler : MonoBehaviour
    {
        private static CourutineHandler _get = null;
        private static CourutineHandler Get
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
                _get = GameObject.FindObjectOfType<CourutineHandler>();

                if (!ApplicationHandler.Quit && _get == null)
                {
                    _get = new GameObject("StaticCoroutine").AddComponent<CourutineHandler>();
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

