using System.Collections;
using UnityEngine;

namespace BP
{
    public class CourutineHandler : MonoBehaviour
    {
        private static CourutineHandler _get = null;

        private static CourutineHandler Get
        {
            get
            {
                if (_get == null)
                {
                    _get = GameObject.FindObjectOfType<CourutineHandler>();

                    if (!OnApplicationEventHandler.Quit && _get == null)
                    {
                        _get = new GameObject("StaticCoroutine").AddComponent<CourutineHandler>();
                        DontDestroyOnLoad(_get);
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

        public static Coroutine StaticStartCoroutine(IEnumerator coroutine)
        {
            return Get?.StartCoroutine(coroutine);
        }
        public static void StaticStopCoroutine(Coroutine coroutine)
        {
            Get?.StopCoroutine(coroutine);
        }

        private void OnApplicationQuit()
        {

        }
    }
}

