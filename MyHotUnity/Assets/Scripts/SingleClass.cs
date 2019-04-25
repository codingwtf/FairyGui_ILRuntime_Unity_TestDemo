using UnityEngine.XR.WSA.Persistence;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace Assets.Scripts
{
    static class SingleClass
    {
        private static AppDomain appDomain;

        public static AppDomain AppDomain
        {
            get
            {
                if (appDomain == null)
                {
                    appDomain = new ILRuntime.Runtime.Enviorment.AppDomain();
                    appDomain.DebugService.StartDebugService(56000);
                }

                return appDomain;
            }
        }
    }
}
