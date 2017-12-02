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

        if(playerControl._velocity > 0)
        {
            playerAnimation.SetBool("isMoving", true);
        } else {
            playerAnimation.SetBool("isMoving", false);
        }

    }

    bool getDirection()
    {
        if(playerControl._direction.x > 0)
        {
            return true;
        } else {
            return false;
        }
    }

}
