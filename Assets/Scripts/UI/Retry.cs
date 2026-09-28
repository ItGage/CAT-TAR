using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject attackMeter;
    [SerializeField] private GameObject hearts;
    [SerializeField] private GameObject bossText;

    [Header("Audio Components")]
    [SerializeField] private AudioSource songPlayer;
    [SerializeField] private GameObject conductor;


    public void ShowPanel()
    {
        songPlayer.Pause();
        conductor.SetActive(false);
        panel.SetActive(true);
        HideUI();
    }

    public void ShowUI()
    {
        GameManager.gm.currentLevelManager.currentSection.attackMeter.gameObject.SetActive(true);
        hearts.SetActive(true);
        bossText.SetActive(true);
    }

    public void HideUI()
    {
        GameManager.gm.currentLevelManager.currentSection.attackMeter.gameObject.SetActive(false);
        hearts.SetActive(false);
        bossText.SetActive(false);
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
