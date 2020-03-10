using Unity.Entities;


namespace ToodlesECS
{
    public interface IReceiveEntity
    {
        void SetReceivedEntity(Entity entity);
    }
} 