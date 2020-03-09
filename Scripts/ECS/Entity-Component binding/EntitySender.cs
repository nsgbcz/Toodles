using Unity.Entities;
using UnityEngine;
using Sirenix.OdinInspector;

public struct EntitySender :  IConvertGameObjectToEntity
{
    [Required]
    public IReceiveEntity[] EntityReceivers;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        for (int i = 0; i < EntityReceivers.Length; i++)
        {
            EntityReceivers[i].SetReceivedEntity(entity);
        }
    }
}
