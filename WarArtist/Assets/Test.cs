using System.Collections;
using System.Collections.Generic;
using App.Component;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var component = new RepositoryComponent<AAA, BBB>();
      //  var a = World.CreateComponent<AAA>();
        var a = component.FindAllFromKey(p => p.GetType() == typeof(AAA));
        var x = component.FindValues();
        

        //BBB c = new BBB();
        //Debug.Log("C id:"+c.Id);
        //BBB d = new BBB();
        //Debug.Log("d ID:"+d.Id);
        //component.Set(a,c);
        //component.Set(b,d);

        //var x = component.Get(a);
        //Debug.Log("x ID:"+x.Id);
        //var y = component.Get(b);
        //Debug.Log("x ID:" +y.Id);

        //var o = component.FindValues(p => p.Id=="");
        //o.ForEach(p=>Debug.Log(p.Id));


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

public class AAA:BaseComponent {


}

public class BBB:BaseComponent
{

}