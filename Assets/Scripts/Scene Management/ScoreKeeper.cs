using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private HitPerformedUI ui;
    private int perfectHits=0, goodHits=0, badHits=0, missedHits=0;

    public void AddPerfectHit()
    {
        perfectHits++;
        UpdateUI("Perfect!");
    }
    public void AddGoodHit()
    {
        goodHits++;
        UpdateUI("Good");
    }
    public void AddBadHit()
    {
        badHits++;
        UpdateUI("Bad.");
    }
    public void AddMissedHit()
    {
        missedHits++;
        UpdateUI("");
    }

    public void UpdateUI(string hit)
    {
        ui.UpdateUI(hit);
    }

}
