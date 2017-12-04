using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SicknessIndicator : MonoBehaviour {

    [SerializeField] private Sprite[] sicnessLevels;
    [SerializeField] private Image image;
    [SerializeField] private int speed = 100;

    [SerializeField] private Animator animator;

    private int level = -1;

    public void IncreaseLevel()
    {
        level++;
        image.sprite = sicnessLevels[level];
        animator.SetTrigger("Play");
    }

    public void DecreaseLevel()
    {
        level--;
        image.sprite = sicnessLevels[level];
        animator.SetTrigger("Play");
    }

    
}
