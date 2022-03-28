namespace PerformanceBenchmarks.TestSubjects
{
    /// <summary>
    /// This class contains two async methods - GetDBCount and GetAPICount
    /// The assumption is that GetAPICount method takes longer to execute than GetDBCount method.
    /// </summary>
    public class AsyncParameters
    {
        public int PerformCalculation(int v1, int v2)
        {
            return v1 + v2;
        }

        public async Task<int> GetDBCount()
        {
            //Assume that some operation is done by this method and it takes around 10ms to complete the same
            await Task.Delay(10);
            return 1;
        }

        public async Task<int> GetAPICount()
        {
            //Assume that some operation is done by this method and it takes around 20ms to complete the same
            await Task.Delay(20);
            return 2;
        }
    }

}
