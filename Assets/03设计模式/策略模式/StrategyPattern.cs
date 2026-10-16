using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 策略模式
/// </summary>
public class StrategyPattern : MonoBehaviour
{
    //测试程序
    void Start()
    {
        ConcreteStrategyA strA = new ConcreteStrategyA();
        ConcreteStrategyB strB = new ConcreteStrategyB();

        //Context cont = new Context(strA);//策略A实行
        //cont.complete();

        Context cont = new Context(strB);//策略B实行
        cont.complete();
    }
}
//客户端程序
public class Context//通过传入不同策略 来完成目的
{
    Strategy strate;
    public Context(Strategy strategy)
    {
        this.strate = strategy;
    }
    public void complete()
    {
        strate.Func();
    }
}
//策略基类
public abstract class Strategy
{
    public abstract void Func();
}
#region 策略子类


public class ConcreteStrategyA : Strategy
{
    public override void Func()
    {
        Debug.Log("策略A实行");
    }
}
public class ConcreteStrategyB : Strategy
{
    public override void Func()
    {
        Debug.Log("策略B实行");
    }
}
#endregion