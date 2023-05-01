using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private DisplayAIs _displayAIs;
    [SerializeField] private DisplayGameInfo _displayGameInfo;
    
    private List<int> currentAIs = new List<int>();
    private List<int> unlockedAIs = new List<int>();

    private float timer;
    public float TimeWaitForSpawn = 5f;

    public float possibility_1 = 0.35f;
    public float possibility_2 = 0.7f;

    private int newAILevel;

    public int CurrentCapacity = 10;

    public int highestLevel = 2;
    
    private void Start()
    {
        currentAIs.Add(0);
        currentAIs.Add(0);
        
        unlockedAIs.Add(0);
    }
    
    public float Spawn()
    {
        //create a timer
        timer += Time.deltaTime;
        
        //if there is space
        if (currentAIs.Count <= CurrentCapacity -1)
        {
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

                //if the new level is out of range
                if (newAILevel > highestLevel)
                {
                    float random2 = Random.Range(0, 1f);
                    if (random2 <= 0.5f)
                    {
                        newAILevel = Math.Min(aiLevel_1,aiLevel_2);
                    }
                    else
                    {
                        newAILevel = Math.Max(aiLevel_1,aiLevel_2);
                    }
                }

                #endregion
                
                //add it to the current running list
                currentAIs.Add(newAILevel);

                //detect the mute
                if (newAILevel == Math.Max(aiLevel_1, aiLevel_2) + 1)
                {
                    //check if it has been unlocked
                    //if no,
                    //tell view script to display the mute
                    AddUnlocked(newAILevel);
                }
                //re-calculate the fasten feature of the game
                GameManager.instance._totalGrowAdd = 0;
                GameManager.instance._totalCapacityAdd = 0;
                
                //re-display the map
                int[] currentCom = currentAIs.ToArray();
                _displayAIs.DisplayAIOnMap(currentCom);

                timer = 0f;
            }
        }

        return (TimeWaitForSpawn -timer);
    }

    
    
    public void DeleteCom(int comIndex)
    {
        //delete one of the computer from the current list
        for (int i = 0; i < currentAIs.Count; i++)
        {
            if (currentAIs[i] == comIndex)
            {
                currentAIs.RemoveAt(i);
                return;
            }
        }
    }

    private void AddUnlocked(int newAIIndex)
    {
        if (!unlockedAIs.Contains(newAIIndex))
        {
            unlockedAIs.Add(newAILevel);
            //tell display script to display
            _displayGameInfo.DisplayMutePanel(newAILevel);
        }

        //make the update slower and slower
        TimeWaitForSpawn += 5f;
    }
}
