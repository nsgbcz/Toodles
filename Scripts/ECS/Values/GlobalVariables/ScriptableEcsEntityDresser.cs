using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Sirenix.OdinInspector;

namespace Toodles.Ecs
{
    [CreateAssetMenu(menuName = "Toodles/EcsVariables/EcsEntityDresser")]
    public class ScriptableEcsEntityDresser : SerializedScriptableObject, IEcsComponent
    {
        [SerializeField, Required]
        IEcsComponent[] Components = new IEcsComponent[0];
        public void DressEntity(EcsEntity entity)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i].DressEntity(entity);
            }
        }
    }
}
