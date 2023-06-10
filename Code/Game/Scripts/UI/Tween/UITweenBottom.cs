using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweenBottom : MonoBehaviour
{
    public float m_fDuration = 0.5f;

    void Start()
    {
        Vector3 v3EndPosition = transform.localPosition;
        RectTransform rt = transform as RectTransform;
        float fMoveSpace = Mathf.Abs(rt.sizeDelta.y) > Mathf.Epsilon ? rt.sizeDelta.y : 100;
        transform.localPosition = v3EndPosition - new Vector3(0, fMoveSpace, 0);
        transform.DOLocalMove(v3EndPosition, m_fDuration);
    }
}
