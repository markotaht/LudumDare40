using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoomController : MonoBehaviour {

    [SerializeField] private Door[] doors;

    [SerializeField] private int MobCount = 6;

    [SerializeField] public int roomId = 1;

    private void Start()
    {
        if(MobCount == 0)
        {
            DecreaseMobCounter(0);
        }
    }

    public void Load(RoomController previousRoom) {

        foreach(Door s in doors)
        {
            if(s.NextRoom.roomId == previousRoom.roomId) {
                GameManager.instance.SetPlayerLocation(s.transform.position);
                break;
            }
        }
        gameObject.SetActive(true);
        GameManager.instance.CurrentRoom = this;
    }

    public void Unload() {
        gameObject.SetActive(false);
    }

    public void DecreaseMobCounter(int dif)
    {
        MobCount += dif;
        Debug.Log(MobCount);
        if(MobCount == 0)
        {
            foreach (Door d in doors)
            {
                d.OpenDoor();
            }
        }
    }
}
