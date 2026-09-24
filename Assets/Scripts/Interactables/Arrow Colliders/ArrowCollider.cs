using UnityEngine;

public abstract class ArrowCollider : MonoBehaviour
{
    [Header("READ ONLY")]
    [SerializeField] private bool inTrigger = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edge"))
        {
            inTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edge"))
        {
            inTrigger = false;
        }
    }

    public bool GetInTrigger()
    {
        return inTrigger;
    }
}
