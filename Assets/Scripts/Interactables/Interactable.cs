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
    
    protected LevelManager manager;

    protected GameObject playerObject, managerObject;

    protected Player player;

    public virtual void Awake()
    {
        //finds player and hp ref in scene
        playerObject = GameObject.Find("Player");
        if (playerObject!=null)
        {
            player = playerObject.GetComponent<Player>();
            hp = player.GetHealth();
        }
        //finds the level manager ref
        managerObject = GameObject.Find("LevelManager");
        if (managerObject!=null)
        {
            manager = managerObject.GetComponent<LevelManager>();
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