using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SicknessIndicator : MonoBehaviour {

    [SerializeField] private Sprite[] sicnessLevels;
    [SerializeField] private Image image;
    [SerializeField] private int speed = 100;

    private int level = 0;

    public void IncreaseLevel()
    {
        level++;
        image.sprite = sicnessLevels[level];
        StartCoroutine(MoveAndShow());
    }

    public void DecreaseLevel()
    {
        level--;
        image.sprite = sicnessLevels[level];
        StartCoroutine(MoveAndShow());
    }

    IEnumerator MoveAndShow()
    {
        while (image.rectTransform.rect.yMin < 0)
        {
            Debug.Log(image.rectTransform.rect.yMin);
            Vector2 pos = image.rectTransform.position;
            pos.y += speed*Time.deltaTime;
            image.rectTransform.position = pos;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1);

        while (image.rectTransform.rect.top < 284)
        {
            Vector3 pos = image.rectTransform.position;
            pos.y -= speed*Time.deltaTime;
            image.rectTransform.position = pos;
            yield return null;
        }
    }
}
