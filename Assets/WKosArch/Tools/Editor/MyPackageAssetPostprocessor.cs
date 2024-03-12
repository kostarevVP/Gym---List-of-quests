using UnityEditor;
using System.IO;

public class MyPackageAssetPostprocessor : AssetPostprocessor
{
    private static readonly string UniTaskPackageName = "com.cysharp.unitask";

    private static bool IsUniTaskInstalled()
    {
        var packageInfo = UnityEditor.PackageManager.PackageInfo.FindForAssetPath("Packages/" + UniTaskPackageName);
        return packageInfo != null && packageInfo.name == UniTaskPackageName;
    }

    private static void InstallUniTask()
    {
        UnityEditor.PackageManager.Client.Add("https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask");
    }

    static void OnPostprocessAllAssets(
        string[] importedAssets,
        string[] deletedAssets,
        string[] movedAssets,
        string[] movedFromAssetPaths)
    {
        foreach (string assetPath in importedAssets)
        {
            if (Path.GetFileName(assetPath) == "package.json")
            {
                if (!IsUniTaskInstalled())
                {
                    InstallUniTask();
                }
            }
        }
    }
}
