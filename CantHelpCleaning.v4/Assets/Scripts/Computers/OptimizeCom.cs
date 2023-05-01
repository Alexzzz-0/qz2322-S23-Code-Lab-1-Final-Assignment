using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizeCom : ExpandCom
{
    public override void Start()
    {
        //tell GM to add effect
        GameManager.instance.FastenUpdateSpeed();
        base.Start();
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        //tell GM to delete effect
        if(col.gameObject.tag == "Player")
        {
            GameManager.instance.ReduceUpdateSpeed();
        }
        base.OnTriggerEnter2D(col);
    }
}
