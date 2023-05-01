using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayGameInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI total;
    [SerializeField] private TextMeshProUGUI display;
    
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

    // public float time;
    // public float growAddTotal;
    // public float dirtCapTotal;
    // public int comCapTotal;
    // public float freshTime;
    // public float evolvePossibility;
    public void DisplayDetails(float time,float growAddTotal,float dirtCapTotal,int comCapTotal,float freshTime,float evolvePossibility)
    {
        display.text = "Next Time Update in: " + time.ToString().Substring(0, 1) + "\n" +
                       "Generate Speed is Added By: " + growAddTotal.ToString().Substring(0, 1) + "\n" +
                       "Each AI's Capacity is Added By: " + dirtCapTotal.ToString().Substring(0, 1) + "\n" +
                       "Total AI Amount: 5 + " + comCapTotal.ToString() + "\n" +
                       "Update Frequency: 5 - " + freshTime.ToString().Substring(0, 1) + "\n" +
                       "Evolved Possibility: 0.7 +" + evolvePossibility.ToString().Substring(0, 1);

    }
}
