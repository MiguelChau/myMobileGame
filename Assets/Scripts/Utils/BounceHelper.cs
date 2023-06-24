using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleBounce = 1.2f;
    public Ease easeBounce = Ease.OutBack;

    private Tweener bounceTweener = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Bounce();
        }

    }
    public void Bounce(float? targetScale = null)
    {
        if( bounceTweener != null)
        {
            bounceTweener.Kill();
        }
        transform.localScale = targetScale.HasValue ? targetScale.Value * Vector3.one : Vector3.one;
        transform.DOScale(scaleBounce, scaleDuration).SetEase(easeBounce).SetLoops(2, LoopType.Yoyo);
    }

}