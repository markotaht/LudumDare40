using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitch : MonoBehaviour {

	[SerializeField] private RoomController nextRoom;
    [SerializeField] private RoomController currentRoom;

    public RoomController NextRoom
    {
        get
        {
            return nextRoom;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currentRoom.Unload();
            nextRoom.Load(currentRoom);
        }
    }
}
