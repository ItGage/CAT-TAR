using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [Header("Stats")]
    public float damage = .25f;

    [Header("Setup")]
    public Sprite[] spriteArray;
    public SpriteRenderer sr;

    private GameObject player;

    public virtual void Awake()
    {
        //finds player gameobject
        //player = GameObject.Find("Player");
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
