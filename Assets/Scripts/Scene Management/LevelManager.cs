using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int numMeasuresInLevel;
    
    [Header("UI Elements")]
    public ScoreKeeper scoreKeep;

    [Header("Music Sections")]
    public Conductor conductor;
    [Space(5)]
    public int currentMeasure;
    [Space(5)]
    public LevelSection currentSection;
    public LevelSection nextSection;
    [Space(5)]
    public LevelSection[] sections;
    [Space(5)]
    public int sectionIndex;

    private void Start()
    {
        sectionIndex = 0;
        SetCurrentSection();
        CheckSection();

        GameManager.gm.currentLevelManager = this;
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

        if(currentMeasure == numMeasuresInLevel + 1)
        {
            EndLevel();
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
        currentSection.attackMeter.slider.gameObject.SetActive(true);
    }

    public void DeactivateAttackMeter()
    {
        currentSection.attackMeter.slider.gameObject.SetActive(false);
    }

    public void EndLevel()
    {
        SceneManager.LoadScene("Report Card");
    }
}
