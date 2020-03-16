using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    using Mono;
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
