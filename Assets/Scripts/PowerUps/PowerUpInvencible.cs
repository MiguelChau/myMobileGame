using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase
{
    //public PlayerSOSetup playerSOSetup;

    /*public void StartsSOSetup(PlayerSOSetup setup)
    {
        playerSOSetup = setup;
    }*/
    public float invencibleScale = 2f;

    protected override void StartPower()
    {
        base.StartPower();
        ScalePlayer(invencibleScale);
        PlayerController.Instance.SetInvencible();
        PlayerController.Instance.animatorManager.Play(AnimatorManager.AnimationType.INVENCIBLE);
        PlayerController.Instance.Bounce();


        /*if (playerSOSetup != null)
        {
            PlayerController.Instance.Bounce(playerSOSetup.invencibleScale);
        }*/

    }

    protected override void EndPower()
    {
        base.EndPower();
        PlayerController.Instance.SetInvencible(false);
        PlayerController.Instance.StartToRun();
    }

    private void ScalePlayer(float targetScale)
    {
        PlayerController.Instance.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
    }
}
