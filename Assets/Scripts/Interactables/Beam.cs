using UnityEngine;

public class Beam : Interactable
{
    private bool inTrigger = false, hasDealtDmg=false;
    public override void PlayerInteraction()
    {
        inTrigger = true; 
    }

    private void Update()
    {
        //Checks if player is in the beam collider and hasn't taken damage from it yet
        if (inTrigger && !hasDealtDmg)
        {
            //Checks if player is not jumping
            if(player.GetState() != PlayerState.jumping)
            {
                hp.TakeDmg(damage);
                hasDealtDmg = true;
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
