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
        SetCurrentSection(0);
    }

    private void Update()
    {
        if(currentMeasure != conductor.GetCurrentMeasure())
        {
            currentMeasure = conductor.GetCurrentMeasure();
        }
    }

    private void SetCurrentSection(int index)
    {
        currentSection = sections[index];

        if(index < sections.Length)
        {
            nextSection = sections[index++];
        }
    }

    public void CheckSection()
    {
        if(currentMeasure == nextSection.startMeasure)
        {
            NextSection();
        }
    }

    private void NextSection()
    {
        sectionIndex++;
        SetCurrentSection(sectionIndex);

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
