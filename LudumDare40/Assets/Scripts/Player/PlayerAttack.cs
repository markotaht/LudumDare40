using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject front;
    public GameObject left;
    public GameObject right;
    public GameObject down;
    public PlayerController player;

    void Start()
    {
        DisableTriggers();
    }

    public void AttackFront()
    {
        front.SetActive(true);
        Debug.Log("Front");
        Invoke("DisableTriggers", 0.1f);
    }

    public void AttackBack()
    {
        down.SetActive(true);
        Debug.Log("Back");
        Invoke("DisableTriggers", 0.1f);
    }

    public void AttackSide()
    {
        if(player._lastdirection.x == 1)
        {
            right.SetActive(true);
            Debug.Log("Attacking right");
            Invoke("DisableTriggers", 0.1f);
        } else {
            left.SetActive(true);
            Debug.Log("Attacking left");
            Invoke("DisableTriggers", 0.1f);
        }
    }

    void DisableTriggers()
    {
        front.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        down.SetActive(false);
    }



}
