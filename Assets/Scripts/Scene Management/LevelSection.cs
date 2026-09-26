using UnityEngine;

public enum section { attack, defense }

public class LevelSection : MonoBehaviour
{
    public section sectionType;
    public int startMeasure;
    [Space(5)]
    public AttackMeter attackMeter;
}
