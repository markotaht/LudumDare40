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
        Invoke("DisableTriggers", 0.1f);
    }

    public void AttackBack()
    {
        down.SetActive(true);
        Invoke("DisableTriggers", 0.1f);
    }

    public void AttackSide()
    {
        if(player._direction.x == 1)
        {
            right.SetActive(true);
            Invoke("DisableTriggers", 0.1f);
        } else {
            left.SetActive(true);
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
