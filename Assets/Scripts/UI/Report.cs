using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Report : MonoBehaviour
{
    [SerializeField] private ReportCard stats;

    [Header("UI Elements")]
    [SerializeField] private TMP_Text perfectText;
    [SerializeField] private TMP_Text goodText;
    [SerializeField] private TMP_Text badText;
    [SerializeField] private TMP_Text missText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        perfectText.text = stats.GetPerfectText();
        goodText.text = stats.GetGoodText();
        badText.text = stats.GetBadText();
        missText.text = stats.GetMissText();

        healthText.text = stats.GetHealthText();
        damageText.text = stats.GetDamageText();
        scoreText.text = stats.GetScoreText();
    }
    
    public void LoadNextScene()
    {
        switch(GameManager.gm.currentLevel)
        {
            case (0):
                SceneManager.LoadScene("Boss Approaches 1");
                break;
            case (1):
                SceneManager.LoadScene("Boss Approaches 2");
                break;
            case (2):
                SceneManager.LoadScene("Boss Approaches 3");
                break;
            case (3):
                SceneManager.LoadScene("Main Menu");
                break;
        }
    }
}
