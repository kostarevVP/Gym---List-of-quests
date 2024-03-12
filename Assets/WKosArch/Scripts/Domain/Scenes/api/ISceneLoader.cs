using Cysharp.Threading.Tasks;
using System;

namespace WKosArch.Domain.Scenes
{
	public struct SceneLoadingArgs
	{
		public string SceneName;
		public int SceneIndex;
		public bool Success;
	}

	public interface ISceneLoader
	{
        string CurrentSceneName { get; }
        int CurrentSceneIndex { get; }

        UniTask LoadScene(int sceneIndex, Action<SceneLoadingArgs> callback = null);
        UniTask LoadScene(string sceneName, Action<SceneLoadingArgs> callback = null);
        UniTask ReloadScene(Action<SceneLoadingArgs> callback = null);
	}
}