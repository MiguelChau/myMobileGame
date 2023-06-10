using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFly : PowerUpBase
{
    public float amountHeight = 2;
    public float animationDuration = .1f;
    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;

    protected override void StartPower()
    {
        base.StartPower();
        PlayerController.Instance.ChangeHeight(amountHeight, duration, animationDuration, ease);
        PlayerController.Instance.animatorManager.Play(AnimatorManager.AnimationType.JUMP);

        StartCoroutine(ReturnToRunAnimation());
    }

    private IEnumerator ReturnToRunAnimation()
    {
        yield return new WaitForSeconds(animationDuration);
        PlayerController.Instance.StartToRun();
    }
}

        


