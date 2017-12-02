using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour {

    [SerializeField] private RoomSwitch[] doors;
	// Use this for initialization
	void Start () {
		
	}
	

    public void Load(RoomController previousRoom) {
        Vector3 playerPosition;
        foreach(RoomSwitch s in doors)
        {
            if(s.NextRoom == previousRoom) {
                playerPosition = s.transform.position;
                break;
            }
        }
        gameObject.SetActive(true);
    }

    public void Unload() {
        gameObject.SetActive(false);
    }
}
