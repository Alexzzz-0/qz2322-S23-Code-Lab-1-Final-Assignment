using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameDictionary _gameDictionary;
    [SerializeField] private DisplayAIs _displayAIs;
    
    private List<int> currentAIs = new List<int>();

    private float timer;
    public float TimeWaitForSpawn = 5f;

    public float possibility_1 = 0.35f;
    public float possibility_2 = 0.7f;

    private int newAILevel;

    public int CurrentCapacity = 9;
    
    private void Start()
    {
        currentAIs.Add(0);
        currentAIs.Add(0);
    }
    
    public void Spawn()
    {
        //create a timer
        timer += Time.deltaTime;
        
        //if there is space
        if (currentAIs.Count <= CurrentCapacity)
        {
            Debug.Log(currentAIs.Count.ToString());
            //if it is the time
            if (timer >= TimeWaitForSpawn)
            {
                #region calculate the possibility
                
                //choose two AIs
                int random = Random.Range(0, currentAIs.Count);
                int aiLevel_1 = currentAIs[random];
                random = Random.Range(0, currentAIs.Count);
                int aiLevel_2 = currentAIs[random];
                
                //get the possibility
                float randomPossibility = Random.Range(0, 1f);
                if (randomPossibility <= possibility_1)
                {
                    //the min
                    newAILevel = Math.Min(aiLevel_1,aiLevel_2);
                }
                else if (randomPossibility >= possibility_2)
                {
                    //the evolved
                    newAILevel = Math.Max(aiLevel_1, aiLevel_2) + 1;
                }
                else
                {
                    //the max
                    newAILevel = Math.Max(aiLevel_1, aiLevel_2);
                }

                #endregion
                
                //add it to the current running list
                currentAIs.Add(newAILevel);
                
                //re-display the map
                int[] currentCom = currentAIs.ToArray();
                _displayAIs.DisplayAIOnMap(currentCom);

                timer = 0f;
            }
        }
        
        
        
        
    }
}
