
using System;
using App.Dispatch;
using UnityEngine;


public class Test : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("1S");
       // Dispatcher<int>.Listener<int>("123", AAA);
        Debug.Log("1E");

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private int AAA(int a)
    {
        Debug.Log($"执行了{a}次AAA");
        return 888;
    }
}
