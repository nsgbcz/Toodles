using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    public class SimpleExecute : IAction, IIteratable, IDrawGizmosSelected
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

        public void OnDrawGizmosSelected()
        {
            if(iterate is IDrawGizmosSelected)
            {
                (iterate as IDrawGizmosSelected).OnDrawGizmosSelected();
            }
        }
    }
}
