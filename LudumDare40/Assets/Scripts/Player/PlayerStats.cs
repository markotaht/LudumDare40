using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    [SerializeField] public float _speed;
    [SerializeField] public float _damage;
    [SerializeField] public float _maxhealth;
    private float _health;

    public Image _healthBar;

    public DebuffUIController DC;

    //Buffs
    public enum Buff { Slowed, Bleeding };
    private Dictionary<Buff, int> currentBuffs = new Dictionary<Buff, int>();

    //Counters
    private float bleedingCounter = 0;

    private void Start()
    {
        //Add 0 of ALL buffs
        currentBuffs.Add(Buff.Slowed, 0);
        currentBuffs.Add(Buff.Bleeding, 0);

        _health = _maxhealth;
    }

    private void Update()
    {
        //Counters
        bleedingCounter -= Time.deltaTime;

        //Effects
        if(currentBuffs[Buff.Bleeding] > 0 && bleedingCounter <= 0)
        {
            _health -= 0.1f * currentBuffs[Buff.Bleeding];
            UpdateHealth();
            bleedingCounter = 1;
        }
    }

    public void OnHit(float damage)
    {
        _health -= damage;
        UpdateHealth();
        Debug.Log("Hit, health=" + _health);
    }

    public void AddBuff(Buff buff)
    {
        Debug.Log("Added " + buff);
        currentBuffs[buff] += 1;
        if(currentBuffs[buff] == 1)
        {
            //Add visuals:
            if(buff == Buff.Bleeding)
            {
                //Add bleeding visual
            }
            else if(buff == Buff.Slowed)
            {
                //Add poisoned visual
            }
        }

        DC.SetBuff(buff, currentBuffs[buff]);
        //Update stats:
        if(buff == Buff.Slowed)
        {
            _speed *= 0.75f;
        }
        //Update UI or whatever
    }

    public void RemoveBuff(Buff buff)
    {
        currentBuffs[buff] -= 1;
        if (currentBuffs[buff] == 0)
        {
            //Remove visuals:
            if (buff == Buff.Bleeding)
            {
                //Remove bleeding visual
            }
            else if (buff == Buff.Slowed)
            {
                //Remove poisoned visual
            }
        }
        DC.SetBuff(buff, currentBuffs[buff]);
        //Update stats:
        if (buff == Buff.Slowed)
        {
            _speed /= 0.75f;
        }
        //Update UI or whatever
    }

    private void UpdateHealth()
    {
        if(_healthBar != null)
        {
            _healthBar.fillAmount = _health / _maxhealth;
        }
    }
}
