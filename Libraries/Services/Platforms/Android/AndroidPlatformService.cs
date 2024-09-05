using Native;

namespace Services.Platforms.Android
{
    public class AndroidPlatformService: IPlatformService
    {
        #region Services

        private readonly IVirtualKeyboard virtualKeyboard;

        public IVirtualKeyboard VirtualKeyboard { get => virtualKeyboard; }

        #endregion

        public AndroidPlatformService(IVirtualKeyboard virtualKeyboard) 
        {
            this.virtualKeyboard = virtualKeyboard;
        }
    }
}
