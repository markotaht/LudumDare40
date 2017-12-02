using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoomController : MonoBehaviour {

    [SerializeField] private Door[] doors;

    [SerializeField] private int MobCount = 6;

    [SerializeField] private int roomId = 1;

    public void Load(RoomController previousRoom) {
        Vector3 playerPosition;
        foreach(Door s in doors)
        {
            if(s.NextRoom == previousRoom) {
                playerPosition = s.transform.position;
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
        MobCount -= dif;
        if(MobCount == 0)
        {
            foreach (Door d in doors)
            {
                d.OpenDoor();
            }
        }
    }
}
