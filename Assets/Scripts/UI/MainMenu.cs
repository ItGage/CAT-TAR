using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("UI elements")]
    public GameObject startButton;
    public GameObject quitButton;
    public GameObject lvlSelect;
    public GameObject lvlButtons;
    public GameObject audioSettings;
    public GameObject masterSlider;
    public GameObject musicSlider;
    public GameObject sfxSlider;

    [Header("Character FX")]
    public GameObject character;
    public Animator characterAnimator;
    public float timeToPlay;

    [Header("Arrows FX")]
    public GameObject upArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject downArrow;
    [Space(5)]
    public Transform arrowStartPos;
    public Transform arrowEndPos;
    [Space(5)]
    public float arrowTravelTime;
    public float timeBetweenArrows;

    private Direction randomDir;
    private bool audioSettingsOpen = false;

    private void Start()
    {
        StartCoroutine(SpawnArrow());
    }

    private void LoadLevel1()
    {
        StopAllCoroutines();
        GameManager.gm.currentLevel = 1;
        SceneManager.LoadScene("Boss Approaches 1");
    }

    private void LoadLevel2()
    {
        StopAllCoroutines();
        GameManager.gm.currentLevel = 2;
        SceneManager.LoadScene("Boss Approaches 2");
    }

    private void LoadLevel3()
    {
        StopAllCoroutines();
        GameManager.gm.currentLevel = 3;
        SceneManager.LoadScene("Boss Approaches 3");
    }

    private void Exit()
    {
        Debug.Log("Application Closed! Goodbye!");
        Application.Quit();
    }

    private void SpawnRandomArrow()
    {
        int randNum = Random.Range(1, 5);

        switch(randNum)
        {
            case (1):
                randomDir = Direction.Up;
                break;

            case (2):
                randomDir = Direction.Left;
                break;

            case (3):
                randomDir = Direction.Right;
                break;

            case (4):
                randomDir = Direction.Down;
                break;
        }

        StartCoroutine(DropArrow(randomDir, arrowStartPos.position, arrowEndPos.position));
    }

    IEnumerator SpawnArrow()
    {
        yield return new WaitForSeconds(timeBetweenArrows);

        SpawnRandomArrow();
        StartCoroutine(SpawnArrow());
    }

    IEnumerator DropArrow(Direction direction, Vector2 start, Vector2 end)
    {
        float timeElapsed = 0f;

        GameObject arrow = GetArrow(direction);

        while(timeElapsed < arrowTravelTime)
        {
            float t = timeElapsed / arrowTravelTime;

            if(timeElapsed > timeToPlay) 
            {
                PlayAnimation(direction);
            }

            arrow.transform.position = Vector2.LerpUnclamped(start, end, t);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        arrow.transform.position = end;
    }

    private GameObject GetArrow(Direction direction)
    {
        switch(direction)
        {
            case (Direction.Up):
                return upArrow;

            case (Direction.Left):
                return leftArrow;

            case (Direction.Right):
                return rightArrow;

            case (Direction.Down):
                return downArrow;

        }

        return null;
    }

    private void PlayAnimation(Direction direction)
    {
        switch (direction)
        {
            case (Direction.Up):
                SetCharacterY(-1.25f);
                characterAnimator.Play("PlayUp");
                break;

            case (Direction.Left):
                SetCharacterY(-1.25f);
                characterAnimator.Play("PlayLeft");
                break;

            case (Direction.Right):
                SetCharacterY(-1.25f);
                characterAnimator.Play("PlayRight");
                break;

            case (Direction.Down):
                SetCharacterY(-2f);
                characterAnimator.Play("PlayDown");
                break;

        }

    }

    private void SetCharacterY(float y)
    {
        character.transform.position = new Vector2(character.transform.position.x, y);
    }

    private void LoadLevelSelect()
    {
        lvlSelect.SetActive(false);
        lvlButtons.SetActive(true);
    }

    private void ActivateButtons(bool activate)
    {
        startButton.SetActive(activate);
        lvlSelect.SetActive(activate);
        quitButton.SetActive(activate);
    }

    private void ActivateSliders(bool activate)
    {
        masterSlider.SetActive(activate);
        musicSlider.SetActive(activate);
        sfxSlider.SetActive(activate);
    }

    public void ToggleAudioSettings()
    {
        if(audioSettingsOpen)
        {
            ActivateButtons(true);
            ActivateSliders(false);

            audioSettingsOpen = false;
        }
        else
        {
            ActivateButtons(false);
            ActivateSliders(true);

            audioSettingsOpen = true;
        }
    }


}
