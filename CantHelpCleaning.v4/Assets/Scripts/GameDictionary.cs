using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDictionary : MonoBehaviour
{
    public Dictionary<int,string> AI_Level = new Dictionary<int,string>();

    private string DATA_PATH;
    
    
    private void Start()
    {
        //create the dictionary for searching
        AI_Level.Add(0,"General AI");
        AI_Level.Add(1,"Better AI");
    }
    
    
}
