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

    public void DestroyCom(int index)
    {
        _spawnController.DeleteCom(index);
        _gameDictionary.WriteIntoDeadFile(index);
    }
}
