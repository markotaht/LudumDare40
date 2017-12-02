using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector3 _direction;
    public Vector3 _lastdirection;
    public float _velocity;

    PlayerStats playerStats;
    CharacterController controller;


    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
    }


    // Update is called once per frame
    void Update () {

        var _H = Input.GetAxisRaw("Horizontal");
        var _V = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(_H, 0, _V);
        _direction = transform.TransformDirection(_direction);
        _velocity = controller.velocity.magnitude;

        if (_H < 0 || _H > 0 || _V < 0 || _V > 0)
        {
            _lastdirection = controller.velocity;
        }


        _direction *= playerStats._speed;

        controller.Move(_direction * Time.deltaTime);

    }

}
