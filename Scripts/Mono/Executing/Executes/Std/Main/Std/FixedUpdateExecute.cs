using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    using Mono;
    public class FixedUpdateExecute : Execute
    {
        [SerializeField]
        int order;
        private void OnEnable()
        {
            FixedUpdateHandler.Subscribe(Action, order);
        }
        private void OnDisable()
        {
            FixedUpdateHandler.Unsubscribe(Action, order);
        }
    }
}
