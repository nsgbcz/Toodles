using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Delegates
{
    using Executers;
    using Controllers;

    public class SimpleExecute : IExecute
    {
        [Required, SerializeField]
        IIterate iterate = new List();

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
