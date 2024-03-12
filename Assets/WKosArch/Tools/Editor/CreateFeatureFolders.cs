using UnityEditor;
using System.IO;
using System;

public class CreateFolders : AssetPostprocessor
{
    private static readonly string[] _featureFolders = new string[] { "api", "Implementation", "View ViewModel",  "Installers", "Prefabs", "Resources" };
    private static readonly string[] _serviceFolders = new string[] { "api", "Implementation", "Installers", "View ViewModel", "Prefabs", "Resources" };
    private static readonly string[] _ecsServiceFolders = new string[] { "api", "Implementation", "Installers", "ECS", "Prefabs", "Resources" };
    private static readonly string[] _ecsFeatureFolders = new string[] { "api", "Implementation", "Installers", "ECS", "Prefabs", "Resources" };

    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        //foreach (string assetPath in importedAssets)
        //{
        //    if (assetPath.EndsWith("Feature") && assetPath.Contains("/Features/"))
        //    {
        //        CreateFoldersAtPath(assetPath, _featureFolders);
        //    }
        //    else if (assetPath.EndsWith("Service") && assetPath.Contains("/Services/"))
        //    {
        //        CreateFoldersAtPath(assetPath, _serviceFolders);
        //    }
        //    else if (assetPath.EndsWith("Service") && assetPath.Contains("/GameFeatures/"))
        //    {
        //        CreateFoldersAtPath(assetPath, _serviceFolders);
        //    }
        //    else if (assetPath.EndsWith("Feature") && assetPath.Contains("/GameFeatures/"))
        //    {
        //        CreateFoldersAtPath(assetPath, _serviceFolders);
        //    }
        //    else if (assetPath.EndsWith("ECS_Service") && assetPath.Contains("/ECS_Services/"))
        //    {
        //        CreateECSFoldersAtPath(assetPath, _ecsServiceFolders);
        //    }
        //    else if (assetPath.EndsWith("ECS_Feature") && assetPath.Contains("/ECS_Features/"))
        //    {
        //        CreateECSFoldersAtPath(assetPath, _ecsFeatureFolders);
        //    }
        //    else if (assetPath.EndsWith("ECS_Service") && assetPath.Contains("/GameFeatures/"))
        //    {
        //        CreateECSFoldersAtPath(assetPath, _ecsServiceFolders);
        //    }
        //    else if (assetPath.EndsWith("ECS_Feature") && assetPath.Contains("/GameFeatures/"))
        //    {
        //        CreateECSFoldersAtPath(assetPath, _ecsFeatureFolders);
        //    }
        //    else if (assetPath.EndsWith("ECS_Service") && assetPath.Contains("/Features/"))
        //    {
        //        CreateECSFoldersAtPath(assetPath, _ecsServiceFolders);
        //    }
        //    else if (assetPath.EndsWith("ECS_Feature") && assetPath.Contains("/Services/"))
        //    {
        //        CreateECSFoldersAtPath(assetPath, _ecsFeatureFolders);
        //    }
        //}
        foreach (string assetPath in importedAssets)
        {

            switch (assetPath)
            {
                case var path when path.EndsWith("Feature") && path.Contains("/Features/"):
                    CreateFoldersAtPath(path, _featureFolders);
                    break;

                case var path when path.EndsWith("Service") && path.Contains("/Services/"):
                    CreateFoldersAtPath(path, _serviceFolders);
                    break;

                case var path when path.EndsWith("Service") && path.Contains("/GameFeatures/"):
                    CreateFoldersAtPath(path, _serviceFolders);
                    break;

                case var path when path.EndsWith("Feature") && path.Contains("/GameFeatures/"):
                    CreateFoldersAtPath(path, _serviceFolders);
                    break;

                case var path when path.EndsWith("ServiceECS") && path.Contains("/ServicesECS/"):
                    CreateECSFoldersAtPath(path, _ecsServiceFolders);
                    break;

                case var path when path.EndsWith("FeatureECS") && path.Contains("/FeaturesECS/"):
                    CreateECSFoldersAtPath(path, _ecsFeatureFolders);
                    break;

                case var path when path.EndsWith("ServiceECS") && path.Contains("/GameServicesECS/"):
                    CreateECSFoldersAtPath(path, _ecsServiceFolders);
                    break;

                case var path when path.EndsWith("FeatureECS") && path.Contains("/GameFeaturesECS/"):
                    CreateECSFoldersAtPath(path, _ecsFeatureFolders);
                    break;

                case var path when path.EndsWith("ServiceECS") && path.Contains("/Features/"):
                    CreateECSFoldersAtPath(path, _ecsServiceFolders);
                    break;

                case var path when path.EndsWith("FeatureECS") && path.Contains("/Services/"):
                    CreateECSFoldersAtPath(path, _ecsFeatureFolders);
                    break;
            }
        }

    }

    private static void CreateFoldersAtPath(string path, string[] folders)
    {
        string parentFolderName = Path.GetFileName(Path.GetDirectoryName(path));
        foreach (string folderName in folders)
        {
            string folderPath = Path.Combine(path, folderName);
            if (folderName.EndsWith("/UI"))
            {
                folderPath = Path.Combine(folderPath, "UI");
            }

            if (!AssetDatabase.IsValidFolder(folderPath))
            {
                AssetDatabase.CreateFolder(path, folderName);
            }
        }
    }

    private static void CreateECSFoldersAtPath(string path, string[] folders)
    {
        if (AssetDatabase.IsValidFolder(path))
        {
            foreach (string folderName in folders)
            {
                string subFolderPath = Path.Combine(path, folderName);

                if (!AssetDatabase.IsValidFolder(subFolderPath))
                {
                    AssetDatabase.CreateFolder(path, folderName);

                    if (folderName.Equals("ECS"))
                    {
                        // Додайте інші підпапки за потреби
                        string entitiesPath = Path.Combine(subFolderPath, "Entities");
                        if (!AssetDatabase.IsValidFolder(entitiesPath))
                        {
                            AssetDatabase.CreateFolder(subFolderPath, "Entities");
                        }

                        string componentsPath = Path.Combine(subFolderPath, "Components");
                        if (!AssetDatabase.IsValidFolder(componentsPath))
                        {
                            AssetDatabase.CreateFolder(subFolderPath, "Components");
                        }

                        string systemsPath = Path.Combine(subFolderPath, "Systems");
                        if (!AssetDatabase.IsValidFolder(systemsPath))
                        {
                            AssetDatabase.CreateFolder(subFolderPath, "Systems");
                        }

                        string aspectsPath = Path.Combine(subFolderPath, "Authoring");
                        if (!AssetDatabase.IsValidFolder(aspectsPath))
                        {
                            AssetDatabase.CreateFolder(subFolderPath, "Authoring");
                        }
                    }
                }

            }
        }
    }


}
