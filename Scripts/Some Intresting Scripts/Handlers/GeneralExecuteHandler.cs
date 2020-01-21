using System;
using UnityEngine;

public class GeneralExecuteHandler : MonoBehaviour
{
    private static GeneralExecuteHandler _get;
    public static GeneralExecuteHandler Get
    {
        get
        {
            if (_get == null)
            {
                _get = FindObjectOfType<GeneralExecuteHandler>();

                if (!OnApplicationEventHandler.SceneQuit && _get == null)
                {
                    _get = new GameObject("MainExecute").AddComponent<GeneralExecuteHandler>();
                }
            }
            return _get;
        }
    }

    event Action OnUpate, OnFixedUpdate, OnLateUpdate;

    public enum UpdateType { Update, FixedUpdate, LateUpdate }

    public static void Subscribe(Action act, UpdateType type)
    {
        switch (type)
        {
            case UpdateType.Update:
                Get.OnUpate += act;
                break;
            case UpdateType.FixedUpdate:
                Get.OnFixedUpdate += act;
                break;
            case UpdateType.LateUpdate:
                Get.OnLateUpdate += act;
                break;
        }
    }

    public static void Unsubscribe(Action act, UpdateType type)
    {
        if (Get == null) return;

        switch (type)
        {
            case UpdateType.Update:
                Get.OnUpate -= act;
                break;
            case UpdateType.FixedUpdate:
                Get.OnFixedUpdate -= act;
                break;
            case UpdateType.LateUpdate:
                Get.OnLateUpdate -= act;
                break;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(_get);
        OnApplicationEventHandler.Subscribe(_Reset, OnApplicationEventHandler.EventType.OnLoaded);
    }

    void _Reset()
    {
        OnUpate = null;
        OnFixedUpdate = null;
        OnLateUpdate = null;
    }

    private void Update()
    {
        OnUpate?.Invoke();
    }
    private void FixedUpdate()
    {
        //if (GameScene.Stop) return;
        OnFixedUpdate?.Invoke();
    }

    private void LateUpdate()
    {
        OnLateUpdate?.Invoke();
    }
    void OnDestroy()
    {
        if(_get == this) _get = null;
    }
}
