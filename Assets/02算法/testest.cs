using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //int[] a = new int[] {0,1,2,3,4,5,6 };
        //int[] b = a;
        //a[1] = 1000;
        wwww a = new wwww(100);
        wwww c = new wwww(3000);
        wwww b = a;
      
        b.value = 200;
        print(a.value);//200
       print(b.value);//200
//*****************************************
        b = c;
        print(a.value);//200
        print(b.value);//3000
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
class wwww
{
    public int value;
    public wwww(int value)
    {
        this.value = value;
    }

}
