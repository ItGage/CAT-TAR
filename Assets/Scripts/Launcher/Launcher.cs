using UnityEngine;
using System.Collections.Generic;

public class Launcher : MonoBehaviour
{
    public SongChart songChart;

    public Transform[] spawnPoints;
    public Transform[] targetPoints;

    public int leadInSixteenths = 8;
   
    private int nextSixteenthToLaunch = 0;

    private List<LaunchedObject> activeObjects = new();

    void Update()
    {
        int launchAtSixteenth = nextSixteenthToLaunch - leadInSixteenths;

        //----------------------------------------Spawning Section------------------------------------//

        if (Conductor.instance.songPositionInSixteenths >= launchAtSixteenth)
        {

            int measureIndex = nextSixteenthToLaunch / 16;
            int sixteenthIndex = nextSixteenthToLaunch % 16;

            //keeps you from going past the end of song
            if (measureIndex < songChart.measures.Count)
            {
                //grabs current measure and stores locally
                Measure currentMeasure = songChart.measures[measureIndex];

                //loops through each lane
                for (int laneIndex = 0; laneIndex < currentMeasure.lanes.Length; laneIndex++)
                {
                    //grabs current sixteenth index and stores locally as "slot"
                    Sixteenth slot = currentMeasure.lanes[laneIndex].sixteenths[sixteenthIndex];

                    //interactable testing
                    /*
                    Debug.Log
                    (
                        "Checking lane " + laneIndex +
                        ", measure " + measureIndex +
                        ", sixteenth " + sixteenthIndex +
                        ", interactable = " +
                        (slot.interactable == null ? "NULL" : slot.interactable.name)
                    );
                    */
                    //if there is an interactable on this slot, spawn it
                    if (slot.interactable != null)
                    {
                        Interactable spawnedObject = Instantiate
                        (
                            slot.interactable,
                            spawnPoints[laneIndex].position,
                            spawnPoints[laneIndex].rotation
                        );

                        /*
                        Debug.Log
                        (
                            "Spawned " + spawnedObject.name +
                            " in lane " + laneIndex
                        );
                        */

                        if (spawnedObject.isMoveable)
                        {
                            LaunchedObject launchedObject = new()
                            {
                                interactable = spawnedObject,
                                startPosition = spawnPoints[laneIndex].position,
                                targetPosition = targetPoints[laneIndex].position,
                                spawnSixteenth = nextSixteenthToLaunch - leadInSixteenths,
                                targetSixteenth = nextSixteenthToLaunch
                            };

                            activeObjects.Add(launchedObject);
                        }
                    }
                }
                /*
                Debug.Log(Conductor.instance.totalSixteenth);
                Debug.Log("Ready to launch sixteenth: " + nextSixteenthToLaunch);
                Debug.Log
                (
                    "Global: " + nextSixteenthToLaunch +
                    " Measure: " + measureIndex +
                    " Sixteenth: " + sixteenthIndex
                );
                */
                nextSixteenthToLaunch++;
            }
        }

        //----------------------------------------Movement Section------------------------------------//

        for (int i = activeObjects.Count - 1; i >= 0; i--)
        {
            LaunchedObject launchedObject = activeObjects[i];

            if (launchedObject.interactable == null)
            {
                activeObjects.RemoveAt(i);
                continue;
            }

            float progress =
                (Conductor.instance.songPositionInSixteenths - launchedObject.spawnSixteenth) /
                (launchedObject.targetSixteenth - launchedObject.spawnSixteenth);

            Vector2 newPosition = Vector2.LerpUnclamped
            (
                launchedObject.startPosition,
                launchedObject.targetPosition,
                progress
            );

            launchedObject.interactable.transform.position = newPosition;
        }
    }
}