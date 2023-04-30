using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private List<int> test0 = new List<int>();
    private int count = 0;
    void Start()
    {
        test0.Add(1);
        test0.Add(2);
        test0.Add(3);
        test0.RemoveAt(1);
        foreach (var num in test0)
        {
            count += 1;
            Debug.Log(count.ToString() + num.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
