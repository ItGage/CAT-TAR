using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject attackMeter;
    [SerializeField] private GameObject hearts;

    [Header("Audio Components")]
    [SerializeField] private AudioSource songPlayer;
    [SerializeField] private GameObject conductor;

    public void ShowPanel()
    {
        songPlayer.Pause();
        conductor.SetActive(false);
        panel.SetActive(true);
    }

    public void ShowUI()
    {
        attackMeter.SetActive(true);
        hearts.SetActive(true);
    }

    public void HideUI()
    {
        attackMeter.SetActive(false);
        hearts.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
