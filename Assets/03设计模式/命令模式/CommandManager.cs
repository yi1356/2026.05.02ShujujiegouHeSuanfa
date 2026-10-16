using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 命令管理器
/// </summary>
public class CommandManager
{
    //1、向列表中添加命令
    //2、撤回命令
    private readonly List<Command> _commandList = new List<Command>();
    private static CommandManager instance;
    public static CommandManager Instance
    {
        get
        { 
            if(instance==null) { instance = new CommandManager(); }
            return instance;
        }
    }

    public void AddCommands(Command command)
    { _commandList.Add(command); }

    public IEnumerator undoStart()
    {
        _commandList.Reverse();
        foreach (Command command in _commandList)
        {
            command.Undo();
            yield return new WaitForSeconds(0.2f);
        }
        _commandList.Clear();
    }

}
