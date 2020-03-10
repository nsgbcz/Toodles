using Unity.Entities;
using UnityEngine;
using Sirenix.OdinInspector;

namespace ToodlesECS
{
    public class EntityConverter : SerializedMonoBehaviour, IConvertGameObjectToEntity
    {
        public IConvertGameObjectToEntity[] convertors = new IConvertGameObjectToEntity[0];

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            for (int i = 0; i < convertors.Length; i++)
            {
                convertors[i].Convert(entity, dstManager, conversionSystem);
            }
        }
    }
}
