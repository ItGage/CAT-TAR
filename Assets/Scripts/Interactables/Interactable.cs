using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [Header("Stats")]
    public float damage = .25f;

    [Header("Setup")]
    public Sprite[] spriteArray;
    public SpriteRenderer sr;
    [Tooltip("The amount of time needed to play the FX before destroying the interactable"), Min(0)]
    public float FXTimer;
    public bool isMoveable=true;

    protected Health hp;

    protected GameObject playerObject;

    protected Player player;

    public virtual void Awake()
    {
        //finds player gameobject
        playerObject = GameObject.Find("Player");
        if (playerObject!=null)
        {
            hp = playerObject.GetComponent<Health>();
            player = playerObject.GetComponent<Player>();
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        //checks if collided with player
        if (other.CompareTag("Player"))
        {
            PlayerInteraction();
        }
        //checks if collided with end of track and destroys gameobject if true
        else if (other.CompareTag("end"))
        {
            endOfTrack();
        }
    }
    //destroy interactable at the end of the lane
    public virtual void endOfTrack()
    {
        Destroy(gameObject);
    }

    public abstract void PlayerInteraction();

    public virtual void dealDmg()
    {
        /*
         * player.takeDmg(damage);
         */
    }

    /*if needed
     * public abstract void Move();
     */
}