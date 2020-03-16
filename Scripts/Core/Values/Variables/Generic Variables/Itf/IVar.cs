namespace Toodles
{
    public interface IVar<T> : IGet<T>, ISet<T>
    {
        new T Value { get; set; }
    }
}