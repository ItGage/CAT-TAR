using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Static instance so other scripts can access it globally
    public static GameManager gm { get; private set; }

    public int currentLevel;
    public LevelManager currentLevelManager;
    public AudioManager audioManager;
    public Player player;

    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
            return;
        }

        gm = this;

        DontDestroyOnLoad(gameObject);
    }
}