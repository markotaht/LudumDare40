using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] public float _speed;
    [SerializeField] public float _damage;
    [SerializeField] public float _maxhealth;
    private float _health;

    public Image _healthBar;

    public DebuffUIController DC;

    public Image DeathFade;
    public GameObject deathMenu;

    public Text winEndingScore;
    public Text deathEndingScore;

    public Sprite[] _debuffs;
    public Sprite[] _operations;
    public GameObject _popup;
    public Transform _popupTransform;

    public GameObject _damagePopup;

    public GameObject confusionVisual;

    private string _cause;

    private bool alive = true;

    public List<bool> endings = new List<bool>(new bool[10]);
    public int savedEndings = 0;

    //Buffs
    public enum Buff { Slowed, Bleeding, Dysentery, Confusion, Weakness };
    private Dictionary<Buff, int> currentBuffs = new Dictionary<Buff, int>();

    //Counters
    private float bleedingCounter = 0;
    private float bleedingCounterMax = 1;
    private float bleedingTimeoutCounter = 0;
    private float bleedingTimeoutCounterMax = 10;
    private float confusionTimeoutCounter = 0;
    private float confusionTimeoutCounterMax = 3;

    private void Start()
    {
        //Add 0 of ALL buffs
        currentBuffs.Add(Buff.Slowed, 0);
        currentBuffs.Add(Buff.Bleeding, 0);
        currentBuffs.Add(Buff.Dysentery, 0);
        currentBuffs.Add(Buff.Confusion, 0);
        currentBuffs.Add(Buff.Weakness, 0);

        _health = _maxhealth;

        UpdateEndingScore();
    }

    private void Update()
    {
        if (!alive) return;
        //Counters
        bleedingCounter -= Time.deltaTime;
        bleedingTimeoutCounter -= Time.deltaTime;
        confusionTimeoutCounter -= Time.deltaTime;

        //Effects
        if (currentBuffs[Buff.Bleeding] > 0 && bleedingCounter <= 0)
        {
            OnHit(0.1f * currentBuffs[Buff.Bleeding], "bleeding");
            bleedingCounter = bleedingCounterMax;
        }

        //Timeouts
        if (currentBuffs[Buff.Bleeding] > 0 && bleedingTimeoutCounter <= 0)
        {
            RemoveBuff(Buff.Bleeding);
            bleedingTimeoutCounter = bleedingTimeoutCounterMax;
        }
        if (currentBuffs[Buff.Confusion] > 0 && confusionTimeoutCounter <= 0)
        {
            RemoveBuff(Buff.Confusion);
            confusionTimeoutCounter = confusionTimeoutCounterMax;
        }
    }

    public void OnHit(float damage, string cause)
    {
        _cause = cause;
        _health -= damage;
        DamageNumber dn = Instantiate(_damagePopup, _popupTransform).GetComponent<DamageNumber>();
        dn.SetDamageNumber(-damage);
        UpdateHealth();
    }

    public void Heal(float health)
    {
        _health = Mathf.Min(_health + health, _maxhealth);
        DamageNumber dn = Instantiate(_damagePopup, _popupTransform).GetComponent<DamageNumber>();
        dn.SetDamageNumber(health);
    }

    public void AddBuff(Buff buff)
    {
        Debug.Log("Added " + buff);
        currentBuffs[buff] += 1;
        //Only for new buff
        if (currentBuffs[buff] == 1)
        {
            //Add visuals:
            if (buff == Buff.Bleeding)
            {
                //Add bleeding visual
            }
            else if (buff == Buff.Slowed)
            {
                //Add slowed visual
            }
            else if (buff == Buff.Dysentery)
            {
                //Add dysentery visual
            }
            else if (buff == Buff.Confusion)
            {
                FlipControls();
                //Add dysentery visual
                confusionVisual.SetActive(true);
            }
            else if (buff == Buff.Weakness)
            {
                //weakness;
            }
        }
        //For first AND existing buffs
        FloatingBuff popup = Instantiate(_popup, _popupTransform).GetComponent<FloatingBuff>();
        //Notify player & do other stuff
        if (buff == Buff.Bleeding)
        {
            popup.SetSprites(_debuffs[0], _operations[0]);
            bleedingTimeoutCounter = bleedingTimeoutCounterMax;
        }
        else if (buff == Buff.Slowed)
        {
            popup.SetSprites(_debuffs[1], _operations[0]);
        }
        else if (buff == Buff.Dysentery)
        {
            popup.SetSprites(_debuffs[2], _operations[0]);
        }
        else if (buff == Buff.Confusion)
        {
            popup.SetSprites(_debuffs[3], _operations[0]);
            confusionTimeoutCounter = confusionTimeoutCounterMax;
        }
        else if (buff == Buff.Weakness)
        {
            popup.SetSprites(_debuffs[4], _operations[0]);
        }

        //Update stats:
        if (buff == Buff.Slowed && currentBuffs[Buff.Slowed] <= 10)
        {
            _speed *= 0.93f;
        }

        else if (buff == Buff.Weakness && currentBuffs[Buff.Slowed] < 5)
        {
            _damage /= 0.9f;
        }
        //Update UI or whatever
        DC.SetBuff(buff, currentBuffs[buff], true);
    }

    public void RemoveBuff(Buff buff)
    {
        Debug.Log("Removed " + buff);
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
                //Remove slowed visual
            }
            else if (buff == Buff.Dysentery)
            {
                //Remove dysentery visual
            }
            else if (buff == Buff.Confusion)
            {
                //Remove dysentery visual
                FlipControls();
                confusionVisual.SetActive(false);
            }
        }

        FloatingBuff popup = Instantiate(_popup, _popupTransform).GetComponent<FloatingBuff>();
        //Notify player and do stuff
        if (buff == Buff.Bleeding)
        {
            popup.SetSprites(_debuffs[0], _operations[1]);
        }
        else if (buff == Buff.Slowed)
        {
            popup.SetSprites(_debuffs[1], _operations[1]);
        }
        else if (buff == Buff.Dysentery)
        {
            popup.SetSprites(_debuffs[2], _operations[1]);
        }
        else if (buff == Buff.Confusion)
        {
            popup.SetSprites(_debuffs[3], _operations[1]);
        }
        else if (buff == Buff.Weakness)
        {
            popup.SetSprites(_debuffs[4], _operations[1]);
        }

        DC.SetBuff(buff, currentBuffs[buff], false);
        //Update stats:
        if (buff == Buff.Slowed && currentBuffs[Buff.Slowed] < 10)
        {
            _speed /= 0.93f;
        }
        else if (buff == Buff.Weakness && currentBuffs[Buff.Slowed] < 5)
        {
            _damage /= 0.9f;
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
        if (presentBuffs.Count != 0)
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
        if (_healthBar != null)
        {
            _healthBar.fillAmount = _health / _maxhealth;
            if (_health <= 0)
            {
                alive = false;
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
        deathMenu.GetComponentInChildren<Text>().text = DeathMessage();
        deathMenu.SetActive(true);
        UpdateEndingScore();
    }

    private void FlipControls()
    {
        Debug.Log("Confusion flip");
        GameManager.instance.Player.inverted = !GameManager.instance.Player.inverted;
    }

    private string DeathMessage()
    {
        if (_cause == "bleeding")
        {
            endings[0] = true;
            return "Thou has't  bled to death ";
        }
        else if (_cause == "Rat")
        {
            endings[1] = true;
            return "Thee wast killeth by a rat";
        }
        else if (_cause == "Fly")
        {
            endings[2] = true;
            endings[2] = true;
            return "Thee hath kicked the bucket from flyes... ";
        }
        endings[3] = true;
        return "Thee hath kicked the bucket of boredom";
    }

    public bool HasDysentery()
    {
        return currentBuffs[Buff.Dysentery] > 0;
    }

    public void UpdateEndingScore()
    {
        int seenEndings = 0;
        for(int i = 0; i< endings.Count; i++)
        {
            int inPrefs = PlayerPrefs.GetInt(i.ToString());
            if(endings[i] == true && inPrefs == 0)
            {
                PlayerPrefs.SetInt(i.ToString(), 1);
                seenEndings++;
            }
            else if(inPrefs == 1)
            {
                seenEndings++;
            }
        }
        Debug.Log("SeenEndings = " + endings.Where(p => p==true).ToList<bool>().Count + ", inprefs = " + seenEndings);
        savedEndings = seenEndings;
        winEndingScore.text = "Endings seen: " + seenEndings + "/" + endings.Count;
        deathEndingScore.text = "Endings seen: " + seenEndings + "/" + endings.Count;
    }

    public void ColorEndingScore(Color color)
    {
        winEndingScore.color = color;
    }

}
