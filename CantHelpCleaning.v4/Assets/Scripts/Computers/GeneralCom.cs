using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCom : MonoBehaviour
{
    public int comIndex;

    public GeneralCom(int _comIndex)
    {
        comIndex = _comIndex;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            
            GameManager.instance.DestroyCom(comIndex);

            Destroy(gameObject);
        }
    }
}
