using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    [SerializeField] private GameObject pnl;
    [SerializeField] private AudioSource songPlayer;
    [SerializeField] private GameObject conductor;

    public void ShowPanel()
    {
        songPlayer.Pause();
        conductor.SetActive(false);
        //Time.timeScale=0f;
        pnl.SetActive(true);
    }
    public void HidePanel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
