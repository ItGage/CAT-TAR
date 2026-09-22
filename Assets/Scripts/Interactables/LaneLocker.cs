using UnityEngine;

public class LaneLocker : Interactable
{
    [Header("LaneLocker Specifics")]
    [Tooltip("The amount of time before the lane locker becomes an active hitbox")]
    [SerializeField] private float countdownTime;

    [Tooltip("The amount of time the hitbox is active")]
    [SerializeField] private float activeTime;

    [Tooltip("The amount of time the Fx need to play")]
    [SerializeField] private float fxTime;

    private float cTimer=0, aTimer=0;
    private BoxCollider2D col;
    private bool colActive = false;

    public override void Awake()
    {
        base.Awake();
        col = GetComponent<BoxCollider2D>();
        col.enabled = false;
        fadeIn();
    }

    private void Update()
    {
        //change to dsp time eventually
        if (colActive)
        {
            cTimer += Time.deltaTime;
        }
        else
        {
            aTimer += Time.deltaTime;
        }

        if (cTimer>=countdownTime)
        {
            cTimer = -1;
            setActive();
        }
        if (aTimer>=activeTime)
        {
            //play fading out FX
            Destroy(gameObject, fxTime);
        }
    }

    public override void PlayerInteraction()
    {
        hp.TakeDmg(damage);
    }

    private void fadeIn()
    {
        //play fade in FX
    }

    private void setActive()
    {
        colActive = true;
        col.enabled = true;

    }
}
