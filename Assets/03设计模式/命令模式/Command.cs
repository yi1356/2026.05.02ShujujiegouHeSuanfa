using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 命令基类
/// </summary>
public abstract class Command 
{
    //1、执行和撤回的方法
    public abstract void Execute(GameObject player);
    public abstract void Undo();
}
