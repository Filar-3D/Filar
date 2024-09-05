using Debugger;
using Native;

public class UnitTest : BaseLogBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Log(Debugger.LogVerbosity.Info, "This is a test log.");
        LogWarning("Test call");
        LogError("Another test");
    }
}
