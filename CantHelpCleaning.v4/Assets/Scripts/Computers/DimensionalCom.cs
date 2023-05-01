using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionalCom : InnovateCom
{
    [SerializeField] private DisplayGameInfo _displayGameInfo;

    public override void Start()
    {
        base.Start();
        dirtCapacity = _displayGameInfo.totalAmt;
    }
}
