using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayGameInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI total;
    private float totalAmt;
    
    public float DisplayTotal(float addAmt)
    {
        totalAmt += addAmt;
        string _totalAmt = totalAmt.ToString();
        if (_totalAmt.Length >= 7)
        {
            total.text = totalAmt.ToString().Substring(0, 7);
        }
        else
        {
            total.text = _totalAmt;
        }

        return totalAmt;
    }
}
