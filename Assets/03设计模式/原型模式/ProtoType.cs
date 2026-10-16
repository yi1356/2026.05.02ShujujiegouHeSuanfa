using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoType : MonoBehaviour
{
    private void Start()
    {
        Resum a = new Resum("小明");
        a.SetPersonalInfo("男", "20");
        a.setWorkExperience("2020-2021", "公司A");

        Resum b = (Resum)a.Clone();

        Resum c = (Resum)a.Clone();
        c.SetPersonalInfo("男", "25");
        c.setWorkExperience("1990-2000", "公司c");

        a.Display();
        b.Display();
        c.Display();

    }
}

class WorkExperience : ICloneable
{
    private string workDate;
    public string WorkDate
    {
        set { workDate = value; }
        get { return workDate; }
    }

    private string company;
   public string Company
    {
        set { company = value; }
        get { return company; }
    }

    public object Clone()//继承接口后，需要实现的方法
    {
        return (object)this.MemberwiseClone();//?????
    }
}

class Resum : ICloneable
{
    private string name;
    private string sex;
    private string age;
    private WorkExperience work;

    public Resum(string name)
    {
        this.name = name;
        work = new WorkExperience();
    }
    private Resum(WorkExperience work)//在克隆函数中能用到
    {
        this.work = (WorkExperience)work.Clone();
    }

    public void SetPersonalInfo(string sex,string age)
    {
        this.sex = sex;
        this.age = age;
    }
    public void setWorkExperience(string workData,string company)
    {
        work.WorkDate = workData;
        work.Company = company;
    }
    //打印信息的方法
    public void Display()
    {
        Debug.Log(name+" "+sex+" "+age);
        Debug.Log(work.WorkDate+" "+work.Company);
    }
    public object Clone()//克隆的方法（ 对象执行深层复制操作）
    {
        Resum obj = new Resum(this.work);
        obj.name = this.name;
        obj.sex = this.sex;
        obj.age = this.age;
        return obj;
    }
}
