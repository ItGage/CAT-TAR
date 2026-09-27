using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private HitPerformedUI ui;
    public int perfectHits=0, goodHits=0, badHits=0, missedHits=0;
    [SerializeField] private float timeTillHitDisappear=2f;
    private float timer = 0;
    private bool blank = true;
    public ReportCard reportCard;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>=timeTillHitDisappear && !blank)
        {
            Blank();
        }
    }

    public void AddPerfectHit()
    {
        perfectHits++;
        UpdateUI("Perfect!", "");
        blank = false;
        ResetTimer();
    }

    public void AddGoodHit(string timing)
    {
        goodHits++;
        UpdateUI("Good", timing);
        blank = false;
        ResetTimer();
    }

    public void AddBadHit(string timing)
    {
        badHits++;
        UpdateUI("Bad.", timing);
        blank = false;
        ResetTimer();
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

    public void ResetTimer()
    {
        timer = 0;
    }

    public void Blank()
    {
        UpdateUI("", "");
    }

    public void ReportScore()
    {
        reportCard.SetPerfectHits(perfectHits);
        reportCard.SetGoodHits(goodHits);
        reportCard.SetBadHits(badHits);
        reportCard.SetMissedHits(missedHits);

        reportCard.SetHealth(GameManager.gm.player.GetHealth().getHP());
    }

}
