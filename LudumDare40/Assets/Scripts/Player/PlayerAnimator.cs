using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    PlayerController playerControl;
    Animator playerAnimation;
    SpriteRenderer playerSprite;

	// Update is called once per frame
	void Start () {
        playerControl = transform.parent.GetComponent<PlayerController>();
        playerAnimation = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        playerAnimation.SetFloat("XSpeed", playerControl._direction.x);
        playerAnimation.SetFloat("YSpeed", playerControl._direction.z);

        playerSprite.flipX = getDirection();

        playerAnimation.SetBool("isAttacking", isAttacking());

        if(playerControl._velocity > 0)
        {
            playerAnimation.SetBool("isMoving", true);
            playerAnimation.SetFloat("LastX", playerControl._lastdirection.x);
            playerAnimation.SetFloat("LastY", playerControl._lastdirection.z);
        } else {
            playerAnimation.SetBool("isMoving", false);
        }

    }

    bool getDirection()
    {
        if(playerControl._lastdirection.x > 0)
        {
            return true;
        } else {
            return false;
        }
    }

    bool isAttacking()
    {
        return playerControl._attacking;
    }

}
