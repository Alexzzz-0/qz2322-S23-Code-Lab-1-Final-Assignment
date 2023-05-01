using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDictionary : MonoBehaviour
{
    //public Dictionary<int,string> AI_Level = new Dictionary<int,string>();
    public string[,] AIs = new string[7, 2];

    private string FILE_PATH;
    private string DATA_PATH;
    
    
    private void Start()
    {
        //create the dictionary for searching
        // AI_Level.Add(0,"General AI");
        // AI_Level.Add(1,"Manager AI");
        // AI_Level.Add(2,"Summary AI");
        // AI_Level.Add(3,"Expand AI");
        // AI_Level.Add(4,"Optimize AI");
        // AI_Level.Add(5,"Innovate AI");
        // AI_Level.Add(6,"Dimensional AI");

        AIs[0, 0] = "General AI";
        AIs[0, 1] = "/";
        AIs[1, 0] = "Manager AI";
        AIs[1, 1] = "Manager AI";
        AIs[2, 0] = "Expand AI";
        AIs[2, 1] = "Manager AI";
        AIs[3, 0] = "External  AI";
        AIs[3, 1] = "Manager AI";
        AIs[4, 0] = "Optimize AI";
        AIs[4, 1] = "Manager AI";
        AIs[5, 0] = "Innovate AI";
        AIs[5, 1] = "Manager AI";
        AIs[6, 0] = "Dimensional AI";
        AIs[6, 1] = "Manager AI";
       

        FILE_PATH = Application.dataPath + "/Data/";
        if (!File.Exists(FILE_PATH))
        {
            Directory.CreateDirectory(FILE_PATH);
        }
        
        DATA_PATH = Application.dataPath + "/Data/DeadFile.txt";
    }

    public void WriteIntoDeadFile(int deadIndex, float deadAmt)
    {
        string comName = AIs[deadIndex,0];
        File.AppendAllText(DATA_PATH,comName+ "/" + deadAmt.ToString() +"\n");
    }
    
    
}
