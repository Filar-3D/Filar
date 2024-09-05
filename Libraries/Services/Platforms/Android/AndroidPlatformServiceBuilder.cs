using Native;

namespace Services.Platforms.Android
{
    public class AndroidPlatformServiceBuilder
    {
        #region Services

        private IVirtualKeyboard virtualKeyboard;


        #endregion

        public AndroidPlatformServiceBuilder WithNotifications(INotificationService notificationService)
        {
            return this;
        }

        public AndroidPlatformServiceBuilder WithPermissions(IUserPermissions userPermissions)
        {
            return this;
        }

        public AndroidPlatformServiceBuilder WithVirtualKeyboard(IVirtualKeyboard virtualKeyboard)
        {
            this.virtualKeyboard = virtualKeyboard;
            return this;
        }

        public IPlatformService Build()
        {
            if(virtualKeyboard == null)
            {
                throw new System.ArgumentNullException("A Virtual Keyboard Is Required.");
            }

            return new AndroidPlatformService(virtualKeyboard);
        }
    }
}
