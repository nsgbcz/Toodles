using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    using Mono;
    public class LateUpdateExecute : Execute
    {
        [SerializeField]
        int order;
        private void OnEnable()
        {
            LateUpdateHandler.Subscribe(Action, order);
        }
        private void OnDisable()
        {
            LateUpdateHandler.Unsubscribe(Action, order);
        }
    }
}
