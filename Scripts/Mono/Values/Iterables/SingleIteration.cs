using UnityEngine;
using Toodles.Variables;
using Toodles.Handlers;
using Sirenix.OdinInspector;

namespace Toodles.Delegates
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
