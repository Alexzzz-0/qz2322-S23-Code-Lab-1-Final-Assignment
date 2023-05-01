using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GeneralCom : MonoBehaviour
{
    public int comIndex;
    public float dirtCapacity;
    public float dirtGrowSpeed;
    
    private float dirtAmt;

    public float growAdd;
    public float capacityAdd;
    private float _growAdd;
    private float _capacityAdd;
    
    [SerializeField] private TextMeshPro dirt;

    // public GeneralCom(int _comIndex, float _dirtGrowSpeed, float _dirtCapacity, float _dirtGrowAdd, float _dirtCapAdd)
    // {
    //     comIndex = _comIndex;
    //     dirtGrowSpeed = _dirtGrowSpeed;
    //     dirtCapacity = _dirtCapacity;
    //     growAdd = _dirtGrowAdd;
    //     capacityAdd = _dirtCapAdd;
    // }
    
    public virtual void Start()
    {
        dirt = transform.Find("display").GetComponent<TextMeshPro>();

        _growAdd = growAdd;
        _capacityAdd = capacityAdd;
        
        //tell GM to add speed
        GameManager.instance.AddSpeednDirtCapacity(_growAdd,_capacityAdd);
    }

    public virtual void Update()
    {
        Grow();
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //call game manager to
            //1. delete from current list
            //2. write into dead file
            //3. add it to the total amout
            GameManager.instance.DestroyCom(comIndex,dirtAmt,_growAdd,_capacityAdd);
            Destroy(gameObject);
        }
    }

    public virtual void Grow()
    {
        //get the current total fasten speed
        growAdd = GameManager.instance._totalGrowAdd;
        capacityAdd = GameManager.instance._totalCapacityAdd;
        
        //automatically grow
        if(dirtAmt < dirtCapacity + capacityAdd)
        {
            dirtAmt += (dirtGrowSpeed + growAdd) * Time.deltaTime;
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
