using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Iterates
{
    using Executes;
    using Controllers;

    public class SimpleExecute : IExecute
    {
        [Required, SerializeField]
        IIteratable iterate = new ListIterable();

        public bool Iterate()
        {
            return iterate.Iterate();
        }

        [Button]
        public virtual void Action()
        {
            iterate?.Iterate();
        }
    }
}
