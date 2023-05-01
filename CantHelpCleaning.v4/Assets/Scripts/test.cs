using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class test : MonoBehaviour
{
    private List<int> test0 = new List<int>();
    private int count = 0;

    [SerializeField] private GameObject _image;
    [SerializeField] private GameObject canvas;
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

        GameObject _test = Instantiate(_image);
        _test.transform.parent = canvas.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
