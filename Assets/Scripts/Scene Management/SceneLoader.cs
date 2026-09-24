using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;
    private string sceneName;
    [SerializeField] private float fxDuration = .5f;
    public Animator transition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("READ ONLY")]
    [SerializeField] private bool lvlLoaded = false;
    private AsyncOperation asyncLoad;
    
    public void SaveCurrentSceneIndex()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


    public void AsyncLoadLevel(string lvlName)
    {
        sceneName = lvlName;

        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        yield return null;
        asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;
        Debug.Log("Progress: " + asyncLoad.progress + "%");
        while (asyncLoad.progress < .9f)
        {
            Debug.Log("Progress: "+"%");
            yield return null;
        }
        Debug.Log("Scene Loaded ready to switch");
        lvlLoaded = true;
    }

    public void AsyncLoadNextLevel()
    {
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncNextScene()
    {
        yield return null;
        asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        asyncLoad.allowSceneActivation = false;
        while (asyncLoad.progress < .9f)
        {
            yield return null;
        }
        lvlLoaded = true;
    }

    public bool LoadCheck()
    {
        return lvlLoaded;
    }

    public void StartLoadLevel()
    {
        StartCoroutine(FXWaitTime());
    }

    public void LoadLevel()
    {
        while (!lvlLoaded)
        {

        }

        Debug.Log("Loading scene the proper way!");
        asyncLoad.allowSceneActivation = true;

        lvlLoaded = false;
    }

    IEnumerator FXWaitTime()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(fxDuration);

        LoadLevel();
    }
}
