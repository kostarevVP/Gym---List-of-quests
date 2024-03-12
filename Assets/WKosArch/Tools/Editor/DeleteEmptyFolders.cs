using System.IO;
using UnityEditor;
using UnityEngine;

public class DeleteEmptyFolders : EditorWindow
{
    private string _assetsFolderPath = "Assets";

    [MenuItem("Tools/Delete Empty Folders")]
    public static void ShowWindow()
    {
        GetWindow<DeleteEmptyFolders>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Delete Empty Folders"))
        {
            DeleteEmptyFoldersInDirectory(_assetsFolderPath);
        }
    }

    private void DeleteEmptyFoldersInDirectory(string directoryPath)
    {
        string[] directories = Directory.GetDirectories(directoryPath);

        foreach (string directory in directories)
        {
            // Перевірка, чи є папка пустою
            if (Directory.GetDirectories(directory).Length == 0 && Directory.GetFiles(directory).Length == 0)
            {
                // Видалення папки
                Directory.Delete(directory);
                Debug.Log($"Видалено папку: {directory}");
            }
            else
            {
                // Рекурсивний виклик для підпапок
                DeleteEmptyFoldersInDirectory(directory);
            }
        }
    }
}
