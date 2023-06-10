using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweenComeOut : MonoBehaviour
{
    void Start()
    {
        transform.localScale = Vector3.zero;
        Tweener twScale1 = transform.DOScale(1.1f, 0.26f);
        Tweener twScale2 = transform.DOScale(1f, 0.04f);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(twScale1);
        sequence.Append(twScale2);
    }
}
