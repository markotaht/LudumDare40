using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector3 _direction;
    public Vector3 _lastdirection;
    public float _velocity;
    public float _H;
    public float _V;

    PlayerStats playerStats;
    CharacterController controller;

    public bool inverted = false;

    public bool _attacking;

    private float idleTimer = 0;
    private float idleDeath = 120;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
    }


    // Update is called once per frame
    void Update () {
        idleTimer += Time.deltaTime;
        _H = Input.GetAxisRaw("Horizontal");
        _V = Input.GetAxisRaw("Vertical");


        _direction = new Vector3(_H, _V, 0).normalized;
        if (inverted) _direction *= -1;

        _direction = transform.TransformDirection(_direction);
        _velocity = controller.velocity.magnitude;

        if (_H < 0 || _H > 0 || _V < 0 || _V > 0)
        {
            _lastdirection = controller.velocity.normalized;
            idleTimer = 0;
        }

        _direction *= playerStats._speed;
        controller.Move(_direction * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            _attacking = true;
            Invoke("StopAttack", 0.1f);
            idleTimer = 0;
        }

        if(idleTimer >= idleDeath)
        {
            playerStats.OnHit(10000, "");
        }
    }

    void StopAttack()
    {
        _attacking = false;
    }

}
