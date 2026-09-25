using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private HitPerformedUI ui;
    private int perfectHits=0, goodHits=0, badHits=0, missedHits=0;

    public void AddPerfectHit()
    {
        perfectHits++;
        UpdateUI("Perfect!", "");
    }
    public void AddGoodHit(string timing)
    {
        goodHits++;
        UpdateUI("Good", timing);
    }
    public void AddBadHit(string timing)
    {
        badHits++;
        UpdateUI("Bad.", timing);
    }
    public void AddMissedHit()
    {
        missedHits++;
        UpdateUI("", "");
    }

    public void UpdateUI(string hit, string timing)
    {
        ui.UpdateUI(hit, timing);
    }

}
