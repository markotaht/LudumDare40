using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractAI : MonoBehaviour {

    public GameObject _player;
    public GameObject bloodeffect;
    public float _speed;
    public float _damage;
    public float _range;
    public float _maxhealth;
    public float _health;
    public List<GameObject> drops;

    [SerializeField] private SpriteRenderer _sprite;

    protected float cd = 1;
    protected float cdCounter = 0;

    [SerializeField] private EnemyHealthbar _hpBar;


    // Use this for initialization
    void Start () {
        _health = _maxhealth;
	}

    private void OnEnable()
    {
        _health = _maxhealth;
    }

    // Update is called once per frame
    void Update () {

        if (Vector3.Distance(transform.position, _player.transform.position) > _range)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            //Trigger attack animation
            if (cdCounter <= 0)
            {
                Attack();
                cdCounter = cd;
            }
            else
            {
                cdCounter -= Time.deltaTime;
            }
        }
    }

    public void OnHit(float damage)
    {
        Instantiate(bloodeffect, transform.position, Quaternion.identity);
        _health -= damage;
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        _hpBar.UpdateFillAmount(_health / _maxhealth);
        if(_health <= 0)
        {
            Die();
        }
    }

    private void Die() {
        GameManager.instance.DecreaseMobCounter();
        if(drops.Count != 0)
        {
            if (Random.Range(0, 100) < 50)
            {
                System.Random r = new System.Random();
                var drop = Instantiate(drops[r.Next(drops.Count)], transform.position, Quaternion.Euler(0, 0, 0));
            }
        }
        Destroy(gameObject);
    }

    public abstract void Attack();

}
