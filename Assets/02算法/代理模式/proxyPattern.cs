using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 代理模式
/// </summary>
public class proxyPattern : MonoBehaviour
{//测试代码
    void Start()
    {
        ProxySunject a = new ProxySunject();
        a.DoWork_01();//通过代理类,简介访问
    }
}
//代理和真正的逻辑类都要继承的接口
interface Subject 
{
    public void DoWork_01();
    public void DoWork_02();
}

//逻辑类
public class RealSubject : Subject
{
    public void DoWork_01()
    {
        Debug.Log("更换轮胎");
    }

    public void DoWork_02()
    {
        Debug.Log("更换方向盘");
    }
}

//代理类(通过它能间接访问 Subject)
public class ProxySunject : Subject
{
    RealSubject sub;
    public ProxySunject()
    {
        sub = new RealSubject();
    }
    public void DoWork_01()
    {
        sub.DoWork_01();
    }

    public void DoWork_02()
    {
        sub.DoWork_02();
    }
}


