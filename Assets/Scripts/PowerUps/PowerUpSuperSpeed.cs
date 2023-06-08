using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSuperSpeed : PowerUpBase
{
    public float amountSpeed;

    protected override void StartPower()
    {
        base.StartPower();
        PlayerController.Instance.PowerUpSpeedUp(amountSpeed);
    }

    protected override void EndPower()
    {
        base.EndPower();
        PlayerController.Instance.ResetSpeed();
    }
}
