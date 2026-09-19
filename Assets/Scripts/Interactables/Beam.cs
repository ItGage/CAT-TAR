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
            //If not in jump state than
                //player.Health.TakeDmg(damage);
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
