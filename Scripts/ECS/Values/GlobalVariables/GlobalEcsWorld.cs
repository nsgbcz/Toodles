using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Ecs
{
    [CreateAssetMenu(menuName = "Toodles/EcsVariables/EcsWorld")]
    public class GlobalEcsWorld : GlobalVariable<EcsWorld> { }
}
