using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayGameInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI total;
    private float totalAmt;
    
    public void DisplayTotal(float addAmt)
    {
        totalAmt += addAmt;
        total.text = totalAmt.ToString().Substring(0, 7);
    }
}
