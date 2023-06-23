using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUpSuperSpeed : PowerUpBase
{
    [Header("Speed")]
    public float amountSpeed;
    public float scale = 0.5f;
    public Ease easeSpeed = Ease.OutBack;

    protected override void StartPower()
    {
        base.StartPower();
        ScalePlayer(scale);
        PlayerController.Instance.PowerUpSpeedUp(amountSpeed);
        PlayerController.Instance.Bounce();
    }

    protected override void EndPower()
    {
        base.EndPower();
        PlayerController.Instance.ResetSpeed();
        ScalePlayer(1f);
    }

    private void ScalePlayer(float targetScale)
    {
        PlayerController.Instance.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
    }
}
