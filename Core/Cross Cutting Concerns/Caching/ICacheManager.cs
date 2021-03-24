namespace Core.Cross_Cutting_Concerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value, int duration);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        bool IsAdded(string key);
        T Get<T>(string key);
        object Get(string key);
        
    }
}