namespace Toodles
{
    public interface IFilter<T>
    {
        bool Filter(T subject);
    }
}
