using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;

namespace BP
{
    public class OnApplicationEventHandler : MonoBehaviour
    {
        private static OnApplicationEventHandler _get = null;
        private static OnApplicationEventHandler Get
        {
            get
            {
                if (_get == null)
                {
                    _get = GameObject.FindObjectOfType<OnApplicationEventHandler>();

                    if (!Quit && _get == null)
                    {
                        _get = new GameObject("StaticOnQuit").AddComponent<OnApplicationEventHandler>();
                        DontDestroyOnLoad(_get);
                    }
                }
                return _get;
            }
        }

        public static bool Quit { get; private set; }
        public static bool SceneQuit;// { get; private set; }
        void Awake()
        {
            if (_get == null) _get = this;
            else if (_get != this) { Destroy(this); return; }

            Quit = false;
            SceneQuit = false;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneUnloaded += Unloaded;
            SceneManager.sceneLoaded += Loaded;
        }

        event Action quit, lateQuit, pause, latePause, resume, load;

        public enum EventType { OnQuit, OnLateQuit, OnPause, OnLatePause, OnResume, OnLoaded }

        public static void Subscribe(Action act, params EventType[] types)
        {
            if (Get == null) return;
            if (types.Length == 0)
            {
                Get.quit += act;
                return;
            }
            foreach (var type in types)
            {
                switch (type)
                {
                    case EventType.OnQuit:
                        Get.quit += act;
                        break;
                    case EventType.OnLateQuit:
                        Get.lateQuit += act;
                        break;
                    case EventType.OnPause:
                        Get.pause += act;
                        break;
                    case EventType.OnLatePause:
                        Get.latePause += act;
                        break;
                    case EventType.OnResume:
                        Get.resume += act;
                        break;
                    case EventType.OnLoaded:
                        Get.load += act;
                        break;
                }
            }
        }
        public static void Unsubscribe(Action act, params EventType[] types)
        {
            if (_get == null) return;
            if (types.Length == 0)
            {
                Get.lateQuit -= act;
                return;
            }
            foreach (var type in types)
            {
                switch (type)
                {
                    case EventType.OnQuit:
                        _get.quit -= act;
                        break;
                    case EventType.OnLateQuit:
                        _get.lateQuit -= act;
                        break;
                    case EventType.OnPause:
                        Get.pause -= act;
                        break;
                    case EventType.OnLatePause:
                        Get.latePause -= act;
                        break;
                    case EventType.OnResume:
                        Get.resume -= act;
                        break;
                    case EventType.OnLoaded:
                        Get.load -= act;
                        break;
                }
            }
        }

        void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                this.pause?.Invoke();
                latePause?.Invoke();
            }
            else
            {
                resume?.Invoke();
            }
        }

        void Unloaded(Scene scene)
        {
            SceneQuit = true;
            load?.Invoke();
        }

        void Loaded(Scene scene, LoadSceneMode mode)
        {
            SceneQuit = false;
        }

        void OnApplicationQuit()
        {
            SceneQuit = true;
            Quit = true;

            quit?.Invoke();
            lateQuit?.Invoke();
        }

        void OnDestroy()
        {
            SceneManager.sceneUnloaded -= Unloaded;
            SceneManager.sceneLoaded -= Loaded;
        }
    }
}
