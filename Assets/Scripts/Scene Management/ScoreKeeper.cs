using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int perfectHits=0, goodHits=0, badHits=0, missedHits=0;

    public void AddPerfectHit()
    {
        perfectHits++;
    }
    public void AddGoodHit()
    {
        goodHits++;
    }
    public void AddBadHit()
    {
        badHits++;
    }
    public void AddMissedHit()
    {
        missedHits++;
    }


}
