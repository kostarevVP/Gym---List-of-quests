using System;
using WKosArch.Services.UIService.Common;

namespace WKosArch.UIService.Views.Windows
{
    [Serializable]
    public struct WindowSettings
    {
        public UILayer TargetLayer;
        public bool IsPreCached;
        public bool OpenWhenCreated;
    }
}