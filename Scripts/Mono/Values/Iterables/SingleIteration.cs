using UnityEngine;
using Toodles.Variables;
using Toodles.Handlers;
using Sirenix.OdinInspector;

namespace Toodles.Iterates
{
    public struct SingleIteration : IIteratable
    {
        [Required]
        public IAction act;

        public bool Iterate()
        {
            act.Action();
            return true;
        }
    }
}
