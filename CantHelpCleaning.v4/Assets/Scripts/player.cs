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

    public void Turn(int direction)
    {
        playerRb.DORotate(direction * 90f, turnSpeedTime);
    }

    public void MoveHorizontal(int direction)
    {
        
        float currentX = transform.position.x;
        playerRb.DOMoveX(direction * _displayAIs.Xgap * 0.5f + currentX, xSpeedTime);
        // Vector3 newPos = transform.position;
        // float xAdd = Time.deltaTime * xSpeedTime * direction;
        // newPos.x += xAdd;
        // Debug.Log(xAdd.ToString());
        // playerRb.MovePosition(newPos);
    }

    public void MoveVertical(int direction)
    {
        float currentY = transform.position.y;
        playerRb.DOMoveY(direction * _displayAIs.Ygap * 0.5f + currentY, ySpeedTime);
        // Vector3 newPos = transform.position;
        // newPos.y += Time.deltaTime * ySpeedTime * direction;
        // playerRb.MovePosition(newPos);
    }
}
