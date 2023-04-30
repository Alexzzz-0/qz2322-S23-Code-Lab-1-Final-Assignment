using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private DisplayAIs _displayAIs;
    
    [SerializeField] private Rigidbody2D playerRb;

    public float xSpeedTime = 1f;
    public float ySpeedTime = 1f;
    public float turnSpeedTime = 1f;

    public void Turn(float direction)
    {
        playerRb.DORotate(direction * 90f, turnSpeedTime);
    }

    public void MoveHorizontal(float direction)
    {
        float currentX = transform.position.x;
        playerRb.DOMoveX(direction * _displayAIs.Xgap + currentX, xSpeedTime);
    }

    public void MoveVertical(float direction)
    {
        float currentY = transform.position.y;
        playerRb.DOMoveY(direction * _displayAIs.Ygap + currentY, ySpeedTime);
    }
}
