using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 抽象工厂模式
/// </summary>
/// 
//-----------------简单工厂问题，不能应对不同系列对象的变化
//提供一个接口，让接口负责实现一些列祥光或相互依赖的对象，无需指定他们的具体的类

//测试程序
public class AbstractFactory:MonoBehaviour
{
    private void Start()
    {
        //由此可以看出：能够很方便的 增加其他类型/风格/其他系列的产品【 [不支持拓展增加产品(比如加一个桥产品)；支持增加产品族(比如赛博风格一套产品)]】
        GameManager game1 = new GameManager(new ancientFactory());
        game1.BuildGameFacilities();
        game1.Run();

        GameManager game2 = new GameManager(new modernFactory());
        game2.BuildGameFacilities();
        game2.Run();
    }
}
//客户端程序
public class GameManager
{
    FacilitiesFactory _factory;
    public GameManager(FacilitiesFactory fac)
    {
        this._factory = fac;
    }
    Road road;
    Tunel tunel;
    Building build;
    //客户端程序中 创建设施的功能
    public void BuildGameFacilities()
    {
        road = _factory.CreateRoad();
        build = _factory.CreateBuilding();
        tunel = _factory.CreateTunel();
    }
    //运行游戏
    public void Run()
    {
        Debug.Log(road.Name);
        Debug.Log(tunel.Name);
        Debug.Log(build.Name);
    }
}

//工厂-------------------------
#region 设施工厂基类
public abstract class FacilitiesFactory
{
    public abstract Road CreateRoad();
    public abstract Tunel CreateTunel();
    public abstract Building CreateBuilding();
}
#endregion
#region 古风设施工厂（子类）
public class ancientFactory : FacilitiesFactory
{
    public override Building CreateBuilding()
    {
        return new ancientryBuilding();
    }

    public override Road CreateRoad()
    {
        return new ancientryRoad();
    }

    public override Tunel CreateTunel()
    {
        return new ancientryTunel();
    }
}
#endregion

#region 现代设施工厂（子类）
public class modernFactory : FacilitiesFactory
{
    public override Building CreateBuilding()
    {
        return new modernBuilding();
    }

    public override Road CreateRoad()
    {
        return new modernRoad();
    }

    public override Tunel CreateTunel()
    {
        return new modernTunel();
    }
}
#endregion
//产品-------------------------
#region 产品基类
public abstract class Road
{
    public abstract string Name { get; }
}

public abstract class Tunel
{
    public abstract string Name { get; }
}

public abstract class Building
{
    public abstract string Name { get; }
}
#endregion
#region 古风产品（子类）
public class ancientryRoad : Road
{
    public override string Name => "古风道路";
}
public class ancientryTunel : Tunel
{
    public override string Name => "古风隧道";
}
public class ancientryBuilding : Building
{
    public override string Name => "古风建筑";
}
#endregion

#region 现代产品（子类）
public class modernRoad : Road
{
    public override string Name => "现代道路";
}
public class modernTunel : Tunel
{
    public override string Name => "现代隧道";
}
public class modernBuilding : Building
{
    public override string Name => "现代建筑";
}
#endregion

