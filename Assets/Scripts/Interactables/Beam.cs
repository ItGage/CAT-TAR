using UnityEngine;

public class Beam : Interactable
{
    private bool inTrigger = false;
    public override void PlayerInteraction()
    {
        inTrigger = true;
    }

    private void Update()
    {
        if (inTrigger)
        {
            //change to not jumping when bool is set
            if(!player.canBeHit)
            {
                hp.TakeDmg(damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }
}
