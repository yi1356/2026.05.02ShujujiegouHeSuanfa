using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 工厂方法模式
/// </summary>
//测试程序
public class FactoryFunc:MonoBehaviour
{
    private void Start()
    {
        //由此可以看出:抽象工程模式  和  工厂方法的区别

        //简单工厂：不能应对不同系列对象的变化
        //抽象工厂模式：需要生产一系列 可能不同风格的 的产品
        //工厂方法：只需要通过工厂创建一种产品（车）
        carTest game1 = new carTest(new HongqiFactory());
        game1.createcar();
        game1.Run();

        carTest game2 = new carTest(new TsFactory());
        game2.createcar();
        game2.Run();

    }
}
//客户端程序
public class carTest
{
    CarFactory _factory;
    AbstractCar car;
    public carTest(CarFactory fac)
    {
        this._factory = fac;
    }
    //创建汽车
    public void createcar()
    {
        car = _factory.CreateCar();
    }
    //运行汽车
    public void Run()
    {
        car.StartUp();
        car.Run();
        car.Stop();
    }
}

//汽车工厂-------------------------
#region 汽车工厂基类
public abstract class CarFactory
{
    public abstract AbstractCar CreateCar();
}
#endregion
#region 红旗汽车工厂(子类)
public class HongqiFactory : CarFactory
{
    public override AbstractCar CreateCar()
    {
        return new HongQiCar();
    }
}
#endregion
#region 特斯拉汽车工厂(子类)
public class TsFactory : CarFactory
{
    public override AbstractCar CreateCar()
    {
        return new TsCar();
    }
}
#endregion

//汽车产品-------------------------
#region 汽车产品基类
public abstract class AbstractCar
{
    public abstract string Name { get; }
    public abstract void StartUp();
    public abstract void Run();
    public abstract void Stop();

}
#endregion
#region 红旗汽车（子类）
public class HongQiCar : AbstractCar
{
    public override string Name => "红旗汽车";

    public override void Run()
    {
        Debug.Log(Name + "红旗运行");
    }

    public override void StartUp()
    {
        Debug.Log(Name + "红旗启动");
    }

    public override void Stop()
    {
        Debug.Log(Name + "红旗停止");
    }
}
#endregion
#region 特斯拉汽车（子类）
public class TsCar : AbstractCar
{
    public override string Name => "特斯拉汽车";

    public override void Run()
    {
        Debug.Log(Name + "特斯拉运行");
    }

    public override void StartUp()
    {
        Debug.Log(Name + "特斯拉启动");
    }

    public override void Stop()
    {
        Debug.Log(Name + "特斯拉停止");
    }
}
#endregion


