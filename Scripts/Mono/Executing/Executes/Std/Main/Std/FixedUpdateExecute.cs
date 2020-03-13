using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    using Handlers;
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
