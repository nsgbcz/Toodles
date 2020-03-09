using Unity.Entities;
using UnityEngine;
using Sirenix.OdinInspector;

public class EntityConverter : SerializedMonoBehaviour, IConvertGameObjectToEntity
{
    public IConvertGameObjectToEntity convertor;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        convertor.Convert(entity, dstManager, conversionSystem);
    }
}
