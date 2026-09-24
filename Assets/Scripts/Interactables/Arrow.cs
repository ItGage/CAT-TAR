using UnityEngine;

public class Arrow : Interactable
{
    public ArrowCollider badEarly, badLate, goodEarly, goodLate, perfect;

    private bool canAttack = false;
    public enum Direction
    {
        Left,
        Up,
        Right,
        Down
    }


    //change to player ref for attackMeter
    public AttackMeter attackMeter;

    [Header("Direction")]
    public Direction dir;

    public override void Awake()
    {
        base.Awake();
        
        switch(dir)
        {
            case Direction.Left:
                sr.sprite = spriteArray[0];
                break;
            case Direction.Up:
                sr.sprite = spriteArray[1];
                break;
            case Direction.Right:
                sr.sprite = spriteArray[2];
                break;
            case Direction.Down:
                sr.sprite = spriteArray[3];
                break;
        }
    }

    private void Update()
    {
        //Only runs when the player is inside the collider
        if(canAttack)
        {
            
            //if player enters the correct key call correct function
            //else if player enters incorrect key call incorect function 
        }
    }

    public override void PlayerInteraction()
    {
        canAttack = false;
    }
    public void correct()
    {
        //adds to the attack meter (number of correct attacks)
        if (badEarly.GetInTrigger())
        {
            attackMeter.BadHit();
        }
        else if (goodEarly.GetInTrigger())
        {
            attackMeter.GoodHit();
        }
        else if (perfect.GetInTrigger())
        {
            attackMeter.PerfectHit();
        }
        else if (goodLate.GetInTrigger())
        {
            attackMeter.GoodHit();
        }
        else if (badLate.GetInTrigger())
        {
            attackMeter.BadHit();
        }

        //play VFX and SFX for correct note

        //destory the object after FX are played
        Destroy(gameObject, FXTimer);
    }
    public void incorrect()
    {
        //change sprite to faded sprite
        player.RegisterHit();

        //disable collider so the player can't make another input
        gameObject.GetComponent<BoxCollider2D>().enabled = false; ;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canAttack = false;
    }
}
