using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUpInvencible : PowerUpBase
{
    [Header("Invencible")]
    public float invencibleScale = 2f;
    public Ease easeInvencbile = Ease.OutBack;

    protected override void StartPower()
    {
        base.StartPower();
        ScalePlayer(invencibleScale);
        PlayerController.Instance.SetInvencible();
        PlayerController.Instance.animatorManager.Play(AnimatorManager.AnimationType.INVENCIBLE);
        PlayerController.Instance.Bounce();
        PlayerController.Instance.SetTargetScale(invencibleScale);
    }

    protected override void EndPower()
    {
        base.EndPower();
        PlayerController.Instance.SetInvencible(false);
        PlayerController.Instance.StartToRun();
        ScalePlayer(1f);
        PlayerController.Instance.SetTargetScale(1f);
    }

    private void ScalePlayer(float targetScale)
    {
        PlayerController.Instance.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
        PlayerController.Instance.SetTargetScale(invencibleScale);
    }

}
