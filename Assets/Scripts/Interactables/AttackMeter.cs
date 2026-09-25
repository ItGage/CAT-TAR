using System;
using UnityEngine;
using UnityEngine.UI;

public class AttackMeter : MonoBehaviour
{
    public float duration;

    [Header("Score")]
    [SerializeField] private float targetScore;
    [SerializeField] private float maxScore;
    [Space(5)]
    [SerializeField] private float currentScore;

    [Header("Note Increments")]
    [SerializeField] private float baseIncrement;
    [SerializeField] private float badMultiplier;
    [SerializeField] private float goodMultiplier;
    [SerializeField] private float perfectMultiplier;

    [Header("UI Elements")]
    [SerializeField] private Slider slider;

    private float threshold;
    private float fillPercent;

    private void Start()
    {
        fillPercent = 0f;
        threshold = targetScore / maxScore;

        UpdateSlider(0f);
    }

    public void BadHit()
    {
        FillMeter(baseIncrement * badMultiplier);
    }

    public void GoodHit()
    {
        FillMeter(baseIncrement * goodMultiplier);
    }

    public void PerfectHit()
    {
        FillMeter(baseIncrement * perfectMultiplier);
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
}
