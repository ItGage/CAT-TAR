using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [Header("Stats")]
    public float damage = .25f;

    [Header("Setup")]
    public Sprite[] spriteArray;
    public SpriteRenderer sr;
    [Tooltip("The amount of time needed to play the FX before destroying the interactable"), Min(0)]
    public float FXTimer=0;
    public bool isMoveable=true;

    protected Health hp;
    protected bool hasDoneDamage = false;

    [SerializeField] protected AudioSource audioPlayer;

    protected GameObject playerObject;

    protected Player player;

    public virtual void Awake()
    {
        //finds player gameobject
        playerObject = GameObject.Find("Player");
        if (playerObject!=null)
        {
            player = playerObject.GetComponent<Player>();
            hp = player.GetHealth();
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
        else if (other.CompareTag("End"))
        {
            endOfTrack();
        }
    }
    //destroy interactable at the end of the lane
    public virtual void endOfTrack()
    {
        //play fx here
        Destroy(gameObject, FXTimer);
    }

    public abstract void PlayerInteraction();

    public virtual void dealDmg()
    {
        if (!hasDoneDamage)
        {
            hasDoneDamage = true;
            hp.TakeDmg(damage);
            Destroy(gameObject, FXTimer);
        }
    }

    /*if needed
     * public abstract void Move();
     */
}