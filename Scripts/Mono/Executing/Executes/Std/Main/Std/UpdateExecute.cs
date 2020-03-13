using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    using Handlers;
    public class UpdateExecute : Execute
    {
        [SerializeField]
        int order;
        private void OnEnable()
        {
            UpdateHandler.Subscribe(Action, order);
        }
        private void OnDisable()
        {
            UpdateHandler.Unsubscribe(Action, order);
        }
    }
}
