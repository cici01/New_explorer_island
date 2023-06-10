using UnityEngine;
using DG.Tweening;

public class UITweenFadeIn : MonoBehaviour
{
    public float m_fDuration = 1f;

    void Start()
    {
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 0f;
        canvasGroup.DOFade(1f, m_fDuration);
    }
}
