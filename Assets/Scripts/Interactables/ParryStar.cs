using UnityEngine;

public class ParryStar : Interactable
{
    [Header("Is It A Special Star?")]
    public bool isSpecial = false;
    private bool parried = false, canParry = false;

    [SerializeField] private SpriteRenderer srGlow;

    public override void Awake()
    {
        base.Awake();
        if (isSpecial) sr.sprite = spriteArray[1];
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        //checks if collided with player
        if (other.CompareTag("Edge"))
        {
            srGlow.enabled = true;
            PlayerInteraction();
        }
        //checks if collided with end of track and destroys gameobject if true
        else if (other.CompareTag("End"))
        {
            endOfTrack();
        }
    }
    public override void PlayerInteraction()
    {
        canParry = true;
    }

    private void Update()
    {
        //checks if player is in the collider
        if (canParry && !parried)
        {
            //Checks if player parries
            if (player.GetState() == PlayerState.parrying)
            {
                audioPlayer.Play();
                parried = true;
                if (isSpecial) hp.PlusParryCount();
                //play fx here

                Destroy(gameObject, FXTimer);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if player parried than return before you apply daamge
        if (parried) return;

        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            srGlow.enabled = false;
            dealDmg();
        }
    }
}
