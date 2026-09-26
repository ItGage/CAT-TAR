using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossApproach : MonoBehaviour
{
    public int levelToLoad;
    [Space(5)]
    public AudioSource SFX;

    private void Start()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(SFX.clip.length);

        LoadScene(levelToLoad);
    }

    public void LoadScene(int levelToLoad)
    {
        switch(levelToLoad)
        {
            case 1:
                Debug.Log("Loading Level 1");
                SceneManager.LoadScene("Level 1");
                break;

            case 2:
                Debug.Log("Loading Level 2");
                SceneManager.LoadScene("Level 2");
                break;

            case 3:
                Debug.Log("Loading Level 3");
                SceneManager.LoadScene("Level 3");
                break;
        }
    }
}
