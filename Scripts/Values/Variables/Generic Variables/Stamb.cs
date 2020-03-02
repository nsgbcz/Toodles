namespace Toodles.Variables
{
    public struct Stamb<T> : IVar<T>
    {
        public T Value
        {
            get => default;
            set { }
        }
    }
}