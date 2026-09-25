using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class HitPerformedUI : MonoBehaviour
{
    [SerializeField] private TMP_Text hitPerformed;

    public void UpdateUI(string hit)
    {
        hitPerformed.text = hit;
    }
}
