using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader2 : MonoBehaviour
{
    [Header("Fade Out Parameters")]
    [SerializeField] private Image fadeOutImage;
    [SerializeField] private float fadeDuration = 1.5f;
    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeOutAndLoadScene());
        }
    }

    private IEnumerator FadeOutAndLoadScene()
    {
        Time.timeScale = 0f; // Pausa el juego

        float elapsedTime = 0f;
        Color color = fadeOutImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.unscaledDeltaTime; // Usar Time.unscaledDeltaTime para animaciones cuando el tiempo está pausado
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeOutImage.color = color;
            yield return null;
        }

        Time.timeScale = 1f; // Restaura la escala de tiempo antes de cargar la nueva escena
        SceneManager.LoadScene(sceneToLoad);
    }
}
