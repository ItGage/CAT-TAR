using UnityEngine;
using UnityEngine.SceneManagement;

public class Report : MonoBehaviour
{
    public void LoadNextScene()
    {
        switch(GameManager.gm.currentLevel)
        {
            case (0):
                SceneManager.LoadScene("Level 1");
                break;
            case (1):
                SceneManager.LoadScene("Level 2");
                break;
            case (2):
                SceneManager.LoadScene("Level 3");
                break;
            case (3):
                SceneManager.LoadScene("Main Menu");
                break;
        }
    }
}
