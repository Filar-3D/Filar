using Native;

public class UnitTest : LogMonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Log(Debugger.LogVerbosity.Info, "This is a test log.", this);
        LogWarning("Test call", this);
        LogError("Another test", this);
    }
}
