using Assets._Game_.Services.UI_Service.Views.UiView;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using WKosArch.Extentions;
using WKosArch.UIService.Views.HUD;
using WKosArch.UIService.Views.Widgets;
using WKosArch.UIService.Views.Windows;

namespace WKosArch.Services.UIService
{
    [CreateAssetMenu(fileName = "UI_SceneConfig", menuName = "UI/Configs/_UI_SceneConfig")]
    public class UISceneConfig : ScriptableObject
    {
        [SerializeField] private WindowViewModel[] _windowPrefabs;
        [SerializeField] private HudViewModel[] _hudPrefabs;
        [SerializeField] private WidgetViewModel[] _widgetPrefabs;

        public WindowViewModel[] WindowPrefabs => _windowPrefabs;
        public HudViewModel[] HudPrefabs => _hudPrefabs;
        public WidgetViewModel[] WidgetPrefabs => _widgetPrefabs;


        [HideInInspector] public string[] SceneName;
        [HideInInspector] public int[] SceneIndex;

#if UNITY_EDITOR
        [Space]
        [SerializeField] private SceneAsset[] _scenes;

        private void OnValidate()
        {
            if (_scenes != null)
            {
                SceneName = new string[_scenes.Length];
                SceneIndex = new int[_scenes.Length];

                for (int i = 0; i < _scenes.Length; i++)
                {
                    if (_scenes[i] != null)
                    {
                        var sceneName = _scenes[i].name;

                        SceneName[i] = sceneName;
                        SceneIndex[i] = GetSceneIndexByName(sceneName);
                    }
                    else
                    {
                        Log.PrintWarning($"Not add Scene to UISceneConfig {this}");
                    }
                }
            }
        }
#endif

        public bool TryGetPrefab<T>(out T requestedPrefab) where T : UiViewModel
        {
            requestedPrefab = null;

            foreach (var prefab in _windowPrefabs)
            {
                if (prefab is T certainPrefab)
                {
                    requestedPrefab = certainPrefab;

                    break;
                }
            }
            foreach (var prefab in _hudPrefabs)
            {
                if (prefab is T certainPrefab)
                {
                    requestedPrefab = certainPrefab;

                    break;
                }
            }

            return requestedPrefab != null;
        }

        public bool TryGetPrefab<T>(Type typeViewModel, out T requestedPrefab) where T : UiViewModel
        {
            requestedPrefab = null;

            foreach (var prefab in _windowPrefabs)
            {
                if (prefab.GetType() == typeViewModel)
                {
                    requestedPrefab = prefab as T;

                    break;
                }
            }

            foreach (var prefab in _hudPrefabs)
            {
                if (prefab.GetType() == typeViewModel)
                {
                    requestedPrefab = prefab as T;

                    break;
                }
            }

            return requestedPrefab != null;
        }


        public bool TryGetWidgetPrefab<T>(Type typeViewModel, out T requestedPrefab) where T : WidgetViewModel
        {
            requestedPrefab = null;

            foreach (var prefab in _widgetPrefabs)
            {
                if (prefab is T certainPrefab)
                {
                    requestedPrefab = certainPrefab;

                    break;
                }
            }

            return requestedPrefab != null;
        }

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
}
