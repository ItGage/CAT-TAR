using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class HitPerformedUI : MonoBehaviour
{
    [SerializeField] private TMP_Text hitPerformed;
    [SerializeField] private TMP_Text timingPerformed;
    public void UpdateUI(string hit, string timing)
    {
        hitPerformed.text = hit;
        timingPerformed.text = timing;
    }
}
