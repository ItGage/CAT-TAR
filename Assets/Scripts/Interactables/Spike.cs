using UnityEngine;

public class Spike : Interactable
{
    public override void PlayerInteraction()
    {
        hp.TakeDmg(damage);
    }
}
