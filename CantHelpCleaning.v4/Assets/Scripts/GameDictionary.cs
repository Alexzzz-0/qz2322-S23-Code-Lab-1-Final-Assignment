using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDictionary : MonoBehaviour
{
    public Dictionary<int,string> AI_Level = new Dictionary<int,string>();

    private string FILE_PATH;
    private string DATA_PATH;
    
    
    private void Start()
    {
        //create the dictionary for searching
        AI_Level.Add(0,"General AI");
        AI_Level.Add(1,"Better AI");

        FILE_PATH = Application.dataPath + "/Data/";
        if (!File.Exists(FILE_PATH))
        {
            Directory.CreateDirectory(FILE_PATH);
        }
        
        DATA_PATH = Application.dataPath + "/Data/DeadFile.txt";
    }

    public void WriteIntoDeadFile(int deadIndex, float deadAmt)
    {
        string comName = AI_Level[deadIndex];
        File.AppendAllText(DATA_PATH,comName+ "/" + deadAmt.ToString() +"\n");
    }
    
    
}
