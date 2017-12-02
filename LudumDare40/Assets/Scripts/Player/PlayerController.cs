using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Vector3 _direction;

    PlayerStats playerStats;
    CharacterController controller;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update () {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _direction = transform.TransformDirection(_direction);
        _direction *= playerStats._speed;

        controller.Move(_direction * Time.deltaTime);
    }
}
