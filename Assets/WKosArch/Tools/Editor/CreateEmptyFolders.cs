using UnityEditor;
using UnityEngine;
using System.IO;

public static class CreateEmptyFolders
{
    [MenuItem("Assets/Create Empty Folders")]
    public static void CreateFolders()
    {
        Object[] selectedObjects = Selection.GetFiltered(typeof(Object), SelectionMode.Assets);

        foreach (Object selectedObject in selectedObjects)
        {
            string assetPath = AssetDatabase.GetAssetPath(selectedObject);

            if (!AssetDatabase.IsValidFolder(assetPath))
            {
                Debug.LogWarning(string.Format("'{0}' is not a valid folder path.", assetPath));
                continue;
            }

            string[] foldersToCreate = Directory.GetDirectories(assetPath, "*", SearchOption.AllDirectories);

            foreach (string folder in foldersToCreate)
            {
                string relativePath = folder.Replace(assetPath + Path.DirectorySeparatorChar, string.Empty);
                AssetDatabase.CreateFolder(assetPath, relativePath);
            }
        }

        AssetDatabase.Refresh();
    }
}
