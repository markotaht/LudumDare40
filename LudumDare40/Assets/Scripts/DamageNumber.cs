using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour {

    [SerializeField] private Text damagenumber;

    public void SetDamageNumber(float number)
    {
        damagenumber.text = number.ToString();
        if(number > 0)
        {

            Debug.Log("before: " + damagenumber.color);
            damagenumber.color = Color.red;
            Debug.Log("after: " + damagenumber.color);
            damagenumber.text = "+" + number.ToString();
        }
    }

    public void Disappear()
    {
        Destroy(gameObject);
    }
}
