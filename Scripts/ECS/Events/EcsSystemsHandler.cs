using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Leopotam.Ecs;

namespace Toodles.Ecs
{
    public class EcsSystemsHandler : IInit, IRun
    {
        public IGet<EcsWorld> World;
        public IEcsSystem[] Systems;

        EcsSystems _systems;
        public void Init()
        {
            _systems = new EcsSystems(World.Value);

            for (int i = 0; i < Systems.Length; i++)
            {
                _systems.Add(Systems[i]);
            }

            _systems.Init();
        }

        public void Run()
        {
            _systems.Run();
        }
    }
}
