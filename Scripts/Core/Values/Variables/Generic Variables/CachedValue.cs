﻿using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    using Mono;
    public class CachedValue<T> : IVar<T>
    {
        [SerializeField, Required, HideLabel]
        IVar<T> value;
        [SerializeField, ReadOnly]
        IVar<T> cache;
        public T Value
        {
            get
            {
                Init();
                return cache.Value;
            }
            set => cache.Value = value;
        }

        void Init()
        {
            if (cache != null) return;

            cache = new Val<T>(value.Value);
            ApplicationQuitHandler.Subscribe(Reset);
        }

        /// <summary>
        /// Needs reset cause SerializableObjects don't do that.
        /// </summary>
        void Reset()
        {
            cache = null;
        }
    }
}
