using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderObject : MonoBehaviour
{
    [SerializeField] private SceneLoader loader;
    [SerializeField] private string nextScene;


    public float fxWaitTime = 0f;

    [Header("READ ONLY")]
    [SerializeField] private bool nextSceneLoaded = false;

    private void Awake()
    {
        loader.AsyncLoadLevel(nextScene);
    }

    //testing purposes only
    private void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        while (!nextSceneLoaded)
        {
            nextSceneLoaded = loader.LoadCheck();
            Debug.Log("Scene Loaded: "+nextSceneLoaded);
        }
        loader.StartLoadLevel();
    }
}
