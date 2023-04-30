using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private SpawnController _spawnController;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameDictionary _gameDictionary;
    [SerializeField] private DisplayGameInfo _displayGameInfo;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        _spawnController.Spawn();

        if (Input.GetKeyDown(KeyCode.A))
        {
            _playerController.TurnOrMove(2);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            _playerController.TurnOrMove(0);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            _playerController.TurnOrMove(3);
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            _playerController.TurnOrMove(1);
        }
    }

    public void DestroyCom(int index,float addAmt)
    {
        //1. delete from current list
        _spawnController.DeleteCom(index);
        
        //2. write into dead file
        _gameDictionary.WriteIntoDeadFile(index,addAmt);
        
        //3. add it to the total amout
        _displayGameInfo.DisplayTotal(addAmt);


    }
}
