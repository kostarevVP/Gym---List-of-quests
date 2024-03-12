using WKosArch.Domain.Contexts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBootstrapLoader : MonoBehaviour
{
    void Start()
    {
        // Check if an object with the class ProjectContext exists in the scene
        ProjectContext projectContext = FindObjectOfType<ProjectContext>();

        // If it doesn't exist, load the first scene from the game's build
        if (projectContext == null)
        {
            LoadFirstScene();
        }
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }
}
