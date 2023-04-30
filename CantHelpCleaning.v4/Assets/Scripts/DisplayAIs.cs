using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayAIs : MonoBehaviour
{
    public GameObject[] Computers;

    public float xOffSet;
    public float yOffSet;
    public float Xgap;
    public float Ygap;

    GameObject newComputer;

    public int numInRow = 5;
    private int count;

    private GameObject computerFather;

    //for debug
    //private string currentAI;

    public void DisplayAIOnMap(int[] currentCom)
    {
        
        Destroy(computerFather);

        computerFather = new GameObject("Computers");
        
        foreach (var com in currentCom)
        {
            switch (com)
            {
                case 0:
                    newComputer = Instantiate(Computers[0]);
                    break;
                case 1:
                    newComputer = Instantiate(Computers[1]);
                    break;
            }
            
            //display on the map
            newComputer.transform.position = new Vector3(xOffSet + (count % numInRow) * Xgap, yOffSet - (count / numInRow) * Ygap);
            newComputer.transform.parent = computerFather.transform;

            //for debug
            //currentAI += com.ToString();
            
            count += 1;
        }
        
        count = 0;

        //For debug
        //Debug.Log(currentAI);
        //currentAI = null;
    }
}
