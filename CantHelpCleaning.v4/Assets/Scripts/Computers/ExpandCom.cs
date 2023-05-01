using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandCom : GeneralCom
{
    public override void Start()
    {
        //tell GM to add the effect\
        GameManager.instance.AddComCapacity();
        base.Start();
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //tell GM to delete the effect
            GameManager.instance.CutComCapacity();
        }
        base.OnTriggerEnter2D(col);
    }
}
