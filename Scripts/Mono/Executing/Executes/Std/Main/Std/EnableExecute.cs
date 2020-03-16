using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class EnableExecute : Execute
    {
        private void OnEnable()
        {
            base.Action();
        }
    }
}
