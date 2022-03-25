using System.Text;

namespace PerformanceBenchmarks.TestSubjects
{
    public class StringTests
    {
        public string GetFullStringNormally()
        {
            string output = "";

            for (int i = 0; i < 100; i++)
            {
                output += i + " test data";
            }
            return output;
        }

        public string GetFullStringWithStringBuilder()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                output.Append(i);
                output.Append(" test data");
            }
            return output.ToString();

        }
        public string GetFullStringWithStringBuilderConcatenation()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                output.Append(i + " test data");
            }
            return output.ToString();

        }
    }
}
