using UnityEditor;

namespace WaynGroup.Mgm.Ability.Editor
{
    internal class ScriptTemplates
    {
        private const string FOLDER_PATH = "Assets/WKosArch/Tools/Editor/ScriptTemplates/";


        #region DOTS
        [MenuItem("Assets/Create/DOTS/IComponentData struct", false, 1)]
        public static void CreateIComponentData() =>
            CreateScriptFromTemplate($"DotsTemplates/IComponentDataStruct-Template.txt", "IComponentData.cs");


        [MenuItem("Assets/Create/DOTS/IAspect")]
        public static void CreateIAspect() =>
            CreateScriptFromTemplate($"DotsTemplates/IAspect-Template.txt", "IAspect.cs");


        [MenuItem("Assets/Create/DOTS/ISystem")]
        public static void CreateISystem() =>
            CreateScriptFromTemplate($"DotsTemplates/ISystem-Template.txt", "ISystem.cs");


        [MenuItem("Assets/Create/DOTS/Authoring")]
        public static void CreateAuthoringComponent() =>
            CreateScriptFromTemplate($"DotsTemplates/Authoring-Template.txt", "Authoring.cs");


        [MenuItem("Assets/Create/DOTS/IJobEntity")]
        public static void CreateIBufferElementData() =>
            CreateScriptFromTemplate($"DotsTemplates/IJobEntity-Template.txt", "IJobEntity.cs");


        [MenuItem("Assets/Create/DOTS/IComponentData Class")]
        public static void CreateHybridComponent() =>
            CreateScriptFromTemplate($"DotsTemplates/IComponentDataClass-Template.txt", "IComponentData.cs");


        [MenuItem("Assets/Create/DOTS/SystemBase")]
        public static void CreateSystemBase() =>
            CreateScriptFromTemplate($"DotsTemplates/SystemBase-Template.txt", "SystemBase.cs");
        #endregion

        #region WKosArch
        [MenuItem("Assets/Create/WKosArch/WindowViewModel", false, 1)]
        public static void CreateWindowViewModel() =>
           CreateScriptFromTemplate($"WKosArchTemplates/Window View Model Template.txt", "WindowViewModel.cs");


        [MenuItem("Assets/Create/WKosArch/HudViewModel")]
        public static void CreateHudViewModel() =>
           CreateScriptFromTemplate($"WKosArchTemplates/Hud View Model Template.txt", "HudModel.cs");


        [MenuItem("Assets/Create/WKosArch/WidgetViewModel")]
        public static void CreateWidgetViewModel() =>
           CreateScriptFromTemplate($"WKosArchTemplates/Widget View Model Template.txt", "WidgetModel.cs");


        [MenuItem("Assets/Create/WKosArch/Feature_Installer")]
        public static void CreateFeatureInstaller() =>
           CreateScriptFromTemplate($"WKosArchTemplates/FeatureInstaller Template.txt", "Feature_Installer.cs");
        #endregion


        private static void CreateScriptFromTemplate(string nameTemplate, string defaultName)
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(FOLDER_PATH + nameTemplate, defaultName);
        }
    }
}