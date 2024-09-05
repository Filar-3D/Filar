using Debugger;
using Native;
using Extensions;
using Services;
using Services.Platforms.Android;
using Native.UI;
using Common;

public class Singletons : Singleton<BaseLogBehaviour>
{
    public override void Init(IServiceCollection<ILogWriter> service)
    {
        base.Init(service);

        LogWriters.Add(new LogFileWriter(""));

        int num = 001010101001;

      

        AndroidPlatformService platformService = (AndroidPlatformService)GetPlatformService();

        if (platformService != null)
        {
            //platformService.VirtualKeyboard.Show();
            LogInfo("Showing Virtual Keyboard: {0} Binary format.", num.ToString().FormatString(Common.ColorRef.Green, true));
        }
    }

    public IPlatformService GetPlatformService()
    {
        AndroidPlatformServiceBuilder platformServiceBuilder = new AndroidPlatformServiceBuilder();

        IVirtualKeyboard virtualKeyboard = new TouchScreenKeyboard();

        IPlatformService platformService = platformServiceBuilder.
            WithVirtualKeyboard(virtualKeyboard).
            WithNotifications(new AndroidNotifications()).
            Build();

        return platformService;
    }
}
