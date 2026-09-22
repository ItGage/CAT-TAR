using UnityEngine;
using TMPro;

public abstract class ReportCard : ScriptableObject
{
    [Header("Level Stats")]
    [Tooltip("The maximum possible score in a level"), Min(0)]
    public float maxScore;
    [Tooltip("The players score"), Min(0)]
    public float score;
    [Tooltip("The number of notes in a song"), Min(0)]
    public float maxHits;
    [Tooltip("The number of perfect hits the player performed"), Min(0)]
    public float perfectHits;
    [Tooltip("The number of bad hits the player performed"), Min(0)]
    public float badHits;
    [Tooltip("The number of missed notes")]
    public float missedHits;
    [Tooltip("The players health"), Min(0)]
    public float health;

    [Header("UI")]
    [SerializeField] private TMP_Text scoreText, pHitsText, bHitsText, mHitsText, hpText;

    public virtual void SetScore(float lvlScore)
    {
        score = lvlScore;
        scoreText.text = "Score: "+score+"/"+maxScore;
    }
    public virtual void SetPerfectHits(float pHits)
    {
        perfectHits = pHits;
        pHitsText.text = "Perfect hits: "+perfectHits+"/"+maxHits;
    }
    public virtual void SetBadHits(float bHits)
    {
        badHits = bHits;
        bHitsText.text = "Bad hits: " + badHits;
    }
    public virtual void SetMissedHits(float mHits)
    {
        missedHits = mHits;
        mHitsText.text = "Missed hits:" + missedHits;
    }
    public virtual void SetHealth(float hp)
    {
        health = hp;
        hpText.text = "Health: ";
        //logic for showing # of hearts
    }
}
