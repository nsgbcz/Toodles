using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
using System.Collections.Generic;

namespace Toodles.Handlers
{
    public class ApplicationHandler : MonoBehaviour
    {
        private static ApplicationHandler _get = null;
        private static ApplicationHandler Get
        {
            get
            {
                Init();
                return _get;
            }
        }
        [RuntimeInitializeOnLoadMethod]
        static void Init()
        {
            if (_get == null)
            {
                _get = GameObject.FindObjectOfType<ApplicationHandler>();

                if (!Quitting && _get == null)
                {
                    _get = new GameObject("Handler").AddComponent<ApplicationHandler>();
                    DontDestroyOnLoad(_get);
                }
            }
        }
        void Awake()
        {
            SceneManager.sceneUnloaded += Unloaded;
            SceneManager.sceneLoaded += Loaded;
        }

        public static bool Quitting { get; private set; } = false;
        public static bool SceneClosing { get; private set; } = false;

        void Unloaded(Scene scene)
        {
            SceneClosing = true;
        }

        void Loaded(Scene scene, LoadSceneMode mode)
        {
            SceneClosing = false;
        }

        void OnApplicationQuit()
        {
            SceneClosing = true;
            Quitting = true;
        }

        void OnDestroy()
        {
            SceneManager.sceneUnloaded -= Unloaded;
            SceneManager.sceneLoaded -= Loaded;
        }
    }
}
