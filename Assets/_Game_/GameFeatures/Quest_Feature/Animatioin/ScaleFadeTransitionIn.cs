using Cysharp.Threading.Tasks;
using WKosArch.Services.UIService.Common;

public class ScaleFadeTransitionIn : Transition
{
    protected override UniTask PlayInternal()
    {
        return UniTask.CompletedTask;
    }
}
