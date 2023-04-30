using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private player _player;
    public enum PlayerDirection
    {
        up,
        down,
        left,
        right
    }

    private PlayerDirection currentDirection = PlayerDirection.right;
    
    public void TurnOrMove(int _directionIndex)
    {
        if (_directionIndex == 0)
        {
            if (currentDirection == PlayerDirection.up)
            {
                _player.MoveVertical(-1f);
            }
            else
            {
                _player.Turn(-1f);
                currentDirection = PlayerDirection.up;
            }
        }
        
        if (_directionIndex == 1)
        {
            if (currentDirection == PlayerDirection.down)
            {
                _player.MoveVertical(1f);
            }
            else
            {
                _player.Turn(1f);
                currentDirection = PlayerDirection.down;
            }
        }
        
        if (_directionIndex == 2)
        {
            if (currentDirection == PlayerDirection.left)
            {
                _player.MoveHorizontal(-1f);
            }
            else
            {
                _player.Turn(2f);
                currentDirection = PlayerDirection.left;
            }
        }
        
        if (_directionIndex == 3)
        {
            if (currentDirection == PlayerDirection.right)
            {
                _player.MoveHorizontal(1f);
            }
            else
            {
                _player.Turn(0);
                currentDirection = PlayerDirection.right;
            }
        }
    }
}
