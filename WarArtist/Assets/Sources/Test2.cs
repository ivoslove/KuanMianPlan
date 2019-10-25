using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Component;
using App.Dispatch;
using App.UI;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Task<int> BBB(int a)
    {
        return Task.Delay(TimeSpan.FromSeconds(10)).ContinueWith(t => 10);
    } 
}
