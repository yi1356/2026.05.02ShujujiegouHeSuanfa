using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 静态单例模式
/// </summary>
/// <typeparam name="T"></typeparam>
public class Thread_Singleton
{
private Thread_Singleton() { }
private static Thread_Singleton instance;
//多线程需要加一把锁；
private static  object obj = new object();
public static Thread_Singleton Instance
{
    get
    {
       if (instance==null)
       {
         lock (obj)//上锁
         {
           if (instance == null)
           {
               instance = new Thread_Singleton();
           }
         }
       }
       return instance;
    }
}
}
