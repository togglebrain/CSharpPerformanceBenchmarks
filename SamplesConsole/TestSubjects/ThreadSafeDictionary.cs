namespace PerformanceBenchmarks.TestSubjects
{
    public class ThreadSafeDictionary<T, V> : Dictionary<T, V>
    {
        private static readonly object _dictionaryLock = new object();

        public void AddorUpdate(T key, V value)
        {

            lock (_dictionaryLock)
            {
                if (this.ContainsKey(key))
                {
                    this[key] = value;
                }
                else
                {
                    this.Add(key, value);
                }
            }

        }
    }
}
