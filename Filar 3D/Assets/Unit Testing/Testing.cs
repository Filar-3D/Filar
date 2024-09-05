using Native;
using Common;
using Debugger;

public class Testing : Singleton<TestSingleton>
{
    public override void Init(IServiceCollection<ILogWriter> service)
    {
        base.Init(service);

        Log(Debugger.LogVerbosity.Info, "Destroy On Load: {0}", DoNotDestroyOnLoad);
    }
}
