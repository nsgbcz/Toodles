using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Gamepiece
{
    using Gamepiece.Input.Joystick;
    using Gamepiece.Input;
    using Ecs;
    using Leopotam.Ecs;

    public class TranslationMovementComponent : ConcreteComponent<MovementData, TranslationMovementComponent>, IJoystickReciever, ITranslationComponent, IWASDReciever
    {
        public Vector3 Translation { get => this; set => Data.translation = value; }

        public void Apply(Vector2 vector)
        {
            Data.translation.x += vector.x;
            Data.translation.z += vector.y;
        }

        public static implicit operator Vector3(TranslationMovementComponent data)
        {
            var translation = data.Data.translation;
            var speed = data.Data.speed.Value;
            translation *= speed;

            if (translation.magnitude > speed) translation = translation.normalized * speed;

            return translation;
        }

        public override void DressEntity(EcsEntity entity)
        {
            entity.Set<Val<IJoystickReciever>>().Value = this;
            entity.Set<Val<ITranslationComponent>>().Value = this;
            entity.Set<Val<IWASDReciever>>().Value = this;
        }
    }
}
