using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI textLevel;

    public Image fadeImage; 
    public float fadeDuration = 1f;
    private void Awake()
    {
        fadeImage.color = new Color(0, 0, 0, 1);
        level = SceneManager.GetActiveScene().buildIndex;
        textLevel.text = "Level " + level.ToString();
        StartCoroutine(FadeIn());
    }

    

    IEnumerator FadeOut(int sceneName)
    {
        fadeImage.gameObject.SetActive(true);
        float fadeSpeed = 1f / fadeDuration;
        float progress = 0f;

        // Tăng dần alpha của hình ảnh để làm tối màn hình
        while (progress < 1f)
        {
            progress += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, Mathf.Clamp01(progress));
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator FadeIn()
    {
        float fadeSpeed = 1f / fadeDuration;
        float progress = 1f;

        // Giảm dần alpha của hình ảnh để sáng dần màn hình
        while (progress > 0f)
        {
            progress -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, Mathf.Clamp01(progress));
            yield return null;
        }

        // Khi hiệu ứng fade-in hoàn tất, tắt UI Image
        fadeImage.gameObject.SetActive(false);
    }
    public void TamDung()
    {
        Time.timeScale = 0f;
    }
    public void TiepTuc()
    {
        Time.timeScale = 1f;
    }
    public void ChoiLai()
    {
        StartCoroutine(FadeOut(level));
        Time.timeScale = 1f;
        //SceneManager.LoadScene(level);
    }
    public void VeHome()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(0);
        StartCoroutine(FadeOut(0));

    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(level+1);
        StartCoroutine(FadeOut(level + 1));
    }
}
