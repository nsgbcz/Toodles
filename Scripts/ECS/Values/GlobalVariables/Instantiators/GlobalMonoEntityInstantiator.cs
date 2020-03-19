using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.ECS
{
    [CreateAssetMenu(menuName = "Toodles/Instantiators/MonoEntity")]
    public class GlobalMonoEntityInstantiator : GlobalVariable<IInstantiator<MonoEntity>>
    {

    }
    /// <summary>
    /// Support class for easy serialization of Odin, otherwise it don't see IVar<IInstantiator<MonoEntity>> directly.
    /// </summary>
    public class MonoEntityInstantiator : Instantiator<MonoEntity>
    {

    }
}
