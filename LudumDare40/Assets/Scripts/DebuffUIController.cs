using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuffUIController : MonoBehaviour {

    [SerializeField] GameObject BuffImagePrefab;
    private Dictionary<PlayerStats.Buff, GameObject> _debuffs = new Dictionary<PlayerStats.Buff, GameObject>();

    public void SetBuff(PlayerStats.Buff debuff, int count)
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
            _debuffs.Remove(debuff);
            Destroy(go);
            return;
        }
        Text _count = go.GetComponentInChildren<Text>();
        _count.text = count.ToString();
    }
}
