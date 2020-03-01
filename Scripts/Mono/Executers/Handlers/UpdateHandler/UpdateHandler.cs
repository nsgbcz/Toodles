using System;
using UnityEngine;
using System.Collections.Generic;

namespace Toodles.Handlers
{
    public class UpdateHandler : MonoBehaviour
    {
        public enum UpdateType { Update, FixedUpdate, LateUpdate }

        List<Func<bool>>[] actions = new List<Func<bool>>[3];

        public void Subscribe(Func<bool> act, UpdateType type)
        {
            actions[(int)type].Add(act);
        }

        public void Unsubscribe(Func<bool> act, UpdateType type)
        {
            actions[(int)type].Remove(act);
        }
        public void Unsubscribe(Func<bool> act)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Remove(act);
            }
        }

        private void Update()
        {
            actions[0].Execute(); //actions[(int)UpdateType.Update]?.Invoke();
        }
        private void FixedUpdate()
        {
            actions[1].Execute(); //actions[(int)UpdateType.FixedUpdate]?.Invoke();
        }
        private void LateUpdate()
        {
            actions[2].Execute(); //actions[(int)UpdateType.LateUpdate]?.Invoke();
        }
    }
}
