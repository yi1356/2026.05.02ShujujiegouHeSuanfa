using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 组合模式
/// </summary>
public class CompositePatern : MonoBehaviour
{
    private void Start()
    {
        client a = new client();
    }
}
//客户端程序
public class client
{
    public client()
    {
     Picture root00 = new Picture("Root");
     Line line01 = new Line("line");
     line01.Draw();

     root00.Add(line01);
     root00.Add(new point("point"));
     root00.Draw();

    }
}


#region 组件（Component）

public abstract class Graphic
{
    protected string _name;
    public Graphic(string name)
    {
        this._name = name;
    }
    public abstract void Draw();
    public abstract void Add(Graphic g);
    public abstract void Remove(Graphic g);
}

#endregion


#region 复合容器(Composite)
public class Picture : Graphic
{

    public List<Graphic> picList = new List<Graphic>();
    public Picture(string name):base(name)
    {

    }
    public override void Add(Graphic g)
    {
        picList.Add(g);
    }

    public override void Draw()
    {
        Debug.Log(_name);
        foreach (var item in picList)
        {
            item.Draw();
        }
    }

    public override void Remove(Graphic g)
    {
        picList.Remove(g);
    }
}
#endregion


#region 叶子（Leaf）
public class Line : Graphic
{
    public Line(string name) : base(name)
    {
        this._name = name;
    }
    public override void Add(Graphic g)
    {
        throw new System.NotImplementedException();
    }

    public override void Draw()
    {
        Debug.Log(_name);
    }

    public override void Remove(Graphic g)
    {
        throw new System.NotImplementedException();
    }
}

public class point : Graphic
{
    public point(string name) : base(name)
    {
        this._name = name;
    }
    public override void Add(Graphic g)
    {
        throw new System.NotImplementedException();
    }

    public override void Draw()
    {
        Debug.Log(_name);
    }

    public override void Remove(Graphic g)
    {
        throw new System.NotImplementedException();
    }
}
public class Circle : Graphic
{
    public Circle(string name) : base(name)
    {
        this._name = name;
    }
    public override void Add(Graphic g)
    {
        throw new System.NotImplementedException();
    }

    public override void Draw()
    {
        Debug.Log(_name);
    }

    public override void Remove(Graphic g)
    {
        throw new System.NotImplementedException();
    }
}
#endregion


