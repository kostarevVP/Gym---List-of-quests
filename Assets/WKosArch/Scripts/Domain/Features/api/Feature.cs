using Cysharp.Threading.Tasks;

namespace WKosArch.Domain.Features
{
	public abstract class Feature : IFeature
	{
		public bool IsReady { get; private set; }
		public async UniTask InitializeAsync()
		{
			if (!IsReady)
			{
				await InitializeInternal();

				IsReady = true;
			}
		}

		public virtual UniTask DestroyAsync()
		{
			return UniTask.CompletedTask;
		}

		public virtual void OnApplicationFocus(bool hasFocus) { }
		public virtual void OnApplicationPause(bool pauseStatus) { }


		protected virtual UniTask InitializeInternal() { return UniTask.CompletedTask; }
	}
}