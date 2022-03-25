namespace PerformanceBenchmarks.TestSubjects
{
    public class ThreadSafeDictionary<T, V> : Dictionary<T, V>
    {
        private static readonly object _dictionaryLock = new object();

        public void AddorUpdate(T key, V value)
        {
            if (this.ContainsKey(key))
            {
                lock (_dictionaryLock)
                {
                    if (this.ContainsKey(key))
                    {
                        this[key] = value;
                    }
                    else
                    {
                        throw new Exception("AddOrUpdate failed.");
                    }
                }
            }
            else
            {
                lock (_dictionaryLock)
                {
                    if (!this.ContainsKey(key))
                    {
                        this.Add(key, value);
                    }
                    else
                    {
                        throw new Exception("AddOrUpdate failed.");
                    }
                }
            }
        }
    }
}
