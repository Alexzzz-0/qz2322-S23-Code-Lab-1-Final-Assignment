using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnovateCom : OptimizeCom
{
    public override void Start()
    {
        //tell GM to add effect
        GameManager.instance.AddEvlvPossibility();
        base.Start();
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        //tell GM to delete effect
        if (col.gameObject.tag == "Player")
        {
            GameManager.instance.ReduceEvlvPossibility();
        }
        base.OnTriggerEnter2D(col);
    }
}
