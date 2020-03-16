using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class DestroyExecute : Execute
    {
        private void OnDestroy()
        {
            base.Action();
        }
    }
}
