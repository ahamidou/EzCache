namespace EzCache
{
    public interface IEzCache<T>
    {
        void Update(T value);
        T Retrieve();
        void Flush();
    }
}
