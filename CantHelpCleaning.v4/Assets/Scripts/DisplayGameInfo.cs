using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DisplayGameInfo : MonoBehaviour
{
    [SerializeField] private GameDictionary _gameDictionary;
    
    [SerializeField] private TextMeshProUGUI total;
    
    [SerializeField] private TextMeshPro _display;

    public GameObject[] mutePanels;
    [SerializeField] private GameObject canvas;
    
    private float totalAmt;

    private GameObject newMutePrompt;
    public Vector2 newPos;

    private float _addAmt;
    private float stage = 20f;
    private string _totalAmt;
    
    public float DisplayTotal(float addAmt)
    {
        //totalAmt += addAmt;
         _addAmt = addAmt;
         StartCoroutine("SlowlyAddToTotal");
        
        // _totalAmt = totalAmt.ToString();
        // if (_totalAmt.Length >= 7)
        // {
        //     total.text = totalAmt.ToString().Substring(0, 7);
        // }
        // else
        // {
        //     total.text = _totalAmt;
        // }

        return totalAmt;
    }

    IEnumerator SlowlyAddToTotal()
    {
        float delta = _addAmt / stage;
            
        for (float q = 0; q < stage; q ++)
        {
            totalAmt += delta;
            
            _totalAmt = totalAmt.ToString();
            if (_totalAmt.Length >= 7)
            {
                total.text = totalAmt.ToString().Substring(0, 7);
            }
            else
            {
                total.text = _totalAmt;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    public void DisplayDetails(float time,float growAddTotal,float dirtCapTotal,int comCapTotal,float freshTime,float evolvePossibility)
    {
        _display.text =  "Next Time Update in: " + time.ToString().Substring(0, 2) + "\n" +
                         "Generate Speed is Added By: " + growAddTotal.ToString().Substring(0, 1) + "\n" +
                         "Each AI's Capacity is Added By: " + dirtCapTotal.ToString().Substring(0, 1) + "\n" +
                         "Total AI Amount: 5 + " + comCapTotal.ToString() + "\n" +
                         "Update Frequency: 5 - " + freshTime.ToString().Substring(0, 1) + "\n" +
                         "Evolved Possibility: 0.7 +" + evolvePossibility.ToString().Substring(0, 1);
    }

    public void DisplayMutePanel(int comIndex)
    {
        //instantiate the panel
        newMutePrompt = Instantiate(mutePanels[comIndex]);
        newMutePrompt.transform.parent = canvas.transform;
        newMutePrompt.transform.position = newPos;
        
        //get the right panel
        Invoke("DestroyMutePanel",5f);
    }

    private void DestroyMutePanel()
    {
        Destroy(newMutePrompt);
    }
}

