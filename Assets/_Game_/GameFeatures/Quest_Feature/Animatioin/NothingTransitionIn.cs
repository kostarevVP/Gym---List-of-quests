using Cysharp.Threading.Tasks;
using WKosArch.Services.UIService.Common;

public class NothingTransitionIn : Transition
{
    protected override UniTask PlayInternal()
    {
        return UniTask.CompletedTask;
    }
}
