using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SpawnController _spawnController;
    [SerializeField] private PlayerController _playerController;
    
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
}
