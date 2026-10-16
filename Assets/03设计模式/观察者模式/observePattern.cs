using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class observePattern : MonoBehaviour
{
   //测试代码
    void Start()
    {
        Observer01 a = new Observer01("观察者1");
        Observer02 b = new Observer02("观察者2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Player.isDeath = true;
        }
        if (Player.isDeath&& Player.playereve!=null)
        {
            Player.playereve.Invoke();//检测到玩家死亡后，执行委托
            Player.playereve = null;
        }
    }
}
#region 观察者


//观察者需要继承 的接口
public interface Observer 
{
    public void DeadFunc();
}
public class Observer01 : Observer
{
    private string _name;
    public Observer01(string name)
    {
        this._name = name;
        Player.Add(this);
    }
    public void DeadFunc()
    {
        Debug.Log(_name+"观察到了玩家死亡");
    }
}
//观察者1
public class Observer02 : Observer
{
    private string _name;
    public Observer02(string name)
    {
        this._name = name;
        Player.Add(this);
    }
    public void DeadFunc()
    {
        Debug.Log(_name + "观察到了玩家死亡");
    }
}
#endregion
#region 玩家类
public class Player 
{
    public static bool isDeath=false;
    public static Action playereve ;//玩家死亡的事件
    public static void Add(Observer ob)
    {
        playereve += ob.DeadFunc;
    }
    public static void Remove(Observer ob)
    {
        playereve -= ob.DeadFunc;
    }
}
#endregion



