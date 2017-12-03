using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerStats : MonoBehaviour {

    [SerializeField] public float _speed;
    [SerializeField] public float _damage;
    [SerializeField] public float _maxhealth;
    private float _health;

    public Image _healthBar;

    public DebuffUIController DC;

    public Image DeathFade;
    public GameObject deathMenu;

    public Sprite[] _debuffs;
    public Sprite[] _operations;
    public GameObject _popup;
    public Transform _popupTransform;

    public GameObject _damagePopup;

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
        DamageNumber dn = Instantiate(_damagePopup, _popupTransform).GetComponent<DamageNumber>();
        dn.SetDamageNumber(-damage);
        UpdateHealth();
    }

    public void AddBuff(Buff buff)
    {
        Debug.Log("Added " + buff);
        currentBuffs[buff] += 1;
        if(currentBuffs[buff] == 1)
        {
            FloatingBuff popup = Instantiate(_popup, _popupTransform).GetComponent<FloatingBuff>();
            //Add visuals:
            if(buff == Buff.Bleeding)
            {
                //Add bleeding visual
                popup.SetSprites(_debuffs[0], _operations[0]);
            }
            else if(buff == Buff.Slowed)
            {
                popup.SetSprites(_debuffs[1], _operations[0]);
                //Add poisoned visual
            }
        }

        DC.SetBuff(buff, currentBuffs[buff], true);
        //Update stats:
        if(buff == Buff.Slowed && currentBuffs[Buff.Slowed] <= 10)
        {
            _speed *= 0.93f;
        }
        //Update UI or whatever
    }

    public void RemoveBuff(Buff buff)
    {
        Debug.Log("Removed " + buff);
        currentBuffs[buff] -= 1;
        if (currentBuffs[buff] == 0)
        {
            FloatingBuff popup = Instantiate(_popup, _popupTransform).GetComponent<FloatingBuff>();
            //Remove visuals:
            if (buff == Buff.Bleeding)
            {
                //Remove bleeding visual
                popup.SetSprites(_debuffs[0], _operations[1]);
            }
            else if (buff == Buff.Slowed)
            {
                //Remove poisoned visual
                popup.SetSprites(_debuffs[1], _operations[1]);
            }
        }
        DC.SetBuff(buff, currentBuffs[buff], false);
        //Update stats:
        if (buff == Buff.Slowed && currentBuffs[Buff.Slowed] < 10)
        {
            _speed /= 0.93f;
        }
        //Update UI or whatever
    }

    public void AddRandomBuff()
    {
        AddBuff((Buff)Random.Range(0, currentBuffs.Count));
    }

    public void RemoveRandomBuff()
    {
        System.Random r = new System.Random();
        List<Buff> presentBuffs = currentBuffs.Where(p => p.Value > 0).Select(p => p.Key).ToList();
        if(presentBuffs.Count != 0)
        {
            RemoveBuff(presentBuffs[r.Next(presentBuffs.Count)]);
        }
        else
        {
            Debug.Log("Nothing happened");
        }
    }

    private void UpdateHealth()
    {
        if(_healthBar != null)
        {
            _healthBar.fillAmount = _health / _maxhealth;
            if(_health <= 0)
            {
                StartCoroutine(DeathScreen());
            }
        }
    }

    public IEnumerator DeathScreen()
    {
        DeathFade.gameObject.SetActive(true);
        while (DeathFade.color.a < 0.99)
        {
            DeathFade.color = Color.Lerp(DeathFade.color, Color.black, 1f * Time.deltaTime);
            yield return null;
        }
        deathMenu.SetActive(true);
    }
}
