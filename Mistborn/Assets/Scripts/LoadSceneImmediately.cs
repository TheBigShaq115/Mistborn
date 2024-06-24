using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneImmediately : MonoBehaviour
{
    public string sceneName = "MainScene"; // Nombre de la siguiente escena

    void Start()
    {
        // Cargar la escena especificada inmediatamente
        SceneManager.LoadScene(sceneName);
    }
}