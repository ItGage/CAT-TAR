using System;

[Serializable]
public class Measure
{
    public Lane[] lanes;

    public Measure()
    {
        lanes = new Lane[5];

        for (int i = 0; i < lanes.Length; i++)
        {
            lanes[i] = new Lane();
        }
    }
}