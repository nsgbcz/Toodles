using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class DisableExecute : Execute
    {
        private void OnDisable()
        {
            base.Action();
        }
    }
}
