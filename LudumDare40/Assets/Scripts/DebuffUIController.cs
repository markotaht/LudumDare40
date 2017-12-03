using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuffUIController : MonoBehaviour {

    [SerializeField] GameObject BuffImagePrefab;
    private Dictionary<PlayerStats.Buff, GameObject> _debuffs = new Dictionary<PlayerStats.Buff, GameObject>();
    private Dictionary<PlayerStats.Buff, Sprite> _sprites = new Dictionary<PlayerStats.Buff, Sprite>();
    public List<Sprite> buffPics;

    private void Start()
    {
        _sprites.Add(PlayerStats.Buff.Bleeding, buffPics[0]);
        _sprites.Add(PlayerStats.Buff.Slowed, buffPics[1]);
        _sprites.Add(PlayerStats.Buff.Dysentery, buffPics[2]);
    }
    public void SetBuff(PlayerStats.Buff debuff, int count, bool increase)
    {
        GameObject go;
        if (_debuffs.ContainsKey(debuff))
        {
            go = _debuffs[debuff];          
        }
        else
        {
            go = Instantiate(BuffImagePrefab,transform);
            _debuffs.Add(debuff, go);
        }

        if(count == 0)
        {
            StartCoroutine(BuffRemoveEffect(go.GetComponent<Image>(), true, debuff));
            return;
        }
        if(increase) StartCoroutine(BuffAddEffect(go.GetComponent<Image>()));
        else StartCoroutine(BuffRemoveEffect(go.GetComponent<Image>(), false, debuff));
        Image _image = go.GetComponent<Image>();
        _image.sprite = _sprites[debuff];
        Text _count = go.GetComponentInChildren<Text>();
        _count.text = count.ToString();
    }
    
    public IEnumerator BuffAddEffect(Image img)
    {
        img.color = Color.red;
        float tParam = 0;
        float speed = 2f;
        while (tParam < 1)
        {
            tParam += Time.deltaTime * speed;
            img.color = Color.Lerp(Color.red, Color.white, tParam);
            yield return null;
        }

    }
    public IEnumerator BuffRemoveEffect(Image img, bool destroy, PlayerStats.Buff buffToDestroy)
    {
        img.color = Color.green;
        float tParam = 0;
        float speed = 2f;
        while (tParam < 1)
        {
            tParam += Time.deltaTime * speed;
            img.color = Color.Lerp(Color.green, Color.white, tParam);
            yield return null;
        }
        if (destroy)
        {
            _debuffs.Remove(buffToDestroy);
            Destroy(img.gameObject);
        }

    }
}
