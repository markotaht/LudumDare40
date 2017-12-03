using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingBuff : MonoBehaviour {

    [SerializeField] private Image _buffSprite;
    [SerializeField] private Image _opSprite;

    public void SetSprites(Sprite buff, Sprite op)
    {
        _buffSprite.sprite = buff;
        _opSprite.sprite = op;
    }

    public void Disappear()
    {
        Destroy(gameObject);
    }
}
