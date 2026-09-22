using UnityEngine;

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
    [Tooltip("The players health"), Min(0)]
    public float health;
}
