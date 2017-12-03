using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour {

    [SerializeField] private AbstractAI enemy;
    [SerializeField] private Image healthbar;

    public void UpdateFillAmount(float amount)
    {
        healthbar.fillAmount = amount;
    }
}
