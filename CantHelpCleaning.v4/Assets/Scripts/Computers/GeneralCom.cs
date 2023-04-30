using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GeneralCom : MonoBehaviour
{
    public int comIndex;
    private float dirtAmt;
    public float dirtCapacity;
    public float dirtGrowSpeed;
    
    [SerializeField] private TextMeshPro dirt;

    public GeneralCom(int _comIndex)
    {
        comIndex = _comIndex;
    }

    private void Start()
    {
        dirt = transform.Find("display").GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        Grow();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //call game manager to
            //1. delete from current list
            //2. write into dead file
            //3. add it to the total amout
            GameManager.instance.DestroyCom(comIndex,dirtAmt);
            Destroy(gameObject);
        }
    }

    public void Grow()
    {
        //automatically grow
        if(dirtAmt < dirtCapacity)
        {
            dirtAmt += dirtGrowSpeed * Time.deltaTime;
        }

        //display with text
        string dirAmt = dirtAmt.ToString();
        
        if (dirAmt.Length >= 8)
        {
            dirt.text = dirAmt.Substring(0,8);
        }
        else
        {
            dirt.text = dirAmt;
        }
        
    }
}
