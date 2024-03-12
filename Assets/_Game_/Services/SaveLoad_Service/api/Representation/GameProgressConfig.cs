using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "StaticData/NEW_GameProgress Config", fileName = "New GameProgressConfig")]
public class GameProgressConfig : ScriptableObject
{
    [HideInInspector] public string SceneName;
    [HideInInspector] public int SceneIndex;

#if UNITY_EDITOR
    [Space]
    [SerializeField] private SceneAsset _firstSceneToLoad;

    private void OnValidate()
    {
        if (_firstSceneToLoad != null)
        {
            SceneName = _firstSceneToLoad.name;
            SceneIndex = GetSceneIndexByName(SceneName);
        }
    }
#endif

    private int GetSceneIndexByName(string sceneName)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        for (int i = 0; i < sceneCount; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneNameInBuildSettings = System.IO.Path.GetFileNameWithoutExtension(scenePath);

            if (sceneNameInBuildSettings == sceneName)
                return i;
        }

        Debug.LogError("Scene not found in build settings: " + sceneName);
        return -1;
    }
}
