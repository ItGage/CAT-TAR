using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHp = 9f, currentHp;
    [Tooltip("Total number of special parries needed to heal")]
    [SerializeField] private int numParriesToHeal=3;
    [Tooltip("Current number of special parries")]
    [SerializeField] private int sParryCount=0;
    [SerializeField] private HpUI hpUI;
    [SerializeField] private Retry retry;

   [SerializeField] private AudioSource audioPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
        sParryCount = 0;
        hpUI.SetHP(currentHp);
    }

    public void TakeDmg(float dmg)
    {
        currentHp -= dmg;
        hpUI.SetHP(currentHp);

        audioPlayer.Play();

        if (currentHp<=0)
        {
            Lose();
        }
    }

    public float getHP()
    {
        return currentHp;
    }
    public void PlusParryCount()
    {
        sParryCount += 1;
        if (sParryCount>=numParriesToHeal)
        {
            sParryCount = 0;
            currentHp += 1;

            if (currentHp > maxHp) currentHp = maxHp;
            hpUI.SetHP(currentHp);
        }
    }
    private void Lose()
    {
        retry.ShowPanel();
    }
}
