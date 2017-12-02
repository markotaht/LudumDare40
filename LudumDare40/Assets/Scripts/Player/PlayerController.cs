using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector3 _direction;
    public Vector3 _lastdirection;
    public float _velocity;

    PlayerStats playerStats;
    CharacterController controller;

    public bool _attacking;


    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
    }


    // Update is called once per frame
    void Update () {

        var _H = Input.GetAxisRaw("Horizontal");
        var _V = Input.GetAxisRaw("Vertical");

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(0f, 0f, 0f), transform.position.z);

        _direction = new Vector3(_H, 0, _V).normalized;
        _direction = transform.TransformDirection(_direction);
        _direction.y = Mathf.Clamp(0.0f, 0.0f, 0.0f);
        _velocity = controller.velocity.magnitude;

        if (_H < 0 || _H > 0 || _V < 0 || _V > 0)
        {
            _lastdirection = controller.velocity.normalized;
        }

        _direction *= playerStats._speed;

        controller.Move(_direction * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            Attack(playerStats._damage);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Stopping");
            _attacking = false;
        }

    }

    void Attack(float damage)
    {
        _attacking = true;
        Debug.DrawRay(transform.position, _lastdirection, Color.black);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _lastdirection, out hit)){
            if(hit.transform.gameObject.GetComponent<AbstractAI>() != null && hit.distance < 0.5f)
            {
                Debug.Log("Hitting enemy");
                GameObject enemy_hit = hit.transform.gameObject;
                enemy_hit.GetComponent<AbstractAI>().OnHit(damage);
            } else {
                Debug.Log(hit.transform.gameObject);
            }
        }
    }

}
