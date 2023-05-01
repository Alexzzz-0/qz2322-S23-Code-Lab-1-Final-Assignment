using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionalCom : InnovateCom
{

    public override void Start()
    {
        base.Start();
        dirtCapacity = GameManager.instance.totalAmt;
    }
}
