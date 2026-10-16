using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{//1¡¢·¢³öÃüÁî
    private readonly MoveForward _moveForward = new MoveForward();
    private readonly MoveBack _moveBack = new MoveBack();
    private readonly MoveLeft _moveLeft = new MoveLeft();
    private readonly MoveRight _moveRight = new MoveRight();

    private GameObject _playerCub;
    private KeyCode[] _keyCodes;
    void Start()
    {
        _playerCub = GameObject.Find("Player");
        _keyCodes = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    }
    void Update()
    {
        playerInputHandler();
    }
    private void playerInputHandler()
    {
        if (Input.GetKeyDown(_keyCodes[0]))
        {
            _moveForward.Execute(_playerCub);
            CommandManager.Instance.AddCommands(_moveForward);

        }
        if (Input.GetKeyDown(_keyCodes[1]))
        {
            _moveLeft.Execute(_playerCub);
            CommandManager.Instance.AddCommands(_moveLeft);

        }
        if (Input.GetKeyDown(_keyCodes[2]))
        {
            _moveBack.Execute(_playerCub);
            CommandManager.Instance.AddCommands(_moveBack);

        }
        if (Input.GetKeyDown(_keyCodes[3]))
        {
            _moveRight.Execute(_playerCub);
            CommandManager.Instance.AddCommands(_moveRight);

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(CommandManager.Instance.undoStart());

        }
        //if (Input.GetKeyDown(KeyCode.W)) MoveForward();
        //if (Input.GetKeyDown(KeyCode.A)) MoveLeft();
        //if (Input.GetKeyDown(KeyCode.S)) MoveBack();
        //if (Input.GetKeyDown(KeyCode.D)) MoveRight();
    }

   
}
