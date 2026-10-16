using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//1、具体的命令内容并执行
public class MoveLeft : Command
{
    private GameObject _playerCub;
    public override void Execute(GameObject player)
    {
       _playerCub = player ;
        _playerCub.transform .transform.Translate(Vector3.left);
    }

    public override void Undo()
    {
        _playerCub.transform.transform.Translate(Vector3.right);
    }
}

public class MoveRight : Command
{
    private GameObject _playerCub;
    public override void Execute(GameObject player)
    {
        _playerCub = player;
        _playerCub.transform.transform.Translate(Vector3.right);
    }

    public override void Undo()
    {
        _playerCub.transform.transform.Translate(Vector3.left);
    }
}

public class MoveForward : Command
{
    private GameObject _playerCub;
    public override void Execute(GameObject player)
    {
        _playerCub = player;
        _playerCub.transform.transform.Translate(Vector3.forward);
    }

    public override void Undo()
    {
        _playerCub.transform.transform.Translate(Vector3.back);
    }
}

public class MoveBack : Command
{
    private GameObject _playerCub;
    public override void Execute(GameObject player)
    {
        _playerCub = player;
        _playerCub.transform.transform.Translate(Vector3.back);
    }

    public override void Undo()
    {
        _playerCub.transform.transform.Translate(Vector3.forward);
    }
}
