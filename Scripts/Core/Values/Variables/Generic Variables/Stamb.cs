namespace Toodles
{
    public struct Stamb<T> : IVar<T>, IFilter<T>
    {
        public T Value
        {
            get => default;
            set { }
        }
        public bool Filter(T subject) => true;
    }
}