using WKosArch.Domain.Features;
using WKosArch.Services.UIService.UI;

namespace WKosArch.Services.UIService
{
    public interface IUIService : IFeature
    {
        IUserInterface UI { get; }
    }
}