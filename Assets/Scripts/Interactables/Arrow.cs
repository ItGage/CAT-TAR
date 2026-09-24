using UnityEngine;

public class Arrow : Interactable
{
    public ArrowCollider badEarly, badLate, goodEarly, goodLate, perfect;

    private bool canAttack = false;
    private InputReader playerInput;
    public enum Direction
    {
        Left,
        Up,
        Right,
        Down
    }


    //change to player ref for attackMeter
    private AttackMeter attackMeter;

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
        attackMeter = player.GetAttackMeter();

        playerInput = player.GetInput();
        playerInput.LeftPerformed += LeftPress;
        playerInput.UpPerformed += UpPress;
        playerInput.RightPerformed += RightPress;
        playerInput.DownPerformed += DownPress;
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        //checks if collided with player
        if (other.CompareTag("Edge"))
        {
            PlayerInteraction();
        }
        //checks if collided with end of track and destroys gameobject if true
        else if (other.CompareTag("End"))
        {
            endOfTrack();
        }
    }

    private void LeftPress()
    {
        if (canAttack)
        {
            if (dir == Direction.Left)
            {
                Correct();
            }
            else
            {
                Incorrect();
            }
        }
    }

    private void UpPress()
    {
        if (canAttack)
        {
            if (dir == Direction.Up)
            {
                Correct();
            }
            else
            {
                Incorrect();
            }
        }
    }
    private void RightPress()
    {
        if (canAttack)
        {
            if (dir == Direction.Right)
            {
                Correct();
            }
            else
            {
                Incorrect();
            }
        }
    }

    private void DownPress()
    {
        if (canAttack)
        {
            if (dir == Direction.Down)
            {
                Correct();
            }
            else
            {
                Incorrect();
            }
        }
    }

    public override void PlayerInteraction()
    {
        canAttack = true;
    }
    public void Correct()
    {
        Debug.Log("Correct arrow hit");
        //adds to the attack meter (number of correct attacks)
        //Still need to add to score keeper
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
        playerInput.LeftPerformed -= LeftPress;
        playerInput.UpPerformed -= UpPress;
        playerInput.RightPerformed -= RightPress;
        playerInput.DownPerformed -= DownPress;
        Destroy(gameObject, FXTimer);
    }
    public void Incorrect()
    {
        Debug.Log("Incorrect arrow hit");
        //change sprite to faded sprite
        player.RegisterHit();

        //disable collider so the player can't make another input
        playerInput.LeftPerformed -= LeftPress;
        playerInput.UpPerformed -= UpPress;
        playerInput.RightPerformed -= RightPress;
        playerInput.DownPerformed -= DownPress;
        gameObject.GetComponent<BoxCollider2D>().enabled = false; ;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canAttack = false;
    }
}
