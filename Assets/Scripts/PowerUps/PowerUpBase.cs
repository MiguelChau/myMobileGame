using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollactableItemBase
{
    public float duration;

    protected override void OnCollect()
    {
        base.OnCollect();
        StartPower();

    }

    protected virtual void StartPower()
    {
        Debug.Log("Start Power");
        Invoke(nameof(EndPower), duration);
    }

    protected virtual void EndPower()
    {
        Debug.Log("End Power");
    }
}
