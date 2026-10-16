using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWeightPattern : MonoBehaviour
{
    private void Start()
    {
        FlyWeightFactory FlyWeightFactory = new FlyWeightFactory();

        FlyWeight FlyWeight1 = FlyWeightFactory.GetFlyWeight("MyFlyWeight");
        FlyWeight1.Operate();

        FlyWeight FlyWeight2 = FlyWeightFactory.GetFlyWeight("MyFlyWeight");
        FlyWeight2.Operate();

        FlyWeight FlyWeight3 = FlyWeightFactory.GetFlyWeight("YourFlyWeight");
        FlyWeight3.Operate();

        FlyWeight FlyWeight4 = FlyWeightFactory.GetFlyWeight("YourFlyWeight");
        FlyWeight4.Operate();

        FlyWeightFactory.ShowAllFlyWeights();
    }
}
/// <summary>
/// 享元抽象类
/// </summary>
public abstract class FlyWeight
{
    //享元模式的内部状态可以共享，但不会随环境的变化而变化。
    //外部状态不可以共享，但会随环境的变化而变化。这里说的是外部状态具有固化特性，即固有化的性质，不应该随【内部状态】的改变而改变，否则会导致系统的逻辑混乱

    //内部状态
    public string mInside;
    //外部状态
    protected string mOutside;
    public string Outside { get { return mOutside; } set { mOutside = Outside; } }

    public FlyWeight(string outside)
    {
        mOutside = outside;
    }

    public abstract void Operate();
}
/// <summary>
/// 具体的享元类
/// </summary>
public class ConcreteFlyWeight : FlyWeight
{
    public ConcreteFlyWeight(string outside): base(outside)
    { }

    public override void Operate()
    {
        Debug.Log("外部状态：" + mOutside);
    }
}

/// <summary>
/// 享元工厂
/// </summary>
public class FlyWeightFactory
{
    private Dictionary<string, FlyWeight> mFlyWeightDict;

    public FlyWeightFactory()
    {
        mFlyWeightDict = new Dictionary<string, FlyWeight>();
    }

    /// <summary>
    /// 获取FlyWeight
    /// </summary>
    public FlyWeight GetFlyWeight(string name)
    {
        if (mFlyWeightDict.ContainsKey(name))
        {
            Debug.Log(name + "：已经存在字典中，直接返回");
            return mFlyWeightDict[name];
        }
        FlyWeight FlyWeight = new ConcreteFlyWeight(name);
        mFlyWeightDict.Add(name, FlyWeight);
        Debug.Log(name + "：不存在字典中，加入字典再返回");
        return FlyWeight;
    }

    public void ShowAllFlyWeights()
    {
        foreach (FlyWeight item in mFlyWeightDict.Values)
        {
            Debug.Log("FlyWeight：" + item.Outside);
        }
    }
}


