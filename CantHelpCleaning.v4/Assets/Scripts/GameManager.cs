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
    [SerializeField] private player _player;

    public float _totalGrowAdd;
    public float _totalCapacityAdd;

    public float totalAmt;

    private float timer;
    private int currentComCap;

    public int MaxAICapacity = 15;

    //private int _directionR = 0;
    private int _directionX = 0;
    private int _directionY = 0;
    
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
        timer = _spawnController.Spawn();
        _displayGameInfo.DisplayDetails(timer,_totalGrowAdd,_totalCapacityAdd,
            5-_spawnController.CurrentCapacity,5-_spawnController.TimeWaitForSpawn,
            _spawnController.possibility_2);
        
        //_player.MoveHorizontal(_directionX);
        //_player.MoveVertical(_directionY);
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            _playerController.TurnOrMove(2);
            //_player.Turn(2);
            //_directionX = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            _playerController.TurnOrMove(0);
            //_player.Turn(3f);
            //_directionY = -1;
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            _playerController.TurnOrMove(3);
            //_player.Turn(0);
            //_directionX = -1;
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            _playerController.TurnOrMove(1);
            //_player.Turn(1f);
            //_directionY = 1;
        }
    }

    public void DestroyCom(int index,float addAmt, float cutSpeed, float cutDirtCap)
    {
        //1. delete from current list
        _spawnController.DeleteCom(index);
        
        //2. write into dead file
        _gameDictionary.WriteIntoDeadFile(index,addAmt);
        
        //3. add it to the total amout
        totalAmt = _displayGameInfo.DisplayTotal(addAmt);
        
        //4. cut the current fasten speed
        _totalGrowAdd -= cutSpeed;
        _totalCapacityAdd -= cutDirtCap;
    }

    public void AddSpeednDirtCapacity(float addAmt, float addCap)
    {
        _totalGrowAdd += addAmt;
        _totalCapacityAdd += addCap;
        //Debug.Log("speed add:" +_totalGrowAdd.ToString() +"//capacity add:" + _totalCapacityAdd.ToString());
    }

    public void AddComCapacity()
    {
        if (_spawnController.CurrentCapacity < MaxAICapacity)
        {
            _spawnController.CurrentCapacity += 1;
        }
    }

    public void CutComCapacity()
    {
        _spawnController.CurrentCapacity -= 1;
    }

    public void FastenUpdateSpeed()
    {
        _spawnController.TimeWaitForSpawn -= 0.2f;
    }

    public void ReduceUpdateSpeed()
    {
        _spawnController.TimeWaitForSpawn += 0.2f;
    }

    public void AddEvlvPossibility()
    {
        _spawnController.possibility_2 -= 0.01f;
    }

    public void ReduceEvlvPossibility()
    {
        _spawnController.possibility_2 += 0.01f;
    }
    
}
