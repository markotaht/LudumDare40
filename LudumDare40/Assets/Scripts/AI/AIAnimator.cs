using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimator : MonoBehaviour {

    Rigidbody rb;
    Vector3 _lastdirection;
    SpriteRenderer enemySprite;

    void Start()
    {
        rb = transform.parent.transform.parent.GetComponent<Rigidbody>();
        enemySprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _lastdirection = rb.velocity.normalized;
        //Debug.Log(_lastdirection);
        enemySprite.flipX = getDirection();
    }

    bool getDirection()
    {
        if (transform.position.x < GameManager.instance.Player.transform.position.x)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
