using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Ecs
{
    [CreateAssetMenu(menuName = "Toodles/Instantiators/MonoEntity")]
    public class GlobalMonoEntityInstantiator : GlobalVariable<IInstantiator<MonoEntityDresser>>
    {

    }
    /// <summary>
    /// Support class for easy serialization of Odin, otherwise it don't see IVar<IInstantiator<MonoEntity>> directly.
    /// </summary>
    public class MonoEntityInstantiator : Instantiator<MonoEntityDresser>
    {

    }
}
