using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Report Card", menuName = "ScriptableObjects/ReportCard", order = 1)]
public class ReportCard : ScriptableObject
{
    [Header("Level Stats")]
    [Tooltip("The maximum possible score in a level"), Min(0)]
    public float maxScore;
    [Tooltip("The number of notes in a song"), Min(0)]
    public float maxHits;

    [Header("Player Stats")]

    [Tooltip("The players score"), Min(0)]
    public float score;

    [Tooltip("The number of perfect hits the player performed"), Min(0)]
    public float perfectHits;

    [Tooltip("The number of good hits the player performed"), Min(0)]
    public float goodHits;

    [Tooltip("The number of bad hits the player performed"), Min(0)]
    public float badHits;

    [Tooltip("The number of missed notes")]
    public float missedHits;

    [Tooltip("The players health"), Min(0)]
    public float health;

    [Tooltip("Total damage the player took throughout the level"), Min(0)]
    public float damage;

    public void SetMaxHits(float hits)
    {
        maxHits = hits;
    }

    public void SetMaxScore(float score)
    {
        maxScore = score;
    }

    public void SetScore(float lvlScore)
    {
        score = lvlScore;
    }

    public string GetScoreText()
    {
        return "Score: " + score + "/" + maxScore; ;
    }

    public void SetPerfectHits(float pHits)
    {
        perfectHits = pHits;
    }

    public string GetPerfectText()
    {
        return "Perfect hits: " + perfectHits + "/" + maxHits; ;
    }

    public void SetGoodHits(float gHits)
    {
        goodHits = gHits;
    }

    public string GetGoodText()
    {
        return "Good hits: " + goodHits + "/" + maxHits; ;
    }

    public void SetBadHits(float bHits)
    {
        badHits = bHits;
    }

    public string GetBadText()
    {
        return "Bad hits: " + badHits + "/" + maxHits; ;
    }

    public void SetMissedHits(float mHits)
    {
        missedHits = mHits;
    }

    public string GetMissText()
    {
        return "Missed hits: " + missedHits + "/" + maxHits; ;
    }

    public void SetHealth(float hp)
    {
        health = hp;
        //logic for showing # of hearts
    }

    public string GetHealthText()
    {
        return "Final Health: "  + health;
    }

    public void SetDamage(float dmg)
    {
        damage = dmg;
    }

    public string GetDamageText()
    {
        return "Damage Taken: " + damage;
    }
}
