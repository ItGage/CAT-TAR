using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("UI Elements")]
    public ScoreKeeper scoreKeep;
    public GameObject attackMeterUI;
    public AttackMeter attackMeterScript;

    [Header("Music Sections")]
    public Conductor conductor;
    [Space(5)]
    public int currentMeasure;
    [Space(5)]
    public LevelSection currentSection;
    public LevelSection nextSection;
    [Space(5)]
    public LevelSection[] sections;

    private int sectionIndex;

    private void Start()
    {
        sectionIndex = 0;
        SetCurrentSection();
    }

    private void Update()
    {
        if(currentMeasure != conductor.GetCurrentMeasure())
        {
            currentMeasure = conductor.GetCurrentMeasure();
        }

        CheckSection();
    }

    public void CheckSection()
    {
        if(currentMeasure == nextSection.startMeasure)
        {
            NextSection();
        }
    }

    private void SetCurrentSection()
    {
        if(sectionIndex < sections.Length)
        {
            currentSection = sections[sectionIndex];
        }

        if (sectionIndex < sections.Length - 1)
        {
            nextSection = sections[sectionIndex + 1];
        }
    }

    private void NextSection()
    {
        sectionIndex++;
        SetCurrentSection();

        if(currentSection.sectionType == section.attack)
        {
            ActivateAttackMeter();
        }
        else if (currentSection.sectionType == section.defense)
        {
            DeactivateAttackMeter();
        }
    }

    public void ActivateAttackMeter()
    {
        attackMeterScript.ResetMeter();
        attackMeterUI.SetActive(true);
    }

    public void DeactivateAttackMeter()
    {
        attackMeterUI.SetActive(false);
    }
}
