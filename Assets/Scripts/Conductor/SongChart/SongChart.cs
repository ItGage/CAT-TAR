using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSongChart", menuName = "CAT-TARCustomAssets/SongChart")]
public class SongChart : ScriptableObject
{
    public List<Measure> measures = new()
    {
        new Measure()
    };

    public void AddMeasure()
    {
        measures.Add(new Measure());
    }
}
