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
        if (_lastdirection.x > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
