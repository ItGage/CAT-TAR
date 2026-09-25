using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Sprite[] hpSprites;
    [SerializeField] private Image hp1, hp2, hp3, hp4, hp5, hp6, hp7, hp8, hp9;

    [Header("READ ONLY")]
    [SerializeField] private float currentHP = 9f;

    public void SetHP(float hp)
    {
        currentHP = hp;
        if (currentHP>8.75)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[0];
            hp8.sprite = hpSprites[0];
            hp9.sprite = hpSprites[0];
        }
        else if (currentHP>8.5)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[0];
            hp8.sprite = hpSprites[0];
            hp9.sprite = hpSprites[1];
        }
        else if (currentHP > 8.25)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[0];
            hp8.sprite = hpSprites[0];
            hp9.sprite = hpSprites[2];
        }
        else if (currentHP > 8)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[0];
            hp8.sprite = hpSprites[0];
            hp9.sprite = hpSprites[3];
        }
        else if (currentHP > 7.75)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[0];
            hp8.sprite = hpSprites[0];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 7.5)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[0];
            hp8.sprite = hpSprites[1];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 7.25)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[0];
            hp8.sprite = hpSprites[2];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 7)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[0];
            hp8.sprite = hpSprites[3];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 6.75)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[0];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 6.5)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[1];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 6.25)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[2];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 6)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[3];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 5.75)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[0];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 5.5)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[1];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 5.25)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[2];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 5)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[3];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 4.75)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[0];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 4.5)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[1];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 4.25)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[2];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 4)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[3];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 3.75)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[0];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 3.5)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[1];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 3.25)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[2];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 3)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[3];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 2.75)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[0];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 2.5)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[1];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 2.25)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[2];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 2)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[3];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 1.75)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[0];
            hp3.sprite = hpSprites[4];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 1.5)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[1];
            hp3.sprite = hpSprites[4];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 1.25)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[2];
            hp3.sprite = hpSprites[4];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 1)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[3];
            hp3.sprite = hpSprites[4];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > .75)
        {
            hp1.sprite = hpSprites[0];
            hp2.sprite = hpSprites[4];
            hp3.sprite = hpSprites[4];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > .5)
        {
            hp1.sprite = hpSprites[1];
            hp2.sprite = hpSprites[4];
            hp3.sprite = hpSprites[4];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > .25)
        {
            hp1.sprite = hpSprites[2];
            hp2.sprite = hpSprites[4];
            hp3.sprite = hpSprites[4];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else if (currentHP > 0)
        {
            hp1.sprite = hpSprites[3];
            hp2.sprite = hpSprites[4];
            hp3.sprite = hpSprites[4];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
        else
        {
            hp1.sprite = hpSprites[4];
            hp2.sprite = hpSprites[4];
            hp3.sprite = hpSprites[4];
            hp4.sprite = hpSprites[4];
            hp5.sprite = hpSprites[4];
            hp6.sprite = hpSprites[4];
            hp7.sprite = hpSprites[4];
            hp8.sprite = hpSprites[4];
            hp9.sprite = hpSprites[4];
        }
    }
}
