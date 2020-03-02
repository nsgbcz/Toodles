using UnityEngine;
using Sirenix.OdinInspector;
using Toodles.Delegates;

namespace Toodles.Variables
{
    #region Bool
    public struct Nor : IGet<bool>, IIterate
    {
        [SerializeField]
        IGet<bool> value;
        public bool Value => !value.Value;

        public bool Iterate()
        {
            return Value;
        }
    }
    public struct IsNull : IGet<bool>, IIterate
    {
        [SerializeField]
        object value;
        public bool Value => value == null;

        public bool Iterate()
        {
            return Value;
        }
    }

    #endregion
    #region Vector2
    /*public struct MousePosition : IGet<Vector2>
    {
        public Vector2 Value => CameraHandler.Main.ScreenToWorldPoint(Input.mousePosition);
    }*/
    #endregion
    #region Float
    public struct MultiplyFloat : IGet<float>
    {
        [SerializeField]
        IGet<float> First, Second;
        public float Value => First.Value * Second.Value;
    }
    public struct RandomFloat : IGet<float>
    {
        [SerializeField]
        IGet<float> Min, Max;
        public float Value => UnityEngine.Random.Range(Min.Value, Max.Value);
    }
    public struct DeltaTime : IGet<float>
    {
        public float Value { get => Time.deltaTime; }
    }
    public struct UnscaledDeltaTime : IGet<float>
    {
        public float Value { get => Time.unscaledDeltaTime; }
    }
    public struct FixedDeltaTime : IGet<float>
    {
        public float Value { get => Time.fixedDeltaTime; }
    }
    public struct FixedUnscaledDeltaTime : IGet<float>
    {
        public float Value { get => Time.fixedUnscaledDeltaTime; }
    }
    #endregion
}