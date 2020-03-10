using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Toodles.Variables;
using ToodlesECS;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Input
{
    public class Joystick : SerializedMonoBehaviour, IReceiveEntity
    {
        [SerializeField]
        IGet<JoystickData> Data;

        EntityManager EntityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        List<Entity> Entities = new List<Entity>();
        public void SetReceivedEntity(Entity entity)
        {
            Entities.Add(entity);
        }

        void UpdateDirection(float2 direction)
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                EntityManager.SetComponentData<InputDirectionData>(Entities[i], direction);
            }
        }

        void Update()
        {

        }
    }
}
