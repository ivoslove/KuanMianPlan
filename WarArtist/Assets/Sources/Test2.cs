using System.Collections;
using System.Collections.Generic;
using App.Dispatch;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("2S");
        Dispatcher<int>.Listener<int>("123",BBB);
        Debug.Log("2E");

        for (int i = 0; i < 5; i++)
        {
           var a = Dispatcher<int>.DoWork("123",i);
           Debug.Log(a);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int BBB(int a)
    {
        Debug.Log($"执行了{a}次BBB");
        return 999;
    } 
}
