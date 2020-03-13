using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    using Handlers;
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
