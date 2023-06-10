using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase
{
    protected override void StartPower()
    {
        base.StartPower();
        PlayerController.Instance.SetInvencible();
        PlayerController.Instance.ChangePlayerColor(Color.white);
        PlayerController.Instance.animatorManager.Play(AnimatorManager.AnimationType.INVENCIBLE);
    }

    protected override void EndPower()
    {
        base.EndPower();
        PlayerController.Instance.SetInvencible(false);
        PlayerController.Instance.ResetPlayerColor();
        PlayerController.Instance.StartToRun();
    }
}
