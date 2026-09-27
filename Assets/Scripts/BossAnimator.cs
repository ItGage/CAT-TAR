using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    public int bossNum;
    public Animator bossAnim;

    public void Start()
    {
        if(bossNum == 1)
        {
            bossAnim.Play("Boss 1 Play");
        }
        else if(bossNum == 2)
        {
            bossAnim.Play("Boss 2 Play");
        }
        else if(bossNum == 3)
        {
            bossAnim.Play("Boss 3 Play");
        }
    }
}
