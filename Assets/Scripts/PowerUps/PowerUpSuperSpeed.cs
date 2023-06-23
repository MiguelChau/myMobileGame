using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSuperSpeed : PowerUpBase
{
    //public PlayerSOSetup playerSOSetup;
    public float amountSpeed;
    public float scale = 0.5f;

    /*public void StartsSOSetup(PlayerSOSetup setup)
    {
        playerSOSetup = setup;
    }*/

    protected override void StartPower()
    {
        base.StartPower();
        ScalePlayer(scale);
        PlayerController.Instance.PowerUpSpeedUp(amountSpeed);
        PlayerController.Instance.PowerUpSpeedUp(scale);
        PlayerController.Instance.Bounce();

        /*if (playerSOSetup != null)
        {
            PlayerController.Instance.Bounce(playerSOSetup.speedScale);
        }*/
    }

    protected override void EndPower()
    {
        base.EndPower();
        PlayerController.Instance.ResetSpeed();
    }

    private void ScalePlayer(float targetScale)
    {
        PlayerController.Instance.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
    }
}
