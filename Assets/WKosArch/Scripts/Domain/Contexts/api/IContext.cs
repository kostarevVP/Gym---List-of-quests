using Cysharp.Threading.Tasks;
using System;

namespace WKosArch.Domain.Contexts
{
	public interface IContext
	{
		bool IsReady { get; }
        Action<Context> OnContextIsReady { get; set; }
        Action<Context> OnContextDestroy { get; set; }

        UniTask InitializeAsync();
		void Destroy();
	}
}