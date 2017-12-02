﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] private RoomController _currentRoom;
    [SerializeField] private PlayerController _player;

    public RoomController CurrentRoom
    {
        get
        {
            return _currentRoom;
        }
        set
        {
            _currentRoom = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        instance = this;
    }


    public void DecreaseMobCounter()
    {
        _currentRoom.DecreaseMobCounter(-1);
    }

    public void SetPlayerLocation(Vector3 position)
    {
        _player.transform.position = position + _player._lastdirection.normalized * 0.2f;
    }

}
