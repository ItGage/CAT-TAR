using UnityEngine;

public class Conductor : MonoBehaviour
{
    //Static Info, useful info accessible by all classes
    public float beatsPerMin;
    public float secondsPerBeat;
    public float secondsPerSixteenth;
    public double songStartDSPTime;
     //public float startOffsetInSec;

    
    public AudioSource songPlayer;

    //Dynamic Info, changes as song progresses.
    public bool isSongPlaying; 
    public float songPositionInSeconds; //elapsed song time in seconds
    public float songPositionInSixteenths;
    public int totalSixteenth;
     //public float currentSection; 
     //public float secondsToNextBeat;

    //Instance
    public static Conductor instance;

    //Testing
    private int previousSixteenth = -1;


    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        secondsPerBeat = 60f / beatsPerMin;
        secondsPerSixteenth = secondsPerBeat / 4;
        StartSong();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSongPlaying) return;
        songPositionInSeconds = (float)(AudioSettings.dspTime - songStartDSPTime);
        songPositionInSixteenths = songPositionInSeconds / secondsPerSixteenth;
        totalSixteenth = (int)Mathf.Floor(songPositionInSixteenths);

        if (totalSixteenth != previousSixteenth)
        {
            /*Debug.Log(
                "Measure: " + GetCurrentMeasure() +
                " Beat: " + GetCurrentBeat() +
                " Sixteenth: " + GetCurrentSixteenth()
            );*/

            previousSixteenth = totalSixteenth;
        }
    }

    public void StartSong() 
    {
        songStartDSPTime = AudioSettings.dspTime;
        songPlayer.Play();
        isSongPlaying = true;

    }

    //Gives Measure, Beat, and Sixteenth indexes
    public int GetCurrentMeasure()
    {
        return totalSixteenth / 16;
    }

    public int GetSixteenthInMeasure()
    {
        return totalSixteenth % 16;
    }
    
    public int GetCurrentBeat()
    {
        return GetSixteenthInMeasure() /4;
    }

    public int GetCurrentSixteenth()
    {
        return GetSixteenthInMeasure() % 4;
    }
    
    //Gives time based on Measure, Beat, and/or Sixteenth indexes
    public float GetTimeAtPosition(int measure, int beat, int sixteenth)
    {
        int targetSixteenth =
            (measure * 16) +
            (beat * 4) +
            sixteenth;

        return targetSixteenth * secondsPerSixteenth;
    }

    public float GetTimeAtSixteenth(int totalSixteenth)
    {
        return totalSixteenth * secondsPerSixteenth;
    }


}
