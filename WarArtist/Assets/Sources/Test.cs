
using System;
using App.Component;
using App.Dispatch;
using App.UI;
using UnityEngine;


public class Test : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       UIComponent ui = new UIComponent();
       ui.SyncOpenView<StartView>();
    
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
