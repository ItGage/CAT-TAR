using UnityEngine;

public class Launcher : MonoBehaviour
{
    public SongChart songChart;

    public Transform[] spawnPoints;
    public Transform[] targetPoints;

    public int leadInSixteenths = 8;

    private int nextSixteenthToLaunch = 8;

    void Update()
    {
        int launchAtSixteenth = nextSixteenthToLaunch - leadInSixteenths;

        if (Conductor.instance.songPositionInSixteenths >= launchAtSixteenth)
        {
            
            int measureIndex = nextSixteenthToLaunch / 16;
            int sixteenthIndex = nextSixteenthToLaunch % 16;

            //keeps you from going past the end of song
            if (measureIndex >= songChart.measures.Count)
            {
                return;
            }
            
            //grabs current measure and stores locally
            Measure currentMeasure = songChart.measures[measureIndex];
            
            //loops through each lane
            for (int laneIndex = 0; laneIndex < currentMeasure.lanes.Length; laneIndex++)
            {
                //grabs current sixteenth index and stores locally as "slot"
                Sixteenth slot = currentMeasure.lanes[laneIndex].sixteenths[sixteenthIndex];
                
                //interactable testing
                Debug.Log
                (
                "Checking lane " + laneIndex +
                ", measure " + measureIndex +
                ", sixteenth " + sixteenthIndex +
                ", interactable = " +
                (slot.interactable == null ? "NULL" : slot.interactable.name)
                );
                //if there is an interactable on this slot, spawn it
                if (slot.interactable != null)
                {
                    Interactable spawnedObject = Instantiate
                    (
                        slot.interactable,
                        spawnPoints[laneIndex].position,
                        spawnPoints[laneIndex].rotation
                    );

                    Debug.Log
                    (
                        "Spawned " + spawnedObject.name +
                        " in lane " + laneIndex
                    );
                }

            }
            Debug.Log(Conductor.instance.totalSixteenth);
            Debug.Log("Ready to launch sixteenth: " + nextSixteenthToLaunch);
            Debug.Log
            (
                "Global: " + nextSixteenthToLaunch +
                " Measure: " + measureIndex +
                " Sixteenth: " + sixteenthIndex
            );

            nextSixteenthToLaunch++;
        }
    }
}