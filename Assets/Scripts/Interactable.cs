using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public Sprite[] spriteArray;
    public SpriteRenderer sr;
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
            Destroy(gameObject);
        }
    }
    public abstract void PlayerInteraction();

    /*if needed
     * public abstract void Move();
     */
}
