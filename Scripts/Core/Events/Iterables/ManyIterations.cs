using UnityEngine;
using Toodles.Mono;
using Sirenix.OdinInspector;

namespace Toodles
{
    public struct ManyIterations : IIteratable
    {
        [Required]
        public IAction act;

        public bool Iterate()
        {
            act.Action();
            return false;
        }
    }
}
