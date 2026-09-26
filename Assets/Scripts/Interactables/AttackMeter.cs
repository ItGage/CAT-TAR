using System;
using UnityEngine;
using UnityEngine.UI;

public class AttackMeter : MonoBehaviour
{
    public float duration;

    [Header("Score")]
    [SerializeField] private float currentScore;
    [Space(5)]
    [SerializeField] private float targetScore;
    [SerializeField] private float maxScore;
    [Space(5)]
    [SerializeField] private float threshold;

    [Header("Note Increments")]
    [SerializeField] private float baseIncrement;
    [SerializeField] private float badMultiplier;
    [SerializeField] private float goodMultiplier;
    [SerializeField] private float perfectMultiplier;

    [Header("UI Elements")]
    public Slider slider;
    [Space(5)]
    [SerializeField] private GameObject thresholdMark;
    [Space(5)]
    [SerializeField] private GameObject top;
    [SerializeField] private GameObject bottom;

    private void Start()
    {
        threshold = targetScore / maxScore;

        SpawnThresholdMark();
        ResetMeter();
    }

    public void BadHit()
    {
        float increment = baseIncrement * badMultiplier;
        FillMeter(increment);

        Debug.Log("PERFECT HIT! Add " + increment + " points!");
    }

    public void GoodHit()
    {
        float increment = baseIncrement * goodMultiplier;
        FillMeter(baseIncrement * goodMultiplier);

        Debug.Log("PERFECT HIT! Add " + increment + " points!");
    }

    public void PerfectHit()
    {
        float increment = baseIncrement * perfectMultiplier;
        FillMeter(increment);

        Debug.Log("PERFECT HIT! Add " + increment + " points!");
    }

    private void FillMeter(float amount)
    {
        float newScore = currentScore + amount;

        if(newScore < maxScore)
        {
            currentScore = newScore;
        }
        else
        {
            currentScore = maxScore;
        }

        UpdateSlider(currentScore / maxScore);
    }

    private void UpdateSlider(float score)
    {
        slider.value = score;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public void ResetMeter()
    {
        ResetScore();
        UpdateSlider(0f);
    }

    private void SpawnThresholdMark()
    {
        Vector3 spawnPosition = Vector2.Lerp(bottom.transform.position, top.transform.position, threshold);

        thresholdMark.transform.position = spawnPosition;
    }
}
