using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toodles.Executes
{
    public interface IAwake
    {
        void OnAwake();
    }
    public interface IEnable
    {
        void OnEnable();
    }
    public interface IStart
    {
        void OnStart();
    }
    public interface IUpdate
    {
        void OnUpdate();
    }
    public interface IFixedUpdate
    {
        void OnFixedUpdate();
    }
    public interface ILateUpdate
    {
        void OnLateUpdate();
    }
    public interface IDisable
    {
        void OnDisable();
    }
    public interface IDestroy
    {
        void OnDestroy();
    }
}