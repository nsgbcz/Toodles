using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Ecs
{
    [CreateAssetMenu(menuName = "Toodles/EcsGlobalVariables/EcsEntity")]
    public class GlobalEcsEntity : GlobalVariable<EcsEntity> { }
}
