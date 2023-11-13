using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
    static FadeCanvas instance;

    public static FadeCanvas Instance  => instance;

    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider loadingBar;
    [SerializeField] float changeValue;
    [SerializeField] float waitTime;
    [SerializeField] bool fadeStarted = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FaderLoadString(string levelName)
    {
        StartCoroutine(FadeOut(levelName));
    }

    public void FaderLoadInt(int levelindex)
    {
        StartCoroutine(FadeOutInt(levelindex));
    }


    IEnumerator FadeIn()
    {
        loadingScreen.SetActive(false);
        fadeStarted = false;
        while (canvasGroup.alpha >0)
        {
            if (fadeStarted)
                yield break;
            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator FadeOut(string levelName)
    {
        if (fadeStarted)
        {
            yield break;
        }
        fadeStarted = true;
        while (canvasGroup.alpha <1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        //SceneManager.LoadScene(levelName);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelName);
        asyncOperation.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.value = 0;
        while (asyncOperation.isDone==false)
        {
            loadingBar.value = asyncOperation.progress / 0.9f;
            if(asyncOperation.progress == 0.9f)
            {
                asyncOperation.allowSceneActivation=true;
            }
            yield return null;
        }
        
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeOutInt(int levelIndex)
    {
        if (fadeStarted)
        {
            yield break;
        }
        fadeStarted = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelIndex);
        asyncOperation.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.value = 0;
        while (asyncOperation.isDone == false)
        {
            loadingBar.value = asyncOperation.progress / 0.9f;
            if (asyncOperation.progress == 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
        StartCoroutine(FadeIn());
    }

}
