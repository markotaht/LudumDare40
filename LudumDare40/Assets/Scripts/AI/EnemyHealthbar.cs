using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour {

    GameObject enemy;
    AbstractAI enemyData;
    Image healthbar;

	void Start () {
        enemy = transform.parent.gameObject.transform.parent.gameObject;
        healthbar = transform.GetComponent<Image>();
	}

	void Update () {
        healthbar.fillAmount = enemy.GetComponent<AbstractAI>()._health/ 100;
	}
}
