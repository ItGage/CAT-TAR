using System;

[Serializable]
public class Lane
{
    public Sixteenth[] sixteenths;

    public Lane()
    {
        sixteenths = new Sixteenth[16];

        for (int i = 0; i < sixteenths.Length; i++)
        {
            sixteenths[i] = new Sixteenth();
        }
    }
}