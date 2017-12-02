using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	[SerializeField] private RoomController nextRoom;
    [SerializeField] private RoomController currentRoom;

    private bool active = false;

    public RoomController NextRoom
    {
        get
        {
            return nextRoom;
        }
    }

    public void OpenDoor()
    {
        active = true;
        //Muuda ukse pilti/ava uks vms
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && active)
        {
            currentRoom.Unload();
            nextRoom.Load(currentRoom);
        }
    }
}
