using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class AwakeExecute : Execute
    {
        private void Awake()
        {
            base.Action();
        }
    }
}
