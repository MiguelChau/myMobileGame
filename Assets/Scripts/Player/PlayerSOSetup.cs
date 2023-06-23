using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class PlayerSOSetup : ScriptableObject
{
    public Animator player;

    [Header("Animation ShowIn")]
    
    public float scaleShowDuration = .2f;
    public Ease easeShow = Ease.OutBack;
}
