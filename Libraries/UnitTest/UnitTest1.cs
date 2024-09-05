using Debugger;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            test_log_message("Logging");
        }

        void test_log_message(string message)
        {
            IWriter logger = new UnityConsoleLogger();

            try
            {
                logger.Write(LogVerbosity.Assertion, message);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}